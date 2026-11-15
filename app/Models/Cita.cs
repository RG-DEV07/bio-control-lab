using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Models
{
    public class Cita : EntidadBase
    {
        public int IdCliente { get; set; }
        public int? IdEmpleado { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }




    }
}
