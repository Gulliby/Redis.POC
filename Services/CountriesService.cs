using System.Collections.Generic;
using System.Linq;
using Caching;
using Caching.Providers;
using Entities;
using Data.Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountiesCachingProvider _countiesCachingProvider;

        public CountriesService(ICountiesCachingProvider countiesCachingProvider)
        {
            _countiesCachingProvider = countiesCachingProvider;
        }

        public CountryEntity GetCountry(int contryId)
        {
            var county = _countiesCachingProvider.GetCountry(contryId);

            return new CountryEntity
            {
                CountryId = county.CountryId,
                Country = county.Country,
                Description = county.Description,
                Wipo = county.Wipo
            };
        }

        public int SaveCountry(CountryEntity country)
        {
            return _countiesCachingProvider.SaveCountry(
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
            return _countiesCachingProvider.GetCountries().Select(country => 
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
