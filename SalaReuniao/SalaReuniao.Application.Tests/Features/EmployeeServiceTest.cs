using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaReuniao.App.Features.Employees;
using SalaReuniao.Common.Tests.Features.Employees;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Employees.Exceptions;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Application.Tests.Features
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private EmployeeService _service;
        private Mock<IEmployeeRepository> _mockRepository;
        private Employee _employee;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_mockRepository.Object);
            _employee = EmployeeObjectMother.CreateValidEmployee();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_EmployeeService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.Add(_employee))
                .Returns(new Employee { Id = 1 });

            var employeeAdded = _service.Add(_employee);

            _mockRepository.Verify(er => er.Add(_employee));
            employeeAdded.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_EmployeeService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.GetByName(_employee.Name))
                .Returns(new Employee { Id = 1 });

            _mockRepository
                .Setup(er => er.Update(_employee))
                .Returns(new Employee { Id = 1 });

            var employeeUpdated = _service.Update(_employee);

            _mockRepository.Verify(er => er.Update(_employee));
            employeeUpdated.Id.Should().Equals(_employee.Id);
        }

        [Test]
        [Order(3)]
        public void Test_EmployeeService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.Delete(_employee.Id));

            _service.Delete(_employee);

            _mockRepository
                .Setup(er => er.Get(_employee.Id));

            var employeeDeleted = _service.Get(_employee.Id);

            _mockRepository.Verify(er => er.Delete(_employee.Id));
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_EmployeeService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.Get(_employee.Id))
                .Returns(new Employee { Id = 1 });

            var employee = _service.Get(_employee.Id);

            _mockRepository.Verify(er => er.Get(_employee.Id));
            employee.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_EmployeeService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.GetAll())
                .Returns(new List<Employee> { new Employee { Id = 1 }, new Employee { Id = 2 } });

            IList<Employee> employees = _service.GetAll();

            _mockRepository.Verify(er => er.GetAll());
            employees.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_EmployeeService_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(er => er.IsTiedTo(Id))
                .Returns(false);

            bool result = _service.IsTiedTo(Id);
            result.Should().Be(false);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_EmployeeService_Add_DuplicatedName_ShouldFail()
        {
            _mockRepository
                .Setup(er => er.Exist(_employee.Name))
                .Returns(true);

            Action action = () => _service.Add(_employee);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(8)]
        public void Test_EmployeeService_Get_UndefinedId_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _service.Get(_employee.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(9)]
        public void Test_EmployeeService_Update_InvalidId_ShouldFail()
        {
            _mockRepository
                .Setup(er => er.GetByName(_employee.Name))
                .Returns(new Employee { Id = 2, Name = "Juca" });

            Action action = () => _service.Update(_employee);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(10)]
        public void Test_EmployeeService_Update_DuplicatedName_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _service.Update(_employee);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_EmployeeService_Delete_UndefinedId_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _service.Delete(_employee);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(12)]
        public void Test_EmployeeService_Delete_ItemTiedTo_ShouldFail()
        {
            _mockRepository
                .Setup(er => er.IsTiedTo(_employee.Id))
                .Returns(true);

            Action action = () => _service.Delete(_employee);
            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(13)]
        public void Test_EmployeeService_IsTiedTo_ShouldFail()
        {
            _employee.Id = -1;

            Action action = () => _service.IsTiedTo(_employee.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_EmployeeService_Add_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _service.Add(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(15)]
        public void Test_EmployeeService_Add_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _service.Add(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(16)]
        public void Test_EmployeeService_Add_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _service.Add(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }

        [Test]
        [Order(17)]
        public void Test_EmployeeService_Update_EmptyName_ShouldFail()
        {
            _employee.Name = "";

            Action action = () => _service.Update(_employee);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(18)]
        public void Test_EmployeeService_Update_EmptyPost_ShouldFail()
        {
            _employee.Post = "";

            Action action = () => _service.Update(_employee);
            action.Should().Throw<PostIsNullOrEmptyException>();
        }

        [Test]
        [Order(19)]
        public void Test_EmployeeService_Update_InvalidBranchLine_ShouldFail()
        {
            _employee.BranchLine = -1;

            Action action = () => _service.Update(_employee);
            action.Should().Throw<InvalidBranchLineException>();
        }
    }
}
