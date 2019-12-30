using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class EscalaRunica
    {
        public int EscalaRunicaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Runa> Runas { get; set; }
    }
}