using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Tp3BertonGonzalo
{
    public class Biblioteca
    {
        [Key]
        public int BibliotecaId { get; set; }
        public string NombreBiblioteca { get; set; }
        public List<Libro> LstLibro { get; set; }
    }
}