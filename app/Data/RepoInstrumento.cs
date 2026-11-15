using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BioControlLab.Data
{
    internal class RepoInstrumento : RepositorioBase
    {

        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT idInstrumento AS ID, codigo AS Codigo, nombre AS Instrumento, categoria AS Categoria, marca AS Marca, modelo AS Modelo, estado AS Estado, fechaRevision AS Revision, observacion AS Observacion FROM Instrumentos WHERE activo = 1 ORDER BY idInstrumento DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(string codigo, string nombre, string categoria, string marca, string modelo, string estado, DateTime fechaRevision, string observacion)
        {
            int resultado = 0;
            if (conectar())
            {
                try
                {
                    string sql = "INSERT INTO Instrumentos(codigo,nombre,categoria,marca,modelo,estado,fechaRevision,observacion,activo) VALUES(@codigo,@nombre,@categoria,@marca,@modelo,@estado,@fechaRevision,@observacion,1)";
                    using (SqlCommand cmd = new SqlCommand(sql, cxn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@marca", marca);
                        cmd.Parameters.AddWithValue("@modelo", modelo);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@fechaRevision", fechaRevision);
                        cmd.Parameters.AddWithValue("@observacion", observacion);
                        resultado = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("Ya existe un instrumento con ese código.");
                }
                finally
                {
                    Desconectar();
                }
            }
            return resultado;
        }

        public int Actualizar(int id, string codigo, string nombre, string categoria, string marca, string modelo, string estado, DateTime fechaRevision, string observacion)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "UPDATE Instrumentos SET codigo=@codigo,nombre=@nombre,categoria=@categoria,marca=@marca,modelo=@modelo,estado=@estado,fechaRevision=@fechaRevision,observacion=@observacion WHERE idInstrumento=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@fechaRevision", fechaRevision);
                    cmd.Parameters.AddWithValue("@observacion", observacion);
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
                string sql = "UPDATE Instrumentos SET activo = 0 WHERE idInstrumento = @id";
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
