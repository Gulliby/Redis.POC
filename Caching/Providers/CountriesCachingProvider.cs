using System.Collections.Generic;
using System.Linq;
using Data.Providers;
using Data.Entities;

namespace Caching.Providers
{
    public class CountriesCachingProvider : ICountiesCachingProvider
    {
        private readonly string _className;

        private readonly ICachingService _cachingService;
        private readonly ICountriesProvider _countriesProvider;

        public CountriesCachingProvider(ICountriesProvider countriesProvider, ICachingService cachingService)
        {
            _countriesProvider = countriesProvider;
            _cachingService = cachingService;
            _className = GetType().Name;
        }

        public int SaveCountry(CountryDb country)
        {
            var countryId = _countriesProvider.SaveCountry(country);

            if (countryId > 0)
            {
                _cachingService.SetValue(_className + countryId, country);
                _cachingService.Delete(_className);
            }

            return countryId;
        }

        public CountryDb GetCountry(int countryId)
        {
            var country = _cachingService.GetValue<CountryDb>(_className + countryId);

            if (country != null)
            {
                return country;
            }

            country = _countriesProvider.GetCountry(countryId);
            _cachingService.SetValue(_className + countryId, country);

            return country;
        }

        public IEnumerable<CountryDb> GetCountries()
        {
            var countries = _cachingService.GetValue<List<CountryDb>>(_className);

            if (countries != null)
            {
                return countries;
            }

            countries = _countriesProvider.GetCountries().ToList();

            _cachingService.SetValue(_className, countries);

            return countries;
        }
    }
}
