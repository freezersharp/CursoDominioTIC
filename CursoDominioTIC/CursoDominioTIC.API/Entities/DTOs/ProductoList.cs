using CursoDominioTIC.Common.Models;
using System.Collections.Generic;

namespace CursoDominioTIC.API.Entities.DTOs
{
    public class ProductoList
    {
        public int IdEstablecimiento { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
