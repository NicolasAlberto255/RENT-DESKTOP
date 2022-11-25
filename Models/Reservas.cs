using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class Reservas
    {
        public int idReserva { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int precioAbono { get; set; }
        public double precioTotal { get; set; }
        public object[] servicios { get; set; }
        public object[] usuarios { get; set; }
        public object[] departamentos { get; set; }

    }
}
