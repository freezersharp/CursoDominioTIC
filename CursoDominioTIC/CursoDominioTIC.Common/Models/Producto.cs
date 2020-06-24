using System;
using System.Collections.Generic;

namespace CursoDominioTIC.Common.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Opinion = new HashSet<Opinion>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public int IdEstablecimiento { get; set; }
        public decimal Calificacion { get; set; }
        public string Foto { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Establecimiento IdEstablecimientoNavigation { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
    }
}
