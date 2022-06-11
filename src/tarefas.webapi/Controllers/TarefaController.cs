using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tarefas.webapi.Domain.ApiModel;
using tarefas.webapi.Domain.Services;

namespace tarefas.webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private readonly TarefaService service;
		public TarefaController(TarefaService service)
		{
			this.service = service;
		}

		[HttpGet]
		public IActionResult GetTarefas()
		{
			var resultado = service.Listar();
			if (resultado.Sucesso)
			{
				return Ok(resultado.ObjetoRetorno);
			}
			else
			{
				return StatusCode(StatusCodes.Status500InternalServerError, resultado);
			}
		}


		[HttpPost]
		public IActionResult Post(TarefaCreateModel model)
		{
			var resultado = service.CriarNovaTarefa(model);

			if (resultado.Sucesso)
			{
				return Ok();
			}
			else
			{
				return BadRequest(resultado);
			}
		}

		[HttpPut("{idTarefa}")]
		public IActionResult Put(int idTarefa, TarefaUpdateModel model)
		{
			var resultado = service.Atualizar(idTarefa, model);

			if (resultado.Sucesso)
			{
				return Ok();
			}
			else if (resultado.StatusRetorno == StatusResultadoOperacao.NaoEncontrado)
			{
				return NotFound(resultado);
			}
			else
			{
				return BadRequest(resultado);
			}
		}

		[HttpDelete("{idTarefa}")]
		public IActionResult Delete(int idTarefa)
		{
			var resultado = service.Deletar(idTarefa);

			if (resultado.Sucesso)
			{
				return Ok();
			}
			else if (resultado.StatusRetorno == StatusResultadoOperacao.NaoEncontrado)
			{
				return NotFound(resultado);
			}
			else
			{
				return BadRequest(resultado);
			}
		}

	}
}
