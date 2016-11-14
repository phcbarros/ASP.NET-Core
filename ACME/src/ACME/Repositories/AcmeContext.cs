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
            this.Database.EnsureCreated();
        }
    }
}
