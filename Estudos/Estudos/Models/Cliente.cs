namespace Estudos.Models
{
    public class Cliente
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public void Atualizar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}
