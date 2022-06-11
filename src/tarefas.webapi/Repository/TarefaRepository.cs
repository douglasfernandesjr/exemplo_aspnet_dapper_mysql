using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.webapi.Database;
using tarefas.webapi.Domain.Entities;

namespace tarefas.webapi.Repository
{
	public class TarefaRepository
	{
		private readonly DatabaseConfig databaseConfig;

		public TarefaRepository(DatabaseConfig databaseConfig)
		{
			this.databaseConfig = databaseConfig;
		}

		private const string criar_sql = "INSERT INTO Tarefa (Descricao, Concluido)" +
				"VALUES (@Descricao, @Concluido);";
		private const string selecionarPorId_sql = "SELECT IdTarefa, Descricao, Concluido FROM Tarefa where IdTarefa = @IdTarefa;";

		private const string selecionarTodos_sql = "SELECT IdTarefa, Descricao, Concluido FROM Tarefa;";

		private const string atualizar_sql = @"UPDATE Tarefa
											SET Descricao = @Descricao,
												Concluido = @Concluido
											WHERE
												IdTarefa = @IdTarefa;";

		private const string deletar_sql = @"DELETE FROM Tarefa
											WHERE IdTarefa = @IdTarefa;";


		public void Criar(string descricao, bool concluido)
		{
			using var connection = new SqliteConnection(databaseConfig.ConnectionString);

			var parametros = new DynamicParameters();
			parametros.Add("@Descricao", descricao);
			parametros.Add("@Concluido", concluido);
			connection.Execute(criar_sql, parametros);

		}

		public void Atualizar(Tarefa tarefa)
		{
			using var connection = new SqliteConnection(databaseConfig.ConnectionString);
			connection.Execute(atualizar_sql, tarefa);
		}

		public IEnumerable<Tarefa> SelecionarTodos()
		{
			using var connection = new SqliteConnection(databaseConfig.ConnectionString);
			return  connection.Query<Tarefa>(selecionarTodos_sql);
		}

		public Tarefa SelecionarPorId(int idTarefa)
		{
			using var connection = new SqliteConnection(databaseConfig.ConnectionString);
			var parametros = new DynamicParameters();
			parametros.Add("@IdTarefa", idTarefa);
			return connection.QueryFirstOrDefault<Tarefa>(selecionarPorId_sql, parametros);
		}

		public void Deletar(int idTarefa)
		{
			using var connection = new SqliteConnection(databaseConfig.ConnectionString);
			var parametros = new DynamicParameters();
			parametros.Add("@IdTarefa", idTarefa);
			connection.Execute(deletar_sql, parametros);
		}

	}
}
