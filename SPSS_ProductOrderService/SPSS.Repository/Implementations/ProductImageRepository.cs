using SPSS.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.DTOs.ProductImage;

namespace SPSS.Repository.Implementations;

public class ProductImageRepository : RepositoryBase<ProductImage, Guid>, IProductImageRepository
{
    public ProductImageRepository(ProductOrderDBContext context) : base(context)
    {
        
    }
    public async Task<List<ProductImageByIdResponse>> GetImagesByProductIdAsync(Guid productId)
    {
        return await _context.Set<ProductImage>()
            .Where(pi => pi.ProductId == productId)
            .Select(pi => new ProductImageByIdResponse
            {
                Id = pi.Id,
                Url = pi.ImageUrl,
            })
            .ToListAsync();
    }
}