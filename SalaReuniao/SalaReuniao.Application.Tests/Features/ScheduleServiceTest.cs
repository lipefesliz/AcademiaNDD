using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaReuniao.App.Features.Schedules;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Schedules.Utils;
using System.Collections.Generic;

namespace SalaReuniao.Application.Tests.Features
{
    [TestFixture]
    public class ScheduleServiceTest
    {
        private ScheduleService _service;
        private Mock<IScheduleRepository> _mockRepository;
        private Schedule _schedule;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IScheduleRepository>();
            _service = new ScheduleService(_mockRepository.Object);
            _schedule = ScheduleObjectMother.CreateValidSchedule();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ScheduleService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.IsBooked(_schedule.Room))
                .Returns(new Schedule { IsAvailable = true });

            _mockRepository
                .Setup(sr => sr.Add(_schedule))
                .Returns(new Schedule { Id = 1 });

            var scheduleAdded = _service.Add(_schedule);

            _mockRepository.Verify(sr => sr.Add(_schedule));
            scheduleAdded.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_ScheduleService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Get(_schedule.Id))
                .Returns(new Schedule { Id = 1 });

            var schedule = _service.Get(_schedule.Id);

            _mockRepository.Verify(sr => sr.Get(_schedule.Id));
            schedule.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(3)]
        public void Test_ScheduleService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetAll())
                .Returns(new List<Schedule> { new Schedule { Id = 1 } });

            var schedules = _service.GetAll();

            _mockRepository.Verify(sr => sr.GetAll());
            schedules.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_ScheduleService_GetAvailableRooms_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetAvailableRooms(_schedule.BookingDate))
                .Returns(new List<Schedule> { new Schedule { Room = RoomTypes.Reuniao} });

            var rooms = _service.GetAvailableRooms(_schedule.BookingDate);

            _mockRepository.Verify(sr => sr.GetAvailableRooms(_schedule.BookingDate));
            rooms.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_ScheduleService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.IsBooked(_schedule.Room))
                .Returns(new Schedule { IsAvailable = false } );

            _mockRepository
                .Setup(sr => sr.GetByRoom(_schedule.Room))
                .Returns(new Schedule { Id = 1 });

            _mockRepository
                .Setup(sr => sr.Update(_schedule))
                .Returns(new Schedule { IsAvailable = false} );

            var newSchedule = _service.Update(_schedule);

            _mockRepository.Verify(sr => sr.Update(_schedule));
            newSchedule.IsAvailable.Should().BeFalse();
        }

        [Test]
        [Order(6)]
        public void Test_ScheduleService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Delete(_schedule.Id));

            _service.Delete(_schedule);

            _mockRepository
                .Setup(sr => sr.Get(_schedule.Id));

            var scheduleDeleted = _service.Get(_schedule.Id);

            _mockRepository.Verify(sr => sr.Delete(_schedule.Id));
            scheduleDeleted.Should().BeNull();
        }
    }
}
