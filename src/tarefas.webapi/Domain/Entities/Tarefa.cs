using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Domain.Entities
{
	public class Tarefa
	{
		public int IdTarefa { get; set; }
		public String Descricao { get; set; }
		public bool Concluido { get; set; }
	}
}
