using ACME.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Repositories
{
    public static class SeedACME
    {
        public static void Inicializa(AcmeContext context)
        {
            context.Database.EnsureCreated();

            if (context.MateriasPrimas.Any())
                return;

            var materiasPrima = new List<MateriaPrima>()
            {
                new MateriaPrima { Nome = "TNT", EstoqueAtual = 100, EstoqueMinimo = 10 },
                new MateriaPrima { Nome = "Barras de Aço", EstoqueAtual = 100, EstoqueMinimo = 5 },
                new MateriaPrima { Nome = "Chapas de Aço", EstoqueAtual = 99, EstoqueMinimo = 10 },
                new MateriaPrima { Nome = "Rodas de Patins", EstoqueAtual = 100, EstoqueMinimo = 8 },
                new MateriaPrima { Nome = "Foguetes", EstoqueAtual = 100, EstoqueMinimo = 10 },
                new MateriaPrima { Nome = "Tinta Preta", EstoqueAtual = 100, EstoqueMinimo = 10 }
            };

            context.MateriasPrimas.AddRange(materiasPrima);
            context.SaveChanges();
        }
    }
}