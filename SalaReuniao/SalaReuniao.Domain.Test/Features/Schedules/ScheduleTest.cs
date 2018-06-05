using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Features.Schedules;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules.Exceptions;
using System;

namespace SalaReuniao.Domain.Test.Features.Schedules
{
    [TestFixture]
    public class ScheduleTest
    {
        private Schedule _schedule;

        [SetUp]
        public void Initialize()
        {
            _schedule = ScheduleObjectMother.CreateValidSchedule();
        }

        /* TESTES CAMINHO FELIZ */
        [Test]
        [Order(1)]
        public void Test_CreateSchedule_ShouldBeOk()
        {
            Action action = _schedule.Validate;
            action.Should().NotThrow<Exception>();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(2)]
        public void Test_CreateSchedule_InvalidStartingDate_ShouldFail()
        {
            _schedule.Statirg = DateTime.Now.AddDays(-2);

            Action action = _schedule.Validate;
            action.Should().Throw<InvalidStartingTimeException>();
        }

        [Test]
        [Order(3)]
        public void Test_CreateSchedule_InvalidEndingDate_ShouldFail()
        {
            _schedule.Ending = DateTime.Now.AddDays(-2);

            Action action = _schedule.Validate;
            action.Should().Throw<InvalidEndingTimeException>();
        }

        [Test]
        [Order(4)]
        public void Test_CreateSchedule_EmptyRoom_ShouldFail()
        {
            _schedule.Room = null;

            Action action = _schedule.Validate;
            action.Should().Throw<NullRoomException>();
        }

        [Test]
        [Order(5)]
        public void Test_CreateSchedule_EmptyEmployee_ShouldFail()
        {
            _schedule.Employee = null;

            Action action = _schedule.Validate;
            action.Should().Throw<NullEmployeeException>();
        }
    }
}
