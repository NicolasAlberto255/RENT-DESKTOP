using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class Servicios
    {
        public int idServicios { get; set; }
        public string? nombreServicios { get; set; }
        public string? descripcionServicios { get; set; }
        public string? estadoServicios { get; set; }
        public int precioServicios { get; set; }
    }
}
