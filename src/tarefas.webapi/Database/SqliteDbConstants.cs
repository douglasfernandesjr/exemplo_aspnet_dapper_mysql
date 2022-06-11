using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Database
{
	public static class SqliteDbConstants
	{
		public const string TabelaTarefa = "Tarefa";

	
		public const string TabelaTarefa_Criar = @"CREATE TABLE IF NOT EXISTS Tarefa (
													IdTarefa INTEGER PRIMARY KEY,
   													Descricao VARCHAR(250) NOT NULL,
													Concluido INTEGER DEFAULT 0
												)";

	}
}
