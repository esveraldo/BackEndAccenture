using Log.Accenture.Application.Interfaces;
using Log.Accenture.Application.ViewModels.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Log.Accenture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogSystemsController : ControllerBase
    {
        private readonly ILogSystemAppService _logAppService;

        public LogSystemsController(ILogSystemAppService logAppService)
        {
            _logAppService = logAppService;
        }

        [HttpGet("resultado")]
        public async Task<ActionResult<IEnumerable<LogSystemViewModel>>> ObterTodos()
        {
            try
            {
                var result = await _logAppService.LerTodosLogs();

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("resultado-por-filtro/{query}")]
        public async Task<ActionResult<IEnumerable<LogSystemViewModel>>> ObterTodosFiltro(string query)
        {
            try
            {
                if(query == null)
                    return BadRequest(new { Message = "Por favor, passe um parametro para pesquisa."});

                var result = await _logAppService.LerTodosLogsFiltro(query);

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("atualizar-log")]
        public async Task<ActionResult> AtualizarLogs()
        {
            try
            {
                _logAppService.GravarLogs();

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
