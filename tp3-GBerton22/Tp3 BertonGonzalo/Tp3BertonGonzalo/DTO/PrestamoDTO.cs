using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3BertonGonzalo.DTO
{
    public class PrestamoDTO
    {
        public int PrestamoId { get; set; }
        public string NombreSolicitante { get; set; }
        public int CantidadDias { get; set; }
        public bool Devuelto { get; set; } // 1 si 0 n o
        public int LibroId { get; set; }
    }
}