using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tp3BertonGonzalo.Controllers;
using Tp3BertonGonzalo.DTO;

namespace Tp3BertonGonzalo.Services
{
    public class InformeServices
    {
        private readonly LibrosContext db;

        public InformeServices()
        {
            db = new LibrosContext();
        }

        public EstadoLibroDTO GetCantidadLibrosPorEstado()
        {
            var libros = db.Libros.ToList();
            var dto = new EstadoLibroDTO
            {
                CantidadDisponible = libros.Count(l => l.EstadoId == 1),
                //LibrosDisponibles = libros.Where(l => l.EstadoId == 1).ToList(),
                CantidadPrestado = libros.Count(l => l.EstadoId == 2),
                //LibrosPrestados = libros.Where(l => l.EstadoId == 2).ToList(),
                CantidadExtraviado = libros.Count(l => l.EstadoId == 3),
                //LibrosExtraviados = libros.Where(l => l.EstadoId == 3).ToList()
            };
            return dto;
        }
        public decimal GetSumatoriaPreciosLibrosExtraviados()
        {
            var librosExtraviados = db.Libros.Where(l => l.EstadoId == 3);
            var sumatoriaPrecios = librosExtraviados.Sum(l => l.Precio);

            return sumatoriaPrecios;
        }

        // public List<string> GetSolicitantesPorTitulo(string titulo)
        // {
        //     titulo = titulo.Replace(" ", "").ToLower();
        //     var prestamos = db.Prestamos.Include(p => p.libro)
        //                                 .Where(p => p.libro.Titulo.Replace(" ", "").ToLower() == titulo);
        //     var nombresSolicitantes = prestamos.Select(p => p.NombreSolicitante).ToList();

        //     return nombresSolicitantes;
        // }
       public List<LibroConSolicitanteDTO> GetSolicitantesPorTitulo(string titulo)
       {
           titulo = titulo.ToLower().Trim();
       
           return db.Prestamos
               .Where(p => p.libro.Titulo.ToLower().Trim().Contains(titulo))
               .Select(p => new LibroConSolicitanteDTO
               {
                   LibroId = p.libro.LibroId,
                   Titulo = p.libro.Titulo,
                   Precio = p.libro.Precio,
                   EstadoId = p.libro.EstadoId,
                   Solicitante = p.NombreSolicitante
               })
               .ToList();
       }
        public List<string> GetSolicitantesPorCodigo(string codigo)
        {
            int codigoInt;
            if (!int.TryParse(codigo, out codigoInt))
            {
                throw new ArgumentException("El código proporcionado no es un número válido.");
            }
            var prestamos = db.Prestamos.Include(p => p.libro)
                                        .Where(p => p.libro.LibroId == codigoInt);
            var nombresSolicitantes = prestamos.Select(p => p.NombreSolicitante).ToList();
            return nombresSolicitantes;
        }
        public double GetPromedioPrestamos()
        {
            var totalPrestamos = db.Prestamos.Count();
            var totalLibros = db.Libros.Count();

            if (totalLibros == 0)
            {
                throw new InvalidOperationException("No se puede calcular el promedio de préstamos porque no hay libros.");
            }

            var promedioPrestamos = (double)totalPrestamos / totalLibros;

            return promedioPrestamos;
        }
        public List<InformePrestamoDTO> GetPrestamos()
        {
            var prestamos = db.Prestamos.Include(p => p.libro)
                                        .GroupBy(p => new { p.NombreSolicitante, p.libro.Titulo })
                                        .Where(g => g.Count() > 1)
                                        .Select(g => new InformePrestamoDTO
                                        {
                                            NombreSolicitante = g.Key.NombreSolicitante,
                                            TituloLibro = g.Key.Titulo,
                                            CantidadPrestamos = g.Count()
                                        })
                                        .ToList();
            return prestamos;
        }
    }
}