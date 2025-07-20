
# APIs com .NET 8 e C# 12   

Novidades

### Compilador AOT (ahead-of-time)
Em alternativa ao JIT (just-in-time), permite pré compilar apps para que não sejam executados no servidor em tempo de execução, permitindo execução em ambientes sem .NET instalado. Inicialização mais rápida, menor consumo de memória, porém maior consumo de disco. Benefícios para cargas de trabalho com muitas instâncias.  

### Data Annotations
Novas funcionalidades como: AllowedValues, DeniedValues, Base64String, Range com mínimo e máximo exclusivo e Length com mínimo/máximo.

### JSON
Disparar uma exceção na desserialização quando: propriedades obrigatórias não forem recebidas, ou proriedades além das esperadas forem recebidas. Uma outra funcionalidade é a possibilidade de definir uma policy no momento da serialização (camelCase,  PascalCase, snake_case ou  kebab-case), sem precisar atribuir manualmente em cada propriedade da classe serializada.