using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class VariationRepository : RepositoryBase<Variation, Guid>, IVariationRepository
    {
        public VariationRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
