using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENT.Models
{
    public class Departamentos
    {
        public int idDepartamentos { get; set; }
        public string? nombreDepartamento { get; set; }
        public string? nombreComunaDepto { get; set; }
        public string? nombreRegionDepto { get; set; }
        public string? tipoDepto { get; set; }
        public string? direccionDepartamento { get; set; }
        public int nBanos { get; set; }
        public int nDepto { get; set; }
        public int nEdificio { get; set; }
        public int nHabitacion { get; set; }
        public int vNoche { get; set; }
        public Boolean balcon { get; set; }
    }
}
