using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.App.Features.Schedules;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules.Exceptions;
using SalaReuniao.Infra.Data.Features.Schedules;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Infra.Tests.Features.Schedules
{
    [TestFixture]
    public class ScheduleSystemIntegrationTest
    {
        private ScheduleRepository _scheduleRepository;
        private ScheduleService _scheduleService;
        private Schedule _schedule;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _scheduleRepository = new ScheduleRepository();
            _scheduleService = new ScheduleService(_scheduleRepository);
            _schedule = ScheduleObjectMother.CreateValidSchedule();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ScheduleIntegration_Add_ShouldBeOk()
        {
            _schedule.Statirg = DateTime.Now.AddHours(2);
            _schedule.Ending = DateTime.Now.AddHours(3);

            _scheduleService.Add(_schedule);

            IList<Schedule> schedules = _scheduleService.GetAll();
            schedules.Count.Should().BeGreaterThan(0);
            schedules[1].Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void Test_ScheduleIntegration_Get_ShouldBeOk()
        {
            var schedule = _scheduleService.Get(_schedule.Id);
            schedule.Id.Should().Be(_schedule.Id);
        }

        [Test]
        [Order(3)]
        public void Test_ScheduleIntegration_GetAll_ShouldBeOk()
        {
            var schedules = _scheduleService.GetAll();
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_ScheduleIntegration_GetAvailableRooms_ShouldBeOk()
        {
            var schedules = _scheduleService.GetAvailableRooms(_schedule.Statirg);
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_ScheduleIntegration_Update_ShouldBeOk()
        {
            _schedule.IsAvailable = false;

            var schedule = _scheduleService.Update(_schedule);
            schedule.Equals(_schedule).Should().BeTrue();
        }

        [Test]
        [Order(7)]
        public void Test_ScheduleIntegration_Delete_ShouldBeOk()
        {
            _schedule.Statirg = DateTime.Now.AddHours(2);
            _schedule.Ending = DateTime.Now.AddHours(3);

            _schedule = _scheduleService.Add(_schedule);

            _scheduleService.Delete(_schedule);

            var employeeDeleted = _scheduleService.Get(_schedule.Id);
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(8)]
        public void Test_ScheduleIntegration_GetEmployeeFromSchedule_ShouldBeOk()
        {
            var employee = _scheduleService.GetEmployeeFromSchedule(_schedule.Id);
            employee.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(9)]
        public void Test_ScheduleIntegration_GetRoomFromSchedule_ShouldBeOk()
        {
            var room = _scheduleService.GetRoomFromSchedule(_schedule.Id);
            room.Id.Should().BeGreaterThan(0);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(11)]
        public void Test_ScheduleIntegration_Add_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _scheduleService.Add(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }

        [Test]
        [Order(13)]
        public void Test_ScheduleIntegration_Update_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _scheduleService.Update(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }

        [Test]
        [Order(14)]
        public void Test_ScheduleIntegration_Get_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _scheduleService.Get(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(15)]
        public void Test_ScheduleIntegration_GetEmployeeFromSchedule_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _scheduleService.GetEmployeeFromSchedule(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(16)]
        public void Test_ScheduleIntegration_Update_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _scheduleService.Update(_schedule);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(17)]
        public void Test_ScheduleIntegration_Delete_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _scheduleService.Delete(_schedule);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(18)]
        public void Test_ScheduleIntegrationData_Add_NullRoom_ShouldFail()
        {
            _schedule.Room = null;

            Action action = () => _scheduleService.Add(_schedule);
            action.Should().Throw<NullRoomException>();
        }

        [Test]
        [Order(19)]
        public void Test_ScheduleIntegrationData_Update_NullRoom_ShouldFail()
        {
            _schedule.Room = null;

            Action action = () => _scheduleService.Update(_schedule);
            action.Should().Throw<NullRoomException>();
        }

        [Test]
        [Order(20)]
        public void Test_ScheduleIntegration_GetRoomFromSchedule_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _scheduleService.GetRoomFromSchedule(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
