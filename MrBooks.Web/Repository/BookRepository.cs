using MrBooks.Web.Data;
using MrBooks.Web.Interface;
using MrBooks.Web.Models;
using System.Data;
using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace MrBooks.Web.Repository
{
    /// <summary>
    /// Implementación de la interfaz IBookRepository que proporciona métodos para acceder a la base de datos de libros.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// Elimina un libro de la base de datos.
        /// </summary>
        /// <param name="id">Identificador del libro a eliminar.</param>
        /// <returns>True si se eliminó correctamente, de lo contrario, False.</returns>
        public bool Delete(int id)
        {
            bool result = false;

            var connectionFactory = new ConnectionFactory();

            using (var connection = new SqlConnection(connectionFactory.GetConnectionString()))
            {

                connection.Open();

                var command = new SqlCommand("SPDeleteBook", connection);
                command.Parameters.AddWithValue("BookId", id);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Obtiene una lista de todos los libros de la base de datos.
        /// </summary>
        /// <returns>Lista de libros.</returns>
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            var connectionFactory = new ConnectionFactory();

            try
            {
                using (var connection = new SqlConnection(connectionFactory.GetConnectionString()))
                {

                    connection.Open();

                    var command = new SqlCommand("SPGetBooks", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book()
                            {
                                BookId = Convert.ToInt32(reader["BookId"].ToString()),
                                Name = reader["Name"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["CreationDate"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                books = new List<Book>();
                string error = ex.Message;
            }

            return books;
        }

        /// <summary>
        /// Obtiene un libro de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">Identificador del libro.</param>
        /// <returns>El libro correspondiente al identificador proporcionado.</returns>
        public Book GetById(int id)
        {
            Book book = new Book();

            var connectionFactory = new ConnectionFactory();

            try
            {
                using (var connection = new SqlConnection(connectionFactory.GetConnectionString()))
                {

                    connection.Open();

                    connection.Open();

                    var command = new SqlCommand("SPGetBookById", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book.BookId = Convert.ToInt32(reader["BookId"].ToString());
                            book.Name = reader["Name"].ToString();
                            book.CreationDate = Convert.ToDateTime(reader["CreationDate"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                book = new Book();
                string error = ex.Message;
            }

            return book;
        }

        /// <summary>
        /// Guarda un nuevo libro en la base de datos.
        /// </summary>
        /// <param name="book">Libro a guardar.</param>
        /// <returns>True si se guardó correctamente, de lo contrario, False.</returns>
        public bool Save(Book book)
        {
            bool result = false;

            var connectionFactory = new ConnectionFactory();

            try
            {
                using (var connection = new SqlConnection(connectionFactory.GetConnectionString()))
                {

                    connection.Open();

                    var command = new SqlCommand("SPSaveBook", connection);
                    command.Parameters.AddWithValue("Name", book.Name);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                string error = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Actualiza un libro en la base de datos.
        /// </summary>
        /// <param name="book">Libro a actualizar.</param>
        /// <returns>True si se actualizó correctamente, de lo contrario, False.</returns>
        public bool Update(Book book)
        {
            bool result = false;

            var connectionFactory = new ConnectionFactory();

            using (var connection = new SqlConnection(connectionFactory.GetConnectionString()))
            {

                connection.Open();

                var command = new SqlCommand("SPUpdateBook", connection);
                command.Parameters.AddWithValue("Name", book.Name);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
    }
}
