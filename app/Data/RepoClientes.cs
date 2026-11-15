using BioControlLab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Data
{
    public class RepoClientes : RepositorioBase
    {

        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT idCliente, codigoCliente, nombres, apellidos, 
                               cedula, telefono, correo, direccion 
                               FROM Clientes WHERE activo = 1 ORDER BY nombres";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Cliente c)
        {
            int resultado = 0;
            if (conectar())
            {
                string sqlInsert = @"INSERT INTO Clientes (codigoCliente, nombres, apellidos, cedula, telefono, correo, direccion, activo)
                             VALUES ('TEMP', @nombres, @apellidos, @cedula, @telefono, @correo, @direccion, 1);
                             SELECT SCOPE_IDENTITY();";

                int nuevoId;
                using (SqlCommand cmd = new SqlCommand(sqlInsert, cxn))
                {
                    cmd.Parameters.AddWithValue("@nombres", c.Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", c.Apellidos);
                    cmd.Parameters.AddWithValue("@cedula", (object)c.Cedula ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)c.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)c.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)c.Direccion ?? DBNull.Value);
                    nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string codigoGenerado = "CLI-" + nuevoId.ToString("D3");

                string sqlUpdate = "UPDATE Clientes SET codigoCliente = @codigo WHERE idCliente = @id";
                using (SqlCommand cmd = new SqlCommand(sqlUpdate, cxn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigoGenerado);
                    cmd.Parameters.AddWithValue("@id", nuevoId);
                    resultado = cmd.ExecuteNonQuery();
                }

                Desconectar();
            }
            return resultado;
        }


        public int Actualizar(Cliente c)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = @"UPDATE Clientes SET codigoCliente=@codigo, nombres=@nombres, 
                               apellidos=@apellidos, cedula=@cedula, telefono=@telefono, 
                               correo=@correo, direccion=@direccion WHERE idCliente=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    cmd.Parameters.AddWithValue("@codigo", c.CodigoCliente);
                    cmd.Parameters.AddWithValue("@nombres", c.Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", c.Apellidos);
                    cmd.Parameters.AddWithValue("@cedula", (object)c.Cedula ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)c.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)c.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)c.Direccion ?? DBNull.Value);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        
        public override int Eliminar(int id)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "UPDATE Clientes SET activo = 0 WHERE idCliente = @id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }
    










    }
}
