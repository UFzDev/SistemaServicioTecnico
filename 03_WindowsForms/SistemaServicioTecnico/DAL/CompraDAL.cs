using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class CompraDAL
    {
        public DataTable ObtenerProveedores()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    IdProveedor, 
                    Nombre AS Empresa, 
                    ISNULL(RFC, '') AS RFC, 
                    ISNULL(Contacto, '') AS Contacto, 
                    ISNULL(Telefono, '') AS Telefono 
                FROM dbo.Proveedor 
                WHERE Activo = 1 
                ORDER BY IdProveedor DESC;";

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

        public int GuardarProveedor(string nombre, string rfc, string contacto, string telefono)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ProveedorGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", 0);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@RFC", string.IsNullOrWhiteSpace(rfc) ? (object)DBNull.Value : rfc);
                    cmd.Parameters.AddWithValue("@Contacto", string.IsNullOrWhiteSpace(contacto) ? (object)DBNull.Value : contacto);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                    cmd.Parameters.AddWithValue("@Correo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Activo", true);

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public DataTable ObtenerCompras()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    c.Folio,
                    CONVERT(VARCHAR(10), c.FechaCompra, 103) AS Fecha,
                    p.Nombre AS Proveedor,
                    r.Nombre AS Refaccion,
                    dc.Cantidad AS Cant,
                    (dc.Cantidad * dc.CostoUnitario) AS Total
                FROM dbo.Compra c
                INNER JOIN dbo.Proveedor p ON c.IdProveedor = p.IdProveedor
                INNER JOIN dbo.DetalleCompra dc ON c.IdCompra = dc.IdCompra
                INNER JOIN dbo.Refaccion r ON dc.IdRefaccion = r.IdRefaccion
                ORDER BY c.IdCompra DESC;";

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

        public string ObtenerSiguienteFolio()
        {
            const string sql = "SELECT ISNULL(MAX(IdCompra), 0) + 1 FROM dbo.Compra;";
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int sig = Convert.ToInt32(cmd.ExecuteScalar());
                    return string.Format("COM-{0}-{1:D4}", DateTime.Now.Year, sig);
                }
            }
        }

        public int RegistrarCompra(int idProveedor, int idUsuario, int idRefaccion, int cantidad, decimal costoUnitario)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Tx_RegistrarCompraProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
                    cmd.Parameters.AddWithValue("@Observaciones", "Compra registrada desde aplicación WinForms");

                    SqlParameter outParam = new SqlParameter("@NuevoIdCompra", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(outParam.Value);
                }
            }
        }
    }
}
