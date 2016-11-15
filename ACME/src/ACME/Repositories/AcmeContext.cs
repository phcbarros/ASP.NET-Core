using ACME.Models;
using Microsoft.EntityFrameworkCore;

namespace ACME.Repositories
{
    public class AcmeContext:DbContext
    {
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }

        public AcmeContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MateriaPrima>(m =>
            {
                m.ToTable("MateriaPrima");
                m.Property(p => p.Nome).HasMaxLength(150).IsRequired();
                m.Property(p => p.EstoqueMinimo).IsRequired();
                m.Property(p => p.EstoqueAtual).IsRequired();
            });
        }
    }
}
