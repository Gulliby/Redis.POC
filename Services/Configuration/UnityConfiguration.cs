using Data;
using System;
using System.Configuration;
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
                .RegisterDataProviders()
                .RegisterCachedDataProviders();

            container.RegisterType<ICountriesService>(new PerResolveLifetimeManager(), new InjectionFactory(c => new CountriesService(c.Resolve<CachedCountriesProvider>())));
            container.RegisterType<ICodesService>(new PerResolveLifetimeManager(), new InjectionFactory(c => new CodesService(c.Resolve<CachedCodesProvider>())));

            return container;
        }

        private static IUnityContainer RegisterDataProviders(this IUnityContainer container)
        {
            container.RegisterType<ICountriesProvider, CountriesProvider>(new PerResolveLifetimeManager());
            container.RegisterType<ICodesProvider, CodesProvider>(new PerResolveLifetimeManager());

            return container;
        }

        private static IUnityContainer RegisterCachedDataProviders(this IUnityContainer container)
        {
            container.RegisterType<CachedCountriesProvider>(new PerResolveLifetimeManager());
            container.RegisterType<CachedCodesProvider>(new PerResolveLifetimeManager());

            return container;
        }

        private static IUnityContainer RegisterUnitOfWork(this IUnityContainer container, Func<LifetimeManager> lifetimeManagerCreator)
        {
            var databaseConnectionString = ConfigurationManager.ConnectionStrings["Database"]?.ConnectionString;

            container.RegisterType<IUnitOfWork, UnitOfWork<CustomDbContext>>(lifetimeManagerCreator());
            container.RegisterType<CustomDbContext>(lifetimeManagerCreator(), new InjectionConstructor(databaseConnectionString));

            return container;
        }
    }
}
