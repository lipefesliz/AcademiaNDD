using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Prova2.Infra.Data
{
    public class OrderDAO
    {
        public SqlConnection _connection; //Classe para conexão com o ADO .NET SQL Server
        public SqlCommand _command; //Representa uma instrução Transact-SQL
        public SqlDataReader _reader; //Fornece uma maneira de ler linhas de uma base de dados no SQL Server
        public string _connectionString = ConfigurationManager.ConnectionStrings["Prova2"].ConnectionString; //Busca em tempo de execução a connections string que está no arquivo App.config na camada de apresentação

        public OrderDAO()
        {
            _connection = new SqlConnection();
            _command = new SqlCommand();
        }

        public Order Add(Order order)
        {
            string sql = @"INSERT INTO [dbo].[Order]
                               ([Customer]
                               ,[ReturnDate]
                               ,[BookId])
                           VALUES
                                 (@Customer
                                  ,@ReturnDate
                                  ,@BookId)";

            using (_connection)
            {
                _command.Parameters.AddWithValue("@Customer", order.Customer);
                _command.Parameters.AddWithValue("@ReturnDate", order.ReturnDate);
                _command.Parameters.AddWithValue("@BookId", order.Book.Id);

                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;

                _connection.Open();

                order.Id = Convert.ToInt32(_command.ExecuteScalar());

                _command.Parameters.Clear();
            }

            return order;
        }

        public IList<Order> GetAll()
        {
            string sql = @"SELECT o.[Id]
                                 ,o.[Customer]
                                 ,o.[ReturnDate]
                                 ,o.[BookId]
	                             ,b.[Title]
	                             ,b.[Theme]
	                             ,b.[Autor]
                                 ,b.[Volume]
	                             ,b.[IsAvailable]
	                             ,b.[DatePublication]
                           FROM [dbo].[Order] AS o
                           INNER JOIN Book AS b
                           ON b.Id = o.BookId";

            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;

                _connection.Open();

                _reader = _command.ExecuteReader();

                _command.Parameters.Clear();

                var list = new List<Order>();

                while (_reader.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(_reader["Id"]);
                    order.Customer = Convert.ToString(_reader["Customer"]);
                    order.ReturnDate = Convert.ToDateTime(_reader["ReturnDate"]);
                    order.Book.Id = Convert.ToInt32(_reader["BookId"]);
                    order.Book.Title = Convert.ToString(_reader["Title"]);
                    order.Book.Theme = Convert.ToString(_reader["Theme"]);
                    order.Book.Autor = Convert.ToString(_reader["Autor"]);
                    order.Book.Volume = Convert.ToInt32(_reader["Volume"]);
                    order.Book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
                    order.Book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

                    list.Add(order);
                }

                return list;
            }
        }

        public Order GetById(int orderId)
        {
            string sql = @"SELECT o.[Id]
                                 ,o.[Customer]
                                 ,o.[ReturnDate]
                                 ,o.[BookId]
	                             ,b.[Title]
	                             ,b.[Theme]
	                             ,b.[Autor]
	                             ,b.[IsAvailable]
	                             ,b.[Volume]
	                             ,b.[DatePublication]
                           FROM [dbo].[Order] AS o
                           INNER JOIN Book AS b
                           ON b.Id = o.BookId
                           WHERE o.[Id] = @Id";

            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;
                _command.Parameters.AddWithValue("@Id", orderId);

                _connection.Open();

                _reader = _command.ExecuteReader();

                _command.Parameters.Clear();

                var list = new List<Order>();

                while (_reader.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(_reader["Id"]);
                    order.Customer = Convert.ToString(_reader["Customer"]);
                    order.ReturnDate = Convert.ToDateTime(_reader["ReturnDate"]);
                    order.Book.Id = Convert.ToInt32(_reader["BookId"]);
                    order.Book.Title = Convert.ToString(_reader["Title"]);
                    order.Book.Theme = Convert.ToString(_reader["Theme"]);
                    order.Book.Autor = Convert.ToString(_reader["Autor"]);
                    order.Book.Volume = Convert.ToInt32(_reader["Volume"]);
                    order.Book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
                    order.Book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

                    list.Add(order);
                }

                return list[0];
            }
        }

        public Order Update(Order order)
        {
            string sql = @"UPDATE [dbo].[Order]
                           SET [Customer] = @Customer
                              ,[ReturnDate] = @ReturnDate
                              ,[BookId] = @BookId
                            WHERE [Id] = @Id";

            using (_connection)
            {
                _command.Parameters.AddWithValue("@Id", order.Id);
                _command.Parameters.AddWithValue("@Customer", order.Customer);
                _command.Parameters.AddWithValue("@ReturnDate", order.ReturnDate);
                _command.Parameters.AddWithValue("@BookId", order.Book.Id);

                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;

                _connection.Open();

                _command.ExecuteScalar();

                _command.Parameters.Clear();
            }

            return order;
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM [dbo].[Order]
                                  WHERE [Id] = @Id";

            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _command.Connection = _connection;
                _command.CommandText = sql;
                _command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var items = _command.ExecuteNonQuery();
                _command.Parameters.Clear();

                return items;
            }
        }
    }
}