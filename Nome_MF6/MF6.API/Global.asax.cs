using MF6.Application.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Features.Impressoras;
using SimpleInjector;
using System.Data.Entity;
using System.Web.Http;

namespace MF6.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();

            container.Register<DbContext, MF6Context>(Lifestyle.Scoped);
            container.Register<IImpressoraService, ImpressoraService>(Lifestyle.Scoped);
            container.Register<IImpressoraRepository, ImpressoraRepository>(Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
