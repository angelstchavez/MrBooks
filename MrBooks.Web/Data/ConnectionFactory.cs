namespace MrBooks.Web.Data
{
    /// <summary>
    /// Clase que representa una fábrica de conexiones.
    /// </summary>
    public class ConnectionFactory
    {
        private string ConnectionString = string.Empty;

        /// <summary>
        /// Constructor de la clase ConnectionFactory.
        /// </summary>
        public ConnectionFactory()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            ConnectionString = builder.GetSection("ConnectionString:ConnectionStringSQL").Value;
        }

        /// <summary>
        /// Obtiene la cadena de conexión.
        /// </summary>
        /// <returns>
        /// La cadena de conexión para acceder a la base de datos.
        /// </returns>
        public string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
