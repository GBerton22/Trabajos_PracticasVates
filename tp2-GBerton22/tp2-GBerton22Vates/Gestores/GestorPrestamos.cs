using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Tp2Biblioteca
{
  public class GestorPrestamos
  {
    GestoresBDContext db = new GestoresBDContext();
    public void CrearPrestamo(Prestamo prestamo) //Create
    {
      using (var transaction = db.Database.BeginTransaction())
      {
        try
        {
          db.Prestamos.Add(prestamo);
          db.SaveChanges();

          transaction.Commit();
        }
        catch (System.Exception)
        {
          transaction.Rollback();
        }
      }
    }
    public List<Prestamo> ObtenerPrestamos() // Read
    {
      return db.Prestamos.ToList();
    }
    public Prestamo ObtenerIdPrestamo(int prestamoId)
    {
      return db.Prestamos.Find(prestamoId);
    }
    public void ActualizarPrestamos(Prestamo prestamo) //Update
    {
      using (var transaction = db.Database.BeginTransaction())
      {
        try
        {
          db.Prestamos.Update(prestamo);
          db.SaveChanges();

          transaction.Commit();
        }
        catch (System.Exception)
        {
          transaction.Rollback();
        }
      }
    }
    public void BorrarPrestamos(int prestamoId) //Delete
    {
      using (var transaction = db.Database.BeginTransaction())
      {
        try
        {
          var prestamo = db.Prestamos.FirstOrDefault(l => l.PrestamoId == prestamoId);
          if (prestamo != null)
          {
            db.Prestamos.Remove(prestamo);
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