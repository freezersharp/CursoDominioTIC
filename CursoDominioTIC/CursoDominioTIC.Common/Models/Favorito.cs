using System;
using System.Collections.Generic;

namespace CursoDominioTIC.Common.Models
{
    public partial class Favorito
    {
        public long IdFavorito { get; set; }
        public string IdUsuario { get; set; }
        public int IdEstablecimiento { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Establecimiento IdEstablecimientoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
