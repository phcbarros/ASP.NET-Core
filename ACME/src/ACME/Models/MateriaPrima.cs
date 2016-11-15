using System.ComponentModel.DataAnnotations;

namespace ACME.Models
{
    public class MateriaPrima
    {
        public int Id { get; set; }
        [StringLength(150, MinimumLength =3)]
        [Required]
        public string Nome { get; set; }
        [Required]
        public int EstoqueMinimo { get; set; }
        [Required]
        public int EstoqueAtual { get; set; }
    }
}
