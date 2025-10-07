using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations;

public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
{
    public ProductRepository(ProductOrderDBContext context) : base(context)
    {
    }
}