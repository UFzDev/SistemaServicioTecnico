using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class RefaccionDAL
    {
        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();
            const string sql = "SELECT IdCategoriaRefaccion, Nombre FROM dbo.CategoriaRefaccion WHERE Activo = 1 ORDER BY IdCategoriaRefaccion;";
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerRefacciones()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    r.IdRefaccion, 
                    r.SKU, 
                    c.Nombre AS Categoria, 
                    r.IdCategoriaRefaccion, 
                    r.Nombre, 
                    r.CostoReferencia AS Costo, 
                    r.PrecioVenta, 
                    ISNULL(i.Existencia, 0) AS Existencia, 
                    r.StockMinimo, 
                    ISNULL(r.Descripcion, '') AS Descripcion, 
                    r.Activo 
                FROM dbo.Refaccion r 
                INNER JOIN dbo.CategoriaRefaccion c ON r.IdCategoriaRefaccion = c.IdCategoriaRefaccion 
                LEFT JOIN dbo.Inventario i ON r.IdRefaccion = i.IdRefaccion 
                ORDER BY r.IdRefaccion;";
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int GuardarRefaccion(int idRefaccion, int idCategoria, string sku, string nombre, string descripcion, decimal costo, decimal precioVenta, int stockMinimo, int existenciaDeseada, bool activo, int idUsuario)
        {
            int idGenerado;
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.usp_RefaccionGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                    cmd.Parameters.AddWithValue("@IdCategoriaRefaccion", idCategoria);
                    cmd.Parameters.AddWithValue("@SKU", sku);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("@CostoReferencia", costo);
                    cmd.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                    cmd.Parameters.AddWithValue("@StockInicial", existenciaDeseada);
                    cmd.Parameters.AddWithValue("@Activo", activo);

                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (idRefaccion > 0)
                {
                    int existenciaActual = 0;
                    using (SqlCommand cmdStock = new SqlCommand("SELECT ISNULL(Existencia, 0) FROM dbo.Inventario WHERE IdRefaccion = @IdRefaccion;", con))
                    {
                        cmdStock.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                        object val = cmdStock.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                            existenciaActual = Convert.ToInt32(val);
                    }

                    int diferencia = existenciaDeseada - existenciaActual;
                    if (diferencia != 0)
                    {
                        using (SqlCommand cmdAjuste = new SqlCommand("dbo.usp_AjustarInventario", con))
                        {
                            cmdAjuste.CommandType = CommandType.StoredProcedure;
                            cmdAjuste.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                            cmdAjuste.Parameters.AddWithValue("@CantidadAjuste", diferencia);
                            cmdAjuste.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmdAjuste.Parameters.AddWithValue("@Motivo", "Ajuste desde catálogo de refacciones");
                            cmdAjuste.ExecuteNonQuery();
                        }
                    }
                }
            }

            return idGenerado;
        }
    }
}
