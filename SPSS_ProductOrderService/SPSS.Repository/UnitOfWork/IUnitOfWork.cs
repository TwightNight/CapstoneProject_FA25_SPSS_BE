using SPSS.Repository.Interfaces;

namespace SPSS.Repository.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
	IProductRepository Products { get; }
	IProductImageRepository ProductImages { get; }
	ICancelReasonRepository CancelReasons { get; }
	IProductItemRepository ProductItems { get; }
	IProductConfigurationRepository ProductConfigurations { get; }
	IProductForSkinTypeRepository ProductForSkinTypes { get; }
	IBrandRepository Brands { get; }
	ISkinTypeRepository SkinTypes { get; }
	IVariationRepository Variations { get; }
    IVariationOptionRepository VariationOptions { get; }
    IProductStatusRepository ProductStatuses { get; }
    IProductCategoryRepository ProductCategories { get; }
    ICartItemRepository CartItems { get; }
    IPaymentMethodRepository PaymentMethods { get; }
    IVoucherRepository Vouchers { get; }
    IOrderRepository Orders { get; }
    IOrderDetailRepository OrderDetails { get; }
    IStatusChangeRepository StatusChanges { get; }
    ICountryRepository Countries { get; }


    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}