using System;
using System.Collections.Generic;
using System.Data;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Features.Rooms;

namespace SalaReuniao.Infra.Data.Features.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        #region
        private const string sqlInsertRoom =
            @"INSERT INTO TBROOMS
                (NAME,
                 CHAIRS)
            VALUES
                ({0}NAME,
                 {0}CHAIRS)";

        private const string sqlDeleteRoom = @"DELETE FROM TBROOMS WHERE ID = {0}ID";

        private const string sqlGetRoom =
            @"SELECT
                 ID,
                 NAME,
                 CHAIRS
            FROM TBROOMS WHERE ID = {0}ID";

        private const string sqlGetAllRooms =
            @"SELECT
                 ID,
                 NAME,
                 CHAIRS
            FROM TBROOMS";

        string sqlUpdateRoom =
            @"UPDATE TBROOMS
                SET
                    NAME = {0}NAME,
                    CHAIRS = {0}CHAIRS
                WHERE ID = {0}ID";

        private const string SqlSelectRoomByName =
            @"SELECT
                 ID,
                 NAME,
                 CHAIRS
            FROM TBROOMS WHERE NAME = {0}NAME";

        private const string sqlIsTied = @"SELECT * FROM TBSCHEDULES WHERE ROOMID = {0}ID";
        #endregion

        public Room Add(Room room)
        {
            room.Validate();

            room.Id = Db.Insert(sqlInsertRoom, GetParameters(room));

            return room;
        }

        public void Delete(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(id))
                throw new TiedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteRoom, parms);
        }

        public bool Exist(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var result = Db.Get(SqlSelectRoomByName, Converter, parms);

            return result != null;
        }

        public Room Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetRoom, Converter, parms);
        }

        public IList<Room> GetAll()
        {
            return Db.GetAll(sqlGetAllRooms, Converter);
        }

        public Room GetByName(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var room = Db.Get(SqlSelectRoomByName, Converter, parms);

            return room;
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterScheduleRoom, parms);

            return result != null;
        }

        public Room Update(Room room)
        {
            room.Validate();

            Db.Update(sqlUpdateRoom, GetParameters(room));

            return room;
        }

        private static Func<IDataReader, Room> Converter = reader =>
          new Room
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Chairs = Convert.ToInt32(reader["CHAIRS"])
          };

        private static Func<IDataReader, Room> ConverterScheduleRoom = reader =>
            new Room
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Room room)
        {
            return new Dictionary<string, object>
            {
                { "ID", room.Id },
                { "NAME", room.Name},
                { "CHAIRS", room.Chairs}
            };
        }
    }
}
