using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Pericia
    {
        public int PericiaId { get; set; }
        public string Nome { get; set; }
        //Total de pontos que a pericia possui
        public int Modificador { get; set; }
        //Indicador do tipo da pericia ex: ( força, inteligencia, destreza...)
        public string Mastery { get; set; }
        //Indicador se o jogador possui proeficiencia na pericia para adicionar o bonus de proeficiencia
        public bool Proeficiencia { get; set; }

        public virtual List<Ficha> Fichas { get; set; }

        public Pericia(){
          
        }
    }
}