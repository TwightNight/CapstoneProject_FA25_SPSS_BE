using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class SkinTypeRoutineStepRepository : RepositoryBase<SkinTypeRoutineStep, Guid>, ISkinTypeRoutineStepRepository
{
    public SkinTypeRoutineStepRepository(SkinAnalysisDBContext dbContext) : base(dbContext)
    {
    }
}
