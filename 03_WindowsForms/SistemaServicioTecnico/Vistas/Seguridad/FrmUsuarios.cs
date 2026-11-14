using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Seguridad
{
    public partial class FrmUsuarios : Form
    {
        private DataTable _dtUsuarios;
        private int _idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cboPuesto.Items.AddRange(new object[] {
                "Administrador",
                "Supervisor",
                "Recepcionista",
                "Tecnico",
                "Auditor"
            });
            cboPuesto.SelectedIndex = 3;

            cboRol.Items.AddRange(new object[] {
                "Administrador",
                "Supervisor",
                "Recepcionista",
                "Tecnico"
            });
            cboRol.SelectedIndex = 3;

            _dtUsuarios = new DataTable();
            _dtUsuarios.Columns.Add("IdUsuario", typeof(int));
            _dtUsuarios.Columns.Add("Empleado", typeof(string));
            _dtUsuarios.Columns.Add("Puesto", typeof(string));
            _dtUsuarios.Columns.Add("Usuario", typeof(string));
            _dtUsuarios.Columns.Add("Rol", typeof(string));
            _dtUsuarios.Columns.Add("Correo", typeof(string));
            _dtUsuarios.Columns.Add("Activo", typeof(bool));

            dgvUsuarios.DataSource = _dtUsuarios;
            if (dgvUsuarios.Columns["IdUsuario"] != null)
            {
                dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                dgvUsuarios.Columns["IdUsuario"].FillWeight = 30;
            }

            Limpiar();
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

            if (_idSeleccionado == 0)
            {
                int nuevoId = _dtUsuarios.Rows.Count + 1;
                _dtUsuarios.Rows.Add(
                    nuevoId,
                    txtEmpleado.Text.Trim(),
                    cboPuesto.SelectedItem.ToString(),
                    txtUsuario.Text.Trim(),
                    cboRol.SelectedItem.ToString(),
                    txtCorreo.Text.Trim(),
                    chkActivo.Checked);

                MessageBox.Show("Usuario y rol registrados correctamente.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                foreach (DataRow fila in _dtUsuarios.Rows)
                {
                    if (Convert.ToInt32(fila["IdUsuario"]) == _idSeleccionado)
                    {
                        fila["Empleado"] = txtEmpleado.Text.Trim();
                        fila["Puesto"] = cboPuesto.SelectedItem.ToString();
                        fila["Usuario"] = txtUsuario.Text.Trim();
                        fila["Rol"] = cboRol.SelectedItem.ToString();
                        fila["Correo"] = txtCorreo.Text.Trim();
                        fila["Activo"] = chkActivo.Checked;
                        break;
                    }
                }
                MessageBox.Show("Datos del usuario actualizados correctamente.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
