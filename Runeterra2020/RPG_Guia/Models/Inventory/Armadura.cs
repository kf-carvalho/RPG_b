using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Armadura
    {
        public int ArmaduraId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string ClasseArmadura { get; set; }
        public string Força { get; set; }
        public string Furtividade { get; set; }
        public string Peso { get; set; }
        public string Preço { get; set; }
        public virtual List<Ficha> Fichas { get; set; }
    }
}