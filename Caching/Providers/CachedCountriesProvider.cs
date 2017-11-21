using System.Collections.Generic;
using Caching.Helpers;
using Data.Entities;
using Data.Providers;

namespace Caching.Providers
{
    public class CachedCountriesProvider : ICountriesProvider
    {
        private readonly ICountriesProvider _countriesProvider;
        private readonly ICachingProvider _cachingProvider;
        private readonly ICacheKeyBuilder _cacheKeyBuilder;

        public CachedCountriesProvider(
            ICountriesProvider countriesProvider,
            ICachingProvider cachingProvider,
            ICacheKeyBuilder cacheKeyBuilder)
        {
            _countriesProvider = countriesProvider;
            _cachingProvider = cachingProvider;
            _cacheKeyBuilder = cacheKeyBuilder;
        }

        public void Save(CountryDb country)
        {
            _cachingProvider.Remove(_cacheKeyBuilder.Build<CountryDb>());
            _countriesProvider.Save(country);
        }

        public CountryDb GetById(int countryId)
        {
            return  _cachingProvider.GetOrUpdate(_cacheKeyBuilder.Build<CountryDb>(countryId.ToString(), nameof(_countriesProvider.GetById)), () => _countriesProvider.GetById(countryId));
        }

        public IEnumerable<CountryDb> GetAll()
        {
            return _cachingProvider.GetOrUpdate(_cacheKeyBuilder.Build<CountryDb>(nameof(_countriesProvider.GetAll)), () => _countriesProvider.GetAll());
        }
    }
}