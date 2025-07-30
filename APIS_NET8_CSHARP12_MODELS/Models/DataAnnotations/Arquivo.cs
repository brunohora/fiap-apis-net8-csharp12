using System.ComponentModel.DataAnnotations;

namespace APIS_NET8_CSHARP12_Shared.Models.DataAnnotations
{
    public class Arquivo
    {
        [Base64String(ErrorMessage = "O campo {0} deve conter uma string Base64 válida.")]
        [DeniedValues("", ErrorMessage = "O campo {0} deve conter uma string Base64 válida.")]
        public required string Base64 { get; set; }
    }
}
