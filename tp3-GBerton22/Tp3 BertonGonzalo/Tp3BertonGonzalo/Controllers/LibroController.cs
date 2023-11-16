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
    public class LibroController : ControllerBase
    {
        private readonly LibroServices libroServices;
        public LibroController(LibroServices service)
        {
            this.libroServices = service;
        }
        // GET: api/Libro // http://localhost:5105/api/Libro
        [HttpGet]
        public IActionResult GetLibros()
        {
            List<LibroDTO> libros = libroServices.GetLibros();
            return Ok(libros);
        }

        // GET: api/Libro/5 // http://localhost:5105/api/Libro/2
        [HttpGet("{id}")]
        public ActionResult<LibroDTO> GetLibro(int id)
        {
            LibroDTO? encontrado = libroServices.GetLibro(id);
            if (encontrado != null)
                return Ok(encontrado);
            return NotFound();
        }

        // POST: api/Libro // http://localhost:5105/api/Libro
        //         {
        //          "NombreSolicitante": "Joan",
        //          "CantidadDias": 10,
        //          "Devuelto": true,
        //          "LibroId": 22
        //         }

        [HttpPost]
        public IActionResult CreateLibro(LibroDTO libroDto)
        {
            try
            {
                var newLibro = libroServices.CreateLibro(libroDto);
                return Ok(newLibro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: http://localhost:5105/api/Libro/30
        // {
        //     "Titulo": "Los Bosteros",
        //     "Precio": 10032,
        //     "EstadoId": 3
        // }

        [HttpPut("{id}")]
        public ActionResult<LibroDTO> UpdateLibro(int id, LibroDTO libroDto)
        {
            try
            {
                var updatedLibro = libroServices.UpdateLibro(id, libroDto);
                if (updatedLibro == null)
                {
                    return NotFound();
                }
                return Ok(updatedLibro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Libro/5 http://localhost:5105/api/Libro/30
        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            var wasDeleted = libroServices.DeleteLibro(id);
            if (!wasDeleted)
            {
                return NotFound();
            }
            return Ok(new { message = "Libro borrado exitosamente" });
        }
    }
}