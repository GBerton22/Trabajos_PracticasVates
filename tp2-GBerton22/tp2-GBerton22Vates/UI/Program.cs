using System.Globalization;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace Tp2Biblioteca
{
  public class program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("Bienvenido a BooksMan!!\n");
      bool continuar = true;
      while (continuar)
      {
        System.Console.WriteLine("Seleccione una opción:");
        System.Console.WriteLine("1. Detalles libros (C.R.U.D) ");
        System.Console.WriteLine("2. Detalles Prestamos (C.R.U.D) ");
        System.Console.WriteLine("3. Cantidad de libros en cada estado: ");
        System.Console.WriteLine("4. Precio de reposicion de todos los libros extraviados:");
        System.Console.WriteLine("5. Nombre de todos los solicitantes de un libro en particular identificado por su título: ");
        System.Console.WriteLine("6. Promedio de veces que fueron prestados los libros de la biblioteca: ");
        System.Console.WriteLine("7. Listado de libros que fueron solicitados mas de una vez por el mismo cliente ");
        System.Console.WriteLine("0. Salir ");
        string opcion = Console.ReadLine();
        switch (opcion)
        {
          case "1":
            bool continuar1 = true;
            while (continuar1)
            {
              System.Console.WriteLine("Seleccione una opción:");
              System.Console.WriteLine("a. Leer Libros ");
              System.Console.WriteLine("b. Crear Libro ");
              System.Console.WriteLine("c. Actualizar libro");
              System.Console.WriteLine("d. Borrar Libro");
              System.Console.WriteLine("0. Salir ");
              string opcion1 = Console.ReadLine();
              switch (opcion1)
              {
                case "a":
                  LLibro();
                  break;
                case "b":
                  CLibro();
                  break;
                case "c":
                  ActLibro();
                  break;
                case "d":
                  BorLibro();
                  break;
                case "0":
                  continuar1 = false;
                  break;
              }
            }
            break;
          case "2":
            bool continuar2 = true;
            while (continuar2)
            {
              System.Console.WriteLine("Seleccione una opción:");
              System.Console.WriteLine("a. Leer Prestamos ");
              System.Console.WriteLine("b. Crear Prestamos ");
              System.Console.WriteLine("c. Actualizar Prestamos");
              System.Console.WriteLine("d. Borrar Prestamos");
              System.Console.WriteLine("0. Salir ");
              string opcion2 = Console.ReadLine();
              switch (opcion2)
              {
                case "a":
                  LPrestamos();
                  break;
                case "b":
                  CPrestamo();
                  break;
                case "c":
                  ActPrestamo();
                  break;
                case "d":
                  BorPrestamo();
                  break;
                case "0":
                  continuar2 = false;
                  break;
              }
            }
            break;
          case "3":
            ObtenerLibrosXEstado();
            break;
          case "4":
            CalculoExtraviados();
            break;
          case "5":
            SolicitantesXTitulo();
            break;
          case "6":
            PromedioPrestamos();
            break;
          case "7":
            LibrosPedidosMasDeUnaVez();
            break;
          case "0":
            return;
        }
      }
      static void LLibro()
      {
        Console.WriteLine("Libros disponibles:");

        var gestorLibro = new GestorLibros();
        List<Libro> libros = gestorLibro.ObtenerLibros();

        foreach (Libro libro in libros)
        {
          Console.WriteLine($"ID: {libro.LibroId}, Título: {libro.Titulo}, Precio: {libro.Precio}, EstadoId: {libro.EstadoId}");
        }
      }
      static void CLibro()
      {
        Console.WriteLine("Ingrese los detalles del nuevo libro:");
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Precio: ");
        decimal precio = decimal.Parse(Console.ReadLine());
        Console.Write("EstadoId: ");
        int estadoId = int.Parse(Console.ReadLine());

        Libro nuevoLibro = new Libro
        {
          Titulo = titulo,
          Precio = precio,
          EstadoId = estadoId
        };
        var gestorLibro = new GestorLibros();
        gestorLibro.CrearLibro(nuevoLibro);
        Console.WriteLine("Libro creado exitosamente.");
      }

      static void ActLibro()
      {
        Console.Write("Ingrese el ID del libro que desea actualizar: ");
        int libroId = int.Parse(Console.ReadLine());

        var gestorLibro = new GestorLibros();
        Libro libro = gestorLibro.ObtenerIdLibro(libroId);

        if (libro == null)
        {
          Console.WriteLine("No se encontró ningún libro con el ID proporcionado.");
          return;
        }

        Console.WriteLine("Ingrese los nuevos detalles del libro:");
        Console.Write("Título: ");
        libro.Titulo = Console.ReadLine();
        Console.Write("Precio: ");
        libro.Precio = decimal.Parse(Console.ReadLine());
        Console.Write("EstadoId: ");
        libro.EstadoId = int.Parse(Console.ReadLine());

        gestorLibro.ActualizarLibro(libro);
        Console.WriteLine("Libro actualizado exitosamente.");
      }

      static void BorLibro()
      {
        Console.Write("Ingrese el ID del libro que desea borrar: ");
        int libroId = int.Parse(Console.ReadLine());

        var gestorLibro = new GestorLibros();
        Libro libro = gestorLibro.ObtenerIdLibro(libroId);

        if (libro == null)
        {
          Console.WriteLine("No se encontró ningún libro con el ID proporcionado.");
          return;
        }

        gestorLibro.BorrarLibro(libroId);

        Console.WriteLine("Libro borrado exitosamente.");
      }

      static void LPrestamos()
      {
        var gestorPrestamo = new GestorPrestamos();
        List<Prestamo> prestamos = gestorPrestamo.ObtenerPrestamos();

        foreach (var prestamo in prestamos)
        {
          Console.WriteLine($"ID: {prestamo.PrestamoId}, Nombre del solicitante: {prestamo.NombreSolicitante}, Cantidad de días: {prestamo.CantidadDias}, Devuelto: {prestamo.Devuelto}, LibroId: {prestamo.LibroId}");
        }
      }

      static void CPrestamo()
      {
        Console.Write("Nombre del solicitante del préstamo: ");
        string nombreSolicitante = Console.ReadLine();
        Console.Write("Cantidad de días del préstamo: ");
        int cantidadDias = int.Parse(Console.ReadLine());
        Console.Write("¿El libro ha sido devuelto? (1: sí, 0: no): ");
        bool devuelto = Console.ReadLine() == "1";
        Console.WriteLine("Id del libro asociado al prestamo; ");
        int libroId = int.Parse(Console.ReadLine());

        Prestamo prestamo = new Prestamo
        {
          NombreSolicitante = nombreSolicitante,
          CantidadDias = cantidadDias,
          Devuelto = devuelto,
          LibroId = libroId
        };

        var gestorPrestamo = new GestorPrestamos();
        gestorPrestamo.CrearPrestamo(prestamo);
      }

      static void ActPrestamo()
      {

        Console.Write("Ingrese el ID del préstamo que desea obtener: ");
        int prestamoId = int.Parse(Console.ReadLine());

        var gestorPrestamo = new GestorPrestamos();
        Prestamo prestamo = gestorPrestamo.ObtenerIdPrestamo(prestamoId);

        if (prestamo != null)
        {
          Console.WriteLine("Ingrese los nuevos detalles del préstamo:");
          Console.Write("Nombre del solicitante del préstamo: ");
          prestamo.NombreSolicitante = Console.ReadLine();
          Console.Write("Cantidad de días del préstamo: ");
          prestamo.CantidadDias = int.Parse(Console.ReadLine());
          Console.Write("¿El libro ha sido devuelto? (1: sí, 0: no): ");
          prestamo.Devuelto = Console.ReadLine() == "1";

          // Actualiza el préstamo en la base de datos
          gestorPrestamo.ActualizarPrestamos(prestamo);
        }
      }

      static void BorPrestamo()
      {
        Console.Write("Ingrese el ID del préstamo que desea borrar: ");
        int prestamoId = int.Parse(Console.ReadLine());

        var gestorPrestamo = new GestorPrestamos();
        Prestamo prestamo = gestorPrestamo.ObtenerIdPrestamo(prestamoId);
        if (prestamo == null)
        {
          Console.WriteLine("No se encontró ningún préstamo con el ID proporcionado.");
          return;
        }
        gestorPrestamo.BorrarPrestamos(prestamoId);

        Console.WriteLine("Préstamo borrado exitosamente.");
      }

      static void ObtenerLibrosXEstado()
      {
        var gestorBiblioteca = new GestorBiblioteca();
        var librosPorEstado = gestorBiblioteca.ObtenerLibrosPorEstado();
        foreach (var estado in librosPorEstado.Keys)
        {
          Console.WriteLine($"Estado: {estado}");
          foreach (var libro in librosPorEstado[estado])
          {
            Console.WriteLine($"\tTitulo: {libro.Titulo}");
            foreach (var prestamo in libro.Prestamos)
            {
              Console.WriteLine($"\t\tPrestamo: {prestamo.PrestamoId}, Solicitante: {prestamo.NombreSolicitante}, Dias: {prestamo.CantidadDias}, Devuelto: {prestamo.Devuelto}");
            }
          }
        }
      }

      static void CalculoExtraviados()
      {
        var gestorBiblioteca = new GestorBiblioteca();
        var precioReposicion = gestorBiblioteca.CalcularLibExtraviados();

        Console.WriteLine($"La sumatoria del precio de reposición de todos los libros extraviados es: {precioReposicion}\n");
      }

      static void SolicitantesXTitulo()
      {
        var gestorBiblioteca = new GestorBiblioteca();
        Console.WriteLine("Por favor, ingresa el título del libro, Ejemplo: (La casita azul)");
        string titulo = Console.ReadLine();
        var (libros, mensaje) = gestorBiblioteca.ObtenerSolicitantesXTitulo(titulo);
        if (!string.IsNullOrEmpty(mensaje))
        {
          Console.WriteLine(mensaje);
        }
        if (libros.Count > 1)
        {
          for (int i = 0; i < libros.Count; i++)
          {
            Console.WriteLine($"{i + 1}. {libros[i].LibroId} - {libros[i].Titulo} - {libros[i].Precio}");
          }

          int seleccion = 0;
          bool esNumeroValido = false;
          while (!esNumeroValido)
          {
            Console.WriteLine("Por favor, selecciona un libro:");
            esNumeroValido = int.TryParse(Console.ReadLine(), out seleccion);
            if (!esNumeroValido || seleccion < 1 || seleccion > libros.Count)
            {
              Console.WriteLine("Número inválido. Por favor, ingresa un número que corresponda a uno de los libros listados.");
              esNumeroValido = false;
            }
          }

          var solicitantes = libros[seleccion - 1].Prestamos.Select(prestamo => prestamo.NombreSolicitante).ToList();

          Console.WriteLine($"Los solicitantes del libro '{libros[seleccion - 1].Titulo}' son:");
          foreach (var solicitante in solicitantes)
          {
            Console.WriteLine(solicitante);
          }
        }
      }

      static void PromedioPrestamos()
      {
        var gestorBiblioteca = new GestorBiblioteca();
        double promedioPrestamos = gestorBiblioteca.AVGPrestamosXLibro();

        Console.WriteLine($"El promedio de veces que fueron prestados los libros de la biblioteca es: {promedioPrestamos}\n");
      }

      static void LibrosPedidosMasDeUnaVez()
      {
        var gestorBiblioteca = new GestorBiblioteca();
        var librosSolicitadosMasDeUnaVez = gestorBiblioteca.ObtenerSolicitadosMasDeUnaVez();

        Console.WriteLine("Libros solicitados más de una vez por el mismo solicitante:\n");
        foreach (var item in librosSolicitadosMasDeUnaVez)
        {
          Console.WriteLine($"Solicitante: {item.Solicitante}, Título: {item.Titulo}, Cantidad: {item.Cantidad}\n");
        }
      }

    }
  }
}

