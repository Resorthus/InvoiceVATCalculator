using CoreServices.Dtos.Country;
using CoreServices.Interfaces;
using DomainModels.Entities;
using OutsideInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class CountryService : ICountryService
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CountryDto> CreateCountry(CreateCountryDto request)
        {
            var country = _mapper.MapToCountry(request);
            int countryId = await _repository.CreateAsync(country);
            var countryDto = _mapper.MapToCountryDto(country);
            countryDto.Id = countryId;
            return countryDto;

        }

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var countries = await _repository.GetAllAsync<Country>();
            var countriesDto = countries.Select(country => _mapper.MapToCountryDto(country));
            return countriesDto;
        }
    }
}
