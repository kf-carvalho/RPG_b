using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Arma
    {
        public int ArmaId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Preço { get; set; }
        public string Peso { get; set; }
        public string Dano { get; set; }
        public string Propriedades { get; set; }
        public virtual List<Ficha> Fichas { get; set; }

    }
}