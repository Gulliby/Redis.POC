using System;

namespace Caching.Providers
{
    public interface ICachingProvider
    {
        T GetOrUpdate<T>(string key, Func<T> updateFunc);

        void Set<T>(string key, T entity);

        void Remove(string key);
    }
}