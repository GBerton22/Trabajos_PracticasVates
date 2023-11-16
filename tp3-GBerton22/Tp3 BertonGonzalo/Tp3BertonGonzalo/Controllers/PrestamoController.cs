using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tp3BertonGonzalo.DTO;
using Tp3BertonGonzalo.Services;

namespace Tp3BertonGonzalo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly PrestamosServices prestamosServices;
        public PrestamosController(PrestamosServices service)
        {
            this.prestamosServices = service;
        }

        // POST: api/Prestamo // http://localhost:5105/api/prestamos
        // {
        //     "NombreSolicitante": "Joan",
        //     "CantidadDias": 10,
        //     "Devuelto": true,
        //     "LibroId": 22
        // }
        
        [HttpPost]
        public ActionResult<Prestamo> CreatePrestamo(PrestamoDTO prestamoDto)
        {
            var prestamo = prestamosServices.CreatePrestamo(prestamoDto.LibroId, prestamoDto);
            return StatusCode(201, prestamo);
        }
        // Delete: api/Prestamo // http://localhost:5105/api/prestamos/5
        [HttpDelete("{id}")]
        public IActionResult DeletePrestamo(int id)
        {
            var wasDeleted = prestamosServices.DeletePrestamo(id);
            if (!wasDeleted)
            {
                return NotFound();
            }
            return Ok(new { message = "Prestamo borrado exitosamente" });
        }
    }
}