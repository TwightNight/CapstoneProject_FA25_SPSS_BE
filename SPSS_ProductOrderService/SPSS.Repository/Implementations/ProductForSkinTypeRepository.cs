using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations
{
    public class ProductForSkinTypeRepository : RepositoryBase<ProductForSkinType, Guid>, IProductForSkinTypeRepository
    {
        public ProductForSkinTypeRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
