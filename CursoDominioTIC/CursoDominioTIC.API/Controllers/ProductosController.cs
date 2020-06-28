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

        /// <summary>
        /// Servicio que retorna los productos en base al ID del establecimiento
        /// </summary>
        /// <param name="idEstablecimiento">ID del establecimiento</param>
        /// <returns>JSON con la lista de productos del establecimiento consultado.</returns>
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

        /// <summary>
        /// Servicio que retorna el producto en base a su ID
        /// </summary>
        /// <param name="id">ID del Producto</param>
        /// <returns>Producto</returns>
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

        /// <summary>
        /// Servicio que crea un Producto
        /// </summary>
        /// <param name="producto">JSON del Producto</param>
        /// <returns></returns>
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

        /// <summary>
        /// Servicio que actualiza un producto
        /// </summary>
        /// <param name="id">ID del Producto</param>
        /// <param name="producto">JSON del Producto</param>
        /// <returns></returns>
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

        /// <summary>
        /// Servicio que elimina un producto en base a su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
