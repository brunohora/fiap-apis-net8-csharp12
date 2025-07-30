using System.Text.Json.Serialization;

namespace APIS_NET8_CSHARP12_Shared.Models.Json
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class MapeamentoPropriedades
    {
        public required string Nome { get; set; } = string.Empty;
        public required int Idade { get; set; } = 0;
    }
}
