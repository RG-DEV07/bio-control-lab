using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Data
{
    public  abstract class RepositorioBase : Conexion
    {
        public abstract DataTable Listar();
        public abstract int Eliminar(int id);


    }
}
