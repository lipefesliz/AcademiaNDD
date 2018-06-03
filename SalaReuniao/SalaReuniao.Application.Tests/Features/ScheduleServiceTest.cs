using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaReuniao.App.Features.Schedules;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Schedules.Exceptions;
using SalaReuniao.Features.Schedules.Utils;
using System;
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
                .Setup(sr => sr.IsAvailable(_schedule.Room))
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
                .Setup(sr => sr.IsAvailable(_schedule.Room))
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

        [Test]
        [Order(7)]
        public void Test_ScheduleService_GetEmployeeFromSchedule_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetEmployeeFromSchedule(_schedule.Id))
                .Returns(new Employee { Id = 1 });

            var employee = _service.GetEmployeeFromSchedule(_schedule.Id);

            _mockRepository.Verify(sr => sr.GetEmployeeFromSchedule(_schedule.Id));
            employee.Id.Should().BeGreaterThan(0);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(8)]
        public void Test_ScheduleService_Add_BookedDate_ShouldFail()
        {
            _mockRepository
                .Setup(sr => sr.IsAvailable(_schedule.Room))
                .Returns(new Schedule { IsAvailable = false });

            Action action = () => _service.Add(_schedule);
            action.Should().Throw<DateBookedException>();
        }

        [Test]
        [Order(9)]
        public void Test_ScheduleService_Delete_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _service.Delete(_schedule);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_ScheduleService_Get_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _service.Get(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_ScheduleService_Update_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _service.Update(_schedule);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(12)]
        public void Test_ScheduleService_Update_BookedDate_ShouldFail()
        {
            _mockRepository
                .Setup(sr => sr.IsAvailable(_schedule.Room))
                .Returns(new Schedule { IsAvailable = true });

            _mockRepository
                .Setup(sr => sr.GetByRoom(_schedule.Room))
                .Returns(new Schedule { Id = 2 });

            Action action = () => _service.Update(_schedule);
            action.Should().Throw<DateBookedException>();
        }

        [Test]
        [Order(13)]
        public void Test_ScheduleService_GetEmployeeFromSchedule_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _service.GetEmployeeFromSchedule(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_ScheduleService_Add_InvalidDate_ShouldFail()
        {
            _schedule.BookingDate = DateTime.Now.AddDays(-2);

            Action action = () => _service.Add(_schedule);
            action.Should().Throw<InvalidDateException>();
        }

        [Test]
        [Order(15)]
        public void Test_ScheduleService_Add_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _service.Add(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }

        [Test]
        [Order(16)]
        public void Test_ScheduleService_Update_InvalidDate_ShouldFail()
        {
            _schedule.BookingDate = DateTime.Now.AddDays(-2);

            Action action = () => _service.Update(_schedule);
            action.Should().Throw<InvalidDateException>();
        }

        [Test]
        [Order(17)]
        public void Test_ScheduleService_Update_NullEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = () => _service.Update(_schedule);
            action.Should().Throw<NullEmployeeException>();
        }
    }
}
