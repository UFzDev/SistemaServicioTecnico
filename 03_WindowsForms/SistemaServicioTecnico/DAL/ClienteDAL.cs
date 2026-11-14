using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class ClienteDAL
    {
        private DataTable EjecutarConsultaTabla(string sql)
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
            return EjecutarConsultaTabla(
                "SELECT IdTipoEquipo, Nombre FROM dbo.TipoEquipo WHERE Activo = 1 ORDER BY IdTipoEquipo;");
        }

        public DataTable ObtenerMarcas()
        {
            return EjecutarConsultaTabla(
                "SELECT IdMarca, Nombre FROM dbo.Marca WHERE Activo = 1 ORDER BY IdMarca;");
        }

        public DataTable ObtenerClientes()
        {
            return EjecutarConsultaTabla(
                "SELECT IdCliente, Nombre, ISNULL(Apellidos, '') AS Apellidos, ISNULL(Telefono, '') AS Telefono, ISNULL(Correo, '') AS Correo, ISNULL(Direccion, '') AS Direccion, Activo FROM dbo.Cliente ORDER BY IdCliente;");
        }

        public DataTable ObtenerEquipos()
        {
            const string sql = @"
                SELECT 
                    eq.IdEquipo, 
                    eq.IdCliente, 
                    te.Nombre AS Tipo, 
                    m.Nombre AS Marca, 
                    eq.Modelo, 
                    ISNULL(eq.NumeroSerie, '') AS Serie, 
                    ISNULL(eq.Caracteristicas, '') AS Caracteristicas 
                FROM dbo.Equipo eq 
                INNER JOIN dbo.TipoEquipo te ON eq.IdTipoEquipo = te.IdTipoEquipo 
                INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca 
                WHERE eq.Activo = 1 
                ORDER BY eq.IdEquipo;";
            return EjecutarConsultaTabla(sql);
        }

        public int GuardarCliente(int idCliente, string nombre, string apellidos, string telefono, string correo, string direccion, bool activo)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ClienteGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", string.IsNullOrWhiteSpace(apellidos) ? (object)DBNull.Value : apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                    cmd.Parameters.AddWithValue("@Correo", string.IsNullOrWhiteSpace(correo) ? (object)DBNull.Value : correo);
                    cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(direccion) ? (object)DBNull.Value : direccion);
                    cmd.Parameters.AddWithValue("@Activo", activo);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public int GuardarEquipo(int idEquipo, int idCliente, int idTipoEquipo, int idMarca, string modelo, string numeroSerie, string caracteristicas, bool activo)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_EquipoGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEquipo", idEquipo);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@IdTipoEquipo", idTipoEquipo);
                    cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@NumeroSerie", string.IsNullOrWhiteSpace(numeroSerie) ? (object)DBNull.Value : numeroSerie);
                    cmd.Parameters.AddWithValue("@Caracteristicas", string.IsNullOrWhiteSpace(caracteristicas) ? (object)DBNull.Value : caracteristicas);
                    cmd.Parameters.AddWithValue("@Activo", activo);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
