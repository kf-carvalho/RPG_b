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
        public string Antepassado { get; set; }
        public string Tendencia { get; set; }
        //FK
        public virtual Territorio Territorio { get; set; }
        public int TerritorioId { get; set; }
        public virtual Raça Raça { get; set; }
        public int RaçaId { get; set; }
        public Classe Classe { get; set; }
        public int ClasseId { get; set; }
        //
        public virtual List<Pericia> Pericias { get; set; }
        public virtual List<Item> Itens { get; set; }

        public Ficha()
        {
        }
    }
    
}