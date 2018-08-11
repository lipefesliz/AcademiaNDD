using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using System;
using System.Collections.Generic;
using System.Data;

namespace Biblioteca.Infra.Data.Features.Books
{
    public class BookRepository : IBookRepository
    {
        #region

        private const string sqlInsertBook =
            @"INSERT INTO TBBOOKS
                (TITLE,
                 AUTHOR,
                 THEME,
                 VOLUME,
                 PUBLICATION,
                 ISAVAILABLE)
            VALUES
                ({0}TITLE,
                 {0}AUTHOR,
                 {0}THEME,
                 {0}VOLUME,
                 {0}PUBLICATION,
                 {0}ISAVAILABLE)";

        private const string sqlDeleteBook = @"DELETE FROM TBBOOKS WHERE ID = {0}ID";

        private const string sqlGetBook =
            @"SELECT
                 ID,
                 TITLE,
                 AUTHOR,
                 THEME,
                 VOLUME,
                 PUBLICATION,
                 ISAVAILABLE
            FROM TBBOOKS WHERE ID = {0}ID";

        private const string sqlGetAllBooks =
            @"SELECT
                 ID,
                 TITLE,
                 AUTHOR,
                 THEME,
                 VOLUME,
                 PUBLICATION,
                 ISAVAILABLE
            FROM TBBOOKS";

        string sqlUpdateBook =
            @"UPDATE TBBOOKS
                SET
                    TITLE = {0}TITLE,
                    AUTHOR = {0}AUTHOR,
                    THEME = {0}THEME,
                    VOLUME = {0}VOLUME,
                    PUBLICATION = {0}PUBLICATION,
                    ISAVAILABLE = {0}ISAVAILABLE
                WHERE ID = {0}ID";

        private const string SqlSelectBookByTitle =
            @"SELECT
                 ID,
                 TITLE,
                 AUTHOR,
                 THEME,
                 VOLUME,
                 PUBLICATION,
                 ISAVAILABLE
            FROM TBBOOKS WHERE TITLE = {0}TITLE";

        private const string sqlIsTied = @"SELECT * FROM TBLOANBOOKS WHERE BOOKID = {0}ID";

        #endregion

        public Book Add(Book book)
        {
            book.Validate();

            book.Id = Db.Insert(sqlInsertBook, GetParameters(book));

            return book;
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(id))
                throw new ItemTiedToException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteBook, parms);
        }

        public bool Exist(string title)
        {
            var parms = new Dictionary<string, object> { { "TITLE", title } };

            var result = Db.Get(SqlSelectBookByTitle, Converter, parms);

            return result != null;
        }

        public Book Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetBook, Converter, parms);
        }

        public IList<Book> GetAll()
        {
            return Db.GetAll(sqlGetAllBooks, Converter);
        }

        public Book GetByTitle(string title)
        {
            var parms = new Dictionary<string, object> { { "TITLE", title } };

            var book = Db.Get(SqlSelectBookByTitle, Converter, parms);

            return book;
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterLoanBooks, parms);

            return result != null;
        }

        public Book Update(Book book)
        {
            book.Validate();

            Db.Update(sqlUpdateBook, GetParameters(book));

            return book;
        }

        private static Func<IDataReader, Book> Converter = reader =>
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

        private static Func<IDataReader, Book> ConverterLoanBooks = reader =>
            new Book
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Book book)
        {
            return new Dictionary<string, object>
            {
                { "ID", book.Id },
                { "TITLE", book.Title},
                { "AUTHOR", book.Author},
                { "THEME", book.Theme},
                { "VOLUME", book.Volume},
                { "PUBLICATION", book.Publication},
                { "ISAVAILABLE", book.IsAvailable},
            };
        }
    }
}
