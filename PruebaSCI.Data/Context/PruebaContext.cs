using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Data.Entities;


namespace PruebaSCI.Data.Context
{
    public class PruebaContext : DbContext
    {

        public PruebaContext()
            : base("pruebaCS")
        {

        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }

    }
}
