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
    internal class RepoInsumos : RepositorioBase
    {
        public override DataTable Listar()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT idInsumo, codigo, nombre, categoria, unidadMedida, stockActual, stockMinimo FROM Insumos WHERE activo = 1 ORDER BY nombre";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public DataTable ListarBajoStock()
        {
            DataTable dt = new DataTable();
            if (conectar())
            {
                string sql = "SELECT codigo, nombre, stockActual, stockMinimo FROM Insumos WHERE stockActual <= stockMinimo AND activo = 1";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    new SqlDataAdapter(cmd).Fill(dt);
                }
                Desconectar();
            }
            return dt;
        }

        public int Insertar(Insumo i)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "INSERT INTO Insumos (codigo, nombre, categoria, unidadMedida, stockActual, stockMinimo, idProveedor, activo) VALUES (@codigo, @nombre, @categoria, @unidad, @stockActual, @stockMinimo, @idProveedor, 1)";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@codigo", i.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", i.Nombre);
                    cmd.Parameters.AddWithValue("@categoria", i.Categoria);
                    cmd.Parameters.AddWithValue("@unidad", i.UnidadMedida);
                    cmd.Parameters.AddWithValue("@stockActual", i.StockActual);
                    cmd.Parameters.AddWithValue("@stockMinimo", i.StockMinimo);
                    cmd.Parameters.AddWithValue("@idProveedor", (object)i.IdProveedor ?? DBNull.Value);
                    resultado = cmd.ExecuteNonQuery();
                }
                Desconectar();
            }
            return resultado;
        }

        public int Actualizar(Insumo i)
        {
            int resultado = 0;
            if (conectar())
            {
                string sql = "UPDATE Insumos SET codigo=@codigo, nombre=@nombre, categoria=@categoria, unidadMedida=@unidad, stockActual=@stockActual, stockMinimo=@stockMinimo WHERE idInsumo=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cxn))
                {
                    cmd.Parameters.AddWithValue("@id", i.Id);
                    cmd.Parameters.AddWithValue("@codigo", i.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", i.Nombre);
                    cmd.Parameters.AddWithValue("@categoria", i.Categoria);
                    cmd.Parameters.AddWithValue("@unidad", i.UnidadMedida);
                    cmd.Parameters.AddWithValue("@stockActual", i.StockActual);
                    cmd.Parameters.AddWithValue("@stockMinimo", i.StockMinimo);
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
                string sql = "UPDATE Insumos SET activo = 0 WHERE idInsumo = @id";
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
