using BioControlLab.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BioControlLab.Data
{
    public class RepoEmpleados : RepositorioBase
    {
        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT idEmpleado, codigoEmpleado, nombres, apellidos, 
                               cargo, telefono, correo 
                               FROM Empleados WHERE activo = 1 ORDER BY nombres";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public DataTable ListarPorCargo(string cargo)
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT idEmpleado, codigoEmpleado, nombres, apellidos, 
                               cargo, telefono, correo 
                               FROM Empleados WHERE activo = 1 AND cargo = @cargo ORDER BY nombres";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@cargo", cargo);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Medicos e)
        {
            int resultado = 0;
            if (conectar())
            {
                string sqlInsert = @"INSERT INTO Empleados (codigoEmpleado, nombres, apellidos, cargo, telefono, correo, activo)
                             VALUES ('TEMP', @nombres, @apellidos, @cargo, @telefono, @correo, 1);
                             SELECT SCOPE_IDENTITY();";

                int nuevoId;
                using (SqlCommand cmd = new SqlCommand(sqlInsert, cxn))
                {
                    cmd.Parameters.AddWithValue("@nombres", e.Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", e.Apellidos);
                    cmd.Parameters.AddWithValue("@cargo", e.Cargo);
                    cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)e.Correo ?? DBNull.Value);
                    nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string codigoGenerado = "EMP-" + nuevoId.ToString("D3");
                string sqlUpdate = "UPDATE Empleados SET codigoEmpleado = @codigo WHERE idEmpleado = @id";
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

        public int Actualizar(Medicos e)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = @"UPDATE Empleados SET codigoEmpleado=@codigo, nombres=@nombres, 
                               apellidos=@apellidos, cargo=@cargo, telefono=@telefono, 
                               correo=@correo WHERE idEmpleado=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", e.Id);
                    cmd.Parameters.AddWithValue("@codigo", e.CodigoEmpleado);
                    cmd.Parameters.AddWithValue("@nombres", e.Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", e.Apellidos);
                    cmd.Parameters.AddWithValue("@cargo", e.Cargo);
                    cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", (object)e.Correo ?? DBNull.Value);
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
                string sql = "UPDATE Empleados SET activo = 0 WHERE idEmpleado = @id";
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