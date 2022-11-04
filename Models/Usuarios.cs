using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RENT.Models
{
    public class Usuarios
    {   
        public int? idUsuario { get; set; }
        public string? nombreUsuario { get; set; }
        public string? apellidoUsuario { get; set; }
        public string? correoUsuario { get; set; }
        public string? cedulaUsuario { get; set; }
        public int? telefonoUsuario { get; set; }
        public int rolUsuario { get; set; }
        public string? regionUsuario { get; set; }
        public string? comunaUsuario { get; set; }
    }
}
