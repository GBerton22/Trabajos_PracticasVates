using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Tp2Biblioteca
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string EstadoL { get; set; } // 1: disponible, 2: prestado, 3: extraviado
        public List<Libro> LstLibros { get; set; }
        public Estado(){}
    }
}