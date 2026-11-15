using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Models
{
    public class Consulta : EntidadBase
    {
        public int IdPaciente { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observacion { get; set; }

    }
}
