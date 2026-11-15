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
    public class RepoExamenes : RepositorioBase
    {
        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT e.idExamen, 
                       c.nombres + ' ' + c.apellidos AS Paciente, 
                       t.nombreExamen AS TipoExamen, 
                       e.fechaSolicitud AS Fecha, 
                       e.estado AS Estado, 
                       e.observacion AS Observacion
                       FROM Examenes e
                       INNER JOIN Clientes c    ON e.idCliente = c.idCliente
                       INNER JOIN TiposExamen t ON e.idTipoExamen = t.idTipoExamen
                       ORDER BY e.fechaSolicitud DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Examen e)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "INSERT INTO Examenes (idCliente, idTipoExamen, idCita, idEmpleado, fechaSolicitud, estado, observacion) VALUES (@idCliente, @idTipo, @idCita, @idEmpleado, @fecha, @estado, @obs)";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", e.IdCliente);
                    cmd.Parameters.AddWithValue("@idTipo", e.IdTipoExamen);
                    cmd.Parameters.AddWithValue("@idCita", (object)e.IdCita ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idEmpleado", (object)e.IdEmpleado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", e.FechaSolicitud);
                    cmd.Parameters.AddWithValue("@estado", e.Estado);
                    cmd.Parameters.AddWithValue("@obs", (object)e.Observacion ?? DBNull.Value);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        public int Actualizar(Examen e)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "UPDATE Examenes SET idTipoExamen=@idTipo, fechaSolicitud=@fecha, estado=@estado, observacion=@obs WHERE idExamen=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", e.Id);
                    cmd.Parameters.AddWithValue("@idTipo", e.IdTipoExamen);
                    cmd.Parameters.AddWithValue("@fecha", e.FechaSolicitud);
                    cmd.Parameters.AddWithValue("@estado", e.Estado);
                    cmd.Parameters.AddWithValue("@obs", (object)e.Observacion ?? DBNull.Value);
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
                string sql = "UPDATE Examenes SET estado = 'Cancelado' WHERE idExamen = @id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }
        public DataTable GetTiposExamen()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT idTipoExamen, nombreExamen FROM TiposExamen WHERE activo = 1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);

                }
                Desconectar();
            }
            return dt;
        }


    }
}
