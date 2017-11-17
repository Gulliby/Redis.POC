using Data;
using System;
using System.Configuration;
using Caching;
using Caching.Providers;
using Data.Providers;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Services.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer Apply(this IUnityContainer container)
        {
            container = Caching.Configuration.UnityConfiguration.Apply(container);

            container.RegisterUnitOfWork(() => new HierarchicalLifetimeManager());
            container.RegisterType<ICountriesProvider, CountriesProvider>(new PerResolveLifetimeManager());
            container.RegisterType<ICountiesCachingProvider, CountriesCachingProvider>(new PerResolveLifetimeManager());

            return container;
        }

        private static IUnityContainer RegisterUnitOfWork(this IUnityContainer container, Func<LifetimeManager> lifetimeManagerCreator)
        {
            var authenticationConnectionString = ConfigurationManager.ConnectionStrings["Database"]?.ConnectionString;

            container.RegisterType<IUnitOfWork, UnitOfWork<CustomDbContext>>(lifetimeManagerCreator());
            container.RegisterType<CustomDbContext>(lifetimeManagerCreator(), new InjectionConstructor(authenticationConnectionString));

            return container;
        }
    }
}
