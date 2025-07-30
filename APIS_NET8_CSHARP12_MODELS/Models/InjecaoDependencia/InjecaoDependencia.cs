namespace APIS_NET8_CSHARP12_Shared.Models.InjecaoDependencia
{
    public class InjecaoDependencia : IInjecaoDependencia
    {
        public Guid IdInstancia { get; } = Guid.NewGuid();
    }
}
