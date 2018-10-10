using Projeto_Prova_Tdd.Infra;

namespace Projeto_Prova_Tdd.Commons.Tests.Base
{
    public static class BaseSqlTest
    {
        /* TBStudents */
        private const string RECREATE_STUDENT_TABLE = @"DELETE FROM [dbo].[TBStudents]";

        private const string RESET_STUDENT_IDENTITY = @"DBCC CHECKIDENT('TBStudents', RESEED, 0)";

        private const string INSERT_STUDENT =
            @"INSERT INTO TBSTUDENTS
                (NAME,
                 AGE)
            VALUES
                ('Felipe',
                 32)";

        /* TBResults */
        private const string RECREATE_RESULT_TABLE = @"DELETE FROM [dbo].[TBResults]";

        private const string RESET_RESULT_IDENTITY = @"DBCC CHECKIDENT('TBResults', RESEED, 0)";

        private const string INSERT_RESULT =
            @"INSERT INTO TBRESULTS
                (GRADE,
                 STUDENTID)
            VALUES
                (10,
                 1)";

        /* TBAudition */
        private const string RECREATE_AUDITION_TABLE = @"TRUNCATE TABLE [dbo].[TBAuditions]";

        private const string RESET_AUDITION_IDENTITY = @"DBCC CHECKIDENT('TBAuditions', RESEED, 0)";

        private const string INSERT_AUDITION =
            @"INSERT INTO TBAUDITIONS
                (THEME,
                 TESTDATE,
                 RESULTID)
            VALUES
                ('TDD',
                 GETDATE(),
                 1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_AUDITION_TABLE);
            Db.Update(RESET_AUDITION_IDENTITY);
            Db.Update(INSERT_AUDITION);

            Db.Update(RECREATE_RESULT_TABLE);
            Db.Update(RESET_RESULT_IDENTITY);
            Db.Update(INSERT_RESULT);

            Db.Update(RECREATE_STUDENT_TABLE);
            Db.Update(RESET_STUDENT_IDENTITY);
            Db.Update(INSERT_STUDENT);
        }
    }
}
