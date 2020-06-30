using CursoDominioTIC.Common.Models;
using CursoDominioTIC.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CursoDominioTIC.Common.Helpers;

namespace CursoDominioTIC.API.Controllers
{
    [Route(Parametros.URLServices)] //prefiero usar URL cortas
    public class EstablecimientosController : Controller
    {
        private CursoDominioTICContext _context = new CursoDominioTICContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new CursoDominioTICContext());

        /// <summary>
        /// Servicio que obtiene todos los establecimientos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEstablecimientos()
        {
            //var establecimientos = _unitOfWork.Establecimientos.Get(null, null, "Producto");
            var establecimientos = _unitOfWork.Establecimientos.Get();
            if (establecimientos != null)
            {
                return Ok(establecimientos);
            }
            else
            {
                return Ok();
            }
        }

        /// <summary>
        /// Servicio que retorna el establecimiento en base a su ID
        /// </summary>
        /// <param name="id">ID del Establecimiento</param>
        /// <returns>Establecimiento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Establecimiento establecimiento = _unitOfWork.Establecimientos.GetById(id);
            if (establecimiento != null)
            {
                return Ok(establecimiento);
            }
            else
            {
                return BadRequest("No se encontró el registro.");
            }

        }

        /// <summary>
        /// Servicio que agrega el Establecimiento
        /// </summary>
        /// <param name="establecimiento">JSON del Establecimiento</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertEstablecimiento([FromBody] Establecimiento establecimiento)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Establecimientos.Insert(establecimiento);
                    _unitOfWork.Save();
                    return Created("/CreateEstablecimiento", establecimiento);
                }
            }
            catch(DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(establecimiento);
        }

        /// <summary>
        /// Servicio que actualiza el establecimiento 
        /// </summary>
        /// <param name="id">ID del establecimiento</param>
        /// <param name="establecimiento">JSON del establecimiento</param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //[FromRoute]int id, 
        public IActionResult UpdateEstablecimiento([FromBody] Establecimiento establecimiento)
        {
            try
            {
                //Establecimiento estab = _unitOfWork.Establecimientos.GetById(id);
                //if (estab != null)
                //{
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.Establecimientos.Update(establecimiento);
                        _unitOfWork.Save();
                        return Ok(establecimiento);
                    }
                //}
                //else return NotFound("No se encuentra el establecimiento.");
                return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Servicio que elimina el Establecimiento en base a su ID
        /// </summary>
        /// <param name="id">ID del Establecimiento</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEstablecimiento(int id)
        {
            try
            {
                if (id != 0)
                {
                    _unitOfWork.Establecimientos.Delete(id);
                    _unitOfWork.Save();
                    return Ok("Establecimiento Eliminado.");
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
