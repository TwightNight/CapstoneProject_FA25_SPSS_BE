using Microsoft.EntityFrameworkCore.Storage;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly SkinAnalysisDBContext _context;
    private IProductCategoryRepository? _productCategoryRepository;
    private ISkinTypeRepository? _skinTypeRepository;
    private IProductForSkinTypeRepository? _productForSkinTypeRepository;
    private IQuizSetRepository? _quizSetRepository;
    private IQuizQuestionRepository? _quizQuestionRepository;
    private IQuizOptionRepository? _quizOptionRepository;
    private IQuizResultRepository? _quizResultRepository;
    private ISkinTypeRoutineStepRepository? _skinTypeRoutineStepRepository;
    private ISkinAnalysisResultRepository? _skinAnalysisResultRepository;
    private ISkinAnalysisIssueRepository? _skinAnalysisIssueRepository;
    private ISkinAnalysisRecommendationRepository? _skinAnalysisRecommendationRepository;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(SkinAnalysisDBContext context) =>  _context = context;

    public ISkinTypeRoutineStepRepository SkinTypeRoutineSteps => _skinTypeRoutineStepRepository ??= new SkinTypeRoutineStepRepository(_context);
    public ISkinTypeRepository SkinTypes => _skinTypeRepository ??= new SkinTypeRepository(_context);
    public IProductCategoryRepository ProductCategories => _productCategoryRepository ??= new ProductCategoryRepository(_context);
    public IProductForSkinTypeRepository ProductForSkinTypes => _productForSkinTypeRepository ??= new ProductForSkinTypeRepository(_context);
    public IQuizSetRepository QuizSets => _quizSetRepository ??= new QuizSetRepository(_context);
    public IQuizQuestionRepository QuizQuestions => _quizQuestionRepository ??= new QuizQuestionRepository(_context);
    public IQuizOptionRepository QuizOptions => _quizOptionRepository ??= new QuizOptionRepository(_context);
    public IQuizResultRepository QuizResults => _quizResultRepository ??= new QuizResultRepository(_context);
    public ISkinAnalysisResultRepository SkinAnalysisResults => _skinAnalysisResultRepository ??= new SkinAnalysisResultRepository(_context);
    public ISkinAnalysisIssueRepository SkinAnalysisIssues => _skinAnalysisIssueRepository ??= new SkinAnalysisIssueRepository(_context);
    public ISkinAnalysisRecommendationRepository SkinAnalysisRecommendations => _skinAnalysisRecommendationRepository ??= new SkinAnalysisRecommendationRepository(_context);

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