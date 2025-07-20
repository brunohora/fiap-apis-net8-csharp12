using System.ComponentModel.DataAnnotations;

namespace APIS_NET8_CSHARP12.Models.DataAnnotations
{
    public class Pessoa
    {
        [Range(18, 100, ErrorMessage = "Intervalo deve estar entre 1 e 99.", MinimumIsExclusive = false, MaximumIsExclusive = true)]
        public required int Idade { get; set; }

        [Length(1, 10, ErrorMessage = "Comprimento deve estar entre 1 e 10 caracteres.")]
        public required string Nome { get; set; }

        /// <summary>
        /// Tipo da CNH. Valores válidos: "A", "B", "".
        /// </summary>
        [AllowedValues("A", "B", "", ErrorMessage = "Valor inválido.")]
        public required string TipoCNH { get; set; } = string.Empty;
    }
}
