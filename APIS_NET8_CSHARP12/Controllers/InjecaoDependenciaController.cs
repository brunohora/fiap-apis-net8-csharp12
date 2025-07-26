using APIS_NET8_CSHARP12.Models.InjecaoDependencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIS_NET8_CSHARP12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjecaoDependenciaController : ControllerBase
    {
        private readonly IInjecaoDependencia _injecaoSingletonUm;
        private readonly IInjecaoDependencia _injecaoSingletonDois;
        private readonly IInjecaoDependencia _injecaoScopedUm;
        private readonly IInjecaoDependencia _injecaoScopedDois;
        private readonly IInjecaoDependencia _injecaoTransientUm;
        private readonly IInjecaoDependencia _injecaoTransientDois;

        public InjecaoDependenciaController(
            [FromKeyedServices("SingletonUm")] IInjecaoDependencia injecaoSingletonUm,
            [FromKeyedServices("SingletonDois")]IInjecaoDependencia injecaoSingletonDois,
            [FromKeyedServices("ScopedUm")]IInjecaoDependencia injecaoScopedUm,
            [FromKeyedServices("ScopedDois")]IInjecaoDependencia injecaoScopedDois,
            [FromKeyedServices("TransientUm")]IInjecaoDependencia injecaoTransientUm,
            [FromKeyedServices("TransientDois")] IInjecaoDependencia injecaoTransientDois)
        {
            _injecaoSingletonUm = injecaoSingletonUm;
            _injecaoSingletonDois = injecaoSingletonDois;
            _injecaoScopedUm = injecaoScopedUm;
            _injecaoScopedDois = injecaoScopedDois;
            _injecaoTransientUm = injecaoTransientUm;
            _injecaoTransientDois = injecaoTransientDois;
        }

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
                    idInstanciaConstrutor: _injecaoSingletonUm.IdInstancia,
                    idInstanciaParametro: injecaoSingletonUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "SingletonDois",
                    idInstanciaConstrutor: _injecaoSingletonDois.IdInstancia,
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
                    idInstanciaConstrutor: _injecaoScopedUm.IdInstancia,
                    idInstanciaParametro: injecaoScopedUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "ScopedDois",
                    idInstanciaConstrutor: _injecaoScopedDois.IdInstancia,
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
                    idInstanciaConstrutor: _injecaoTransientUm.IdInstancia,
                    idInstanciaParametro: injecaoTransientUm.IdInstancia),
                new ComparacaoInstancia(
                    key: "TransientDois",
                    idInstanciaConstrutor: _injecaoTransientDois.IdInstancia,
                    idInstanciaParametro: injecaoTransientDois.IdInstancia)
            };

            return Ok(comparacao);
        }
    }
}
