using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Locales> Locales { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}