using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.App.Features.Employees;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Employees;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Employees.Exceptions;
using SalaReuniao.Infra.Data.Features.Employees;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Infra.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeSystemIntegrationTest
    {
        private EmployeeRepository _employeeRepository;
        private EmployeeService _employeeService;
        private Employee _employee;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _employeeRepository = new EmployeeRepository();
            _employeeService = new EmployeeService(_employeeRepository);
            _employee = EmployeeObjectMother.CreateValidEmployee();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Employee_SystemIntegration_Add_ShouldBeOk()
        {
            _employeeService.Add(_employee);

            IList<Employee> employees = _employeeService.GetAll();
            employees.Count.Should().BeGreaterThan(0);
            employees[1].Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void Test_Employee_SystemIntegration_Get_ShouldBeOk()
        {
            var employee = _employeeService.Get(_employee.Id);
            employee.Id.Should().Be(_employee.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Employee_SystemIntegration_GetAll_ShouldBeOk()
        {
            var employees = _employeeService.GetAll();
            employees.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_Employee_SystemIntegration_Update_ShouldBeOk()
        {
            _employee.Name = "Clovis";

            var newEmployee = _employeeService.Update(_employee);
            newEmployee.Equals(_employee).Should().BeTrue();
        }

        [Test]
        [Order(5)]
        public void Test_Employee_SystemIntegration_Delete_ShouldBeOk()
        {
            _employee = _employeeService.Add(_employee);

            _employeeService.Delete(_employee);

            var employeeDeleted = _employeeService.Get(_employee.Id);
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(6)]
        public void Test_Employee_SystemIntegration_IsTiedTo_ShouldBeOk()
        {
            bool result = _employeeService.IsTiedTo(_employee.Id);
            result.Should().Be(true);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(7)]
        public void Test_Employee_SystemIntegration_Add_ShouldFail()
        {
            _employee.Name = "Zeca";

            Action action = () => _employeeService.Add(_employee);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(8)]
        public void Test_Employee_SystemIntegration_Update_DuplicatedName_ShouldFail()
        {
            _employee.Id = 2;
            _employee.Name = "Zeca";

            Action action = () => _employeeService.Update(_employee);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(9)]
        public void Test_Employee_SystemIntegration_Delete_ItemTiedTo_ShouldFail()
        {
            Action action = () => _employeeService.Delete(_employee);
            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(10)]
        public void Test_Employee_SystemIntegration_Add_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _employeeService.Add(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(11)]
        public void Test_Employee_SystemIntegration_Add_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _employeeService.Add(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(12)]
        public void Test_Employee_SystemIntegration_Add_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _employeeService.Add(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }

        [Test]
        [Order(13)]
        public void Test_Employee_SystemIntegration_Update_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _employeeService.Update(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(14)]
        public void Test_Employee_SystemIntegration_Update_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _employeeService.Update(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(15)]
        public void Test_Employee_SystemIntegration_Update_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _employeeService.Update(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }
    }
}
