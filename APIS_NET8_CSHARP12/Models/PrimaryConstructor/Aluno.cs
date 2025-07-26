namespace APIS_NET8_CSHARP12.Models.PrimaryConstructor
{
    public class Aluno(string nome, string email)
    {
        public Aluno(string nome) : this(nome, string.Empty)
        {
        }

        public string Nome => nome;
        public string Email => email;
    }
}
