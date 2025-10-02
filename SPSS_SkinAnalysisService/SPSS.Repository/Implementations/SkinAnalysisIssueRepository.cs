using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;

namespace SPSS.Repository.Implementations;

public class SkinAnalysisIssueRepository : RepositoryBase<SkinAnalysisIssue, Guid>, ISkinAnalysisIssueRepository
{
    public SkinAnalysisIssueRepository(SkinAnalysisDBContext context) : base(context)
    {
    }
}