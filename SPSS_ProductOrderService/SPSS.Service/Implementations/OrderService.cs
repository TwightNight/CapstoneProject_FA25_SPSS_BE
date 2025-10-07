using AutoMapper;
using SPSS.BusinessObject.DTOs.Address;
using SPSS.BusinessObject.DTOs.Order;
using SPSS.BusinessObject.DTOs.OrderDetail;
using SPSS.BusinessObject.DTOs.StatusChange;
using SPSS.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SPSS.Shared.Base;
using SPSS.Repository.UnitOfWork;
using SPSS.Shared.Constants;

namespace SPSS.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<PagedResponse<OrderDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            // Tính tổng số đơn hàng
            var totalCount = await _unitOfWork.Orders.Entities
                .Where(o => !o.IsDeleted)
                .CountAsync();

            // Lấy danh sách đơn hàng theo phân trang
            var orders = await _unitOfWork.Orders.Entities
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                        .ThenInclude(pi => pi.Product)
                            .ThenInclude(p => p.ProductImages)
                .Include(o => o.OrderDetails)
                    .ThenInclude(pi => pi.ProductItem)
                        .ThenInclude(pc => pc.ProductConfigurations)
                            .ThenInclude(vo => vo.VariationOption)
                .Where(o => !o.IsDeleted)
                .OrderByDescending(o => o.CreatedTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Ánh xạ sang DTO sử dụng AutoMapper
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            // Trả về kết quả phân trang
            return new PagedResponse<OrderDto>
            {
                Items = orderDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<int> GetTotalOrdersByUserIdAsync(Guid userId)
        {
            // Đếm tổng số lượng đơn hàng của người dùng không bị xóa
            var totalOrders = await _unitOfWork.Orders.Entities
                .Where(o => !o.IsDeleted && o.UserId == userId)
                .CountAsync();

            return totalOrders;
        }

        public async Task<bool> UpdateOrderStatusAsync(Guid id, string newStatus, Guid userId, Guid? cancelReasonId = null)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentNullException(nameof(newStatus), "Order status cannot be null or empty.");

            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null || order.IsDeleted)
                throw new KeyNotFoundException($"Order with ID {id} not found or has been deleted.");

            // Handle restocking for cancelled orders
            if (newStatus.Equals(StatusForOrder.Cancelled, StringComparison.OrdinalIgnoreCase))
            {
                var orderDetails = await _unitOfWork.OrderDetails.Entities
                    .Where(od => od.OrderId == id)
                    .ToListAsync();

                foreach (var orderDetail in orderDetails)
                {
                    var productItem = await _unitOfWork.ProductItems.Entities
                        .FirstOrDefaultAsync(pi => pi.Id == orderDetail.ProductItemId);

                    if (productItem == null)
                        throw new KeyNotFoundException($"ProductItem with ID {orderDetail.ProductItemId} not found.");

                    // Restock the quantity
                    productItem.QuantityInStock += orderDetail.Quantity;

                    // Update the product item
                    _unitOfWork.ProductItems.Update(productItem);
                }

                // If cancelReasonId is provided, update the order's CancelReasonId
                if (cancelReasonId.HasValue)
                {
                    order.CancelReasonId = cancelReasonId.Value;
                }
            }

            // Handle updating SoldCount for delivered orders
            if (newStatus.Equals(StatusForOrder.Delivered, StringComparison.OrdinalIgnoreCase))
            {
                var orderDetails = await _unitOfWork.OrderDetails.Entities
                    .Where(od => od.OrderId == id)
                    .ToListAsync();

                foreach (var orderDetail in orderDetails)
                {
                    var productItem = await _unitOfWork.ProductItems.Entities
                        .Include(pi => pi.Product)
                        .FirstOrDefaultAsync(pi => pi.Id == orderDetail.ProductItemId);

                    if (productItem == null)
                        throw new KeyNotFoundException($"ProductItem with ID {orderDetail.ProductItemId} not found.");

                    // Update the SoldCount
                    productItem.Product.SoldCount += orderDetail.Quantity;

                    // Update the product
                    _unitOfWork.Products.Update(productItem.Product);
                }
            }

            // Update the order's status
            order.Status = newStatus;
            order.LastUpdatedTime = DateTimeOffset.UtcNow;
            order.LastUpdatedBy = userId.ToString();

            // Create a status change record
            var statusChange = new StatusChange
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Status = order.Status,
                Date = DateTimeOffset.UtcNow,
            };

            // Add the status change record
            _unitOfWork.StatusChanges.Add(statusChange);

            // Update the order
            _unitOfWork.Orders.Update(order);

            // Save changes
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOrderPaymentMethodAsync(Guid orderId, Guid paymentMethodId, Guid userId)
        {
            // Validate payment method ID
            if (paymentMethodId == Guid.Empty)
                throw new ArgumentNullException(nameof(paymentMethodId), "Payment method cannot be null or empty.");

            // Fetch the order
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null || order.IsDeleted)
                throw new KeyNotFoundException($"Order with ID {orderId} not found or has been deleted.");

            // Ensure the order is in a modifiable status
            if (!order.Status.Equals(StatusForOrder.AwaitingPayment, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Payment method can only be updated when the order is in 'Awaiting Payment' status. Current status: {order.Status}");

            // Fetch the payment method to ensure it exists
            var paymentMethod = await _unitOfWork.PaymentMethods.GetByIdAsync(paymentMethodId);
            if (paymentMethod == null)
                throw new KeyNotFoundException($"Payment method with ID {paymentMethodId} not found.");

            // If the new payment method is COD, update the order status to Processing
            if (paymentMethod.PaymentType.Equals(SPSS.Shared.Constants.PaymentMethod.COD, StringComparison.OrdinalIgnoreCase))
            {
                if (!order.Status.Equals(StatusForOrder.Processing, StringComparison.OrdinalIgnoreCase))
                {
                    // Update status to Processing
                    order.Status = StatusForOrder.Processing;

                    // Record the status change
                    var statusChange = new StatusChange
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order.Id,
                        Status = order.Status,
                        Date = DateTimeOffset.UtcNow,
                    };
                    _unitOfWork.StatusChanges.Add(statusChange);
                }
            }

            // Update the order's payment method
            order.PaymentMethodId = paymentMethodId;
            order.LastUpdatedTime = DateTimeOffset.UtcNow;
            order.LastUpdatedBy = userId.ToString();

            // Update the order
            _unitOfWork.Orders.Update(order);

            // Save changes
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOrderAddressAsync(Guid id, Guid newAddressId, Guid userId)
        {

            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null || order.IsDeleted)
                throw new KeyNotFoundException($"Order with ID {id} not found or has been deleted.");

            order.AddressId = newAddressId;
            order.LastUpdatedTime = DateTimeOffset.UtcNow;
            order.LastUpdatedBy = userId.ToString();

            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(Guid id, Guid userId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null || order.IsDeleted)
                throw new KeyNotFoundException($"Order with ID {id} not found or has been deleted.");

            order.IsDeleted = true;
            order.DeletedTime = DateTimeOffset.UtcNow;
            order.DeletedBy = userId.ToString();

            _unitOfWork.Orders.Update(order); // Soft delete via update
            await _unitOfWork.SaveChangesAsync();
        }

		public Task<OrderWithDetailDto> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<CanceledOrderDto>> GetCanceledOrdersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<PagedResponse<OrderDto>> GetOrdersByUserIdAsync(Guid userId, int pageNumber, int pageSize, string? status = null)
		{
			throw new NotImplementedException();
		}

		public Task<OrderDto> CreateAsync(OrderForCreationDto orderDto, Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
