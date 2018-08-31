using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Application.Features.Funcionarios;
using Anderson.MF7.Application.Features.Gastos;
using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Domain.Features.Gastos;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.ORM.Contexts;
using Anderson.MF7.Infra.ORM.Features.Funcionarios;
using Anderson.MF7.Infra.ORM.Features.Gastos;
using Anderson.MF7.Infra.ORM.Features.Users;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace Anderson.MF7.IoC
{
    /// <summary>
    /// Classe responsável por realizar as configurações de injeção de depêndencia.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container ContainerInstance { get; private set; }

        /// <summary>
        /// Método que inicializa a injeção de depêndencia
        /// </summary>
        public static void Initialize()
        {
            ContainerInstance = new Container();

            RegisterServices();

            //ContainerInstance.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ContainerInstance.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ContainerInstance);

            using (AsyncScopedLifestyle.BeginScope(ContainerInstance))
            {
                AuthenticationService instance = ContainerInstance.GetInstance<AuthenticationService>();
            }
        }

        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices()
        {
            ContainerInstance.Register<IFuncionarioRepository, FuncionarioRepository>();
            ContainerInstance.Register<IGastoRepository, GastoRepository>();
            ContainerInstance.Register<IUserRepository, UserRepository>();

            ContainerInstance.Register<IFuncionarioService, FuncionarioService>();
            ContainerInstance.Register<IGastoService, GastoService>();

            ContainerInstance.Register<IAuthenticationService, AuthenticationService>();

            ContainerInstance.Register(() => new AndersonMF7DbContext(), Lifestyle.Singleton);
        }
    }
}