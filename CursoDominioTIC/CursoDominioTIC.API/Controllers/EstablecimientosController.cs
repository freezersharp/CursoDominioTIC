using CursoDominioTIC.Common.Models;
using CursoDominioTIC.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CursoDominioTIC.API.Controllers
{
    [Route("api/v1/CursoDominioTIC/[controller]")]
    public class EstablecimientosController : Controller
    {
        private CursoDominioTICContext _context = new CursoDominioTICContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new CursoDominioTICContext());

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
        [HttpGet("id")]
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

        [HttpPut("{id}")]
        public IActionResult UpdateEstablecimiento([FromRoute]int id, [FromBody] Establecimiento establecimiento)
        {
            try
            {
                Establecimiento estab = _unitOfWork.Establecimientos.GetById(id);
                if (estab != null)
                {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.Establecimientos.Update(establecimiento);
                        _unitOfWork.Save();
                        return Ok();
                    }
                }
                else return NotFound("No se encuentra el establecimiento.");
                return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
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
