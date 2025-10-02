using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class ReviewImageRepository : RepositoryBase<ReviewImage, Guid>, IReviewImageRepository
{
    public ReviewImageRepository(UserDBContext context) : base(context)
    {
    }
}
