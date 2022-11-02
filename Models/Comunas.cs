using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class Comunas
    {
        public Comunas() { 
        }

        public int idComuna { get; set; }

        public int idRegion { get; set; }

        public string? nombreComuna { get; set; }
    }
}
