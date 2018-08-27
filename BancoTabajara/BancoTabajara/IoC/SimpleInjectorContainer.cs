using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Application.Features.Usuarios;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;
using BancoTabajara.Domain.Features.Usuarios;
using BancoTabajara.Infra.ORM.Contexts;
using BancoTabajara.Infra.ORM.Features.Clientes;
using BancoTabajara.Infra.ORM.Features.Contas;
using BancoTabajara.Infra.ORM.Features.Movimentacoes;
using BancoTabajara.Infra.ORM.Features.Usuarios;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace BancoTabajara.IoC
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container Container { get; internal set; }

        public static Container Initialize()
        {
            string conString = ConfigurationManager.ConnectionStrings["BancoTabajaraDbContext"].ConnectionString;

            Container = new Container();

            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<IContaRepository, ContaRepository>(Lifestyle.Singleton);
            Container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);
            Container.Register<IMovimentacaoRepository, MovimentacaoRepository>(Lifestyle.Singleton);
            Container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Singleton);

            Container.Register<IContaService, ContaService>(Lifestyle.Singleton);
            Container.Register<IUsuarioService, UsuarioService>(Lifestyle.Singleton);

            Container.Register<BancoTabajaraDbContext>(() => new BancoTabajaraDbContext(conString), Lifestyle.Singleton);

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();

            return Container;
        }
    }
}