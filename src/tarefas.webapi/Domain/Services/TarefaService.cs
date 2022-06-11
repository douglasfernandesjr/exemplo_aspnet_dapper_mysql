using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.webapi.Domain.ApiModel;
using tarefas.webapi.Domain.Entities;
using tarefas.webapi.Repository;

namespace tarefas.webapi.Domain.Services
{
	public class TarefaService
	{
		private readonly TarefaRepository repositorio;
		public TarefaService(TarefaRepository repositorio)
		{
			this.repositorio = repositorio;
		}
		public ResultadoOperacao<bool> CriarNovaTarefa(TarefaCreateModel model)
		{
			if (model == null || model.Descricao == null || string.IsNullOrWhiteSpace(model.Descricao))
			{
				return new ResultadoOperacao<bool>(false).AdicionarMensagemErro("Descricao não pode ser nulo ou vazio");
			}
			else
			{
				repositorio.Criar(model.Descricao, false);
				return new ResultadoOperacao<bool>(true);
			}
		}

		public ResultadoOperacao<bool> Atualizar(int idTarefa, TarefaUpdateModel model)
		{
			if (model == null || model.Descricao == null || string.IsNullOrWhiteSpace(model.Descricao))
			{
				return new ResultadoOperacao<bool>(false).AdicionarMensagemErro("Descricao não pode ser nulo ou vazio");
			}

			var encontrado = repositorio.SelecionarPorId(idTarefa);

			if (encontrado == null)
			{
				return new ResultadoOperacao<bool>(false).AdicionarMensagemErro($"Id {idTarefa} não encontrado",StatusResultadoOperacao.NaoEncontrado);
			}

			Tarefa TarefaParaAtualizar = new Tarefa()
			{
				IdTarefa = idTarefa,
				Descricao = model.Descricao,
				Concluido = model.Concluido
			};

			repositorio.Atualizar(TarefaParaAtualizar);
			return new ResultadoOperacao<bool>(true);
		}


		public ResultadoOperacao<bool> Deletar(int idTarefa)
		{
			var encontrado = repositorio.SelecionarPorId(idTarefa);

			if (encontrado == null)
			{
				return new ResultadoOperacao<bool>(false).AdicionarMensagemErro($"Id {idTarefa} não encontrado", StatusResultadoOperacao.NaoEncontrado);
			}

			repositorio.Deletar(idTarefa);
			return new ResultadoOperacao<bool>(true);
		}

		public ResultadoOperacao<IEnumerable<Tarefa>> Listar()
		{
			try
			{
				var lista = repositorio.SelecionarTodos();
				var resposta = new ResultadoOperacao<IEnumerable<Tarefa>>(lista);

				return resposta;
			}
			catch (Exception ex) {
				// logger.save(ex) -- em um cenário real
				var resposta = new ResultadoOperacao<IEnumerable<Tarefa>>(null).AtualizarStatus(StatusResultadoOperacao.ErroInterno).AdicionarMensagemErro("Erro interno ao realizar operação!");

				return resposta;
			}
		}
	}
}
