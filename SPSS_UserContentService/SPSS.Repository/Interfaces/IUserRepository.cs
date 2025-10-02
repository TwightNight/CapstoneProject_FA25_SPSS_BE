using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;

namespace SPSS.Repository.Interfaces;

public interface IUserRepository : IRepositoryBase<User, Guid>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUserNameAsync(string userName);
}