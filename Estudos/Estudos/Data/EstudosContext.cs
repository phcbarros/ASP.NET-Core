using Estudos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
