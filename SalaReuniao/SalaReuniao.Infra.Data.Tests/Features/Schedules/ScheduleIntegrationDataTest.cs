﻿using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Schedules.Utils;
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
            var schedule = _repository.GetByRoom(_schedule.Room);
            schedule.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_ScheduleIntegrationData_Update_ShouldBeOk()
        {
            _schedule.Room = RoomTypes.VideoConferencia;

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
        public void Test_ScheduleIntegrationData_IsBooked_ShouldBeOk()
        {
            var schedule = _repository.IsBooked(_schedule.Room);
            schedule.IsAvailable.Should().BeTrue();
        }

        /* TESTE ALTERNATIVOS */
        [Test]
        [Order(9)]
        public void Test_ScheduleIntegrationData_Get_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _repository.Get(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_ScheduleIntegrationData_Delete_InvalidId_ShouldFail()
        {
            _schedule.Id = -1;

            Action action = () => _repository.Delete(_schedule.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
