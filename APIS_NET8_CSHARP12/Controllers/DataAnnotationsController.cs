using APIS_NET8_CSHARP12.Models.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace APIS_NET8_CSHARP12.Controllers
{
    [Route("api/data-annotations")]
    [ApiController]
    public class DataAnnotationsController : ControllerBase
    {
        /// <summary>
        /// Recebe e valida um arquivo em Base64.
        /// </summary>
        /// <returns></returns>
        /// <param name="arquivo"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/data-annotations/arquivo
        ///     {
        ///        "Base64":"SGVsbG8sIFdvcmxkIQ=="
        ///     }
        ///
        /// </remarks>
        /// <response code="200">O arquivo em Base64 recebido e validado</response>
        /// <response code="400">Erro ao validar o Base64</response>
        [HttpPost("arquivo")]
        public IActionResult PostArquivoBase64([FromBody]Arquivo arquivo)
        {
            return Ok(arquivo);
        }

        /// <summary>
        /// Recebe e valida os atributos com Range, Length e AllowedValues.
        /// </summary>
        /// <returns></returns>
        /// <param name="pessoa"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/data-annotations/pessoa
        ///     {
        ///        "Idade": 18,
        ///        "Nome": "John",
        ///        "TipoCNH": "A"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">O objeto recebido e validado</response>
        /// <response code="400">Erro ao validar atributos</response>
        [HttpPost("pessoa")]
        public IActionResult PostPessoa([FromBody] Pessoa pessoa)
        {
            return Ok(pessoa);
        }
    }
}
