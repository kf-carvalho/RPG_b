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
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PulsoRunico> PulsoRunicos { get; set; }
        public DbSet<Pericia> Pericias { get; set; }
        public DbSet<Runa> Runas { get; set; }
        public DbSet<Territorio> Territorios { get; set; }
        public DbSet<Raça> Raças { get; set; }
    }
}