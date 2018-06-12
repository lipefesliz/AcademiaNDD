using FluentAssertions;
using NUnit.Framework;
using SalaReuniao.Common.Tests.Base;
using SalaReuniao.Common.Tests.Features.Rooms;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Features.Rooms;
using SalaReuniao.Features.Rooms.Exceptions;
using SalaReuniao.Infra.Data.Features.Rooms;
using System;

namespace SalaReuniao.Infra.Data.Tests.Features.Rooms
{
    [TestFixture]
    public class RoomIntegrationDataTest
    {
        private IRoomRepository _repository;
        private Room _room;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new RoomRepository();
            _room = RoomObjectMother.CreateValidRoom();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Room_IntegrationData_Add_ShouldBeOk()
        {
            var room = _repository.Add(_room);

            room.Id.Should().Be(_room.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Room_IntegrationData_Get_ShouldBeOk()
        {
            var room = _repository.Get(_room.Id);

            room.Id.Should().Be(_room.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Room_IntegrationData_GetAll_ShouldBeOk()
        {
            var rooms = _repository.GetAll();

            rooms.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_Room_IntegrationData_GetByName_ShouldBeOk()
        {
            _room.Name = "sala de treinamento";

            var room = _repository.GetByName(_room.Name);

            room.Name.Should().Be(_room.Name);
        }

        [Test]
        [Order(5)]
        public void Test_Room_IntegrationData_Delete_ShouldBeOk()
        {
            _room = _repository.Add(_room);
            _repository.Delete(_room.Id);

            var roomDeleted = _repository.Get(_room.Id);
            roomDeleted.Should().BeNull();
        }

        [Test]
        [Order(6)]
        public void Test_Room_IntegrationData_Update_ShouldBeOk()
        {
            _room.Name = "sala de reuniao";

            var room = _repository.Update(_room);

            room.Name.Should().Be(_room.Name);
        }

        [Test]
        [Order(7)]
        public void Test_Room_IntegrationData_Exist_ShouldBeOk()
        {
            var result = _repository.Exist("sala de treinamento");

            result.Should().BeTrue();
        }

        [Test]
        [Order(8)]
        public void Test_Room_IntegrationData_IsTiedTo_ShouldBeOk()
        {
            var result = _repository.IsTiedTo(_room.Id);

            result.Should().BeTrue();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(9)]
        public void Test_Room_IntegrationData_Add_EmptyName_ShouldFail()
        {
            _room.Name = String.Empty;

            Action action = () => _repository.Add(_room);

            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        [Order(10)]
        public void Test_Room_IntegrationData_Add_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _repository.Add(_room);

            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        [Order(11)]
        public void Test_Room_IntegrationData_Get_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _repository.Get(_room.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(12)]
        public void Test_Room_IntegrationData_Delete_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _repository.Delete(_room.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(13)]
        public void Test_Room_IntegrationData_Delete_TiedTo_ShouldFail()
        {
            Action action = () => _repository.Delete(_room.Id);

            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(14)]
        public void Test_Room_IntegrationData_Update_EmptyName_ShouldFail()
        {
            _room.Name = String.Empty;

            Action action = () => _repository.Update(_room);

            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        [Order(15)]
        public void Test_Room_IntegrationData_Update_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _repository.Update(_room);

            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        [Order(16)]
        public void Test_Room_IntegrationData_IsTiedTo_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _repository.IsTiedTo(_room.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
