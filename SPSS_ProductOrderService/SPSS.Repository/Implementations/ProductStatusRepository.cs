using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations
{
    public class ProductStatusRepository : RepositoryBase<ProductStatus ,Guid>, IProductStatusRepository
    {
        public ProductStatusRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
