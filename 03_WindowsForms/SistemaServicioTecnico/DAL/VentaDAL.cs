using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class VentaDAL
    {
        public DataTable ObtenerMetodosPago()
        {
            DataTable dt = new DataTable();
            const string sql = "SELECT IdMetodoPago, Nombre FROM dbo.MetodoPago WHERE Activo = 1 ORDER BY IdMetodoPago;";
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

        public DataTable ObtenerVentas()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    v.Folio,
                    CONVERT(VARCHAR(10), v.FechaVenta, 103) AS Fecha,
                    (c.Nombre + ' ' + ISNULL(c.Apellidos, '')) AS Cliente,
                    r.Nombre AS Refaccion,
                    dv.Cantidad,
                    (dv.Cantidad * dv.PrecioUnitario) AS Total,
                    ISNULL((SELECT TOP 1 mp.Nombre FROM dbo.Pago p INNER JOIN dbo.MetodoPago mp ON p.IdMetodoPago = mp.IdMetodoPago WHERE p.IdVentaRefaccion = v.IdVentaRefaccion), 'Efectivo') AS MetodoPago,
                    v.Estado
                FROM dbo.VentaRefaccion v
                INNER JOIN dbo.Cliente c ON v.IdCliente = c.IdCliente
                INNER JOIN dbo.DetalleVenta dv ON v.IdVentaRefaccion = dv.IdVentaRefaccion
                INNER JOIN dbo.Refaccion r ON dv.IdRefaccion = r.IdRefaccion
                ORDER BY v.IdVentaRefaccion DESC;";

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
            const string sql = "SELECT ISNULL(MAX(IdVentaRefaccion), 0) + 1 FROM dbo.VentaRefaccion;";
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int sig = Convert.ToInt32(cmd.ExecuteScalar());
                    return string.Format("VTA-{0}-{1:D4}", DateTime.Now.Year, sig);
                }
            }
        }

        public int RegistrarVenta(int idCliente, int idUsuario, int idRefaccion, int cantidad, int idMetodoPago)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Tx_RegistrarVentaMostrador", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@IdMetodoPago", idMetodoPago);

                    SqlParameter outParam = new SqlParameter("@NuevoIdVenta", SqlDbType.Int)
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
