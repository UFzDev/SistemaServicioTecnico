using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmHistorial : Form
    {
        private readonly OperacionesTallerBLL _tallerBLL = new OperacionesTallerBLL();
        private readonly OrdenServicioBLL _ordenBLL = new OrdenServicioBLL();
        private DataTable _dtHistorial;

        public FrmHistorial()
        {
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarHistorialGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            DataTable dtEstados = _ordenBLL.ObtenerEstadosOrden();
            DataRow filaTodos = dtEstados.NewRow();
            filaTodos["IdEstadoOrden"] = 0;
            filaTodos["Nombre"] = "Todos";
            dtEstados.Rows.InsertAt(filaTodos, 0);

            cboEstado.DataSource = dtEstados;
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "IdEstadoOrden";
            cboEstado.SelectedIndex = 0;

            DataTable dtClientes = _ordenBLL.ObtenerClientesCombo();
            DataRow filaCli = dtClientes.NewRow();
            filaCli["IdCliente"] = 0;
            filaCli["NombreCompleto"] = "Todos los Clientes";
            dtClientes.Rows.InsertAt(filaCli, 0);

            cboCliente.DataSource = dtClientes;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "IdCliente";
            cboCliente.SelectedIndex = 0;
        }

        private void CargarHistorialGeneral()
        {
            _dtHistorial = _tallerBLL.ObtenerHistorialTickets();
            dgvHistorial.DataSource = _dtHistorial;
            FormatearColumnas();
        }

        private void FormatearColumnas()
        {
            if (dgvHistorial.Columns["IdOrdenServicio"] != null)
                dgvHistorial.Columns["IdOrdenServicio"].Visible = false;

            string[] colsMoneda = { "TotalServicios", "TotalRefacciones", "Total", "Pagado", "Saldo", "TotalCalculado", "SaldoPendiente" };
            foreach (string col in colsMoneda)
            {
                if (dgvHistorial.Columns[col] != null)
                    dgvHistorial.Columns[col].DefaultCellStyle.Format = "C2";
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            if (_dtHistorial == null) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");
            string estado = cboEstado.Text;

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                if (_dtHistorial.Columns.Contains("Cliente"))
                    filtro = string.Format("(Folio LIKE '%{0}%' OR Cliente LIKE '%{0}%' OR NumeroSerie LIKE '%{0}%' OR Dispositivo LIKE '%{0}%')", texto);
                else
                    filtro = string.Format("(Folio LIKE '%{0}%' OR NumeroSerie LIKE '%{0}%' OR Dispositivo LIKE '%{0}%')", texto);
            }

            if (!string.IsNullOrEmpty(estado) && estado != "Todos" && _dtHistorial.Columns.Contains("EstadoOrden"))
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("EstadoOrden = '{0}'", estado.Replace("'", "''"));
            }

            _dtHistorial.DefaultView.RowFilter = filtro;
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue == null || cboCliente.SelectedValue is DataRowView)
                return;

            int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
            if (idCliente == 0)
            {
                lblClasificacion.Text = "Nivel: -";
                CargarHistorialGeneral();
                Filtros_Changed(null, EventArgs.Empty);
            }
            else
            {
                try
                {
                    lblClasificacion.Text = "Nivel: " + _tallerBLL.ObtenerClasificacionCliente(idCliente);
                    DataTable dtCli = _tallerBLL.ObtenerHistorialPorCliente(idCliente);
                    _dtHistorial = dtCli;
                    dgvHistorial.DataSource = _dtHistorial;
                    FormatearColumnas();
                    Filtros_Changed(null, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
