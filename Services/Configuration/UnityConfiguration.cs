using Data;
using System;
using System.Configuration;
using Caching.Helpers;
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

            container.RegisterUnitOfWork(() => new HierarchicalLifetimeManager())
                .RegisterDataProviders();

            container.RegisterType<ICountriesService>(new PerResolveLifetimeManager(), new InjectionFactory(CreateCountriesService));

            return container;
        }

        private static IUnityContainer RegisterDataProviders(this IUnityContainer container)
        {
            container.RegisterType<ICountriesProvider, CountriesProvider>(new PerResolveLifetimeManager());

            return container;
        }

        private static IUnityContainer RegisterUnitOfWork(this IUnityContainer container, Func<LifetimeManager> lifetimeManagerCreator)
        {
            var databaseConnectionString = ConfigurationManager.ConnectionStrings["Database"]?.ConnectionString;

            container.RegisterType<IUnitOfWork, UnitOfWork<CustomDbContext>>(lifetimeManagerCreator());
            container.RegisterType<CustomDbContext>(lifetimeManagerCreator(), new InjectionConstructor(databaseConnectionString));

            return container;
        }


        private static ICountriesService CreateCountriesService(this IUnityContainer unityContainer)
        {
            return new CountriesService(new CachedCountriesProvider(
                unityContainer.Resolve(typeof(ICountriesProvider)) as ICountriesProvider,
                unityContainer.Resolve(typeof(ICachingProvider)) as ICachingProvider,
                unityContainer.Resolve(typeof(ICacheKeyBuilder)) as ICacheKeyBuilder));
        }
    }
}
