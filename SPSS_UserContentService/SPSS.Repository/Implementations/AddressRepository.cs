using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class AddressRepository : RepositoryBase<Address, Guid>, IAddressRepository
{
    public AddressRepository(UserDBContext context) : base(context)
    {
    }
}
