using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class FileContent
    {
        public string? nombre { get; set; }
        public string tipo { get; set; }
        public byte[] data { get; set; }
        public int IdTipoDepartamento { get; set; }
    }
}
