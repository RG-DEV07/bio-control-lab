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
    public class RepoCitas : RepositorioBase
    {
        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT ci.idCita, 
                       cl.nombres + ' ' + cl.apellidos AS Paciente, 
                       s.nombreServicio AS Servicio, 
                       ci.fechaCita AS Fecha, 
                       ci.horaCita AS Hora, 
                       ci.estado AS Estado, 
                       ci.observacion AS Observacion
                       FROM Citas ci
                       INNER JOIN Clientes cl  ON ci.idCliente = cl.idCliente
                       INNER JOIN Servicios s  ON ci.idServicio = s.idServicio
                       ORDER BY ci.fechaCita DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Cita c)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "INSERT INTO Citas (idCliente, idEmpleado, idServicio, fechaCita, horaCita, estado, observacion) VALUES (@idCliente, @idEmpleado, @idServicio, @fecha, @hora, @estado, @obs)";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", c.IdCliente);
                    cmd.Parameters.AddWithValue("@idEmpleado", DBNull.Value);
                    cmd.Parameters.AddWithValue("@idServicio", c.IdServicio);
                    cmd.Parameters.AddWithValue("@fecha", c.FechaCita);
                    cmd.Parameters.AddWithValue("@hora", c.HoraCita);
                    cmd.Parameters.AddWithValue("@estado", c.Estado);
                    cmd.Parameters.AddWithValue("@obs", (object)c.Observacion ?? DBNull.Value);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        public int Actualizar(Cita c)
        {
            int resultado = 0;
            if (conectar())
            {

               string sql = "UPDATE Citas SET idServicio=@idServicio, fechaCita=@fecha, horaCita=@hora, estado=@estado, observacion=@obs WHERE idCita=@id";
                
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    cmd.Parameters.AddWithValue("@idServicio", c.IdServicio);
                    cmd.Parameters.AddWithValue("@fecha", c.FechaCita);
                    cmd.Parameters.AddWithValue("@hora", c.HoraCita);
                    cmd.Parameters.AddWithValue("@estado", c.Estado);
                    cmd.Parameters.AddWithValue("@obs", (object)c.Observacion ?? DBNull.Value);
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
                string sql = "UPDATE Citas SET estado = 'Cancelada' WHERE idCita = @id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        public DataTable GetServicios()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT idServicio, nombreServicio FROM Servicios WHERE activo = 1";
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
