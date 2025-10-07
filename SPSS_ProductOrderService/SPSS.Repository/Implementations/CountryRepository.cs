using SPSS.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class CountryRepository : RepositoryBase<Country, Guid> , ICountryRepository
    {
        public CountryRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
