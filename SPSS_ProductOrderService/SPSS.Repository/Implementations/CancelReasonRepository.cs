using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.DTOs;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations
{
    public class CancelReasonRepository : RepositoryBase<CancelReason, Guid>, ICancelReasonRepository
    {
        public CancelReasonRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
