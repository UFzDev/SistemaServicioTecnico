using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmOrdenServicio : Form
    {
        private readonly OrdenServicioBLL _ordenBLL = new OrdenServicioBLL();
        private readonly int _idUsuarioActual;
        private DataTable _dtOrdenes;
        private DataTable _dtServiciosRapidos;
        private int _idOrdenSeleccionada = 0;
        private string _folioSeleccionado = null;

        public FrmOrdenServicio() : this(1)
        {
        }

        public FrmOrdenServicio(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmOrdenServicio_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarCatalogos();
                CargarOrdenes();
                PrepararNuevaOrden();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar órdenes de servicio: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarCatalogos()
        {
            DataTable dtClientes = _ordenBLL.ObtenerClientesCombo();
            cboCliente.DataSource = dtClientes;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "IdCliente";

            DataTable dtEstados = _ordenBLL.ObtenerEstadosOrden();
            cboEstado.DataSource = dtEstados;
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "IdEstadoOrden";

            DataTable dtFiltroEstados = dtEstados.Copy();
            DataRow filaTodos = dtFiltroEstados.NewRow();
            filaTodos["IdEstadoOrden"] = 0;
            filaTodos["Nombre"] = "Todos los Estados";
            dtFiltroEstados.Rows.InsertAt(filaTodos, 0);

            cboFiltroEstado.DataSource = dtFiltroEstados;
            cboFiltroEstado.DisplayMember = "Nombre";
            cboFiltroEstado.ValueMember = "IdEstadoOrden";
            cboFiltroEstado.SelectedIndex = 0;

            _dtServiciosRapidos = _ordenBLL.ObtenerServiciosRapidos();
            cboServicioRapido.DataSource = _dtServiciosRapidos;
            cboServicioRapido.DisplayMember = "Nombre";
            cboServicioRapido.ValueMember = "IdServicio";
        }

        private void CargarOrdenes()
        {
            _dtOrdenes = _ordenBLL.ObtenerOrdenes();
            dgvOrdenes.DataSource = _dtOrdenes;

            if (dgvOrdenes.Columns["IdOrdenServicio"] != null) dgvOrdenes.Columns["IdOrdenServicio"].Visible = false;
            if (dgvOrdenes.Columns["IdCliente"] != null) dgvOrdenes.Columns["IdCliente"].Visible = false;
            if (dgvOrdenes.Columns["IdEquipo"] != null) dgvOrdenes.Columns["IdEquipo"].Visible = false;
            if (dgvOrdenes.Columns["IdEstadoOrden"] != null) dgvOrdenes.Columns["IdEstadoOrden"].Visible = false;
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
            if (cboCliente.SelectedValue == null || cboCliente.SelectedValue is DataRowView)
                return;

            int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
            DataTable dtEquipos = _ordenBLL.ObtenerEquiposPorClienteCombo(idCliente);
            cboEquipo.DataSource = dtEquipos;
            cboEquipo.DisplayMember = "DescripcionEquipo";
            cboEquipo.ValueMember = "IdEquipo";
        }

        private void cboServicioRapido_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = cboServicioRapido.SelectedItem as DataRowView;
            if (drv != null && drv.Row["PrecioBase"] != DBNull.Value)
            {
                txtPresupuesto.Text = Convert.ToDecimal(drv.Row["PrecioBase"]).ToString("0.00");
            }
        }

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvOrdenes.CurrentRow != null ? dgvOrdenes.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idOrdenSeleccionada = Convert.ToInt32(fila["IdOrdenServicio"]);
                _folioSeleccionado = fila["Folio"].ToString();
                txtFolio.Text = _folioSeleccionado;

                if (fila["IdCliente"] != DBNull.Value)
                    cboCliente.SelectedValue = Convert.ToInt32(fila["IdCliente"]);

                if (fila["IdEquipo"] != DBNull.Value)
                    cboEquipo.SelectedValue = Convert.ToInt32(fila["IdEquipo"]);

                if (fila["IdEstadoOrden"] != DBNull.Value)
                    cboEstado.SelectedValue = Convert.ToInt32(fila["IdEstadoOrden"]);

                txtFallaReportada.Text = fila["FallaReportada"].ToString();
                txtDiagnostico.Text = fila["Diagnostico"].ToString();
                txtPresupuesto.Text = Convert.ToDecimal(fila["Presupuesto"]).ToString("0.00");

                DateTime fechaProm;
                if (DateTime.TryParseExact(fila["FechaPrometida"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaProm))
                {
                    dtpFechaPrometida.Value = fechaProm;
                }
            }
        }

        private void FiltroOrdenes_Changed(object sender, EventArgs e)
        {
            if (_dtOrdenes == null) return;

            string texto = txtBuscarOrden.Text.Trim().Replace("'", "''");
            string estado = cboFiltroEstado.Text;

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                filtro = string.Format("(Folio LIKE '%{0}%' OR Cliente LIKE '%{0}%' OR Equipo LIKE '%{0}%')", texto);
            }

            if (!string.IsNullOrEmpty(estado) && estado != "Todos los Estados")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Estado = '{0}'", estado.Replace("'", "''"));
            }

            _dtOrdenes.DefaultView.RowFilter = filtro;
        }

        private void PrepararNuevaOrden()
        {
            _idOrdenSeleccionada = 0;
            _folioSeleccionado = null;
            txtFolio.Text = _ordenBLL.ObtenerSiguienteFolio();
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
            if (cboCliente.SelectedValue == null || cboEquipo.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente y un equipo asociado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFallaReportada.Text))
            {
                MessageBox.Show("Debe capturar la falla reportada por el cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFallaReportada.Focus();
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            try
            {
                string nuevoFolio = _ordenBLL.ObtenerSiguienteFolio();
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                int idEquipo = Convert.ToInt32(cboEquipo.SelectedValue);
                int idServicio = (cboServicioRapido.SelectedValue != null && !(cboServicioRapido.SelectedValue is DataRowView))
                    ? Convert.ToInt32(cboServicioRapido.SelectedValue)
                    : 0;

                _ordenBLL.RegistrarOrden(
                    nuevoFolio,
                    idCliente,
                    idEquipo,
                    _idUsuarioActual,
                    txtFallaReportada.Text,
                    txtDiagnostico.Text,
                    presupuesto,
                    dtpFechaPrometida.Value,
                    idServicio);

                CargarOrdenes();
                PrepararNuevaOrden();

                MessageBox.Show(
                    string.Format("Orden de Servicio [{0}] registrada exitosamente en SQL Server.", nuevoFolio),
                    "Orden Creada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarOrden_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada <= 0 || string.IsNullOrEmpty(_folioSeleccionado))
            {
                MessageBox.Show("Seleccione primero una orden de la bitácora inferior para actualizar su estado o diagnóstico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un estado válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            try
            {
                int idNuevoEstado = Convert.ToInt32(cboEstado.SelectedValue);
                _ordenBLL.ActualizarOrden(
                    _idOrdenSeleccionada,
                    idNuevoEstado,
                    _idUsuarioActual,
                    txtFallaReportada.Text,
                    txtDiagnostico.Text,
                    presupuesto,
                    dtpFechaPrometida.Value);

                string folioActualizado = _folioSeleccionado;
                string estadoTexto = cboEstado.Text;
                CargarOrdenes();

                MessageBox.Show(
                    string.Format("Orden [{0}] actualizada al estado: {1}", folioActualizado, estadoTexto),
                    "Actualización Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
