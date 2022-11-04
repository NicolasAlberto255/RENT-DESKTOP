using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    internal class Reservas
    {
        public int idReservas { get; set; }
        public DateOnly fechaCreacion { get; set; }
        public DateOnly fechaInicio { get; set; }
        public DateOnly fechaFin { get; set; }
        public int cntDias { get; set; }
        public int precioAbono { get; set; }
    }
}
