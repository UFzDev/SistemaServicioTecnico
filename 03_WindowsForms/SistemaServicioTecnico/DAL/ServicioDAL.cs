using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class ServicioDAL
    {
        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();
            const string sql = "SELECT IdCategoriaServicio, Nombre FROM dbo.CategoriaServicio WHERE Activo = 1 ORDER BY IdCategoriaServicio;";
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

        public DataTable ObtenerServicios()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    s.IdServicio, 
                    cs.Nombre AS Categoria, 
                    s.IdCategoriaServicio, 
                    s.Nombre, 
                    ISNULL(s.Descripcion, '') AS Descripcion, 
                    s.PrecioBase, 
                    s.Activo 
                FROM dbo.Servicio s 
                INNER JOIN dbo.CategoriaServicio cs ON s.IdCategoriaServicio = cs.IdCategoriaServicio 
                ORDER BY s.IdServicio;";
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

        public int GuardarServicio(int idServicio, int idCategoriaServicio, string nombre, string descripcion, decimal precioBase, bool activo)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ServicioGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdServicio", idServicio);
                    cmd.Parameters.AddWithValue("@IdCategoriaServicio", idCategoriaServicio);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("@PrecioBase", precioBase);
                    cmd.Parameters.AddWithValue("@Activo", activo);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
