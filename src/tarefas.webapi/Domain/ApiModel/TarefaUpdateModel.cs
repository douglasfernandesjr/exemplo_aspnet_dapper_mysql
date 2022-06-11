using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.webapi.Domain.ApiModel
{
	public class TarefaUpdateModel : TarefaCreateModel
	{
		[Required(ErrorMessage = "O Campo Concluido é obrigatório!")]
		public Boolean Concluido { get; set; }
	}
}
