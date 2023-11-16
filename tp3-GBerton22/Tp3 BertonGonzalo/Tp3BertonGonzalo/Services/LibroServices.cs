using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp3BertonGonzalo.Controllers;
using Tp3BertonGonzalo.DTO;

namespace Tp3BertonGonzalo.Services
{
    public class LibroServices
    {
        private readonly LibrosContext db;

        public LibroServices()
        {
            db = new LibrosContext();
        }

        //Libros
        private static readonly List<Libro> libros = new();

        public List<LibroDTO> GetLibros()
        {
            return new LibrosContext().Libros.Select(libro => new LibroDTO
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                EstadoId = libro.EstadoId
            }).ToList();
        }
        public LibroDTO? GetLibro(int id)
        {
            var libro = new LibrosContext().Libros.Find(id);
            if (libro != null)
            {
                return new LibroDTO
                {
                    LibroId = libro.LibroId,
                    Titulo = libro.Titulo,
                    Precio = libro.Precio,
                    EstadoId = libro.EstadoId
                };
            }
            return null;
        }

        public LibroDTO CreateLibro(LibroDTO libroDto)
        {
            if (libroDto.EstadoId < 1 || libroDto.EstadoId > 3)
            {
                throw new ArgumentException("EstadoId Debe ser 1, 2, or 3");
            }

            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                Precio = libroDto.Precio,
                EstadoId = libroDto.EstadoId
            };
            db.Libros.Add(libro);
            db.SaveChanges();
            db.Entry(libro).Reload();

            return new LibroDTO
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                EstadoId = libro.EstadoId
            };
        }

        public LibroDTO UpdateLibro(int id, LibroDTO libroDto)
        {
            if (libroDto.EstadoId < 1 || libroDto.EstadoId > 3)
            {
                throw new ArgumentException("EstadoId Debe ser 1, 2, or 3");
            }

            var libro = db.Libros.Find(id);
            if (libro == null)
            {
                return null;
            }
            libro.Titulo = libroDto.Titulo;
            libro.Precio = libroDto.Precio;
            libro.EstadoId = libroDto.EstadoId;

            db.SaveChanges();
            db.Entry(libro).Reload();
            return new LibroDTO
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                EstadoId = libro.EstadoId
            };
        }

        public bool DeleteLibro(int id)
        {
            var libro = db.Libros.Find(id);
            if (libro == null)
            {
                return false;
            }
            db.Libros.Remove(libro);
            db.SaveChanges();
            return true;
        }
    }
}