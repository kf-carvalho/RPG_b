using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Territorio
    {
        public int TerritorioId { get; set; }
        public string Descriçao { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}