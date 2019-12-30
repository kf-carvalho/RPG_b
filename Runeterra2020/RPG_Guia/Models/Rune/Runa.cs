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
        //Atributo para dizer o tipo da runa { ex: fagulha runica } 
        public virtual EscalaRunica Escala { get; set; }
        public int EscalaRunicaId { get; set; }
        //Atributos modificados pelo nivel
        public string Alcance { get; set; }
        public string Cura { get; set; }
        public string Duracao { get; set; }
        public string Dano { get; set; }
        public string Uso { get; set; }
        //fk
        public virtual List<Ficha> Fichas { get; set; }
        public Runa()
        {
            string indef = "Não se aplica";
            this.Nivel = indef;
            this.Alcance = indef;
            this.Cura = indef;
            this.Duracao = indef;
            this.Dano = indef;
            this.Uso = indef;
        }
    }
}