using Anderson.MF7.App_Start;
using Anderson.MF7.Application.Mapping;
using Anderson.MF7.IoC;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(Anderson.MF7.API.Startup))]

namespace Anderson.MF7.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperInitializer.Initialize();
            SimpleInjectorContainer.Initialize();

            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            OAuthConfig.ConfigOAuth(app);
            app.UseWebApi(config);
        }
    }
}