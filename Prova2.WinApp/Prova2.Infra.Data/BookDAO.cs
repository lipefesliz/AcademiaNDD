using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Prova2.Domain;

namespace Prova2.Infra.Data
{
    public class BookDAO
    {
        public SqlConnection _connection; //Classe para conexão com o ADO .NET SQL Server
        public SqlCommand _command; //Representa uma instrução Transact-SQL
        public SqlDataReader _reader; //Fornece uma maneira de ler linhas de uma base de dados no SQL Server
        public string _connectionString = ConfigurationManager.ConnectionStrings["Prova2"].ConnectionString; //Busca em tempo de execução a connections string que está no arquivo App.config na camada de apresentação

        public BookDAO()
        {
            _connection = new SqlConnection();
            _command = new SqlCommand();
        }

        public void UsingConnection(Book book, string sql)
        {
            _command.Parameters.AddWithValue("@Id", book.Id);
            _command.Parameters.AddWithValue("@Title", book.Title);
            _command.Parameters.AddWithValue("@Theme", book.Theme);
            _command.Parameters.AddWithValue("@Autor", book.Autor);
            _command.Parameters.AddWithValue("@Volume", book.Volume);
            _command.Parameters.AddWithValue("@DatePublication", book.DatePublication);
            _command.Parameters.AddWithValue("@IsAvailable", book.IsAvailable);

            _connection.ConnectionString = _connectionString;
            _command.Connection = _connection;
            _command.CommandText = sql;

            _connection.Open();

            _command.ExecuteScalar();

            _command.Parameters.Clear();

            _connection.Close();
        }

        public Book Add(Book book)
        {
            string sql = @"INSERT INTO [dbo].[Book]
                               ([Title]
                               ,[Theme]
                               ,[Autor]
                               ,[Volume]
                               ,[DatePublication]
                               ,[IsAvailable])
                           VALUES
                                 (@Title
                                  ,@Theme
                                  ,@Autor
                                  ,@Volume
                                  ,@DatePublication
                                  ,@IsAvailable);SELECT SCOPE_IDENTITY();";

            UsingConnection(book, sql);

            return book;
        }

        public Book GetById(int bookId)
        {
            string sql = @"SELECT [Id]
                                 ,[Title]
                                 ,[Theme]
                                 ,[Autor]
                                 ,[Volume]
                                 ,[DatePublication]
                                 ,[IsAvailable]
                           FROM [dbo].[Book]
                           WHERE [Id] = @Id";
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;
                _command.Parameters.AddWithValue("@Id", bookId);

                _connection.Open();

                _reader = _command.ExecuteReader();

                _command.Parameters.Clear();

                var list = new List<Book>();
                
                while (_reader.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(_reader["Id"]);
                    book.Title = Convert.ToString(_reader["Title"]);
                    book.Theme = Convert.ToString(_reader["Theme"]);
                    book.Autor = Convert.ToString(_reader["Autor"]);
                    book.Volume = Convert.ToInt32(_reader["Volume"]);
                    book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
                    book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

                    list.Add(book);
                }

                return list[0];
            }
        }
        public IList<Book> GetAll()
        {
            string sql = @"SELECT [Id]
                                 ,[Title]
                                 ,[Theme]
                                 ,[Autor]
                                 ,[Volume]
                                 ,[DatePublication]
                                 ,[IsAvailable]
                           FROM [dbo].[Book]";

            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;

                _connection.Open();

                _reader = _command.ExecuteReader();

                _command.Parameters.Clear();

                var list = new List<Book>();

                while (_reader.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(_reader["Id"]);
                    book.Title = Convert.ToString(_reader["Title"]);
                    book.Theme = Convert.ToString(_reader["Theme"]);
                    book.Autor = Convert.ToString(_reader["Autor"]);
                    book.Volume = Convert.ToInt32(_reader["Volume"]);
                    book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
                    book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

                    list.Add(book);
                }

                return list;
            }
        }

        public Book Update(Book book)
        {
            string sql = @"UPDATE [dbo].[Book]
                           SET [Title] = @Title
                              ,[Theme] = @Theme
                              ,[Autor] = @Autor
                              ,[Volume] = @Volume
                              ,[DatePublication] = @DatePublication
                              ,[IsAvailable] = @IsAvailable
                            WHERE [Id] = @Id";

            UsingConnection(book, sql);

            return book;
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM [dbo].[Book]
                                  WHERE [Id] = @Id";

            _connection.ConnectionString = _connectionString;

            _connection.Open();

            _command.Connection = _connection;
            _command.CommandText = sql;

            _command.Parameters.AddWithValue("@Id", id);

            var items = _command.ExecuteNonQuery();

            _command.Parameters.Clear();

            _connection.Close();

            return items;
        }
    }
}
