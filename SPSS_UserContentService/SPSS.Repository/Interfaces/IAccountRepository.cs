using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;

namespace SPSS.Repository.Interfaces;

public interface IAccountRepository : IRepositoryBase<User, Guid>
{
}