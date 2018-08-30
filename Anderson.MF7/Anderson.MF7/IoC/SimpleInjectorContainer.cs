using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.ORM.Contexts;
using Anderson.MF7.Infra.ORM.Features.Users;
using SimpleInjector;
using System.Diagnostics.CodeAnalysis;

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

            ContainerInstance.Verify();
        }

        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices()
        {

            ContainerInstance.Register<IUserRepository, UserRepository>();
            ContainerInstance.Register<IAuthenticationService, AuthenticationService>();

            ContainerInstance.Register(() => new AndersonMF7DbContext(), Lifestyle.Singleton);
        }
    }
}