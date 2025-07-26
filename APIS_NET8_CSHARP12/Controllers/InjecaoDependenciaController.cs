using APIS_NET8_CSHARP12.Models.InjecaoDependencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIS_NET8_CSHARP12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjecaoDependenciaController(
        [FromKeyedServices("SingletonUm")] IInjecaoDependencia injecaoSingletonUmCtor,
        [FromKeyedServices("SingletonDois")] IInjecaoDependencia injecaoSingletonDoisCtor,
        [FromKeyedServices("ScopedUm")] IInjecaoDependencia injecaoScopedUmCtor,
        [FromKeyedServices("ScopedDois")] IInjecaoDependencia injecaoScopedDoisCtor,
        [FromKeyedServices("TransientUm")] IInjecaoDependencia injecaoTransientUmCtor,
        [FromKeyedServices("TransientDois")] IInjecaoDependencia injecaoTransientDoisCtor) : ControllerBase
    {
        /// <summary>
        /// Retorna um objeto que permite comparar a partir dos Ids, a injeção de dependencia de dois keyed services, onde cada um deles contém duas instâncias, uma recebida pelo construtor da controller e a outra por parâmetro do método.
        /// </summary>
        /// <returns></returns>
        /// <param name="comparacao"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/json/singleton
        ///     
        /// </remarks>
        /// <response code="200">O objeto com duas diferentes injeções singleton realizadas para cada chave, uma recebida no construtor e outra por parâmetro.</response>
        [HttpGet("singleton")]
        public IActionResult GetSingleton(
            [FromKeyedServices("SingletonUm")] IInjecaoDependencia injecaoSingletonUm,
            [FromKeyedServices("SingletonDois")] IInjecaoDependencia injecaoSingletonDois)
        {
            var comparacao = new List<ComparacaoInstancia>
            {
                new ComparacaoInstancia(
                    key: "SingletonUm",
                    idInstanciaConstrutor: injecaoSingletonUmCtor.IdInstancia,
                    idInstanciaParametro: injecaoSingletonUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "SingletonDois",
                    idInstanciaConstrutor: injecaoSingletonDoisCtor.IdInstancia,
                    idInstanciaParametro: injecaoSingletonDois.IdInstancia)
            };

            return Ok(comparacao);
        }

        /// <summary>
        /// Retorna um objeto que permite comparar a partir dos Ids, a injeção de dependencia de dois keyed services, onde cada um deles contém duas instâncias, uma recebida pelo construtor da controller e a outra por parâmetro do método.
        /// </summary>
        /// <returns></returns>
        /// <param name="comparacao"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/json/scoped
        ///     
        /// </remarks>
        /// <response code="200">O objeto com duas diferentes injeções scoped realizadas para cada chave, uma recebida no construtor e outra por parâmetro.</response>
        [HttpGet("scoped")]
        public IActionResult GetScoped(
            [FromKeyedServices("ScopedUm")] IInjecaoDependencia injecaoScopedUm,
            [FromKeyedServices("ScopedDois")] IInjecaoDependencia injecaoScopedDois)
        {
            var comparacao = new List<ComparacaoInstancia>
            {
                new ComparacaoInstancia(
                    key: "ScopedUm",
                    idInstanciaConstrutor: injecaoScopedUmCtor.IdInstancia,
                    idInstanciaParametro: injecaoScopedUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "ScopedDois",
                    idInstanciaConstrutor: injecaoScopedDoisCtor.IdInstancia,
                    idInstanciaParametro: injecaoScopedDois.IdInstancia)
            };

            return Ok(comparacao);
        }

        /// <summary>
        /// Retorna um objeto que permite comparar a partir dos Ids, a injeção de dependencia de dois keyed services, onde cada um deles contém duas instâncias, uma recebida pelo construtor da controller e a outra por parâmetro do método.
        /// </summary>
        /// <returns></returns>
        /// <param name="comparacao"></param>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/json/transient
        ///     
        /// </remarks>
        /// <response code="200">O objeto com duas diferentes injeções transient realizadas para cada chave, uma recebida no construtor e outra por parâmetro.</response>
        [HttpGet("transient")]
        public IActionResult GetTransient(
            [FromKeyedServices("TransientUm")] IInjecaoDependencia injecaoTransientUm,
            [FromKeyedServices("TransientDois")] IInjecaoDependencia injecaoTransientDois)
        {
            var comparacao = new List<ComparacaoInstancia>
            {
                new ComparacaoInstancia(
                    key: "TransientUm",
                    idInstanciaConstrutor: injecaoTransientUmCtor.IdInstancia,
                    idInstanciaParametro: injecaoTransientUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "TransientDois",
                    idInstanciaConstrutor: injecaoTransientDoisCtor.IdInstancia,
                    idInstanciaParametro: injecaoTransientDois.IdInstancia)
            };

            return Ok(comparacao);
        }
    }
}
