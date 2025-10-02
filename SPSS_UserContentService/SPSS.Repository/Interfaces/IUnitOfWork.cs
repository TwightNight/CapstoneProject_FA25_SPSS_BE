namespace SPSS.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAddressRepository Addresses { get; }
    IBlogSectionRepository BlogSections { get; }
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    IBlogRepository Blogs { get; }
    IReviewRepository Reviews { get; }
    IReplyRepository Replies { get; }
    ISkinTypeRepository SkinTypes { get; }
    IReviewImageRepository ReviewImages { get; }
    ICountryRepository Countries { get; }
    ITransactionRepository Transactions { get; }
    IChatHistoryRepository ChatHistories { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}