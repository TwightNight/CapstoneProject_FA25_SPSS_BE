using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail, Guid>, IOrderDetailRepository
    {
        public OrderDetailRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
