using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs.ProductImage;
using SPSS.Shared.Base;

namespace SPSS.Repository.Interfaces
{
    public interface IProductImageRepository : IRepositoryBase<ProductImage, Guid>
    {
        Task<List<ProductImageByIdResponse>> GetImagesByProductIdAsync(Guid productId);
    }
}
