using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class ProductConfigurationRepository : RepositoryBase<ProductConfiguration, Guid>, IProductConfigurationRepository
    {
        public ProductConfigurationRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
