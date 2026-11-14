using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class OperacionesTallerDAL
    {
        private DataTable EjecutarConsulta(string sql, Action<SqlCommand> configurarParams = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (configurarParams != null) configurarParams(cmd);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerOrdenesParaTaller()
        {
            const string sql = @"
                SELECT 
                    IdOrdenServicio, 
                    (Folio + ' - ' + Cliente + ' (' + Dispositivo + ')') AS DescripcionOrden, 
                    EstadoActual, 
                    IdOrdenServicio AS Id 
                FROM dbo.vw_OrdenesTallerActivas 
                ORDER BY IdOrdenServicio DESC;";
            return EjecutarConsulta(sql);
        }

        public void ObtenerTotalesOrden(int idOrdenServicio, out decimal costoTotal, out decimal saldoPendiente, out int diasGarantia)
        {
            costoTotal = 0;
            saldoPendiente = 0;
            diasGarantia = 0;

            const string sql = @"
                SELECT 
                    dbo.fn_CostoTotalOrden(@Id) AS Costo, 
                    dbo.fn_SaldoPendienteOrden(@Id) AS Saldo, 
                    dbo.fn_DiasGarantiaRestantes(@Id) AS Garantia;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idOrdenServicio);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            costoTotal = dr["Costo"] != DBNull.Value ? Convert.ToDecimal(dr["Costo"]) : 0m;
                            saldoPendiente = dr["Saldo"] != DBNull.Value ? Convert.ToDecimal(dr["Saldo"]) : 0m;
                            diasGarantia = dr["Garantia"] != DBNull.Value ? Convert.ToInt32(dr["Garantia"]) : 0;
                        }
                    }
                }
            }
        }

        public DataTable ObtenerRefaccionesOrden(int idOrdenServicio)
        {
            const string sql = @"
                SELECT 
                    orf.IdOrdenRefaccion, 
                    r.SKU, 
                    r.Nombre AS Refaccion, 
                    orf.Cantidad, 
                    orf.PrecioUnitario, 
                    (orf.Cantidad * orf.PrecioUnitario) AS Subtotal, 
                    CONVERT(VARCHAR(16), orf.FechaConsumo, 120) AS FechaConsumo 
                FROM dbo.OrdenRefaccion orf 
                INNER JOIN dbo.Refaccion r ON orf.IdRefaccion = r.IdRefaccion 
                WHERE orf.IdOrdenServicio = @Id 
                ORDER BY orf.IdOrdenRefaccion DESC;";
            return EjecutarConsulta(sql, cmd => cmd.Parameters.AddWithValue("@Id", idOrdenServicio));
        }

        public void ConsumirRefaccionEnOrden(int idOrdenServicio, int idRefaccion, int cantidad)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Tx_ConsumirRefaccionEnOrden", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdOrdenServicio", idOrdenServicio);
                    cmd.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void FinalizarYEntregarOrden(int idOrdenServicio, int idUsuario, int idMetodoPago)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Tx_FinalizarYEntregarOrden", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdOrdenServicio", idOrdenServicio);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@IdMetodoPago", idMetodoPago);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AjustarInventario(int idRefaccion, int cantidadAjuste, int idUsuario, string motivo)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_AjustarInventario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRefaccion", idRefaccion);
                    cmd.Parameters.AddWithValue("@CantidadAjuste", cantidadAjuste);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerMovimientosInventario()
        {
            const string sql = @"
                SELECT TOP 100 
                    m.IdMovimientoInventario AS ID, 
                    r.SKU, 
                    r.Nombre AS Refaccion, 
                    m.TipoMovimiento AS Tipo, 
                    m.Cantidad, 
                    m.Motivo, 
                    CONVERT(VARCHAR(16), m.FechaMovimiento, 120) AS Fecha 
                FROM dbo.MovimientoInventario m 
                INNER JOIN dbo.Refaccion r ON m.IdRefaccion = r.IdRefaccion 
                ORDER BY m.IdMovimientoInventario DESC;";
            return EjecutarConsulta(sql);
        }

        public DataTable ObtenerHistorialTickets()
        {
            const string sql = @"
                SELECT 
                    t.IdOrdenServicio, 
                    t.Folio, 
                    t.Cliente, 
                    t.Dispositivo, 
                    ISNULL(t.NumeroSerie, '') AS NumeroSerie, 
                    t.EstadoOrden, 
                    CONVERT(VARCHAR(10), t.FechaRecepcion, 103) AS Recepcion, 
                    ISNULL(CONVERT(VARCHAR(10), t.FechaEntrega, 103), '-') AS Entrega, 
                    t.TotalServicios, 
                    t.TotalRefacciones, 
                    t.TotalCostoCalculado AS Total, 
                    t.TotalPagado AS Pagado, 
                    t.SaldoPendiente AS Saldo, 
                    dbo.fn_DiasGarantiaRestantes(t.IdOrdenServicio) AS DiasGarantia 
                FROM dbo.vw_TicketOrdenCompleto t 
                ORDER BY t.IdOrdenServicio DESC;";
            return EjecutarConsulta(sql);
        }

        public string ObtenerClasificacionCliente(int idCliente)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_ClasificacionCliente(@Id);", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    con.Open();
                    object res = cmd.ExecuteScalar();
                    return res != null && res != DBNull.Value ? res.ToString() : "ESTANDAR";
                }
            }
        }

        public DataTable ObtenerHistorialPorCliente(int idCliente)
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.fn_HistorialOrdenesCliente(@Id);",
                cmd => cmd.Parameters.AddWithValue("@Id", idCliente));
        }
    }
}
