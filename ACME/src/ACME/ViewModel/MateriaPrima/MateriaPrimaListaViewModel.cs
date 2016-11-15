using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.ViewModel.MateriaPrima
{
    public class MateriaPrimaListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Estoque Atual")]
        public int EstoqueAtual { get; set; }
        public bool EstoqueEstaAbaixoDoMinimo { get; set; }
    }
}
