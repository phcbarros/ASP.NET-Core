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
        [Display(Name = "Estoque mínimo")]
        public int EstoqueMinimo { get; set; }
        [Required]
        [Display(Name = "Estoque atual")]
        public int EstoqueAtual { get; set; }
    }
}
