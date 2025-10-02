using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(UserDBContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await Entities
            .Where(u => u.EmailAddress == email && !u.IsDeleted)
            .FirstOrDefaultAsync();
        return user;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await Entities
            .Where(u => u.UserName == userName && !u.IsDeleted)
            .FirstOrDefaultAsync();
        return user;
    }
}