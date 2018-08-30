using Anderson.MF7.Common.Tests.Features.Users;
using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.ORM.Features.Users;
using Anderson.MF7.Infra.ORM.Tests.Context;
using Anderson.MF7.Infra.ORM.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Anderson.MF7.Infra.ORM.Tests.Features.Users
{
    public class UsersRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private UserRepository _repository;
        private User _user;
        private User _userSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new UserRepository(_ctx);
            _user = ObjectMother.GetValidUser();
            //Seed
            _userSeed = ObjectMother.GetValidUser();
            _ctx.Users.Add(_userSeed);
            _ctx.SaveChanges();
        }

        #region GetByCredentials
        [Test]
        public void Users_Repository_GetByCredentials_ShouldBeOk()
        {
            //Action
            var userRegistered = _repository.GetByCredentials(_user.Email, _user.Password);
            //Assert
            userRegistered.Should().NotBeNull();
            userRegistered.Should().Be(_user);
            userRegistered.Email.Should().Be(_user.Email);
            userRegistered.Password.Should().Be(_user.Password);
        }

        [Test]
        public void Users_Repository_GetByCredentials_ShouldBeHandleInvalidCredentialsException()
        {
            //Action
            var invalidUser = ObjectMother.GetInvalidUser();
            Action action = () => _repository.GetByCredentials(invalidUser.Email, invalidUser.Password);
            //Assert
            action.Should().ThrowExactly<InvalidCredentialsException>();
        }

        #endregion
    }
}
