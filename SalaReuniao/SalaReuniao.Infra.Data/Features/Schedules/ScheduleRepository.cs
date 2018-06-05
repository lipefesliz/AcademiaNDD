﻿using System;
using System.Collections.Generic;
using System.Data;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Utils;

namespace SalaReuniao.Infra.Data.Features.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        #region

        private const string sqlInsertSchedule =
            @"INSERT INTO TBSCHEDULES
                (BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE)
            VALUES
                ({0}BOOKINGDATE,
                 {0}ROOM,
                 {0}CHAIRS,
                 {0}EMPLOYEEID,
                 {0}ISAVAILABLE)";

        private const string sqlDeleteSchedule = @"DELETE FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetSchedule =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetAllSchedules =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES";

        string sqlUpdateSchedule =
            @"UPDATE TBSCHEDULES
                SET
                    BOOKINGDATE = {0}BOOKINGDATE,
                    ROOM = {0}ROOM,
                    CHAIRS = {0}CHAIRS,
                    EMPLOYEEID = {0}EMPLOYEEID,
                    ISAVAILABLE = {0}ISAVAILABLE
                WHERE ID = {0}ID";

        private const string SqlSelectScheduleByRoom =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ROOM = {0}ROOMTYPE";

        private const string SqlSelectScheduleByDate =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ISAVAILABLE = 1 AND BOOKINGDATE LIKE {0}BOOKINGDATE";

        private const string SqlSelectAvailableRoom =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 CHAIRS,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ROOM = {0}ROOMTYPE";

        private const string SqlSelectEmployee =
            @"SELECT
                TBEMPLOYEES.*
            FROM
                TBSCHEDULES
                INNER JOIN TBEMPLOYEES ON TBSCHEDULES.EMPLOYEEID = TBEMPLOYEES.ID
                WHERE TBSCHEDULES.ID = {0}ID";

        #endregion

        public bool IsAvailable(int roomType)
        {
            var parms = new Dictionary<string, object> { { "ROOMTYPE", roomType } };

            var schedule = Db.Get(SqlSelectAvailableRoom, Converter, parms);

            if (schedule == null)
                return true;

            return schedule.IsAvailable;
        }

        public Schedule GetByRoom(int roomType)
        {
            var parms = new Dictionary<string, object> { { "ROOMTYPE", roomType } };

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

        public IList<Schedule> GetAvailableRooms(DateTime bookingDate)
        {
            var parms = new Dictionary<string, object> { { "BOOKINGDATE", bookingDate } };

            return Db.GetAll(SqlSelectScheduleByDate, Converter, parms);
        }

        public Employee GetEmployeeFromSchedule(int id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectEmployee, ConverterEmployee, parms);
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
                { "BOOKINGDATE", schedule.BookingDate},
                { "ROOM", schedule.Room},
                { "CHAIRS", schedule.Chairs},
                { "EMPLOYEEID", schedule.Employee.Id},
                { "ISAVAILABLE", schedule.IsAvailable}
            };
        }

        private static Func<IDataReader, Schedule> Converter = reader =>
          new Schedule
          {
              Id = Convert.ToInt32(reader["ID"]),
              BookingDate = Convert.ToDateTime(reader["BOOKINGDATE"]),
              Room = (RoomTypes)(reader["ROOM"]),
              Chairs = Convert.ToInt32(reader["CHAIRS"]),
              IsAvailable = Convert.ToBoolean(reader["ISAVAILABLE"])
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
