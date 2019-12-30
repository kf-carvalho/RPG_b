using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }
        //Atributos descritivos da ficha
        public string Nome { get; set; }
        public string Antepassado { get; set; }
        public string Tendencia { get; set; }
        public string Personalidade { get; set; }
        public string Ideal { get; set; }
        public string Vinculo { get; set; }
        public string Fraqueza { get; set; }
        public string Caracteristica { get; set; }
        //Habilidades Naturais
        public int Força { get; set; }
        public int Inteligencia { get; set; }
        public int Sabedoria { get; set; }
        public int Destreza { get; set; }
        public int Constituição { get; set; }
        public int Carisma { get; set; }
        //FK
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual Territorio Territorio { get; set; }
        public int TerritorioId { get; set; }
        public virtual Raça Raça { get; set; }
        public int RaçaId { get; set; }
        public Classe Classe { get; set; }
        public int ClasseId { get; set; }
        //
        public virtual List<Runa> Runas { get; set; }
        public virtual List<Pericia> Pericias { get; set; }
        public virtual List<Item> Itens { get; set; }

        public Ficha()
        {
            this.Pericias = new List<Pericia>();
            this.Itens = new List<Item>();
        }
    }
    
}