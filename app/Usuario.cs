using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BioControlLab
{
    internal class Usuario : Conexion
    {
        public bool ValidarLogin(string usuario, string clave)
        {
            bool acceso = false;

            if (conectar())
            {
                string sql = @"SELECT COUNT(1) FROM Usuarios 
                               WHERE usuario = @u 
                                 AND clave   = @c 
                                 AND activo  = 1";

                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@u", usuario);
                    cmd.Parameters.AddWithValue("@c", clave);
                    acceso = (int)cmd.ExecuteScalar() == 1;
                }

                Desconectar();
            }

            return acceso;
        }
        public int ObtenerRol(string usuario, string clave)
        {
            int rol = 0;
            if (conectar())
            {
                string sql = "SELECT idRol FROM Usuarios WHERE usuario=@u AND clave=@c AND activo=1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@u", usuario);
                    cmd.Parameters.AddWithValue("@c", clave);
                    object result = cmd.ExecuteScalar();
                    if (result != null) rol = Convert.ToInt32(result);
                }
                Desconectar();
            }
            return rol;
        }
        public string ObtenerNombre(string usuario, string clave)
        {
            string nombre = "";
            if (conectar())
            {
                string sql = "SELECT nombreCompleto FROM Usuarios WHERE usuario=@u AND clave=@c AND activo=1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@u", usuario);
                    cmd.Parameters.AddWithValue("@c", clave);
                    object result = cmd.ExecuteScalar();
                    if (result != null) nombre = result.ToString();
                }
                Desconectar();
            }
            return nombre;
        }
    }
}