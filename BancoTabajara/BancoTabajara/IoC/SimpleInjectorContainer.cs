using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Infra.ORM.Contexts;
using BancoTabajara.Infra.ORM.Features.Clientes;
using BancoTabajara.Infra.ORM.Features.Contas;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;

namespace BancoTabajara.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container Initialize()
        {
            string conString = ConfigurationManager.ConnectionStrings["BancoTabajaraDbContext"].ConnectionString;

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IContaRepository, ContaRepository>(Lifestyle.Singleton);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);
            container.Register<IContaService, ContaService>(Lifestyle.Singleton);

            container.Register<BancoTabajaraDbContext>(() => new BancoTabajaraDbContext(conString), Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            return container;
        }
    }
}