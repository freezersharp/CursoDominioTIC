using CursoDominioTIC.API.Services;
using CursoDominioTIC.Common.Helpers;
using CursoDominioTIC.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace CursoDominioTIC.API.Controllers
{
    [Route(Parametros.URLServices)] //prefiero usar URL cortas
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Producto producto = _unitOfWork.Productos.GetById(id);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return BadRequest("No se encontró el registro.");
            }

        }
        [HttpPost]
        public IActionResult InsertProducto([FromBody] Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Productos.Insert(producto);
                    _unitOfWork.Save();
                    return Created("/CreateProducto", producto);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(producto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProducto([FromRoute] int id, [FromBody] Producto producto)
        {
            try
            {
                Producto estab = _unitOfWork.Productos.GetById(id);
                if (estab != null)
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.Productos.Update(producto);
                        _unitOfWork.Save();
                        return Ok();
                    }
                }
                else return NotFound("No se encuentra el producto.");
                return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                if (id != 0)
                {
                    _unitOfWork.Productos.Delete(id);
                    _unitOfWork.Save();
                    return Ok("Producto Eliminado.");
                }
                else
                {
                    return BadRequest("ID inválido.");
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
