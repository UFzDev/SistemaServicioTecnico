using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmClientes : Form
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private DataTable _dtClientes;
        private DataTable _dtEquipos;
        private int _idClienteSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCatalogosCombo();
                CargarDatosBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de clientes: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCatalogosCombo()
        {
            DataTable dtTipos = _clienteBLL.ObtenerTiposEquipo();
            cboTipoEquipo.DataSource = dtTipos;
            cboTipoEquipo.DisplayMember = "Nombre";
            cboTipoEquipo.ValueMember = "IdTipoEquipo";

            DataTable dtMarcas = _clienteBLL.ObtenerMarcas();
            cboMarca.DataSource = dtMarcas;
            cboMarca.DisplayMember = "Nombre";
            cboMarca.ValueMember = "IdMarca";
        }

        private void CargarDatosBD()
        {
            _dtClientes = _clienteBLL.ObtenerClientes();
            _dtEquipos = _clienteBLL.ObtenerEquipos();

            dgvClientes.DataSource = _dtClientes;
            if (dgvClientes.Columns["IdCliente"] != null)
            {
                dgvClientes.Columns["IdCliente"].HeaderText = "ID";
                dgvClientes.Columns["IdCliente"].FillWeight = 35;
            }
            if (dgvClientes.Columns["Direccion"] != null) dgvClientes.Columns["Direccion"].Visible = false;
            if (dgvClientes.Columns["Correo"] != null) dgvClientes.Columns["Correo"].Visible = false;

            if (_idClienteSeleccionado > 0)
            {
                FiltrarEquiposCliente(_idClienteSeleccionado);
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvClientes.CurrentRow != null ? dgvClientes.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idClienteSeleccionado = Convert.ToInt32(fila["IdCliente"]);
                txtNombre.Text = fila["Nombre"].ToString();
                txtApellidos.Text = fila["Apellidos"].ToString();
                txtTelefono.Text = fila["Telefono"].ToString();
                txtCorreo.Text = fila["Correo"].ToString();
                txtDireccion.Text = fila["Direccion"].ToString();
                chkClienteActivo.Checked = Convert.ToBoolean(fila["Activo"]);

                lblClienteSeleccionadoEquipo.Text = string.Format("Para: {0} {1}", txtNombre.Text, txtApellidos.Text);
                FiltrarEquiposCliente(_idClienteSeleccionado);
            }
        }

        private void FiltrarEquiposCliente(int idCliente)
        {
            if (_dtEquipos == null) return;

            DataView dv = new DataView(_dtEquipos);
            dv.RowFilter = string.Format("IdCliente = {0}", idCliente);
            dgvEquipos.DataSource = dv;

            if (dgvEquipos.Columns["IdEquipo"] != null) dgvEquipos.Columns["IdEquipo"].Visible = false;
            if (dgvEquipos.Columns["IdCliente"] != null) dgvEquipos.Columns["IdCliente"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtClientes == null) return;

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            DataView dv = _dtClientes.DefaultView;

            if (string.IsNullOrEmpty(filtro))
            {
                dv.RowFilter = string.Empty;
            }
            else
            {
                dv.RowFilter = string.Format(
                    "Nombre LIKE '%{0}%' OR Apellidos LIKE '%{0}%' OR Telefono LIKE '%{0}%'",
                    filtro);
            }
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            _idClienteSeleccionado = 0;
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            chkClienteActivo.Checked = true;
            lblClienteSeleccionadoEquipo.Text = "(Nuevo cliente en captura)";
            txtNombre.Focus();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                bool esNuevo = (_idClienteSeleccionado == 0);
                int idGenerado = _clienteBLL.GuardarCliente(
                    _idClienteSeleccionado,
                    txtNombre.Text,
                    txtApellidos.Text,
                    txtTelefono.Text,
                    txtCorreo.Text,
                    txtDireccion.Text,
                    chkClienteActivo.Checked);

                _idClienteSeleccionado = idGenerado;
                CargarDatosBD();

                MessageBox.Show(
                    esNuevo ? "Cliente registrado correctamente en SQL Server." : "Datos del cliente actualizados correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            if (_idClienteSeleccionado == 0)
            {
                MessageBox.Show("Primero seleccione un cliente de la lista inferior para asociarle el equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTipoEquipo.SelectedValue == null || cboMarca.SelectedValue == null)
            {
                MessageBox.Show("Seleccione tipo de equipo y marca.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("El modelo del equipo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelo.Focus();
                return;
            }

            try
            {
                int idTipo = Convert.ToInt32(cboTipoEquipo.SelectedValue);
                int idMarca = Convert.ToInt32(cboMarca.SelectedValue);

                _clienteBLL.GuardarEquipo(
                    0,
                    _idClienteSeleccionado,
                    idTipo,
                    idMarca,
                    txtModelo.Text,
                    txtSerie.Text,
                    txtCaracteristicas.Text,
                    true);

                CargarDatosBD();
                txtModelo.Clear();
                txtSerie.Clear();
                txtCaracteristicas.Clear();

                MessageBox.Show("Equipo vinculado al cliente exitosamente.", "Equipo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
