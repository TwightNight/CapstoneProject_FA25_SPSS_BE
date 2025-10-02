using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class BlogSectionRepository : RepositoryBase<BlogSection, Guid>, IBlogSectionRepository
{
    public BlogSectionRepository(UserDBContext context) : base(context)
    {
    }
}
