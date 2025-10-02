using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class BlogRepository : RepositoryBase<Blog, Guid>, IBlogRepository
{
    public BlogRepository(UserDBContext context) : base(context)
    {
    }
}