using SalaReuniao.Infra;

namespace SalaReuniao.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        /* TBEmployees */
        private const string RECREATE_EMPLOYEE_TABLE = @"DELETE FROM [dbo].[TBEmployees]";

        private const string RESET_EMPLOYEE_IDENTITY = @"DBCC CHECKIDENT('TBEmployees', RESEED, 0)";

        private const string INSERT_EMPLOYEE =
            @"INSERT INTO TBEMPLOYEES
                (NAME,
                 POST,
                 BRANCHLINE)
            VALUES
                ('Zeca',
                 'Desenvolvedor',
                 1)";

        /* TBRooms */
        private const string RECREATE_ROOM_TABLE = @"DELETE FROM [dbo].[TBRooms]";

        private const string RESET_ROOM_IDENTITY = @"DBCC CHECKIDENT('TBRooms', RESEED, 0)";

        private const string INSERT_ROOM =
            @"INSERT INTO TBROOMS
                (ROOMTYPE)
            VALUES
                ('Sala de Treinamento')";

        /* TBSchedules */
        private const string RECREATE_SCHEDULE_TABLE = @"TRUNCATE TABLE [dbo].[TBSchedules]";

        private const string INSERT_SCHEDULE =
            @"INSERT INTO TBSCHEDULES
                (BOOKINGDATE,
                 ROOMID,
                 EMPLOYEEID)
            VALUES
                (GETDATE(),
                 1,
                 1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_SCHEDULE_TABLE);

            Db.Update(RECREATE_EMPLOYEE_TABLE);
            Db.Update(RESET_EMPLOYEE_IDENTITY);
            Db.Update(INSERT_EMPLOYEE);

            Db.Update(RECREATE_ROOM_TABLE);
            Db.Update(RESET_ROOM_IDENTITY);
            Db.Update(INSERT_ROOM);

            Db.Update(INSERT_SCHEDULE);
        }
    }
}
