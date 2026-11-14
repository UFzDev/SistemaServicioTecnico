using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Seguridad
{
    public partial class FrmUsuarios : Form
    {
        private readonly SeguridadBLL _seguridadBLL = new SeguridadBLL();
        private DataTable _dtUsuarios;
        private int _idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cboPuesto.Items.Clear();
                cboPuesto.Items.AddRange(new object[] {
                    "Administrador",
                    "Supervisor",
                    "Recepcionista",
                    "Tecnico",
                    "Auditor"
                });
                cboPuesto.SelectedIndex = 3;

                cboRol.Items.Clear();
                cboRol.Items.AddRange(new object[] {
                    "Administrador",
                    "Supervisor",
                    "Recepcionista",
                    "Tecnico"
                });
                cboRol.SelectedIndex = 3;

                CargarUsuarios();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            _dtUsuarios = _seguridadBLL.ObtenerUsuarios();
            dgvUsuarios.DataSource = _dtUsuarios;
            if (dgvUsuarios.Columns["IdUsuario"] != null)
            {
                dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                dgvUsuarios.Columns["IdUsuario"].FillWeight = 30;
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvUsuarios.CurrentRow != null ? dgvUsuarios.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idSeleccionado = Convert.ToInt32(fila["IdUsuario"]);
                txtEmpleado.Text = fila["Empleado"].ToString();
                string puesto = fila["Puesto"].ToString();
                if (cboPuesto.Items.Contains(puesto)) cboPuesto.SelectedItem = puesto;
                txtUsuario.Text = fila["Usuario"].ToString();
                string rol = fila["Rol"].ToString();
                if (cboRol.Items.Contains(rol)) cboRol.SelectedItem = rol;
                txtCorreo.Text = fila["Correo"].ToString();
                txtContrasena.Clear();
                chkActivo.Checked = Convert.ToBoolean(fila["Activo"]);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtUsuarios == null) return;
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            _dtUsuarios.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                ? ""
                : string.Format("Empleado LIKE '%{0}%' OR Usuario LIKE '%{0}%' OR Rol LIKE '%{0}%'", filtro);
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            txtEmpleado.Clear();
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            chkActivo.Checked = true;
            txtEmpleado.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpleado.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre del empleado y su usuario de acceso son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool esNuevo = (_idSeleccionado == 0);
                string puesto = cboPuesto.SelectedItem != null ? cboPuesto.SelectedItem.ToString() : "Tecnico";
                string rol = cboRol.SelectedItem != null ? cboRol.SelectedItem.ToString() : "Tecnico";

                _seguridadBLL.GuardarUsuario(
                    _idSeleccionado,
                    txtEmpleado.Text,
                    puesto,
                    txtUsuario.Text,
                    txtContrasena.Text,
                    rol,
                    txtCorreo.Text,
                    chkActivo.Checked);

                CargarUsuarios();
                if (esNuevo) Limpiar();

                MessageBox.Show(
                    esNuevo ? "Usuario y rol registrados correctamente en SQL Server." : "Datos del usuario actualizados correctamente.",
                    "Seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
