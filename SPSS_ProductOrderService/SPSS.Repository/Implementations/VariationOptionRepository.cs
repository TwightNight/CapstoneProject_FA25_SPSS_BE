using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations
{
    public class VariationOptionRepository : RepositoryBase<VariationOption, Guid>, IVariationOptionRepository
    {
        public VariationOptionRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
