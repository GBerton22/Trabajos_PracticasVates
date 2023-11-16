using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3BertonGonzalo.DTO
{
    public class EstadoLibroDTO
    {
            public int CantidadDisponible { get; set; }
            //public List<Libro> LibrosDisponibles { get; set; } 
            //Devuelve la lista de libros Disponibles, pero como no lo pide en la consigna devuelvo solo el numero
            public int CantidadPrestado { get; set; }
            //public List<Libro> LibrosPrestados { get; set; }
            //Devuelve la lista de libros Prestados, pero como no lo pide en la consigna devuelvo solo el numero
            public int CantidadExtraviado { get; set; }
            //public List<Libro> LibrosExtraviados { get; set; }
            //Devuelve la lista de libros Extraviados, pero como no lo pide en la consigna devuelvo solo el numero
    }
}