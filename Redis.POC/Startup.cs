using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Redis.POC;
using Redis.POC.Configuration;
using Unity;

[assembly: OwinStartup(typeof(Startup))]
namespace Redis.POC
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();

            var ioc = new UnityContainer();

            ioc.Apply();

            WebApiConfig.Register(config);

            config.DependencyResolver = new UnityResolver(ioc);

            builder.UseWebApi(config);
        }
    }
}