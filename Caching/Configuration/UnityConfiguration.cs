using StackExchange.Redis;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Caching.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer Apply(this IUnityContainer container)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect("localhost");
            container.RegisterInstance<IConnectionMultiplexer>(connectionMultiplexer, new ContainerControlledLifetimeManager());
            container.RegisterType<ICachingService, RedisCachingService>(new PerResolveLifetimeManager());

            return container;
        }
    }
}
