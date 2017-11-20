using Unity;

namespace Redis.POC.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer Apply(this IUnityContainer container)
        {
            container = Services.Configuration.UnityConfiguration.Apply(container);

            return container;
        }
    }
}