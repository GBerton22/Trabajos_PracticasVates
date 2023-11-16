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
    public class PrestamosServices
    {
        private readonly LibrosContext db;

        public PrestamosServices()
        {
            db = new LibrosContext();
        }

        public List<Prestamo> GetPrestamo()
        {
            return db.Prestamos.ToList();
        }
        public Prestamo? GetPrestamo(int id)
        {
            return db.Prestamos.Find(id);
        }
        public PrestamoDTO CreatePrestamo(int libroId, PrestamoDTO prestamoDto)
        {
            var prestamo = new Prestamo
            {
                NombreSolicitante = prestamoDto.NombreSolicitante,
                CantidadDias = prestamoDto.CantidadDias,
                Devuelto = prestamoDto.Devuelto,
                LibroId = libroId,
            };
            db.Prestamos.Add(prestamo);
            db.SaveChanges();
            db.Entry(prestamo).GetDatabaseValues();

            return new PrestamoDTO
            {
                PrestamoId = prestamo.PrestamoId,
                NombreSolicitante = prestamo.NombreSolicitante,
                CantidadDias = prestamo.CantidadDias,
                Devuelto = prestamo.Devuelto,
                LibroId = prestamo.LibroId
            };
        }

        public bool DeletePrestamo(int id)
        {
            var prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return false;
            }
            db.Prestamos.Remove(prestamo);
            db.SaveChanges();
            return true;
        }
    }
}