using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        public string Nome { get; set; }
        public virtual List<Ficha> Fichas { get; set; }

    }
}