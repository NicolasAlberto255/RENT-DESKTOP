using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    class CheckIn
    {
        public int idCheckIn { get; set; }
        public string? nombreCliente { get; set; }
        public string? anotaciones { get; set; }
        public DateTime fechaCheckIn { get; set; }
        public double montoFinalReserva { get; set; }
    }
}
