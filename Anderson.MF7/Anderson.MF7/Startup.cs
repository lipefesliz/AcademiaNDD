using Anderson.MF7.App_Start;
using Anderson.MF7.Application.Mapping;
using Anderson.MF7.IoC;
using Anderson.MF7.Logger;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector.Integration.WebApi;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(Anderson.MF7.API.Startup))]

namespace Anderson.MF7.API
{
    /// <summary>
    /// Classe para o inicio da API.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Método que invoca as configurações iniciais para execução da API
        ///
        /// Existem configurações que são executadas durante a inicialização. Veja também em Global.asax
        ///
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorContainer.Initialize();
            AutoMapperInitializer.Initialize();

            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver
                (SimpleInjectorContainer.ContainerInstance)
            };

            WebApiConfig.Register(config);

            OAuthConfig.ConfigureOAuth(app);

            config.MessageHandlers.Add(new CustomLogHandler());

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}