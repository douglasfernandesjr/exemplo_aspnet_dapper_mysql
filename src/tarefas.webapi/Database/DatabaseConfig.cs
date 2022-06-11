using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Database
{
	public class DatabaseConfig
	{
		public DatabaseConfig( string connectionString)
		{
			ConnectionString = connectionString;
		}
		public string ConnectionString { get; private set; }
	}
}
