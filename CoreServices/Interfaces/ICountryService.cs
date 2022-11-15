using CoreServices.Dtos.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface ICountryService
    {
        Task<CountryDto> CreateCountry(CreateCountryDto createCountryDto);

        Task<IEnumerable<CountryDto>> GetAllCountries();
    }
}
