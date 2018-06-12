using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.App.Features.Rooms;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Rooms;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Features.Rooms;
using SalaReuniao.Features.Rooms.Exceptions;
using SalaReuniao.Infra.Data.Features.Rooms;
using System;

namespace SalaReuniao.Infra.Tests.Features.Rooms
{
    [TestFixture]
    public class RoomSystemIntegrationTest
    {
        private RoomRepository _roomRepository;
        private RoomService _roomService;
        private Room _room;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _roomRepository = new RoomRepository();
            _roomService = new RoomService(_roomRepository);
            _room = RoomObjectMother.CreateValidRoom();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Room_SystemIntegration_Add_ShouldBeOk()
        {
            _roomService.Add(_room);

            var rooms = _roomService.GetAll();
            rooms.Count.Should().BeGreaterThan(0);
            rooms[1].Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void Test_Room_SystemIntegration_Get_ShouldBeOk()
        {
            var room = _roomService.Get(_room.Id);
            room.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(3)]
        public void Test_Room_SystemIntegration_GetAll_ShouldBeOk()
        {
            var rooms = _roomService.GetAll();
            rooms.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_Room_SystemIntegration_Delete_ShouldBeOk()
        {
            _room = _roomService.Add(_room);

            _roomService.Delete(_room);

            var employeeDeleted = _roomService.Get(_room.Id);
            employeeDeleted.Should().BeNull();
        }

        [Test]
        [Order(5)]
        public void Test_Room_SystemIntegration_Update_ShouldBeOk()
        {
            _room.Name = "sala de reuniao";

            var room = _roomService.Update(_room);

            room.Name.Should().Be(_room.Name);
        }

        [Test]
        [Order(6)]
        public void Test_Room_SystemIntegration_IsTiedTo_ShouldBeOk()
        {
            bool result = _roomService.IsTiedTo(_room.Id);
            result.Should().Be(true);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(7)]
        public void Test_Room_SystemIntegration_Add_EmptyName_ShouldFail()
        {
            _room.Name = String.Empty;

            Action action = () => _roomService.Add(_room);

            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        [Order(8)]
        public void Test_Room_SystemIntegration_Add_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _roomService.Add(_room);

            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        [Order(9)]
        public void Test_Room_SystemIntegration_Add_DuplicatedName_ShouldFail()
        {
            _room.Name = "sala de treinamento";

            Action action = () => _roomService.Add(_room);

            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(10)]
        public void Test_Room_SystemIntegration_Get_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _roomService.Get(_room.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_Room_SystemIntegration_Delete_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _roomService.Delete(_room);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(12)]
        public void Test_Room_SystemIntegration_Delete_TiedTo_ShouldFail()
        {
            Action action = () => _roomService.Delete(_room);

            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(13)]
        public void Test_Room_SystemIntegration_Update_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _roomService.Delete(_room);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_Room_SystemIntegration_Update_EmptyName_ShouldFail()
        {
            _room.Name = String.Empty;

            Action action = () => _roomService.Update(_room);

            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        [Order(15)]
        public void Test_Room_SystemIntegration_Update_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _roomService.Update(_room);

            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        [Order(15)]
        public void Test_Room_SystemIntegration_Update_DuplicatedName_ShouldFail()
        {
            _room.Id = 2;
            _room.Name = "sala de treinamento";

            Action action = () => _roomService.Update(_room);

            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(17)]
        public void Test_Room_SystemIntegration_IsTiedTo_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _roomService.IsTiedTo(_room.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
