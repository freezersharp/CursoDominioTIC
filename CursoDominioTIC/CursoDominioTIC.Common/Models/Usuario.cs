using System;
using System.Collections.Generic;

namespace CursoDominioTIC.Common.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Favorito = new HashSet<Favorito>();
            Opinion = new HashSet<Opinion>();
        }

        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string IdPerfil { get; set; }
        public string Estado { get; set; }
        public decimal? Calificacion { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Favorito> Favorito { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
    }
}
