namespace APIS_NET8_CSHARP12.Models.InjecaoDependencia
{
    public class InjecaoDependencia : IInjecaoDependencia
    {
        public Guid IdInstancia { get; } = Guid.NewGuid();
    }
}
