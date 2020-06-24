using System;
using System.Collections.Generic;

namespace CursoDominioTIC.Common.Models
{
    public partial class Opinion
    {
        public long IdOpinion { get; set; }
        public string IdUsuario { get; set; }
        public int? IdEstablecimiento { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Calificacion { get; set; }
        public string Tipo { get; set; }

        public virtual Establecimiento IdEstablecimientoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
