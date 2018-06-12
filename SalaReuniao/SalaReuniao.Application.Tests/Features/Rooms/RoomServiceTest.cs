using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaReuniao.App.Features.Rooms;
using SalaReuniao.Common.Tests.Features.Rooms;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Features.Rooms;
using SalaReuniao.Features.Rooms.Exceptions;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Application.Tests.Features.Rooms
{
    [TestFixture]
    public class RoomServiceTest
    {
        private RoomService _service;
        private Mock<IRoomRepository> _mockRepository;
        private Room _room;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IRoomRepository>();
            _service = new RoomService(_mockRepository.Object);
            _room = RoomObjectMother.CreateValidRoom();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        public void Test_RoomService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Add(_room))
                .Returns(new Room { Id = 1 });

            var roomAdded = _service.Add(_room);

            _mockRepository.Verify(rr => rr.Add(_room));
            roomAdded.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_RoomService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Get(_room.Id))
                .Returns(new Room { Id = 1 });

            var room = _service.Get(_room.Id);

            _mockRepository.Verify(rr => rr.Get(_room.Id));
            room.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_RoomService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.GetAll())
                .Returns(new List<Room> { new Room { Id = 1 } });

            var rooms = _service.GetAll();

            _mockRepository.Verify(rr => rr.GetAll());
            rooms.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_RoomService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.GetByName(_room.Name));

            _mockRepository
                .Setup(rr => rr.Update(_room))
                .Returns(_room);

            var room = _service.Update(_room);

            _mockRepository.Verify(rr => rr.Update(_room));
            room.Name.Should().Equals(_room.Name);
        }

        [Test]
        public void Test_RoomService_Update_RoomFounded_ShouldBeOk()
        {
            _mockRepository
                .Setup(er => er.GetByName(_room.Name))
                .Returns(_room);

            _mockRepository
                .Setup(rr => rr.Update(_room))
                .Returns(_room);

            var room = _service.Update(_room);

            _mockRepository.Verify(rr => rr.Update(_room));
            room.Name.Should().Equals(_room.Name);
        }

        [Test]
        public void Test_RoomService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Delete(_room.Id));

            Action action = () => _service.Delete(_room);
            action.Should().NotThrow<Exception>();
            _mockRepository.Verify(rr => rr.Delete(_room.Id));
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        public void Test_RoomService_Add_DuplicatedName_ShouldFail()
        {
            _mockRepository
                .Setup(rr => rr.Exist(_room.Name))
                .Returns(true);

            Action action = () => _service.Add(_room);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        public void Test_RoomService_Add_EmptyName_ShouldFail()
        {
            _room.Name = "";

            Action action = () => _service.Add(_room);
            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        public void Test_RoomService_Add_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _service.Add(_room);
            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        public void Test_RoomService_Get_InvalidId_ShouldBeFail()
        {
            _room.Id = 0;

            Action action = () => _service.Get(_room.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_RoomService_Update_InvalidId_ShouldBeFail()
        {
            _room.Id = 0;

            Action action = () => _service.Update(_room);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_RoomService_Update_DuplicatedName_ShouldFail()
        {
            _mockRepository
                .Setup(rr => rr.GetByName(_room.Name))
                .Returns(new Room { Id = 2 });

            Action action = () => _service.Update(_room);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        public void Test_RoomService_Update_EmptyName_ShouldFail()
        {
            _room.Name = "";

            Action action = () => _service.Update(_room);
            action.Should().Throw<EmptyNameException>();
        }

        [Test]
        public void Test_RoomService_Update_ChairsNumber_ShouldFail()
        {
            _room.Chairs = 0;

            Action action = () => _service.Update(_room);
            action.Should().Throw<ChairsNumberException>();
        }

        [Test]
        public void Test_RoomService_Delete_InvalidId_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _service.Delete(_room);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_RoomService_Delete_TiedTo_ShouldFail()
        {
            _mockRepository
                .Setup(rr => rr.IsTiedTo(_room.Id))
                .Returns(true);

            Action action = () => _service.Delete(_room);
            action.Should().Throw<TiedException>();
        }

        [Test]
        public void Test_RoomService_IsTiedTo_ShouldFail()
        {
            _room.Id = 0;

            Action action = () => _service.IsTiedTo(_room.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
