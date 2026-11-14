using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public class OrdenServicioDAL
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

        public DataTable ObtenerClientesCombo()
        {
            return EjecutarConsulta(
                "SELECT IdCliente, (Nombre + ' ' + ISNULL(Apellidos, '')) AS NombreCompleto FROM dbo.Cliente WHERE Activo = 1 ORDER BY Nombre;");
        }

        public DataTable ObtenerEquiposPorClienteCombo(int idCliente)
        {
            const string sql = @"
                SELECT 
                    eq.IdEquipo, 
                    (m.Nombre + ' ' + eq.Modelo + CASE WHEN eq.NumeroSerie IS NOT NULL AND eq.NumeroSerie <> '' THEN ' (S/N: ' + eq.NumeroSerie + ')' ELSE '' END) AS DescripcionEquipo 
                FROM dbo.Equipo eq 
                INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca 
                WHERE eq.IdCliente = @IdCliente AND eq.Activo = 1 
                ORDER BY eq.IdEquipo;";

            return EjecutarConsulta(sql, cmd => cmd.Parameters.AddWithValue("@IdCliente", idCliente));
        }

        public DataTable ObtenerEstadosOrden()
        {
            return EjecutarConsulta(
                "SELECT IdEstadoOrden, Nombre FROM dbo.EstadoOrden WHERE Activo = 1 ORDER BY IdEstadoOrden;");
        }

        public DataTable ObtenerServiciosRapidos()
        {
            return EjecutarConsulta(
                "SELECT IdServicio, Nombre, PrecioBase FROM dbo.Servicio WHERE Activo = 1 ORDER BY Nombre;");
        }

        public DataTable ObtenerOrdenes()
        {
            const string sql = @"
                SELECT 
                    o.IdOrdenServicio,
                    o.Folio,
                    CONVERT(VARCHAR(10), o.FechaRecepcion, 103) AS FechaRecepcion,
                    (c.Nombre + ' ' + ISNULL(c.Apellidos, '')) AS Cliente,
                    o.IdCliente,
                    (m.Nombre + ' ' + eq.Modelo + CASE WHEN eq.NumeroSerie IS NOT NULL AND eq.NumeroSerie <> '' THEN ' (S/N: ' + eq.NumeroSerie + ')' ELSE '' END) AS Equipo,
                    o.IdEquipo,
                    o.FallaReportada,
                    ISNULL(o.DiagnosticoGeneral, '') AS Diagnostico,
                    eo.Nombre AS Estado,
                    o.IdEstadoOrden,
                    ISNULL(o.Presupuesto, 0) AS Presupuesto,
                    ISNULL(CONVERT(VARCHAR(10), o.FechaPrometida, 103), '') AS FechaPrometida
                FROM dbo.OrdenServicio o
                INNER JOIN dbo.Cliente c ON o.IdCliente = c.IdCliente
                INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
                INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
                INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden
                ORDER BY o.IdOrdenServicio DESC;";

            return EjecutarConsulta(sql);
        }

        public string ObtenerSiguienteFolio()
        {
            const string sql = "SELECT ISNULL(MAX(IdOrdenServicio), 0) + 1 FROM dbo.OrdenServicio;";
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int siguiente = Convert.ToInt32(cmd.ExecuteScalar());
                    return string.Format("ORD-{0}-{1:D4}", DateTime.Now.Year, siguiente);
                }
            }
        }

        public int RegistrarOrden(string folio, int idCliente, int idEquipo, int idUsuario, string falla, string diagnostico, decimal presupuesto, DateTime fechaPrometida)
        {
            int idOrdenGenerada = 0;
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_RegistrarOrdenServicio", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Folio", folio);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@IdEquipo", idEquipo);
                    cmd.Parameters.AddWithValue("@IdUsuarioRecepcion", idUsuario);
                    cmd.Parameters.AddWithValue("@FallaReportada", falla);
                    cmd.Parameters.AddWithValue("@Observaciones", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Presupuesto", presupuesto);
                    cmd.Parameters.AddWithValue("@FechaPrometida", fechaPrometida);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idOrdenGenerada = Convert.ToInt32(dr["IdOrdenServicio"]);
                        }
                    }
                }

                if (idOrdenGenerada > 0 && !string.IsNullOrWhiteSpace(diagnostico))
                {
                    using (SqlCommand cmdDiag = new SqlCommand("UPDATE dbo.OrdenServicio SET DiagnosticoGeneral = @Diag WHERE IdOrdenServicio = @Id;", con))
                    {
                        cmdDiag.Parameters.AddWithValue("@Diag", diagnostico);
                        cmdDiag.Parameters.AddWithValue("@Id", idOrdenGenerada);
                        cmdDiag.ExecuteNonQuery();
                    }
                }
            }

            return idOrdenGenerada;
        }

        public void ActualizarOrden(int idOrdenServicio, int idNuevoEstado, int idUsuario, string falla, string diagnostico, decimal presupuesto, DateTime fechaPrometida)
        {
            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                con.Open();

                int estadoActual = 0;
                using (SqlCommand cmdEstado = new SqlCommand("SELECT IdEstadoOrden FROM dbo.OrdenServicio WHERE IdOrdenServicio = @Id;", con))
                {
                    cmdEstado.Parameters.AddWithValue("@Id", idOrdenServicio);
                    object res = cmdEstado.ExecuteScalar();
                    if (res == null || res == DBNull.Value)
                        throw new InvalidOperationException("No se encontró la orden de servicio seleccionada.");
                    estadoActual = Convert.ToInt32(res);
                }

                const string sqlUpdate = @"
                    UPDATE dbo.OrdenServicio
                    SET FallaReportada = @Falla,
                        DiagnosticoGeneral = @Diagnostico,
                        Presupuesto = @Presupuesto,
                        FechaPrometida = CASE WHEN @FechaPrometida >= FechaRecepcion THEN @FechaPrometida ELSE FechaPrometida END
                    WHERE IdOrdenServicio = @Id;";

                using (SqlCommand cmdUpd = new SqlCommand(sqlUpdate, con))
                {
                    cmdUpd.Parameters.AddWithValue("@Falla", falla);
                    cmdUpd.Parameters.AddWithValue("@Diagnostico", string.IsNullOrWhiteSpace(diagnostico) ? (object)DBNull.Value : diagnostico);
                    cmdUpd.Parameters.AddWithValue("@Presupuesto", presupuesto);
                    cmdUpd.Parameters.AddWithValue("@FechaPrometida", fechaPrometida);
                    cmdUpd.Parameters.AddWithValue("@Id", idOrdenServicio);
                    cmdUpd.ExecuteNonQuery();
                }

                if (idNuevoEstado != estadoActual)
                {
                    using (SqlCommand cmdEstadoSp = new SqlCommand("dbo.usp_CambiarEstadoOrden", con))
                    {
                        cmdEstadoSp.CommandType = CommandType.StoredProcedure;
                        cmdEstadoSp.Parameters.AddWithValue("@IdOrdenServicio", idOrdenServicio);
                        cmdEstadoSp.Parameters.AddWithValue("@IdNuevoEstado", idNuevoEstado);
                        cmdEstadoSp.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmdEstadoSp.Parameters.AddWithValue("@Motivo", "Actualización desde módulo de órdenes");
                        cmdEstadoSp.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
