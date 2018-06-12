using System;
using System.Collections.Generic;
using System.Data;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Rooms;
using SalaReuniao.Features.Schedules;

namespace SalaReuniao.Infra.Data.Features.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        #region

        private const string sqlInsertSchedule =
            @"INSERT INTO TBSCHEDULES
                (STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE)
            VALUES
                ({0}STARTING,
                 {0}ENDING,
                 {0}ROOMID,
                 {0}EMPLOYEEID,
                 {0}ISAVAILABLE)";

        private const string sqlDeleteSchedule = @"DELETE FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetSchedule =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetAllSchedules =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES";

        string sqlUpdateSchedule =
            @"UPDATE TBSCHEDULES
                SET
                    STARTING = {0}STARTING,
                    ENDING = {0}ENDING,
                    ROOMID = {0}ROOMID,
                    EMPLOYEEID = {0}EMPLOYEEID,
                    ISAVAILABLE = {0}ISAVAILABLE
                WHERE ID = {0}ID";

        private const string SqlSelectScheduleByRoom =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ROOMID = {0}ID";

        private const string SqlSelectAvailableRoomByDate =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ISAVAILABLE = 1 AND STARTING LIKE {0}STARTING";

        private const string SqlSelectAvailableRoom =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ROOMID = {0}ID";

        private const string SqlSelectRoom =
            @"SELECT
                TBROOMS.*
            FROM
                TBSCHEDULES
                INNER JOIN TBROOMS ON TBSCHEDULES.ROOMID = TBROOMS.ID
                WHERE TBSCHEDULES.ID = {0}ID";

        private const string SqlSelectEmployee =
            @"SELECT
                TBEMPLOYEES.*
            FROM
                TBSCHEDULES
                INNER JOIN TBEMPLOYEES ON TBSCHEDULES.EMPLOYEEID = TBEMPLOYEES.ID
                WHERE TBSCHEDULES.ID = {0}ID";

        private const string sqlGetEndingTime =
            @"SELECT
                 ID,
                 STARTING,
                 ENDING,
                 ROOMID,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ROOMID = {0}ID";

        #endregion

        public bool IsAvailable(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var schedule = Db.Get(SqlSelectAvailableRoom, Converter, parms);

            if (schedule == null)
                return true;

            return schedule.IsAvailable;
        }

        public Schedule GetByRoom(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var schedule = Db.Get(SqlSelectScheduleByRoom, Converter, parms);

            return schedule;
        }

        public Schedule Add(Schedule entity)
        {
            entity.Validate();

            entity.Id = Db.Insert(sqlInsertSchedule, GetParameters(entity));

            return entity;
        }

        public Schedule Update(Schedule entity)
        {
            entity.Validate();

            Db.Update(sqlUpdateSchedule, GetParameters(entity));

            var parms = new Dictionary<string, object> { { "ID", entity.Id } };

            return entity;
        }

        public Schedule Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetSchedule, Converter, parms);
        }

        public IList<Schedule> GetAll()
        {
            return Db.GetAll(sqlGetAllSchedules, Converter);
        }

        public IList<Schedule> GetAvailableRooms(DateTime starting)
        {
            var parms = new Dictionary<string, object> { { "STARTING", starting } };

            return Db.GetAll(SqlSelectAvailableRoomByDate, Converter, parms);
        }

        public Schedule GetEndingTime(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetEndingTime, Converter, parms);
        }

        public Employee GetEmployeeFromSchedule(int id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectEmployee, ConverterEmployee, parms);
        }

        public Room GetRoomFromSchedule(int id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectRoom, ConverterRoom, parms);
        }

        public void Delete(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteSchedule, parms);
        }

        private Dictionary<string, object> GetParameters(Schedule schedule)
        {
            return new Dictionary<string, object>
            {
                { "ID", schedule.Id },
                { "STARTING", schedule.Statirg},
                { "ENDING", schedule.Ending},
                { "ROOMID", schedule.Room.Id},
                { "EMPLOYEEID", schedule.Employee.Id},
                { "ISAVAILABLE", schedule.IsAvailable}
            };
        }

        private static Func<IDataReader, Schedule> Converter = reader =>
          new Schedule
          {
              Id = Convert.ToInt32(reader["ID"]),
              Statirg = Convert.ToDateTime(reader["STARTING"]),
              Ending = Convert.ToDateTime(reader["ENDING"]),
              IsAvailable = Convert.ToBoolean(reader["ISAVAILABLE"])
          };

        private static Func<IDataReader, Room> ConverterRoom = reader =>
          new Room
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Chairs = Convert.ToInt32(reader["CHAIRS"]),
          };

        private static Func<IDataReader, Employee> ConverterEmployee = reader =>
          new Employee
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Post = Convert.ToString(reader["POST"]),
              BranchLine = Convert.ToInt32(reader["BRANCHLINE"])
          };
    }
}
