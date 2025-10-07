using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class ProductItemRepository : RepositoryBase<ProductItem, Guid>, IProductItemRepository
    {
        public ProductItemRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
