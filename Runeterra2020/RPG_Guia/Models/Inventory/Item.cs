using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Nome { get; set; }
        public string Custo { get; set; }
        public string Peso { get; set; }
        public virtual List<Ficha> Fichas { get; set; }
    }
}