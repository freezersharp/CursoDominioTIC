using CursoDominioTIC.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace CursoDominioTIC.API.Controllers
{
    [Route("api/v1/CursoDominioTIC/[controller]")]
    public class ProductosController : Controller
    {
        private CursoDominioTICContext _context = new CursoDominioTICContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new CursoDominioTICContext());

        [HttpGet("idEstablecimiento")]
        public IActionResult GetProductos(int idEstablecimiento)
        {
            try
            {
                if (idEstablecimiento != 0)
                {
                    var establecimiento = _unitOfWork.Establecimientos.Get(x => x.IdEstablecimiento == idEstablecimiento);
                    if (establecimiento != null)
                    {
                        var productos = _unitOfWork.Productos.Get(x => x.IdEstablecimiento == idEstablecimiento).ToList();
                        //var result = CreateMappedObject(productos, idEstablecimiento);
                        //var serializedList = JsonConvert.SerializeObject(productos, Formatting.Indented, new JsonSerializerSettings()
                        //{
                        //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        //});
                        return Ok(productos);

                    }
                    else
                    {
                        return BadRequest("No se encontró el establecimiento.");
                    }
                }
                else
                {
                    return BadRequest("Falta el parámetro del establecimiento.");
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        //private ProductoList CreateMappedObject(IEnumerable<Producto> productos, int idEstablecimiento)
        //{
        //    ProductoList lista = new ProductoList();
        //    foreach (var item in productos)
        //    {

        //    }
        //}
    }
}
