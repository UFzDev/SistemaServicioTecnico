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

            _dtProveedores.Rows.Add("Mayorista Tecnológico de México", "MTM120315ABC", "Roberto Fuentes", "5551234501");
            _dtProveedores.Rows.Add("CT Internacional del Noroeste", "CIN940212XYZ", "Laura Bernal", "5551234502");
            _dtProveedores.Rows.Add("Ingram Micro México", "IMM980614123", "Mauricio Garza", "5551234503");
            _dtProveedores.Rows.Add("Grupo CVA Mayorista", "CVA010520890", "Estela Rivas", "5551234504");
            _dtProveedores.Rows.Add("Distribuidora de Pantallas y Displays", "DPD160418RTY", "Miguel Ángel León", "5551234507");

            dgvProveedores.DataSource = _dtProveedores;

            ActualizarComboProveedores();

            cboRefaccionCompra.Items.AddRange(new object[] {
                "SSD Kingston A400 480GB SATA3",
                "SSD Kingston NV2 1TB M.2 NVMe",
                "Memoria RAM Kingston Fury 8GB DDR4",
                "Display 15.6 Slim FHD 30 Pines IPS",
                "Batería Original HP HT03XL",
                "Pasta Térmica Arctic MX-4 4g"
            });
            cboRefaccionCompra.SelectedIndex = 0;

            _dtCompras = new DataTable();
            _dtCompras.Columns.Add("Folio", typeof(string));
            _dtCompras.Columns.Add("Fecha", typeof(string));
            _dtCompras.Columns.Add("Proveedor", typeof(string));
            _dtCompras.Columns.Add("Refaccion", typeof(string));
            _dtCompras.Columns.Add("Cant", typeof(int));
            _dtCompras.Columns.Add("Total", typeof(decimal));

            _dtCompras.Rows.Add("CMP-2026-0001", "05/11/2026", "Mayorista Tecnológico de México", "SSD Kingston A400 480GB SATA3", 10, 4800.00m);
            _dtCompras.Rows.Add("CMP-2026-0002", "07/11/2026", "Grupo CVA Mayorista", "Memoria RAM Kingston Fury 8GB DDR4", 12, 4560.00m);
            _dtCompras.Rows.Add("CMP-2026-0003", "10/11/2026", "Distribuidora de Pantallas y Displays", "Display 15.6 Slim FHD 30 Pines IPS", 4, 3800.00m);

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
            int sig = (_dtCompras != null ? _dtCompras.Rows.Count : 3) + 1;
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
                cboProveedorCompra.SelectedItem.ToString(),
                cboRefaccionCompra.SelectedItem.ToString(),
                cant,
                total);

            MessageBox.Show(string.Format("Orden de compra [{0}] registrada por {1:C2}.", folio, total), "Compra Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PrepararFolioCompra();
        }
    }
}
