using Anderson.MF7.Filters;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Anderson.MF7.App_Start
{
    /// <summary>
    /// Classe para configurações gerais da API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        /// <summary>
        /// Método executado ao inicio da API que adiciona configurações e permissionamentos.
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            config.MapApiRoutes();
            config.ConfigureJsonSerialization();
            config.ConfigureXMLSerialization();
            config.EnableOdata();
            config.Filters.Add(new ExceptionHandlerAttribute());
        }

        /// <summary>
        /// Método responsável por configurar as rotas de api
        /// </summary>
        /// <param name="config"></param>
        private static void MapApiRoutes(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "AndersonMF7.API",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em JSON
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureJsonSerialization(this HttpConfiguration config)
        {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        /// <summary>
        /// Método responsável por configurar a forma de serialização em XML
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureXMLSerialization(this HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }

        /// <summary>
        /// Método responsável por habilitar o OData num ApiController
        /// </summary>
        /// <param name="config">É a configuração da api</param>
        private static void EnableOdata(this HttpConfiguration config)
        {
            config.Count().Select().Filter().OrderBy().MaxTop(null);
            config.AddODataQueryFilter();
            config.EnableDependencyInjection(builder =>
            {
                builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new StringAsEnumResolver() { EnableCaseInsensitive = true });
            });
        }
    }
}