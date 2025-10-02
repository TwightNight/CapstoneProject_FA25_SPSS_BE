using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly UserDBContext _context;
    private IAddressRepository? _addressRepository;
    private IRefreshTokenRepository? _refreshTokenRepository;
    private IBlogRepository? _blogRepository;
    private IUserRepository? _userRepository;
    private IRoleRepository? _roleRepository;
    private IReviewRepository? _reviewRepository;
    private IReplyRepository? _replyRepository;
    private ISkinTypeRepository? _skinTypeRepository;
    private IDbContextTransaction? _transaction;
    private IReviewImageRepository? _reviewImageRepository;
    private ICountryRepository? _countryRepository;
    private IAccountRepository? _accountRepository;
    private IBlogSectionRepository? _blogSectionRepository;
    private ITransactionRepository? _transactionRepository;
    private IChatHistoryRepository? _chatHistoryRepository;

    public UnitOfWork(UserDBContext context) => _context = context;

    public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_context);
    public IBlogSectionRepository BlogSections => _blogSectionRepository ??= new BlogSectionRepository(_context);
    public IReviewImageRepository ReviewImages => _reviewImageRepository ?? (_reviewImageRepository = new ReviewImageRepository(_context));
    public ISkinTypeRepository SkinTypes => _skinTypeRepository ??= new SkinTypeRepository(_context);
    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public IAddressRepository Addresses => _addressRepository ??= new AddressRepository(_context);
    public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);
    public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository ??= new RefreshTokenRepository(_context);
    public IBlogRepository Blogs => _blogRepository ??= new BlogRepository(_context);
    public IReviewRepository Reviews => _reviewRepository ??= new ReviewRepository(_context);
    public IReplyRepository Replies => _replyRepository ??= new ReplyRepository(_context);
    public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);
    public ITransactionRepository Transactions => _transactionRepository ??= new TransactionRepository(_context);
    public IChatHistoryRepository ChatHistories => _chatHistoryRepository ??= new ChatHistoryRepository(_context);

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
            if (_transaction != null)
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
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}