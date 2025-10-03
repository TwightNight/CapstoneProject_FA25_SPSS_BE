using SPSS.BusinessObject.Dtos.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Service.Interfaces;
public interface ICountryService
{
    Task<CountryDto> GetByIdAsync(int id);
    Task<IEnumerable<CountryDto>> GetAllAsync();
    Task<CountryDto> CreateAsync(CountryForCreationDto countryForCreationDto);
    Task<CountryDto> UpdateAsync(int countryId, CountryForUpdateDto countryForUpdateDto);
    Task DeleteAsync(int id);
}
