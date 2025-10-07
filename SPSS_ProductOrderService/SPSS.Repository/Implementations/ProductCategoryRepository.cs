using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory, Guid>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
