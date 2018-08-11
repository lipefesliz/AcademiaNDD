using Biblioteca.Infra;

namespace Biblioteca.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        /* TBBooks */
        private const string RECREATE_BOOK_TABLE = @"DELETE FROM [dbo].[TBBooks]";

        private const string RESET_BOOK_IDENTITY = @"DBCC CHECKIDENT('TBBooks', RESEED, 0)";

        private const string INSERT_BOOK =
            @"INSERT INTO TBBOOKS
                (TITLE,
                 AUTHOR,
                 THEME,
                 VOLUME,
                 PUBLICATION,
                 ISAVAILABLE)
            VALUES
                ('Python',
                 'John Wick',
                 'Linguagens de Programacao',
                 1,
                 GETDATE(),
                 1)";

        /* TBLoan */
        private const string RECREATE_LOAN_TABLE = @"DELETE FROM [dbo].[TBLoan]";

        private const string RESET_LOAN_IDENTITY = @"DBCC CHECKIDENT('TBLoan', RESEED, 0)";

        private const string INSERT_LOAN =
            @"INSERT INTO TBLOAN
                (CUSTOMER,
                 BOOKID,
                 RETURNDATE)
            VALUES
                ('Morty',
                 1,
                 GETDATE())";

        /* TBLoanBooks */
        private const string RECREATE_LOAN_BOOKS_TABLE = @"TRUNCATE TABLE [dbo].[TBLoanBooks]";

        private const string INSERT_LOAN_BOOKS =
            @"INSERT INTO TBLOANBOOKS
                (BOOKID,
                 LOANID)
            VALUES
                (1,
                 1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_LOAN_BOOKS_TABLE);

            Db.Update(RECREATE_BOOK_TABLE);
            Db.Update(RESET_BOOK_IDENTITY);
            Db.Update(INSERT_BOOK);

            Db.Update(RECREATE_LOAN_TABLE);
            Db.Update(RESET_LOAN_IDENTITY);
            Db.Update(INSERT_LOAN);

            Db.Update(INSERT_LOAN_BOOKS);
        }
    }
}
