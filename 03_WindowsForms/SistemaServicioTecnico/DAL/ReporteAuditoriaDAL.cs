using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class ReporteAuditoriaDAL
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

        public DataTable ObtenerReporteIngresosMensuales()
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.vw_ReporteIngresosMensuales ORDER BY Anio DESC, MesNumero DESC;");
        }

        public DataTable ObtenerReporteIngresosPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ReporteIngresosPeriodo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@IdMetodoPago", DBNull.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerReporteOrdenesPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ReporteOrdenesPeriodo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@IdEstadoOrden", DBNull.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerTopServicios()
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.vw_TopServiciosSolicitados ORDER BY TotalRecaudado DESC;");
        }

        public DataTable ObtenerRendimientoTecnicos()
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.vw_RendimientoTecnicos ORDER BY OrdenesEntregadas DESC;");
        }

        public DataTable ObtenerStockAlerta()
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.vw_InventarioStockAlerta ORDER BY Existencia ASC;");
        }

        public DataTable ObtenerExpedienteClientes()
        {
            return EjecutarConsulta(
                "SELECT * FROM dbo.vw_ExpedienteCliente ORDER BY TotalPagadoHistorico DESC;");
        }

        public DataTable ObtenerAuditoria()
        {
            const string sql = @"
                SELECT 
                    a.IdAuditoria AS ID, 
                    ISNULL(u.NombreUsuario, 'Trigger SQL') AS Usuario, 
                    a.TablaAfectada AS Tabla, 
                    a.IdRegistro AS Registro, 
                    a.Operacion, 
                    ISNULL(a.ValorAnterior, '-') AS ValorAnterior, 
                    ISNULL(a.ValorNuevo, '-') AS ValorNuevo, 
                    CONVERT(VARCHAR(19), a.FechaEvento, 120) AS Fecha 
                FROM dbo.Auditoria a 
                LEFT JOIN dbo.Usuario u ON a.IdUsuario = u.IdUsuario 
                ORDER BY a.IdAuditoria DESC;";
            return EjecutarConsulta(sql);
        }
    }
}
