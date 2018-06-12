using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Features.Rooms;
using SalaReuniao.Features.Rooms;
using SalaReuniao.Features.Rooms.Exceptions;
using System;

namespace SalaReuniao.Domain.Test.Features.Rooms
{
    [TestFixture]
    public class RoomTest
    {
        private Room _room;

        [SetUp]
        public void Initialize()
        {
            _room = RoomObjectMother.CreateValidRoom();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateRoom_ShouldBeOk()
        {
            Action action = _room.Validate;
            action.Should().NotThrow<Exception>();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(2)]
        public void Test_CreateRoom_EmptyName_ShouldFail()
        {
            _room.Name = "";

            Action action = _room.Validate;
            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        [Order(3)]
        public void Test_CreateRoom_EmptyChairs_ShouldFail()
        {
            _room.Chairs = -1;

            Action action = _room.Validate;
            action.Should().Throw<ChairsNumberException>();
        }
    }
}
