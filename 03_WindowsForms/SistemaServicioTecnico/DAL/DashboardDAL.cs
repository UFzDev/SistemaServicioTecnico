using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class DashboardDAL
    {
        // Una sola ida al servidor. Todas las consultas son de lectura.
        public DataSet ObtenerReporte()
        {
            const string sql = @"
SELECT
 (SELECT COUNT(*) FROM dbo.OrdenServicio o JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden WHERE e.EsFinal=0) AS Activas,
 (SELECT COUNT(*) FROM dbo.OrdenServicio o JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden WHERE e.EsFinal=0 AND e.Nombre=N'En Reparación') AS Reparacion,
 (SELECT COUNT(*) FROM dbo.OrdenServicio o JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden WHERE e.EsFinal=0 AND o.FechaPrometida < CONVERT(date,GETDATE())) AS Vencidas,
 (SELECT COUNT(*) FROM dbo.OrdenServicio o JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden WHERE e.EsFinal=0 AND e.Nombre=N'Terminada / Lista') AS Listas;
SELECT e.Nombre AS Estado, COUNT(o.IdOrdenServicio) AS Total
 FROM dbo.EstadoOrden e LEFT JOIN dbo.OrdenServicio o ON o.IdEstadoOrden=e.IdEstadoOrden
 WHERE e.EsFinal=0 GROUP BY e.IdEstadoOrden,e.Nombre ORDER BY e.IdEstadoOrden;
SELECT TOP (8) o.Folio, LTRIM(RTRIM(c.Nombre + ' ' + ISNULL(c.Apellidos, ''))) AS Cliente, e.Nombre AS Estado,
 o.FechaRecepcion AS Recepcion, o.FechaPrometida AS Compromiso
 FROM dbo.OrdenServicio o JOIN dbo.Cliente c ON c.IdCliente=o.IdCliente
 JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden
 WHERE e.EsFinal=0 ORDER BY CASE WHEN o.FechaPrometida < CONVERT(date,GETDATE()) THEN 0 ELSE 1 END,
 o.FechaRecepcion DESC,o.IdOrdenServicio DESC;
SELECT N'Trabajos pendientes' AS Proceso, COUNT(*) AS Total FROM dbo.DetalleOrdenServicio d
 JOIN dbo.OrdenServicio o ON o.IdOrdenServicio=d.IdOrdenServicio JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden
 WHERE e.EsFinal=0 AND d.EstadoActividad=N'Pendiente'
UNION ALL SELECT N'Trabajos en proceso', COUNT(*) FROM dbo.DetalleOrdenServicio d
 JOIN dbo.OrdenServicio o ON o.IdOrdenServicio=d.IdOrdenServicio JOIN dbo.EstadoOrden e ON e.IdEstadoOrden=o.IdEstadoOrden
 WHERE e.EsFinal=0 AND d.EstadoActividad=N'EnProceso'
UNION ALL SELECT N'Refacciones con stock bajo',COUNT(*) FROM dbo.vw_InventarioStockAlerta WHERE EstadoStock IN ('AGOTADO','CRITICO','BAJO');";
            var datos = new DataSet();
            using (var con = ConexionBD.CrearConexion())
            using (var comando = new SqlCommand(sql, con))
            using (var adaptador = new SqlDataAdapter(comando))
            {
                comando.CommandTimeout = 15;
                adaptador.Fill(datos);
            }
            return datos;
        }
    }
}
