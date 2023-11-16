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
    [Route("api/libros/informes")]
    public class InformesController : ControllerBase
    {
        private readonly InformeServices informeServices;
        public InformesController(InformeServices service)
        {
            this.informeServices = service;
        }

        //GET http://localhost:5105/api/libros/informes/estados

        [HttpGet("estados")]
        public ActionResult<EstadoLibroDTO> GetCantidadLibrosPorEstado()
        {
            var dto = informeServices.GetCantidadLibrosPorEstado();
            return Ok(dto);
        }

        //GET http://localhost:5105/api/libros/informes/extraviados/preciototal
        [HttpGet("extraviados/preciototal")]
        public IActionResult GetSumatoriaPreciosLibrosExtraviados()
        {
            var sumatoriaPrecios = informeServices.GetSumatoriaPreciosLibrosExtraviados();
            return Ok(new { message = $"La sumatoria de los precios de los libros extraviados es: {sumatoriaPrecios}" });
        }

        //GET http://localhost:5105/api/libros/informes/{titulo}

        //GET http://localhost:5105/api/libros/informes?titulo=la

        [HttpGet]
        public ActionResult<List<string>> GetSolicitantesPorTitulo([FromQuery] string titulo)
        {
            var nombresSolicitantes = informeServices.GetSolicitantesPorTitulo(titulo);
            return Ok(nombresSolicitantes);
        }

        //GET http://localhost:5105/api/libros/informes/{codigo}/solicitantes

        //GET http://localhost:5105/api/libros/informes/solicitantes?codigo=10

        [HttpGet("solicitantes")]
        public IActionResult GetSolicitantesPorCodigo([FromQuery] string codigo)
        {
            try
            {
                var solicitantes = informeServices.GetSolicitantesPorCodigo(codigo);
                return Ok(solicitantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET http://localhost:5105/api/libros/informes/prestamos/promedio
        [HttpGet("prestamos/promedio")]
        public ActionResult<double> GetPromedioPrestamos()
        {
            var promedioPrestamos = informeServices.GetPromedioPrestamos();
            return Ok(promedioPrestamos);
        }

        //GET http://localhost:5105/api/libros/informes/prestamos/multiples
        [HttpGet("prestamos/multiples")]
        public ActionResult<List<InformePrestamoDTO>> GetPrestamos()
        {
            var prestamos = informeServices.GetPrestamos();
            return Ok(prestamos);
        }


    }
}