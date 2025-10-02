using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class AccountRepository : RepositoryBase<User, Guid>, IAccountRepository
{
    public AccountRepository(UserDBContext context) : base(context)
    {
    }
}
