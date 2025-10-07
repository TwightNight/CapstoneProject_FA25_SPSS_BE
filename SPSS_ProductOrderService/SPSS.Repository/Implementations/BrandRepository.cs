using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.DTOs;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class BrandRepository : RepositoryBase<Brand, Guid>, IBrandRepository
{
    public BrandRepository(ProductOrderDBContext context) : base(context)
    {
    }
}
