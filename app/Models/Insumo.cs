using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Models
{
    
        public class Insumo : EntidadBase
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public string UnidadMedida { get; set; }
            public int StockActual { get; set; }
            public int StockMinimo { get; set; }
            public int? IdProveedor { get; set; }
        }
    
}
