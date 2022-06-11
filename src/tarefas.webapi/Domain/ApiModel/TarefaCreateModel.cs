using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Domain.ApiModel
{
	public class TarefaCreateModel
	{
		[Required(ErrorMessage = "O Campo Descricao é obrigatório!")]
		public String Descricao { get; set; }
	}
}
