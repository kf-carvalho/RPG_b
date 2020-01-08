using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_Guia.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Ficha> Fichas { get; set; }

    }
}