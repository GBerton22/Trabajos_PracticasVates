using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3BertonGonzalo.DTO
{
    public class LibroConSolicitanteDTO
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public int EstadoId { get; set; }
        public string Solicitante { get; set; }
    }
}