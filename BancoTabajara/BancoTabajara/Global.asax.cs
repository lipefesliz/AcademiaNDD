using BancoTabajara.Application.Mapping;
using BancoTabajara.IoC;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace BancoTabajara
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = SimpleInjectorContainer.Initialize();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperInitializer.Initialize();
        }
    }
}
