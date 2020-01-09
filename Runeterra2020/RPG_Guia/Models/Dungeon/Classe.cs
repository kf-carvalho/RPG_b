using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Classe
    {
        public int ClasseId { get; set; }
        public string Descriçao { get; set; }
        public string DadoVida { get; set; }
        public string Resistência { get; set; }
        public string Habilidades { get; set; }
        public string Proeficiencias { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Ficha> Fichas { get; set; }

    }
}