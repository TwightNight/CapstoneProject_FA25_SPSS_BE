using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Repository.Interfaces
{
    public interface ICountryRepository : IRepositoryBase<Country, Guid>
    {
    }
}
