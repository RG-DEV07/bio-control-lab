using BioControlLab.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BioControlLab.Data
{
    public class RepoProveedores : RepositorioBase
    {
        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT idProveedor, nombreProveedor, ruc, telefono, correo, direccion 
                               FROM Proveedores WHERE activo = 1 ORDER BY nombreProveedor";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Proveedor p)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = @"INSERT INTO Proveedores (nombreProveedor, ruc, telefono, correo, direccion, activo)
                             VALUES (@nombreProveedor, @ruc, @telefono, @correo, @direccion, 1)";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@nombreProveedor", p.NombreProveedor);
                    cmd.Parameters.AddWithValue("@ruc", (object)p.Ruc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)p.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)p.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)p.Direccion ?? DBNull.Value);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        public int Actualizar(Proveedor p)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = @"UPDATE Proveedores SET nombreProveedor=@nombreProveedor, ruc=@ruc, 
                               telefono=@telefono, correo=@correo, direccion=@direccion 
                               WHERE idProveedor=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nombreProveedor", p.NombreProveedor);
                    cmd.Parameters.AddWithValue("@ruc", (object)p.Ruc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)p.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)p.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)p.Direccion ?? DBNull.Value);
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
                string sql = "UPDATE Proveedores SET activo = 0 WHERE idProveedor = @id";
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