using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Tp2Biblioteca
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public string NombreSolicitante { get; set; }
        public int CantidadDias { get; set; }
        public bool Devuelto { get; set; } // 1 si 0 n o
        public int LibroId { get; set; }
        public Libro libro { get; set; }
        public Prestamo() {}
        public override string ToString()
        {
            return NombreSolicitante.ToString();
        }
    }
}