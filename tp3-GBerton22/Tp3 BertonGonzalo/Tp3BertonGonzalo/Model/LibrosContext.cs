using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Tp3BertonGonzalo
{
    public class LibrosContext : DbContext
    {
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public string DbPath { get; private set; }
        private string CONN = @"Server=DESKTOP-KI5LVF5\SQLEXPRESS;Database=BibliotecaTp2Gon; User ID=sa; Password=gonzaberton22; Trusted_Connection=true;Encrypt=False;";
        
        public LibrosContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Biblioteca.Tp2");
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
               => options.UseSqlServer(CONN);
               //.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
