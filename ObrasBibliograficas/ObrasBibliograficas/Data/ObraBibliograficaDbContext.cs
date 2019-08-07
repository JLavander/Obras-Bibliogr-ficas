using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObrasBibliograficas.Model;

namespace ObrasBibliograficas.Data
{
    public class ObraBibliograficaDbContext : DbContext
    {
        public ObraBibliograficaDbContext(DbContextOptions<ObraBibliograficaDbContext> options) : base(options) { }

        public virtual DbSet<Autor> Autor { get; set; }
    }
}
