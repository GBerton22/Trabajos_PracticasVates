using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Tp2Biblioteca
{
    //Hacer crud de todo
    public class GestorLibros
    {
        GestoresBDContext db = new GestoresBDContext();
        public void CrearLibro(Libro libro) //Create
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Libros.Add(libro);
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }
        public List<Libro> ObtenerLibros() // Read
        {
            return db.Libros.ToList();
        }
        public Libro ObtenerIdLibro(int libroId)
        {
            return db.Libros.Find(libroId);
        }
        public void ActualizarLibro(Libro libro) //Update
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Libros.Update(libro);
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }
        public void BorrarLibro(int libroId) //Delete
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var libro = db.Libros.FirstOrDefault(l => l.LibroId == libroId);
                    if (libro != null)
                    {
                        db.Libros.Remove(libro);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}