using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Infra.Data.Features.Schedules;

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
        [Order(5)]
        public void Test_ScheduleIntegrationData_Update_ShouldBeOk()
        {
            _schedule.Room = Schedule.RoomType.VideoConferencia;

            var schedule = _repository.Update(_schedule);
            schedule.Equals(_schedule).Should().BeTrue();
        }
    }
}
