using System;
using System.Collections.Generic;

namespace CursoDominioTIC.Common.Models
{
    public partial class Establecimiento
    {
        public Establecimiento()
        {
            Favorito = new HashSet<Favorito>();
            Opinion = new HashSet<Opinion>();
            Producto = new HashSet<Producto>();
        }

        public int IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Calificacion { get; set; }

        public virtual ICollection<Favorito> Favorito { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
