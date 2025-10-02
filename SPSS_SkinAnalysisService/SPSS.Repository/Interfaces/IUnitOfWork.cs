namespace SPSS.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ISkinTypeRoutineStepRepository SkinTypeRoutineSteps { get; }
    IProductCategoryRepository ProductCategories { get; }
    ISkinTypeRepository SkinTypes { get; }
    IProductForSkinTypeRepository ProductForSkinTypes { get; }
    IQuizSetRepository QuizSets { get; }
    IQuizQuestionRepository QuizQuestions { get; }
    IQuizOptionRepository QuizOptions { get; }
    IQuizResultRepository QuizResults { get; }
    ISkinAnalysisResultRepository SkinAnalysisResults { get; }
    ISkinAnalysisIssueRepository SkinAnalysisIssues { get; }
    ISkinAnalysisRecommendationRepository SkinAnalysisRecommendations { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}