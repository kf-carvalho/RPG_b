using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Runa
    {
        //Atributos descritivos da runa
        public int RunaId { get; set; }
        public string Descriçao { get; set; }
        public string Nivel { get; set; }
        public string Nome { get; set; }
        //Atributos modificados pelo nivel
        public string Alcance { get; set; }
        public string Cura { get; set; }
        public string Duracao { get; set; }
        public string Dano { get; set; }
        public string Uso { get; set; }

        public Runa()
        {
            string indef = "Não se aplica";
            this.Alcance = indef;
            this.Cura = indef;
            this.Duracao = indef;
            this.Dano = indef;
            this.Uso = indef;
        }
    }
}