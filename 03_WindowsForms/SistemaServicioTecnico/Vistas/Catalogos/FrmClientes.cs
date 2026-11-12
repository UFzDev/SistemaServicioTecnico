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
            cboTipoEquipo.Items.AddRange(new object[] {
                "Laptop",
                "PC de Escritorio",
                "Smartphone",
                "Tablet",
                "Consola de Videojuegos",
                "Impresora Multifuncional",
                "Monitor",
                "Servidor"
            });
            cboTipoEquipo.SelectedIndex = 0;

            cboMarca.Items.Clear();
            cboMarca.Items.AddRange(new object[] {
                "HP", "Dell", "Lenovo", "Apple", "Samsung", "Asus", "Acer", "Sony"
            });
            cboMarca.SelectedIndex = 0;
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

            // Datos iniciales de muestra basados en 04_DatosIniciales.sql
            _dtClientes.Rows.Add(1, "Alejandro", "Gómez Ruiz", "7712010001", "agomez@gmail.com", "Col. Centro, Pachuca, Hgo.", true);
            _dtClientes.Rows.Add(2, "Mariana", "Torres Domínguez", "7712010002", "mtorres@gmail.com", "Fracc. Constitución, Pachuca", true);
            _dtClientes.Rows.Add(3, "Javier", "Herrera Bravo", "7712010003", "jherrera@hotmail.com", "Col. Morelos, Pachuca", true);
            _dtClientes.Rows.Add(4, "Sofía", "Camacho Solís", "7712010004", "scamacho@yahoo.com", "Col. Periodistas, Pachuca", true);
            _dtClientes.Rows.Add(5, "Ricardo", "Salazar Peña", "7712010005", "rsalazar@gmail.com", "Real del Monte, Hgo.", true);
            _dtClientes.Rows.Add(6, "Gabriela", "Fuentes Meza", "7712010006", "gfuentes@outlook.com", "Col. Venta Prieta, Pachuca", true);

            _dtEquipos = new DataTable();
            _dtEquipos.Columns.Add("IdEquipo", typeof(int));
            _dtEquipos.Columns.Add("IdCliente", typeof(int));
            _dtEquipos.Columns.Add("Tipo", typeof(string));
            _dtEquipos.Columns.Add("Marca", typeof(string));
            _dtEquipos.Columns.Add("Modelo", typeof(string));
            _dtEquipos.Columns.Add("Serie", typeof(string));
            _dtEquipos.Columns.Add("Caracteristicas", typeof(string));

            _dtEquipos.Rows.Add(1, 1, "Laptop", "HP", "Pavilion 15-dk0020la", "5CD9321ABC", "Core i5 9th, 8GB RAM, GTX 1050");
            _dtEquipos.Rows.Add(2, 1, "Smartphone", "Samsung", "Galaxy S21 Ultra", "R58M901XYZ", "128GB Negro Fantasma");
            _dtEquipos.Rows.Add(3, 2, "Laptop", "Dell", "Inspiron 3501", "8HK2199KLM", "Core i3 10th, 4GB RAM, SSD 256GB");
            _dtEquipos.Rows.Add(4, 2, "Tablet", "Apple", "iPad Air 4ta Gen", "DMPZ1990OPQ", "64GB Wi-Fi Gris Espacial");
            _dtEquipos.Rows.Add(5, 3, "PC de Escritorio", "Asus", "ROG Strix G15", "K9N01234ASU", "Ryzen 7 5800X, 16GB RAM, RTX 3060");
            _dtEquipos.Rows.Add(6, 4, "Laptop", "Lenovo", "ThinkPad T14 Gen 2", "PF299901LEN", "Core i7 11th, 16GB RAM");
            _dtEquipos.Rows.Add(7, 5, "Consola de Videojuegos", "Sony", "PlayStation 5 Standard", "FC102938475", "Edición disco 825GB");
            _dtEquipos.Rows.Add(8, 6, "Laptop", "Apple", "MacBook Air M1 2020", "C02F9812APL", "Chip M1, 8GB RAM, 256GB SSD");

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
                cboTipoEquipo.SelectedItem.ToString(),
                cboMarca.SelectedItem.ToString(),
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
