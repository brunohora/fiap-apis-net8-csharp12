using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIS_NET8_CSHARP12.Controllers
{
    [Route("api/middlewares")]
    [ApiController]
    public class MiddlewaresController : ControllerBase
    {
        /// <summary>
        /// Retorna uma Exception para demonstrar a utilização do Middleware UseExceptionHandler
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/middlewares/exception-handler/1
        ///     
        /// </remarks>
        /// <response code="500">Detalhes da Exception gerada e capturada pelo ExceptionHandler</response>

        [HttpGet("exception-handler/{id}")]
        public IActionResult GetExceptionHandler([FromRoute]int id) 
        {
            throw new Exception("Exceção simulada.");
        }
    }
}
