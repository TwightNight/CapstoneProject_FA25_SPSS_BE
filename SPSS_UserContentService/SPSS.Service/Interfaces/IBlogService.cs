using SPSS.BusinessObject.Dtos.Blog;
using SPSS.Shared.Base;

namespace SPSS.Service.Interfaces;
public interface IBlogService
{
    Task<BlogWithDetailDto> GetByIdAsync(Guid id);
    Task<PagedResponse<BlogDto>> GetPagedAsync(int pageNumber, int pageSize);
    Task<BlogDto> CreateBlogAsync(BlogForCreationDto blogDto, Guid userId);
    Task<BlogDto> UpdateBlogAsync(Guid blogId, BlogForUpdateDto blogDto, Guid userId);
    Task<bool> DeleteAsync(Guid id, Guid userId);
}