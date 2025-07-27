
# APIs com .NET 8 e C# 12   

Novidades

### Compilador AOT (ahead-of-time)
Em alternativa ao JIT (just-in-time), permite pré compilar apps para que não sejam executados no servidor em tempo de execução, permitindo execução em ambientes sem .NET instalado. Inicialização mais rápida, menor consumo de memória, porém maior consumo de disco. Benefícios para cargas de trabalho com muitas instâncias.  

### Data Annotations
Novas funcionalidades como: AllowedValues, DeniedValues, Base64String, Range com mínimo e máximo exclusivo e Length com mínimo/máximo. Exemplo:
```csharp
public class Arquivo
{
    [Base64String(ErrorMessage = "O campo {0} deve conter uma string Base64 válida.")]
    [DeniedValues("", ErrorMessage = "O campo {0} deve conter uma string Base64 válida.")]
    public required string Base64 { get; set; }
}
```
```csharp
public class Pessoa
{
    [Range(18, 100, 
    ErrorMessage = "Intervalo deve estar entre 1 e 99.", 
    MinimumIsExclusive = false, 
    MaximumIsExclusive = true)]
    public required int Idade { get; set; }

    [Length(1, 10, ErrorMessage = "Comprimento deve estar entre 1 e 10 caracteres.")]
    public required string Nome { get; set; }

    /// <summary>
    /// Tipo da CNH. Valores válidos: "A", "B", "".
    /// </summary>
    [AllowedValues("A", "B", "", ErrorMessage = "Valor inválido.")]
    public required string TipoCNH { get; set; } = string.Empty;
}
```

### JSON
Disparar uma exceção na desserialização quando: propriedades obrigatórias não forem recebidas, ou proriedades além das esperadas forem recebidas. Uma outra funcionalidade é a possibilidade de definir uma policy no momento da serialização (camelCase,  PascalCase, snake_case ou  kebab-case), sem precisar atribuir manualmente em cada propriedade da classe serializada. Exemplo:
```csharp
[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
public class MapeamentoPropriedades
{
    public required string Nome { get; set; } = string.Empty;
}
```
```csharp
[HttpGet("kebab-lower")]
public IActionResult GetKebabLower()
{
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
    };

    var manipulacaoPolicies = new ManipulacaoPolicies { NomeCompleto = "John Richards" };
    var jsonSerializadoComPolicy = JsonSerializer.Serialize(manipulacaoPolicies, options);

    return Ok(jsonSerializadoComPolicy);
}
```

### Dependency Injection
Suporte para keyed services, que permite registrar serviços com uma chave específica e resolvê-los posteriormente usando essa chave. Útil para cenários onde é necessário utilizar múltiplas implementações do mesmo serviço. Exemplo:
```csharp
void ConfigureKeyedDI(IServiceCollection services)
{
    services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonUm");
    services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonDois");
}
```

### Primary Constructors
Construtores primários permitem definir propriedades diretamente na declaração da classe, simplificando a sintaxe. Versátil por permitir uma variedade de aplicações, como por exemplo se combinado com record, structs, data annotations e construtores de controllers com injeção de dependência. Exemplo:
```csharp
public class InjecaoDependenciaController(
        [FromKeyedServices("Singleton")] IInjecaoDependencia injecaoSingleton
) : ControllerBase { ... }
```

## Referência

 - [Native AOT - Microsoft](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=windows%2Cnet8)
 - [What's new in .NET 8](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8/overview)