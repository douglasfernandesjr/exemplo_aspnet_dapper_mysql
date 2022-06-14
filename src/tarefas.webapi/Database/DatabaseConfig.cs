using MySqlConnector;
using System.Data.Common;

namespace tarefas.webapi.Database
{
	public class DatabaseConfig
	{
		public DatabaseConfig( string connectionString)
		{
			ConnectionString = connectionString;
		}
		public string ConnectionString { get; private set; }

		public DbConnection GetConnection() {
			return new MySqlConnection(ConnectionString);
		}
		
	}
}
