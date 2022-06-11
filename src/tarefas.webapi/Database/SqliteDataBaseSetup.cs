using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Database
{
	public class SqliteDatabaseSetup : IDatabaseSetup
	{
		private readonly DatabaseConfig databaseConfig;

		public SqliteDatabaseSetup(DatabaseConfig databaseConfig)
		{
			this.databaseConfig = databaseConfig;
		}
		public void RunSetup() {

			using var connection = new SqliteConnection(databaseConfig.ConnectionString);
			//Criar tabela Tarefa
			connection.Execute(SqliteDbConstants.TabelaTarefa_Criar);
		}
	}
}
