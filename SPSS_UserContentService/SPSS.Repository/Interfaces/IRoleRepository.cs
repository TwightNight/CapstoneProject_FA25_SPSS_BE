using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;

namespace SPSS.Repository.Interfaces;

public interface IRoleRepository : IRepositoryBase<Role, Guid>
{
    Task<Role?> GetRoleByNameAsync(string roleName);
}