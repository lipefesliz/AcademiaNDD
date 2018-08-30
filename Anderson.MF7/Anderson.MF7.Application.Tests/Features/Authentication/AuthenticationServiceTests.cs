using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Application.Tests.Initializer;
using Anderson.MF7.Common.Tests.Features.Users;
using Anderson.MF7.Domain.Features.Users;
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
        private Mock<IUserRepository> _userRepositoryFake;

        [SetUp]
        public void Initialize()
        {
            _userRepositoryFake = new Mock<IUserRepository>();
            _service = new AuthenticationService(_userRepositoryFake.Object);
        }

        #region Login 
        [Test]
        public void Auth_Service_Login_ShouldBeOk()
        {
            //Arrange
            var user = ObjectMother.GetValidUser();
            var pass = user.Password.GenerateHash();
            _userRepositoryFake.Setup(ur => ur.GetByCredentials(user.Email, pass)).Returns(user);
            //Action
            var userLogged = _service.Login(user.Email, user.Password);
            //Assert
            _userRepositoryFake.Verify(ur => ur.GetByCredentials(user.Email, pass), Times.Once);
            userLogged.Should().NotBeNull();
            userLogged.Should().Be(user);
        }
        #endregion
    }
}
