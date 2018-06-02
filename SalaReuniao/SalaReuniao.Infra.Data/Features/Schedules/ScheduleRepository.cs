using System;
using System.Collections.Generic;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;

namespace SalaReuniao.Infra.Data.Features.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        #region

        private const string sqlInsertSchedule =
            @"INSERT INTO TBSCHEDULES
                (BOOKINGDATE,
                 ROOM,
                 EMPLOYEEID,
                 ISAVAILABLE)
            VALUES
                ({0}BOOKINGDATE,
                 {0}ROOM,
                 {0}EMPLOYEEID,
                 {0}ISAVAILABLE)";

        private const string sqlDeleteSchedule = @"DELETE FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetSchedule =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE ID = {0}ID";

        private const string sqlGetAllSchedules =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES";

        string sqlUpdateSchedule =
            @"UPDATE TBSCHEDULES
                SET
                    BOOKINGDATE = {0}BOOKINGDATE,
                    ROOM = {0}ROOM,
                    EMPLOYEEID = {0}EMPLOYEEID,
                    ISAVAILABLE = {0}ISAVAILABLE
                WHERE ID = {0}ID";

        private const string SqlSelectScheduleByRoom =
            @"SELECT
                 ID,
                 BOOKINGDATE,
                 ROOM,
                 EMPLOYEEID,
                 ISAVAILABLE
            FROM TBSCHEDULES WHERE NAME = {0}NAME";

        #endregion

        public bool IsBooked(string room)
        {
            throw new NotImplementedException();
        }

        public Schedule GetByRoom(string room)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAvailableRooms(DateTime bookingDate)
        {
            throw new NotImplementedException();
        }

        public Schedule Add(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public Schedule Update(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public Schedule Get(long id)
        {
            throw new NotImplementedException();
        }

        public IList<Schedule> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
