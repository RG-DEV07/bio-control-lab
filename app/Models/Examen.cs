using BioControlLab.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Models
{
    public class Examen :EntidadBase
    {
        public int IdCliente { get; set; }
        public int IdTipoExamen { get; set; }
        public int? IdCita { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }

    }
}
