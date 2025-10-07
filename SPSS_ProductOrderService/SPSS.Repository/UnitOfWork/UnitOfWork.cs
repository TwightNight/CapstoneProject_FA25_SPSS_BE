using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Implementations;

namespace SPSS.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductOrderDBContext _context;
    private IProductRepository _productRepository;
    private ICancelReasonRepository _cancelReasonRepository;
    private IProductImageRepository _productImageRepository;
    private IProductConfigurationRepository _productConfigurationRepository;
    private IProductItemRepository _productItemRepository;
    private IVariationRepository _variationRepository;
    private IVariationOptionRepository _variationOptionRepository;
    private IProductStatusRepository _productStatusRepository;
    private IProductCategoryRepository _productCategoryRepository;
    private IPaymentMethodRepository _paymentMethodRepository;
    private ICartItemRepository _cartItemRepository;
    private IBrandRepository _brandRepository;
    private IVoucherRepository _voucherRepository;
    private IDbContextTransaction _transaction; 
    private IOrderRepository _orderRepository;
    private IOrderDetailRepository _orderDetailRepository;
    private IStatusChangeRepository _statusChangeRepository;
    private ICountryRepository _countryRepository;
	private ISkinTypeRepository _skinTypeRepository;
	private IProductForSkinTypeRepository _productForSkinTypeRepository;


	public UnitOfWork(ProductOrderDBContext context) =>  _context = context;


    public IProductImageRepository ProductImages => _productImageRepository ?? (_productImageRepository = new ProductImageRepository(_context));
    public IStatusChangeRepository StatusChanges => _statusChangeRepository ?? (_statusChangeRepository = new StatusChangeRepository(_context));
    public IOrderDetailRepository OrderDetails => _orderDetailRepository ?? (_orderDetailRepository = new OrderDetailRepository(_context));
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
    public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
    public ICancelReasonRepository CancelReasons => _cancelReasonRepository ??= new CancelReasonRepository(_context);
    public IProductConfigurationRepository ProductConfigurations => _productConfigurationRepository ??= new ProductConfigurationRepository(_context);
    public IProductItemRepository ProductItems => _productItemRepository ??= new ProductItemRepository(_context);
    public IVariationRepository Variations => _variationRepository ??= new VariationRepository(_context);
    public IBrandRepository Brands => _brandRepository ??= new BrandRepository(_context);
    public IVariationOptionRepository VariationOptions => _variationOptionRepository ??= new VariationOptionRepository(_context);
    public IProductStatusRepository ProductStatuses => _productStatusRepository ??= new ProductStatusRepository(_context);
    public IProductCategoryRepository ProductCategories => _productCategoryRepository ??= new ProductCategoryRepository(_context);
    public IPaymentMethodRepository PaymentMethods => _paymentMethodRepository ??= new PaymentMethodRepository(_context);
    public ICartItemRepository CartItems => _cartItemRepository ??= new CartItemRepository(_context);
    public IVoucherRepository Vouchers => _voucherRepository ??= new VoucherRepository(_context);
    public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);
	public IProductForSkinTypeRepository ProductForSkinTypes => _productForSkinTypeRepository ??= new ProductForSkinTypeRepository(_context);
	public ISkinTypeRepository SkinTypes => _skinTypeRepository ??= new SkinTypeRepository(_context);


	public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}