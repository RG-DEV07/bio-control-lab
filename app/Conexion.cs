using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BioControlLab
{
    public class Conexion
    {
        protected SqlConnection cxn;

        protected bool conectar()
        {
            try
            {
                cxn = new SqlConnection(Properties.Settings.Default.cnn);
                cxn.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                return false;
            }
        }

        protected bool Desconectar()
        {
            try
            {
                if (cxn.State == ConnectionState.Open)
                {
                    cxn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
