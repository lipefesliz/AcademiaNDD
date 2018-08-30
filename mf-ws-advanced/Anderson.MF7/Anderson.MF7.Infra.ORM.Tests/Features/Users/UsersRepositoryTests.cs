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

    }
}
