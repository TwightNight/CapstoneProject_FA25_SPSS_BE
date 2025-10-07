using SPSS.BusinessObject.DTOs.ProductStatus;
using SPSS.Shared.Base;

namespace Services.Interface
{
    public interface IProductStatusService
    {
        Task<ProductStatusDto> GetByIdAsync(Guid id);

        Task<Guid?> GetFirstAvailableProductStatusIdAsync();

        Task<PagedResponse<ProductStatusDto>> GetPagedAsync(int pageNumber, int pageSize);

        Task<ProductStatusDto> CreateAsync(ProductStatusForCreationDto productStatusDto);

        Task<ProductStatusDto> UpdateAsync(Guid id, ProductStatusForUpdateDto productStatusDto);

        Task DeleteAsync(Guid id);
    }
}
