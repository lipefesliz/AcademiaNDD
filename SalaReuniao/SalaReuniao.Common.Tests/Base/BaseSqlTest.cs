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

        /* TBSchedules */
        private const string RECREATE_SCHEDULE_TABLE = @"TRUNCATE TABLE [dbo].[TBSchedules]";

        private const string INSERT_SCHEDULE =
            @"INSERT INTO TBSCHEDULES
                (BOOKINGDATE,
                 ROOM,
                 EMPLOYEEID)
            VALUES
                (GETDATE(),
                 'Treinamento',
                 1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_SCHEDULE_TABLE);

            Db.Update(RECREATE_EMPLOYEE_TABLE);
            Db.Update(RESET_EMPLOYEE_IDENTITY);
            Db.Update(INSERT_EMPLOYEE);

            Db.Update(INSERT_SCHEDULE);
        }
    }
}
