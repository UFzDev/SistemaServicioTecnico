using System;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class DashboardDAL
    {
        public void ObtenerResumen(out int ordenesActivas, out int enReparacion, out int totalClientes, out int stockAlerta)
        {
            ordenesActivas = 0;
            enReparacion = 0;
            totalClientes = 0;
            stockAlerta = 0;

            const string sql = @"
                SELECT
                    (SELECT COUNT(*) FROM dbo.vw_OrdenesTallerActivas) AS OrdenesActivas,
                    (SELECT COUNT(*) FROM dbo.OrdenServicio WHERE IdEstadoOrden = 5) AS EnReparacion,
                    (SELECT COUNT(*) FROM dbo.Cliente WHERE Activo = 1) AS TotalClientes,
                    (SELECT COUNT(*) FROM dbo.vw_InventarioStockAlerta WHERE EstadoStock IN ('AGOTADO', 'CRITICO', 'BAJO')) AS StockAlerta;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ordenesActivas = Convert.ToInt32(dr["OrdenesActivas"]);
                            enReparacion = Convert.ToInt32(dr["EnReparacion"]);
                            totalClientes = Convert.ToInt32(dr["TotalClientes"]);
                            stockAlerta = Convert.ToInt32(dr["StockAlerta"]);
                        }
                    }
                }
            }
        }
    }
}
