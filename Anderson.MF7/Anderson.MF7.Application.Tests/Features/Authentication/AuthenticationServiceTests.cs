using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Application.Tests.Initializer;
using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Infra.Crypto;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Anderson.MF7.Application.Tests.Features.Authentication
{
    [TestFixture]
    public class AuthenticationServiceTests : TestServiceBase
    {
        private IAuthenticationService _service;
        private Mock<IFuncionarioRepository> _funcionarioRepositoryFake;

        [SetUp]
        public void Initialize()
        {
            _funcionarioRepositoryFake = new Mock<IFuncionarioRepository>();
            _service = new AuthenticationService(_funcionarioRepositoryFake.Object);
        }

        #region Login 
        [Test]
        public void Auth_Service_Login_ShouldBeOk()
        {
            //Arrange
            var funcionario = new Funcionario { Id = 1, Usuario = "teste", Senha = "teste", };
            var pass = funcionario.Senha.GenerateHash();
            _funcionarioRepositoryFake.Setup(ur => ur.GetByCredentials(funcionario.Usuario, pass)).Returns(funcionario);
            //Action
            var funcionarioLogged = _service.Login(funcionario.Usuario, funcionario.Senha);
            //Assert
            _funcionarioRepositoryFake.Verify(ur => ur.GetByCredentials(funcionario.Usuario, pass), Times.Once);
            funcionarioLogged.Should().NotBeNull();
            funcionarioLogged.Should().Be(funcionario);
        }
        #endregion
    }
}
