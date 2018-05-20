using Estudos.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data
{
    public class EstudosContext: DbContext
    {

        public DbSet<Cliente> Cliente { get; set; }

        public EstudosContext(DbContextOptions<EstudosContext> options)
            :base(options)
        {

        }
    }
}
