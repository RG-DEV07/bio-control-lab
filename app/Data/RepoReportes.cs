using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioControlLab.Data
{
    public class RepoReportes : Conexion 
    {
        public int ContarPacientes()
        {
            int total = 0;
            if (conectar())
            {
                string sql = "SELECT COUNT(1) FROM Clientes WHERE activo = 1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    total = (int)cmd.ExecuteScalar();
                Desconectar();
            }
            return total;
        }
        public int ContarCitasHoy()
        {
            int total = 0;
            if (conectar())
            {
                string sql = "SELECT COUNT(1) FROM Citas WHERE CAST(fechaCita AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    total = (int)cmd.ExecuteScalar();
                Desconectar();
            }
            return total;
        }

        public int ContarExamenesPendientes()
        {
            int total = 0;
            if (conectar())
            {
                string sql = "SELECT COUNT(1) FROM Examenes";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    total = (int)cmd.ExecuteScalar();
                Desconectar();
            }
            return total;
        }

        public int ContarInsumosBajoStock()
        {
            int total = 0;
            if (conectar())
            {
                string sql = "SELECT COUNT(1) FROM Insumos WHERE stockActual <= stockMinimo AND activo = 1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    total = (int)cmd.ExecuteScalar();
                Desconectar();
            }
            return total;
        }
        public DataTable ExamenesPorEstado()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT LTRIM(RTRIM(estado)) AS estado, COUNT(1) AS total FROM Examenes GROUP BY LTRIM(RTRIM(estado))";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    new SqlDataAdapter(cmd).Fill(dt);
                Desconectar();
            }
            return dt;
        }
        public DataTable CitasPorServicio()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = @"SELECT s.nombreServicio, COUNT(c.idCita) AS total
                       FROM Citas c
                       INNER JOIN Servicios s ON c.idServicio = s.idServicio
                       GROUP BY s.nombreServicio";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    new SqlDataAdapter(cmd).Fill(dt);
                Desconectar();
            }
            return dt;
        }

    }
}
