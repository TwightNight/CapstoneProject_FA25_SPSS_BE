using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSS.Repository.Implementations;

public class CountryRepository : RepositoryBase<Country, Guid> , ICountryRepository
{
    public CountryRepository(UserDBContext context) : base(context)
    {
    }
}
