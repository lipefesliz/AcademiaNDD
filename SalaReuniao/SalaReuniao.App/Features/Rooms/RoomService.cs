using System.Collections.Generic;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Features.Rooms;

namespace SalaReuniao.App.Features.Rooms
{
    public class RoomService : IService<Room>
    {
        IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room Add(Room entity)
        {
            entity.Validate();

            var roomFounded = _roomRepository.Exist(entity.Name);
            if (roomFounded)
                throw new DuplicatedNameException();

            return _roomRepository.Add(entity);
        }

        public void Delete(Room entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(entity.Id))
                throw new TiedException();

            _roomRepository.Delete(entity.Id);
        }

        public Room Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _roomRepository.Get(id);
        }

        public IList<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room Update(Room entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            entity.Validate();

            var roomFounded = _roomRepository.GetByName(entity.Name);
            if (roomFounded != null)
            {
                if (roomFounded.Id != entity.Id)
                    throw new DuplicatedNameException();
            }

            return _roomRepository.Update(entity);
        }

        public bool IsTiedTo(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _roomRepository.IsTiedTo(id);
        }
    }
}
