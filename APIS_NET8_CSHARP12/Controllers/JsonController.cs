using APIS_NET8_CSHARP12_Shared.Models.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIS_NET8_CSHARP12.Controllers
{
    [Route("api/json")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        /// <summary>
        /// Recebe um json e valida as propriedades não mapeadas.
        /// </summary>
        /// <returns></returns>
        /// <param name="propriedadesMapeadas"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/json/mapeamento-propriedades?json={"Nome":"John","Idade":30} 
        ///     GET /api/json/mapeamento-propriedades?json={"Nome":"John","Idade":30,"Profissao":"Desenvolvedor"}
        ///     
        /// </remarks>
        /// <response code="200">O objeto com as propriedades mapeadas.</response>
        /// <response code="500">Propriedades não mapeadas recebidas ou propriedades obrigatórias ausentes.</response>
        [HttpGet("mapeamento-propriedades")]
        public IActionResult Get([FromQuery]string json)
        {
            var propriedadesMapeadas = JsonSerializer.Deserialize<MapeamentoPropriedades>(json);

            return Ok(propriedadesMapeadas);
        }

        /// <summary>
        /// Recebe uma policy e a aplica na serialização de um objeto exemplo.
        /// </summary>
        /// <returns></returns>
        /// <param name="jsonSerializadoComPolicy"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/json/policies?policy=1 
        ///     
        /// </remarks>
        /// <response code="200">O objeto serializado com a policy aplicada.</response>
        /// <response code="500">Policy desconhecida recebida.</response>
        [HttpGet("policies")]
        public IActionResult Get([FromQuery]EPolicy policy)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = policy switch
                {
                    EPolicy.Pascal => null,
                    EPolicy.Camel => JsonNamingPolicy.CamelCase,
                    EPolicy.SnakeLower => JsonNamingPolicy.SnakeCaseLower,
                    EPolicy.SnakeUpper => JsonNamingPolicy.SnakeCaseUpper,
                    EPolicy.KebabLower => JsonNamingPolicy.KebabCaseLower,
                    EPolicy.KebabUpper => JsonNamingPolicy.KebabCaseUpper,
                    _ => throw new ArgumentOutOfRangeException(nameof(policy), policy, null)
                },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var manipulacaoPolicies = new ManipulacaoPolicies { NomeCompleto = "John Richards", EnderecoCompleto = "Avenida Dr Gastao Vidigal" };
            var jsonSerializadoComPolicy = JsonSerializer.Serialize(manipulacaoPolicies, options);

            return Ok(jsonSerializadoComPolicy);
        }
    }
}
