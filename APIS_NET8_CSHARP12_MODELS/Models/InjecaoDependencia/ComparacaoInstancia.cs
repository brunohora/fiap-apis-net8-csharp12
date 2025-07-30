namespace APIS_NET8_CSHARP12_Shared.Models.InjecaoDependencia
{
    public class ComparacaoInstancia
    {
        public ComparacaoInstancia(string key, Guid idInstanciaConstrutor, Guid idInstanciaParametro)
        {
            KeyInstancia = key;
            IdInstanciaConstrutor = idInstanciaConstrutor;
            IdInstanciaParametro = idInstanciaParametro;
        }

        public string KeyInstancia { get; private set; }
        public Guid IdInstanciaConstrutor { get; private set; }
        public Guid IdInstanciaParametro { get; private set; }
    }
}
