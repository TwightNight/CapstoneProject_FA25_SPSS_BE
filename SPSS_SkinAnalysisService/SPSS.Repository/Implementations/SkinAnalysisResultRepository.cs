using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;

namespace SPSS.Repository.Implementations;

public class SkinAnalysisResultRepository : RepositoryBase<SkinAnalysisResult, Guid>, ISkinAnalysisResultRepository
{
    public SkinAnalysisResultRepository(SkinAnalysisDBContext context) : base(context)
    {
    }
}