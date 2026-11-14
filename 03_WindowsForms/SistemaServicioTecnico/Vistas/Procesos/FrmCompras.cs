using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmCompras : Form
    {
        private DataTable _dtProveedores;
        private DataTable _dtCompras;

        public FrmCompras()
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            _dtProveedores = new DataTable();
            _dtProveedores.Columns.Add("Empresa", typeof(string));
            _dtProveedores.Columns.Add("RFC", typeof(string));
            _dtProveedores.Columns.Add("Contacto", typeof(string));
            _dtProveedores.Columns.Add("Telefono", typeof(string));

            dgvProveedores.DataSource = _dtProveedores;

            ActualizarComboProveedores();

            cboRefaccionCompra.Items.Clear();

            _dtCompras = new DataTable();
            _dtCompras.Columns.Add("Folio", typeof(string));
            _dtCompras.Columns.Add("Fecha", typeof(string));
            _dtCompras.Columns.Add("Proveedor", typeof(string));
            _dtCompras.Columns.Add("Refaccion", typeof(string));
            _dtCompras.Columns.Add("Cant", typeof(int));
            _dtCompras.Columns.Add("Total", typeof(decimal));

            dgvCompras.DataSource = _dtCompras;
            if (dgvCompras.Columns["Total"] != null) dgvCompras.Columns["Total"].DefaultCellStyle.Format = "C2";

            PrepararFolioCompra();
        }

        private void ActualizarComboProveedores()
        {
            cboProveedorCompra.Items.Clear();
            foreach (DataRow fila in _dtProveedores.Rows)
            {
                cboProveedorCompra.Items.Add(fila["Empresa"].ToString());
            }
            if (cboProveedorCompra.Items.Count > 0) cboProveedorCompra.SelectedIndex = 0;
        }

        private void PrepararFolioCompra()
        {
            int sig = (_dtCompras != null ? _dtCompras.Rows.Count : 0) + 1;
            txtFolioCompra.Text = string.Format("CMP-2026-{0:D4}", sig);
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProv.Text))
            {
                MessageBox.Show("El nombre de la empresa proveedora es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dtProveedores.Rows.Add(
                txtNombreProv.Text.Trim(),
                txtRFCProv.Text.Trim(),
                txtContactoProv.Text.Trim(),
                txtTelProv.Text.Trim());

            ActualizarComboProveedores();
            txtNombreProv.Clear();
            txtRFCProv.Clear();
            txtContactoProv.Clear();
            txtTelProv.Clear();

            MessageBox.Show("Proveedor registrado exitosamente.", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            int cant = 1;
            decimal costo = 0;
            int.TryParse(txtCantidadCompra.Text, out cant);
            decimal.TryParse(txtCostoUnitario.Text, out costo);
            if (cant <= 0) cant = 1;

            decimal total = cant * costo;
            string folio = txtFolioCompra.Text;

            _dtCompras.Rows.Add(
                folio,
                DateTime.Now.ToString("dd/MM/yyyy"),
                cboProveedorCompra.SelectedItem != null ? cboProveedorCompra.SelectedItem.ToString() : "",
                cboRefaccionCompra.SelectedItem != null ? cboRefaccionCompra.SelectedItem.ToString() : "",
                cant,
                total);

            MessageBox.Show(string.Format("Orden de compra [{0}] registrada por {1:C2}.", folio, total), "Compra Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PrepararFolioCompra();
        }
    }
}
