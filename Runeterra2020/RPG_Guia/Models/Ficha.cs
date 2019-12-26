using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }
        public string Nome_Jogador { get; set; }
        public string Nome_Personagem { get; set; }
        public string Raça { get; set; }
        public string Classe { get; set; }
        public string Antepassado { get; set; }
        public string Alinhamento { get; set; }
        public virtual Territorio Territorio { get; set; }
        public int TerritorioId { get; set; }
        
        public List<Pericia> Pericias { get; set; }
        public List<Item> Items { get; set; }
        public Ficha()
        {
            this.Pericias = new List<Pericia>();
        }
    }
    
}