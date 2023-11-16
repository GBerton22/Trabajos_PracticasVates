using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tp2Biblioteca
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set;}
        public int EstadoId { get; set; } 
        public Estado Estado { get; set; }
        public List<Prestamo> Prestamos { get; set; }
        public Libro() {}
       
       
    }
}