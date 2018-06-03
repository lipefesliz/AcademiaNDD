using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Employees;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Employees.Exceptions;
using SalaReuniao.Infra.Data.Features.Employees;
using System;

namespace SalaReuniao.Infra.Data.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeIntegrationDataTest
    {
        private IEmployeeRepository _repository;
        private Employee _employee;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new EmployeeRepository();
            _employee = EmployeeObjectMother.CreateValidEmployee();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_EmployeeIntegrationData_Add_ShouldBeOk()
        {
            var newEmployee = _repository.Add(_employee);
            newEmployee.Id.Should().Be(_employee.Id);
        }

        [Test]
        [Order(2)]
        public void Test_EmployeeIntegrationData_Get_ShouldBeOk()
        {
            var employee = _repository.Get(_employee.Id);
            employee.Id.Should().Be(_employee.Id);
        }

        [Test]
        [Order(3)]
        public void Test_EmployeeIntegrationData_GetAll_ShouldBeOk()
        {
            var employees = _repository.GetAll();
            employees.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_EmployeeIntegrationData_GetByName_ShouldBeOk()
        {
            _employee.Name = "Zeca";

            var employee = _repository.GetByName(_employee.Name);
            employee.Name.Should().Be(_employee.Name);
        }

        [Test]
        [Order(5)]
        public void Test_EmployeeIntegrationData_Update_ShouldBeOk()
        {
            _employee.Name = "Clovis";

            var newEmployee = _repository.Update(_employee);
            newEmployee.Equals(_employee).Should().BeTrue();
        }

        [Test]
        [Order(6)]
        public void Test_EmployeeIntegrationData_Delete_ShouldBeOk()
        {
            _employee = _repository.Add(_employee);

            _repository.Delete(_employee.Id);

            var employeeDeleted = _repository.Get(_employee.Id);
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(7)]
        public void Test_EmployeeIntegrationData_Exist_ShouldBeOk()
        {
            bool result = _repository.Exist("Zeca");
            result.Should().Be(true);
        }

        [Test]
        [Order(8)]
        public void Test_EmployeeIntegrationData_IsTiedTo_ShouldBeOk()
        {
            bool result = _repository.IsTiedTo(_employee.Id);
            result.Should().Be(true);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(9)]
        public void Test_EmployeeIntegrationData_Get_InvalidId_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _repository.Get(_employee.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_EmployeeIntegrationData_Delete_InvalidId_ShouldBeOk()
        {
            _employee.Id = -1;

            Action action = () => _repository.Delete(_employee.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_EmployeeIntegrationData_Delete_ItemTiedTo_ShouldBeOk()
        {
            Action action = () => _repository.Delete(_employee.Id);
            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(12)]
        public void Test_EmployeeIntegrationData_IsTiedTo_InvalidId_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _repository.IsTiedTo(_employee.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_EmployeeIntegrationData_Add_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _repository.Add(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(15)]
        public void Test_EmployeeIntegrationData_Add_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _repository.Add(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(16)]
        public void Test_EmployeeIntegrationData_Add_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _repository.Add(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }

        [Test]
        [Order(17)]
        public void Test_EmployeeIntegrationData_Update_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _repository.Update(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(18)]
        public void Test_EmployeeIntegrationData_Update_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _repository.Update(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(19)]
        public void Test_EmployeeIntegrationData_Update_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _repository.Update(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }
    }
}
