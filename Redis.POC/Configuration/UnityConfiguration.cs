using Infrastructure.Common.Helpers;
using Services;
using Unity;
using Unity.Lifetime;

namespace Redis.POC.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer Apply(this IUnityContainer container)
        {
            container = Services.Configuration.UnityConfiguration.Apply(container);

            container.RegisterType<ICountriesService, CountriesService>(new PerResolveLifetimeManager());

            container.RegisterType<CustomJsonSerializer>(new PerResolveLifetimeManager());

            return container;
        }
    }
}