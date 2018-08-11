using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Loans;

namespace Biblioteca.Infra.Data.Features.Loans
{
    public class LoanRepository : ILoanRepository
    {
        #region QUERYS

        private const string SqlInsertLoan =
            @"INSERT INTO TBLOAN
                (CUSTOMER
                 ,BOOKID
                 ,RETURNDATE)
            VALUES
                ({0}CUSTOMER
                 ,{0}BOOKID
                 ,{0}RETURNDATE)";

        private const string SqlUpdateLoan =
            @"UPDATE TBLOAN
                SET
                    CUSTOMER = {0}CUSTOMER,
                    BOOKID = {0}BOOKID,
                    RETURNDATE = {0}RETURNDATE
                WHERE ID = {0}ID";

        private const string SqlDeleteLoan =
           @"DELETE FROM TBLOAN
                WHERE ID = {0}ID";

        private const string SqlDeleteLoanBook =
            @"DELETE FROM TBLOANBOOKS
                WHERE LOANID = {0}ID";

        private const string SqlSelectAllLoans =
           @"SELECT
                ID,
                CUSTOMER,
                BOOKID,
                RETURNDATE
            FROM
                TBLOAN ORDER BY CUSTOMER";

        private const string SqlSelectLoanById =
           @"SELECT
                ID,
                CUSTOMER,
                BOOKID,
                RETURNDATE
            FROM
                TBLOAN
            WHERE ID = {0}ID";

        private const string SqlSelectLoanByBook =
           @"SELECT
                ID,
                CUSTOMER,
                BOOKID,
                RETURNDATE
            FROM
                TBLOAN
            WHERE BOOKID = {0}BOOKID";

        private const string SqlInsertLoanBook =
            @"INSERT INTO TBLOANBOOKS
                (BOOKID
                 ,LOANID)
            VALUES
                ({0}BOOKID
                 ,{0}LOANID)";

        private const string SqlUpdateLoanBook =
            @"UPDATE TBLOANBOOKS
                SET
                    BOOKID = {0}BOOKID,
                    LOANID = {0}LOANID,
                WHERE ID = {0}ID";

        private const string SqlSelectBook =
            @"SELECT
                TBBOOKS.*
            FROM
                TBLOAN
                INNER JOIN TBLOANBOOKS ON TBLOAN.ID = TBLOANBOOKS.LOANID
                INNER JOIN TBBOOKS ON TBLOANBOOKS.BOOKID = TBBOOKS.ID
                WHERE TBLOAN.ID = {0}ID";

        #endregion QUERYS

        public Loan Add(Loan loan)
        {
            loan.Validate();

            loan.Id = Db.Insert(SqlInsertLoan, GetParameters(loan));

            Db.Insert(SqlInsertLoanBook, GetParameters(loan.Book.Id, loan.Id));

            return loan;
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeleteLoanBook, parms);
            Db.Delete(SqlDeleteLoan, parms);
        }

        public Loan Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectLoanById, Converter, parms);
        }

        public IList<Loan> GetAll()
        {
            return Db.GetAll(SqlSelectAllLoans, Converter);
        }

        public Book GetBookFromLoan(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectBook, ConverterBook, parms);
        }

        public Loan GetByBook(int id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "BOOKID", id } };

            var loan = Db.Get(SqlSelectLoanByBook, Converter, parms);

            return loan;
        }

        public Loan Update(Loan loan)
        {
            loan.Validate();

            Db.Update(SqlUpdateLoan, GetParameters(loan));

            var parms = new Dictionary<string, object> { { "ID", loan.Id } };

            Db.Delete(SqlDeleteLoanBook, parms);

            Db.Insert(SqlInsertLoanBook, GetParameters(loan.Book.Id, loan.Id));

            return loan;
        }

        private Dictionary<string, object> GetParameters(Loan loan)
        {
            return new Dictionary<string, object>
            {
                { "ID", loan.Id },
                { "CUSTOMER", loan.Customer },
                { "BOOKID", loan.Book.Id},
                { "RETURNDATE", loan.ReturnDate}
            };
        }

        private Dictionary<string, object> GetParameters(int bookId, int loanId)
        {
            return new Dictionary<string, object>
            {
                { "BOOKID", bookId},
                { "LOANID", loanId}
            };
        }

        private static Func<IDataReader, Loan> Converter = reader =>
          new Loan
          {
              Id = Convert.ToInt32(reader["ID"]),
              Customer = Convert.ToString(reader["CUSTOMER"]),
              ReturnDate = Convert.ToDateTime(reader["RETURNDATE"]),
          };

        private static Func<IDataReader, Book> ConverterBook = reader =>
          new Book
          {
              Id = Convert.ToInt32(reader["ID"]),
              Title = Convert.ToString(reader["TITLE"]),
              Author = Convert.ToString(reader["AUTHOR"]),
              Theme = Convert.ToString(reader["THEME"]),
              Volume = Convert.ToInt32(reader["VOLUME"]),
              Publication = Convert.ToDateTime(reader["PUBLICATION"]),
              IsAvailable = Convert.ToBoolean(reader["ISAVAILABLE"]),
          };
    }
}
