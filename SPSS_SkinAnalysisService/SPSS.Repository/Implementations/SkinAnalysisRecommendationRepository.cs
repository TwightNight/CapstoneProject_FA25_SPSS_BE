using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;

namespace SPSS.Repository.Implementations;

public class SkinAnalysisRecommendationRepository : RepositoryBase<SkinAnalysisRecommendation, Guid>, ISkinAnalysisRecommendationRepository
{
    public SkinAnalysisRecommendationRepository(SkinAnalysisDBContext context) : base(context)
    {
    }
}