using System.Collections.Generic;
using System.Linq;
using Entities;
using Data.Entities;
using Caching.Providers;
using Data.Providers;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesProvider _countriesProvider;

        public CountriesService(ICountriesProvider countriesProvider)
        {
            _countriesProvider = countriesProvider;
        }

        public CountryEntity GetCountry(int contryId)
        {
            var county = _countriesProvider.GetById(contryId);

            return new CountryEntity
            {
                CountryId = county.CountryId,
                Country = county.Country,
                Description = county.Description,
                Wipo = county.Wipo
            };
        }

        public void SaveCountry(CountryEntity country)
        {
            _countriesProvider.Save(
                new CountryDb
                {
                   CountryId = country.CountryId,
                   Country = country.Country,
                   Description = country.Description,
                   Wipo = country.Wipo
                });
        }

        public IEnumerable<CountryEntity> GetCountries()
        {
            return _countriesProvider.GetAll().Select(country => 
                new CountryEntity
                {
                    CountryId = country.CountryId,
                    Country = country.Country,
                    Description = country.Description,
                    Wipo = country.Wipo
                });
        }
    }
}
