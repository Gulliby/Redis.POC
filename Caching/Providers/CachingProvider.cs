using System;
using Caching.Extensions;
using Caching.Services;

namespace Caching.Providers
{
    public class CachingProvider : ICachingProvider
    {
        private readonly ICachingService _cachingService;

        public CachingProvider(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        public T GetOrUpdate<T>(string key, Func<T> retrive)
        {
            var result = _cachingService.GetValue<T>(key);

            if (result != null)
            {
                return result;
            }

            var entity = retrive();
            _cachingService.SetValue(key, entity);
            
            return entity;
        }

        public void Set<T>(string key, T entity)
        {
            _cachingService.SetValue(key, entity);
        }

        public void Remove(string key)
        {
            _cachingService.Delete(key);
        }
    }
}
