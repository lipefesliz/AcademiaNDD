using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.App.Features.Schedules;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules.Utils;
using SalaReuniao.Infra.Data.Features.Schedules;
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
            var schedules = _scheduleService.GetAvailableRooms(_schedule.BookingDate);
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_ScheduleIntegrationData_GetAvailableRooms_ShouldBeOk()
        {
            var schedules = _scheduleService.GetAvailableRooms(_schedule.BookingDate);
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_ScheduleIntegration_Update_ShouldBeOk()
        {
            _schedule.Room = RoomTypes.VideoConferencia;

            var schedule = _scheduleService.Update(_schedule);
            schedule.Equals(_schedule).Should().BeTrue();
        }

        [Test]
        [Order(7)]
        public void Test_ScheduleIntegrationData_Delete_ShouldBeOk()
        {
            _schedule = _scheduleService.Add(_schedule);

            _scheduleService.Delete(_schedule);

            var employeeDeleted = _scheduleService.Get(_schedule.Id);
            employeeDeleted.Should().BeNull();
        }
    }
}
