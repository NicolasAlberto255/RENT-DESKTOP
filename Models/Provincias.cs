using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class Provincias
    {
        public Provincias()
        {
            
        }
        
        public int provinciasId { get; set; }
        
        public int regionesId { get; set; }

        public string? nombreProvincia { get; set; }
    }
}
