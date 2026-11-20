using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Reportes
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteAuditoriaBLL _bll = new ReporteAuditoriaBLL();

        public FrmReportes()
        {
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            cboReporte.Items.AddRange(new object[] {
                "1. Ingresos Mensuales (Taller vs Mostrador)",
                "2. Ingresos Detallados por Período",
                "3. Top Servicios Más Solicitados",
                "4. Rendimiento de Técnicos",
                "5. Semáforo de Stock e Inventario",
                "6. Expediente Histórico de Clientes",
                "7. Órdenes y Saldos por Período"
            });
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFechaFin.Value = DateTime.Now;
            cboReporte.SelectedIndex = 0;
            Generar();
        }

        private void cboReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool usaFechas = (cboReporte.SelectedIndex == 1 || cboReporte.SelectedIndex == 6);
            dtpFechaInicio.Enabled = usaFechas;
            dtpFechaFin.Enabled = usaFechas;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Generar();
        }

        private void Generar()
        {
            try
            {
                DataTable dt;
                switch (cboReporte.SelectedIndex)
                {
                    case 0:
                        dt = _bll.ObtenerReporteIngresosMensuales();
                        break;
                    case 1:
                        dt = _bll.ObtenerReporteIngresosPeriodo(dtpFechaInicio.Value, dtpFechaFin.Value);
                        break;
                    case 2:
                        dt = _bll.ObtenerTopServicios();
                        break;
                    case 3:
                        dt = _bll.ObtenerRendimientoTecnicos();
                        break;
                    case 4:
                        dt = _bll.ObtenerStockAlerta();
                        break;
                    case 5:
                        dt = _bll.ObtenerExpedienteClientes();
                        break;
                    default:
                        dt = _bll.ObtenerReporteOrdenesPeriodo(dtpFechaInicio.Value, dtpFechaFin.Value);
                        break;
                }

                dgvReporte.DataSource = dt;
                FormatearMonedas(dt);
                lblResumen.Text = string.Format("Registros encontrados: {0}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearMonedas(DataTable dt)
        {
            string[] colsMoneda = {
                "IngresosServiciosTaller", "IngresosVentasMostrador", "IngresoTotal",
                "Importe", "PrecioBase", "TotalRecaudado", "MontoTotalPresupuestado",
                "CostoReferencia", "PrecioVenta", "ValorInventario", "TotalPagadoHistorico",
                "CostoTotal", "SaldoPendiente"
            };

            foreach (string col in colsMoneda)
            {
                if (dt.Columns.Contains(col) && dgvReporte.Columns[col] != null)
                {
                    dgvReporte.Columns[col].DefaultCellStyle.Format = "C2";
                }
            }
        }
    }
}
