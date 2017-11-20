using Caching.Helpers;
using Caching.Providers;
using Caching.Services;
using StackExchange.Redis;
using System.Configuration;
using Unity;
using Unity.Lifetime;

namespace Caching.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer Apply(this IUnityContainer container)
        {
            var redisConnectionConfiguration = ConfigurationManager.AppSettings.Get("RedisConfiguration");
            var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionConfiguration);

            container.RegisterInstance<IConnectionMultiplexer>(connectionMultiplexer, new ContainerControlledLifetimeManager());
            container.RegisterType<ICachingService, RedisCachingService>(new PerResolveLifetimeManager());

            container.RegisterType<ICacheKeyBuilder, CacheKeyBuilder>(new PerResolveLifetimeManager());
            container.RegisterType<ICachingProvider, CachingProvider>(new PerResolveLifetimeManager());

            return container;
        }
    }
}