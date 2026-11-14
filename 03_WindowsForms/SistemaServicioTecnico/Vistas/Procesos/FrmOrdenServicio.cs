using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmOrdenServicio : Form
    {
        private DataTable _dtOrdenes;
        private string _folioSeleccionado = null;
        private readonly Dictionary<string, string[]> _equiposPorCliente = new Dictionary<string, string[]>();
        private readonly Dictionary<string, decimal> _preciosServicio = new Dictionary<string, decimal>();

        public FrmOrdenServicio()
        {
            InitializeComponent();
        }

        private void FrmOrdenServicio_Load(object sender, EventArgs e)
        {
            InicializarCatalogos();
            InicializarTablaOrdenes();
            PrepararNuevaOrden();
        }

        private void InicializarCatalogos()
        {
            _equiposPorCliente.Clear();
            cboCliente.Items.Clear();

            string[] estados = {
                "Recibida",
                "En Diagnóstico",
                "Presupuestada",
                "Esperando Aprobación",
                "En Reparación",
                "Esperando Refacción",
                "Terminada / Lista",
                "Entregada",
                "Cancelada"
            };

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(estados);

            cboFiltroEstado.Items.Clear();
            cboFiltroEstado.Items.Add("Todos los Estados");
            cboFiltroEstado.Items.AddRange(estados);
            cboFiltroEstado.SelectedIndex = 0;

            _preciosServicio.Clear();
            cboServicioRapido.Items.Clear();

            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void InicializarTablaOrdenes()
        {
            _dtOrdenes = new DataTable();
            _dtOrdenes.Columns.Add("Folio", typeof(string));
            _dtOrdenes.Columns.Add("FechaRecepcion", typeof(string));
            _dtOrdenes.Columns.Add("Cliente", typeof(string));
            _dtOrdenes.Columns.Add("Equipo", typeof(string));
            _dtOrdenes.Columns.Add("FallaReportada", typeof(string));
            _dtOrdenes.Columns.Add("Diagnostico", typeof(string));
            _dtOrdenes.Columns.Add("Estado", typeof(string));
            _dtOrdenes.Columns.Add("Presupuesto", typeof(decimal));
            _dtOrdenes.Columns.Add("FechaPrometida", typeof(string));

            dgvOrdenes.DataSource = _dtOrdenes;
            if (dgvOrdenes.Columns["Diagnostico"] != null) dgvOrdenes.Columns["Diagnostico"].Visible = false;
            if (dgvOrdenes.Columns["Folio"] != null) dgvOrdenes.Columns["Folio"].FillWeight = 65;
            if (dgvOrdenes.Columns["FechaRecepcion"] != null)
            {
                dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Recepción";
                dgvOrdenes.Columns["FechaRecepcion"].FillWeight = 55;
            }
            if (dgvOrdenes.Columns["FechaPrometida"] != null)
            {
                dgvOrdenes.Columns["FechaPrometida"].HeaderText = "Prometida";
                dgvOrdenes.Columns["FechaPrometida"].FillWeight = 55;
            }
            if (dgvOrdenes.Columns["Presupuesto"] != null)
            {
                dgvOrdenes.Columns["Presupuesto"].DefaultCellStyle.Format = "C2";
                dgvOrdenes.Columns["Presupuesto"].FillWeight = 55;
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEquipo.Items.Clear();
            if (cboCliente.SelectedItem != null && _equiposPorCliente.ContainsKey(cboCliente.SelectedItem.ToString()))
            {
                cboEquipo.Items.AddRange(_equiposPorCliente[cboCliente.SelectedItem.ToString()]);
                if (cboEquipo.Items.Count > 0)
                    cboEquipo.SelectedIndex = 0;
            }
        }

        private void cboServicioRapido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServicioRapido.SelectedItem != null)
            {
                string srv = cboServicioRapido.SelectedItem.ToString();
                if (_preciosServicio.ContainsKey(srv))
                {
                    txtPresupuesto.Text = _preciosServicio[srv].ToString("0.00");
                }
            }
        }

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvOrdenes.CurrentRow != null ? dgvOrdenes.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _folioSeleccionado = fila["Folio"].ToString();
                txtFolio.Text = _folioSeleccionado;

                string cliente = fila["Cliente"].ToString();
                if (cboCliente.Items.Contains(cliente))
                    cboCliente.SelectedItem = cliente;

                string equipo = fila["Equipo"].ToString();
                if (cboEquipo.Items.Contains(equipo))
                    cboEquipo.SelectedItem = equipo;

                string estado = fila["Estado"].ToString();
                if (cboEstado.Items.Contains(estado))
                    cboEstado.SelectedItem = estado;

                txtFallaReportada.Text = fila["FallaReportada"].ToString();
                txtDiagnostico.Text = fila["Diagnostico"].ToString();
                txtPresupuesto.Text = Convert.ToDecimal(fila["Presupuesto"]).ToString("0.00");
            }
        }

        private void FiltroOrdenes_Changed(object sender, EventArgs e)
        {
            if (_dtOrdenes == null) return;

            string texto = txtBuscarOrden.Text.Trim().Replace("'", "''");
            string estado = cboFiltroEstado.SelectedItem != null ? cboFiltroEstado.SelectedItem.ToString() : "Todos los Estados";

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                filtro = string.Format("(Folio LIKE '%{0}%' OR Cliente LIKE '%{0}%' OR Equipo LIKE '%{0}%')", texto);
            }

            if (estado != "Todos los Estados")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Estado = '{0}'", estado);
            }

            _dtOrdenes.DefaultView.RowFilter = filtro;
        }

        private void PrepararNuevaOrden()
        {
            _folioSeleccionado = null;
            int siguienteNumero = (_dtOrdenes != null ? _dtOrdenes.Rows.Count : 0) + 1;
            txtFolio.Text = string.Format("OS-2026-{0:D4}", siguienteNumero);
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            dtpFechaPrometida.Value = DateTime.Now.AddDays(2);
            txtFallaReportada.Clear();
            txtDiagnostico.Clear();
            txtPresupuesto.Text = "0.00";
            txtFallaReportada.Focus();
        }

        private void btnLimpiarOrden_Click(object sender, EventArgs e)
        {
            PrepararNuevaOrden();
        }

        private void btnRegistrarOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFallaReportada.Text))
            {
                MessageBox.Show("Debe capturar la falla reportada por el cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFallaReportada.Focus();
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            int siguienteNumero = _dtOrdenes.Rows.Count + 1;
            string nuevoFolio = string.Format("OS-2026-{0:D4}", siguienteNumero);

            _dtOrdenes.Rows.Add(
                nuevoFolio,
                DateTime.Now.ToString("dd/MM/yyyy"),
                cboCliente.SelectedItem != null ? cboCliente.SelectedItem.ToString() : "",
                cboEquipo.SelectedItem != null ? cboEquipo.SelectedItem.ToString() : "",
                txtFallaReportada.Text.Trim(),
                txtDiagnostico.Text.Trim(),
                cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Recibida",
                presupuesto,
                dtpFechaPrometida.Value.ToString("dd/MM/yyyy"));

            MessageBox.Show(
                string.Format("Orden de Servicio [{0}] registrada exitosamente.", nuevoFolio),
                "Orden Creada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            PrepararNuevaOrden();
        }

        private void btnActualizarOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_folioSeleccionado))
            {
                MessageBox.Show("Seleccione primero una orden de la bitácora inferior para actualizar su estado o diagnóstico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            foreach (DataRow fila in _dtOrdenes.Rows)
            {
                if (fila["Folio"].ToString() == _folioSeleccionado)
                {
                    fila["Estado"] = cboEstado.SelectedItem.ToString();
                    fila["FallaReportada"] = txtFallaReportada.Text.Trim();
                    fila["Diagnostico"] = txtDiagnostico.Text.Trim();
                    fila["Presupuesto"] = presupuesto;
                    fila["FechaPrometida"] = dtpFechaPrometida.Value.ToString("dd/MM/yyyy");
                    break;
                }
            }

            MessageBox.Show(
                string.Format("Orden [{0}] actualizada al estado: {1}", _folioSeleccionado, cboEstado.SelectedItem),
                "Actualización Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
