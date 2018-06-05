using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Schedules.Exceptions;
using SalaReuniao.Features.Utils;
using SalaReuniao.Infra.Data.Features.Schedules;
using System;

namespace SalaReuniao.Infra.Data.Tests.Features.Schedules
{
    [TestFixture]
    public class ScheduleIntegrationDataTest
    {
        private IScheduleRepository _repository;
        private Schedule _schedule;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ScheduleRepository();
            _schedule = ScheduleObjectMother.CreateValidSchedule();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ScheduleIntegrationData_Add_ShouldBeOk()
        {
            var newSchedule = _repository.Add(_schedule);
            newSchedule.Id.Should().Be(_schedule.Id);
        }

        [Test]
        [Order(2)]
        public void Test_ScheduleIntegrationData_Get_ShouldBeOk()
        {
            var schedule = _repository.Get(_schedule.Id);
            schedule.Id.Should().Be(_schedule.Id);
        }

        [Test]
        [Order(3)]
        public void Test_ScheduleIntegrationData_GetAll_ShouldBeOk()
        {
            var schedules = _repository.GetAll();
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_ScheduleIntegrationData_GetAvailableRooms_ShouldBeOk()
        {
            var schedules = _repository.GetAvailableRooms(_schedule.BookingDate);
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_ScheduleIntegrationData_GetByRoom_ShouldBeOk()
        {
            var schedule = _repository.GetByRoom(_schedule.Room.GetHashCode());
            schedule.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_ScheduleIntegrationData_Update_ShouldBeOk()
        {
            _schedule.IsAvailable = false;

            var schedule = _repository.Update(_schedule);
            schedule.Equals(_schedule).Should().BeTrue();
        }

        [Test]
        [Order(7)]
        public void Test_ScheduleIntegrationData_Delete_ShouldBeOk()
        {
            _schedule = _repository.Add(_schedule);

            _repository.Delete(_schedule.Id);

            var employeeDeleted = _repository.Get(_schedule.Id);
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(8)]
        public void Test_ScheduleIntegrationData_IsAvailable_ShouldBeOk()
        {
            var result = _repository.IsAvailable(_schedule.Room.GetHashCode());
            result.Should().BeTrue();
        }

        [Test]
        [Order(8)]
        public void Test_ScheduleIntegrationData_IsAvailable_UndefinedRoomType_ShouldBeOk()
        {
            _schedule.Room = (RoomTypes)4;

            var result = _repository.IsAvailable(_schedule.Room.GetHashCode());
            result.Should().BeTrue();
        }

        [Test]
        [Order(10)]
        public void Test_ScheduleIntegrationData_GetEmployeeFromSchedule_ShouldBeOk()
        {
            _schedule.Employee = _repository.GetEmployeeFromSchedule(_schedule.Id);
            _schedule.Employee.Id.Should().BeGreaterThan(0);
        }

        /* TESTE ALTERNATIVOS */
        [Test]
        [Order(11)]
        public void Test_ScheduleIntegrationData_Get_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _repository.Get(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(12)]
        public void Test_ScheduleIntegrationData_Delete_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _repository.Delete(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(13)]
        public void Test_ScheduleIntegrationData_GetEmployeeFromSchedule_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _repository.GetEmployeeFromSchedule(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_ScheduleIntegrationData_Add_InvalidDate_ShouldFail()
        {
            _schedule.BookingDate = DateTime.Now.AddDays(-2);

            Action action = () => _repository.Add(_schedule);
            action.Should().Throw<InvalidDateException>();
        }

        [Test]
        [Order(15)]
        public void Test_ScheduleIntegrationData_Add_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _repository.Add(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }

        [Test]
        [Order(16)]
        public void Test_ScheduleIntegrationData_Add_NegativeChairNumber_ShouldFail()
        {
            _schedule.Chairs = -1;

            Action action = () => _repository.Add(_schedule);
            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        [Order(17)]
        public void Test_ScheduleIntegrationData_Update_InvalidDate_ShouldFail()
        {
            _schedule.BookingDate = DateTime.Now.AddDays(-2);

            Action action = () => _repository.Update(_schedule);
            action.Should().Throw<InvalidDateException>();
        }

        [Test]
        [Order(18)]
        public void Test_ScheduleIntegrationData_Update_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _repository.Update(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }

        [Test]
        [Order(19)]
        public void Test_ScheduleIntegrationData_Update_NegativeChairNumber_ShouldFail()
        {
            _schedule.Chairs = -1;

            Action action = () => _repository.Update(_schedule);
            action.Should().Throw<ChairsNumberException>();
        }
    }
}
