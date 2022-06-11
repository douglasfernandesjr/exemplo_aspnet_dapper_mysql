using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tarefas.webapi.Domain.Services
{
	public enum StatusResultadoOperacao
	{
		Sucesso,
		NaoEncontrado,
		DadosInvalidos,
		ErroInterno
	}
	public class ResultadoOperacao<T>
	{
		public ResultadoOperacao(T objetoRetorno)
		{
			ObjetoRetorno = objetoRetorno;
			StatusRetorno = StatusResultadoOperacao.Sucesso;
			Erros = new List<string>();
		}

		public ResultadoOperacao<T> AdicionarMensagemErro(string erro)
		{
			Erros.Add(erro);
			return this;
		}
		public ResultadoOperacao<T> AtualizarStatus(StatusResultadoOperacao status)
		{
			StatusRetorno = status;
			return this;
		}
		public ResultadoOperacao<T> AdicionarMensagemErro(string erro, StatusResultadoOperacao status)
		{
			AdicionarMensagemErro(erro);
			AtualizarStatus(status);
			return this;
		}

		[JsonIgnore]
		public StatusResultadoOperacao StatusRetorno { get; private set; }

		[JsonIgnore]
		public T ObjetoRetorno { get; private set; }

		public bool Sucesso => StatusRetorno == StatusResultadoOperacao.Sucesso;

		public List<String> Erros { get; private set; }

	}
}
