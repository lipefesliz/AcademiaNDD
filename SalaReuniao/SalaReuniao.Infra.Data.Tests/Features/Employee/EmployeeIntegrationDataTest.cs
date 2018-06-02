using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Employees;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Infra.Data.Features.Employees;

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
    }
}
