using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class DeptoImagen
    {
        public int idImagen { get; set; }
        public string? nombreImagen { get; set; }
        public string? url { get; set; }
        public string? tipoExtension { get; set; }
        public int size { get; set; }
        public int idDepartamentos { get; set; }
    }
}
