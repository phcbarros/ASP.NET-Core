namespace ACME.Models
{
    public class MateriaPrima
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueAtual { get; set; }
    }
}
