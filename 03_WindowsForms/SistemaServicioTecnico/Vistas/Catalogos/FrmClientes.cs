using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmClientes : Form
    {
        private DataTable _dtClientes;
        private DataTable _dtEquipos;
        private int _idClienteSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarCatalogosCombo();
            InicializarTablas();
        }

        private void CargarCatalogosCombo()
        {
            cboTipoEquipo.Items.Clear();
            cboMarca.Items.Clear();
        }

        private void InicializarTablas()
        {
            _dtClientes = new DataTable();
            _dtClientes.Columns.Add("IdCliente", typeof(int));
            _dtClientes.Columns.Add("Nombre", typeof(string));
            _dtClientes.Columns.Add("Apellidos", typeof(string));
            _dtClientes.Columns.Add("Telefono", typeof(string));
            _dtClientes.Columns.Add("Correo", typeof(string));
            _dtClientes.Columns.Add("Direccion", typeof(string));
            _dtClientes.Columns.Add("Activo", typeof(bool));

            _dtEquipos = new DataTable();
            _dtEquipos.Columns.Add("IdEquipo", typeof(int));
            _dtEquipos.Columns.Add("IdCliente", typeof(int));
            _dtEquipos.Columns.Add("Tipo", typeof(string));
            _dtEquipos.Columns.Add("Marca", typeof(string));
            _dtEquipos.Columns.Add("Modelo", typeof(string));
            _dtEquipos.Columns.Add("Serie", typeof(string));
            _dtEquipos.Columns.Add("Caracteristicas", typeof(string));

            dgvClientes.DataSource = _dtClientes;
            if (dgvClientes.Columns["IdCliente"] != null) dgvClientes.Columns["IdCliente"].HeaderText = "ID";
            if (dgvClientes.Columns["IdCliente"] != null) dgvClientes.Columns["IdCliente"].FillWeight = 35;
            if (dgvClientes.Columns["Direccion"] != null) dgvClientes.Columns["Direccion"].Visible = false;
            if (dgvClientes.Columns["Correo"] != null) dgvClientes.Columns["Correo"].Visible = false;
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

            if (_idClienteSeleccionado == 0)
            {
                int nuevoId = _dtClientes.Rows.Count + 1;
                _dtClientes.Rows.Add(
                    nuevoId,
                    txtNombre.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    chkClienteActivo.Checked);

                MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow fila in _dtClientes.Rows)
                {
                    if (Convert.ToInt32(fila["IdCliente"]) == _idClienteSeleccionado)
                    {
                        fila["Nombre"] = txtNombre.Text.Trim();
                        fila["Apellidos"] = txtApellidos.Text.Trim();
                        fila["Telefono"] = txtTelefono.Text.Trim();
                        fila["Correo"] = txtCorreo.Text.Trim();
                        fila["Direccion"] = txtDireccion.Text.Trim();
                        fila["Activo"] = chkClienteActivo.Checked;
                        break;
                    }
                }
                MessageBox.Show("Datos del cliente actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            if (_idClienteSeleccionado == 0)
            {
                MessageBox.Show("Primero seleccione un cliente de la lista inferior para asociarle el equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("El modelo del equipo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelo.Focus();
                return;
            }

            int nuevoIdEquipo = _dtEquipos.Rows.Count + 1;
            _dtEquipos.Rows.Add(
                nuevoIdEquipo,
                _idClienteSeleccionado,
                cboTipoEquipo.SelectedItem != null ? cboTipoEquipo.SelectedItem.ToString() : "",
                cboMarca.SelectedItem != null ? cboMarca.SelectedItem.ToString() : "",
                txtModelo.Text.Trim(),
                txtSerie.Text.Trim(),
                txtCaracteristicas.Text.Trim());

            FiltrarEquiposCliente(_idClienteSeleccionado);
            txtModelo.Clear();
            txtSerie.Clear();
            txtCaracteristicas.Clear();

            MessageBox.Show("Equipo vinculado al cliente exitosamente.", "Equipo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
