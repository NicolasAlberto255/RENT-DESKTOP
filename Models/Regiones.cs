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
    public class Regiones
    {
        public int? idRegion { get; set; }
        public string? nombreRegion { get; set; }        
    }
}
