using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class CatalogosBaseDAL
    {
        private DataTable EjecutarConsulta(string sql)
        {
            DataTable dt = new DataTable();
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

        public DataTable ObtenerTiposEquipo()
        {
            return EjecutarConsulta(
                "SELECT IdTipoEquipo, Nombre, ISNULL(Descripcion, '') AS Descripcion, Activo FROM dbo.TipoEquipo ORDER BY IdTipoEquipo;");
        }

        public void GuardarTipoEquipo(int id, string nombre, string descripcion, bool activo)
        {
            const string sql = @"
                IF @Id = 0
                    INSERT INTO dbo.TipoEquipo (Nombre, Descripcion, Activo) VALUES (@Nombre, @Descripcion, @Activo);
                ELSE
                    UPDATE dbo.TipoEquipo SET Nombre = @Nombre, Descripcion = @Descripcion, Activo = @Activo WHERE IdTipoEquipo = @Id;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerMarcas()
        {
            return EjecutarConsulta(
                "SELECT IdMarca, Nombre, Activo FROM dbo.Marca ORDER BY IdMarca;");
        }

        public void GuardarMarca(int id, string nombre, bool activo)
        {
            const string sql = @"
                IF @Id = 0
                    INSERT INTO dbo.Marca (Nombre, Activo) VALUES (@Nombre, @Activo);
                ELSE
                    UPDATE dbo.Marca SET Nombre = @Nombre, Activo = @Activo WHERE IdMarca = @Id;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerCategoriasServicio()
        {
            return EjecutarConsulta(
                "SELECT IdCategoriaServicio, Nombre, Activo FROM dbo.CategoriaServicio ORDER BY IdCategoriaServicio;");
        }

        public void GuardarCategoriaServicio(int id, string nombre, bool activo)
        {
            const string sql = @"
                IF @Id = 0
                    INSERT INTO dbo.CategoriaServicio (Nombre, Activo) VALUES (@Nombre, @Activo);
                ELSE
                    UPDATE dbo.CategoriaServicio SET Nombre = @Nombre, Activo = @Activo WHERE IdCategoriaServicio = @Id;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
