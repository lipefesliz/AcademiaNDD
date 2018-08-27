using BancoTabajara.Filters;
using BancoTabajara.Logger;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Web.Http;

namespace BancoTabajara
{
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapApiRoutes();
            config.ConfigureJsonSerialization();
            config.ConfigureXMLSerialization();
            config.EnableOdata();
            config.Filters.Add(new ExceptionHandlerAttribute());
            config.MessageHandlers.Add(new CustomLogHandler());
        }

        private static void MapApiRoutes(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BancoTabajara",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional,
                }
            );
        }

        private static void ConfigureJsonSerialization(this HttpConfiguration config)
        {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

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
            // Web API Enable OData
            config.Count().Select().Filter().OrderBy().MaxTop(null);
            config.AddODataQueryFilter();
            config.EnableDependencyInjection(builder =>
            {
                /* string as enum, substitui o antigo EnableEnumPrefixFree. Converte a String que vem no FiltroOdata para o Enum correspondente*/
                builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new StringAsEnumResolver() { EnableCaseInsensitive = true });
            });
        }
    }
}
