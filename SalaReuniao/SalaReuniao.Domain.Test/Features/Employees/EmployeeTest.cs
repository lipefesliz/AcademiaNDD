using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Features.Employees;
using SalaReuniao.Features.Employees;
using SalaReuniao.Features.Employees.Exceptions;
using System;

namespace SalaReuniao.Domain.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeTest
    {
        private Employee _employee;

        [SetUp]
        public void Initialize()
        {
            _employee = EmployeeObjectMother.CreateValidEmployee();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateEmployee_ShouldBeOk()
        {
            Action action = _employee.Validate;
            action.Should().NotThrow<Exception>();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(2)]
        public void Test_CreateEmployee_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = _employee.Validate;
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(3)]
        public void Test_CreateEmployee_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = _employee.Validate;
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(4)]
        public void Test_CreateEmployee_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = 0;

            Action action = _employee.Validate;
            action.Should().Throw<InvalidBranchLineException>();
        }
    }
}
