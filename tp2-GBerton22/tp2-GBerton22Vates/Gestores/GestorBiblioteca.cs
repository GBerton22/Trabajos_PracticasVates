using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Tp2Biblioteca
{
    public class GestorBiblioteca
    {
        private readonly GestoresBDContext db;

        public GestorBiblioteca()
        {
            db = new GestoresBDContext();
        }

        public Dictionary<string, List<Libro>> ObtenerLibrosPorEstado()
        {
            return db.Set<Libro>()
                .Include(libro => libro.Estado)
                .Include(libro => libro.Prestamos)
                .GroupBy(libro => libro.Estado.EstadoL)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        public decimal CalcularLibExtraviados()
        {
            return db.Set<Libro>()
            .Where(libro => libro.Estado.EstadoL == "Extraviado")
            .Sum(libro => libro.Precio);
        }

        public (List<Libro> Libros, string Mensaje) ObtenerSolicitantesXTitulo(string titulo)
        {
            var libros = db.Set<Libro>()
                .Include(libro => libro.Prestamos)
                .Where(libro => libro.Titulo == titulo)
                .ToList();

            if (libros.Count > 1)
            {
                var mensaje = "Se encontraron varios libros con el mismo título.";
                return (libros, mensaje);
            }
            else if (libros.Count == 1)
            {
                return (libros, null);
            }
            else
            {
                var mensaje = "No se encontró ningún libro con ese título.";
                return (new List<Libro>(), mensaje);
            }
        }
        // public double AVGPrestamosXLibro()
        // {
        //     int totalPrestamos = db.Set<Prestamo>().Count();
        //     int totalLibros = db.Set<Libro>().Count();

        //     if (totalLibros == 0)
        //     {
        //         return 0;
        //     }

        //     return (double)totalPrestamos / totalLibros;
        // }
        public double AVGPrestamosXLibro()
        {
            var prestamosPorLibro = db.Set<Libro>()
                .Select(libro => libro.Prestamos.Count)
                .ToList();

            if (prestamosPorLibro.Count == 0)
            {
                return 0;
            }

            return prestamosPorLibro.Average();
        }
        public List<(string Solicitante, string Titulo, int Cantidad)> ObtenerSolicitadosMasDeUnaVez()
        {
            return db.Set<Prestamo>()
         .Include(prestamo => prestamo.libro)
         .GroupBy(prestamo => new { Solicitante = prestamo.NombreSolicitante, Titulo = prestamo.libro.Titulo })
         .Where(grupo => grupo.Count() > 1)
         .Select(grupo => new { grupo.Key.Solicitante, grupo.Key.Titulo, Cantidad = grupo.Count() })
         .AsEnumerable() // Transforma a IEnumerable para poder crear una tupla
         .Select(item => (item.Solicitante, item.Titulo, item.Cantidad))
         .ToList();
        }


    }
}