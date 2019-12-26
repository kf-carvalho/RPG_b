using RPG_Guia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RPG_Guia.Data
{
    public class Context : DbContext
    {
        public Context() : base ("DefaultConnection")
        {

        }
        public DbSet<Ficha> fichas { get; set; }
        public DbSet<Item> itens { get; set; }
        public DbSet<PulsoRunico> pulsos { get; set; }
        public DbSet<Pericia> pericias { get; set; }
        public DbSet<Runa> runas { get; set; }
        public DbSet<Territorio> territorios { get; set; }
    }
}