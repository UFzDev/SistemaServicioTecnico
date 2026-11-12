using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmRefacciones : Form
    {
        private DataTable _dtRefacciones;
        private int _idSeleccionado = 0;

        public FrmRefacciones()
        {
            InitializeComponent();
        }

        private void FrmRefacciones_Load(object sender, EventArgs e)
        {
            string[] categorias = {
                "Almacenamiento (SSD / HDD)",
                "Memoria RAM",
                "Pantallas y Displays",
                "Baterías y Cargadores",
                "Teclados y Touchpads",
                "Fuentes de Poder",
                "Ventiladores y Disipadores",
                "Pastas Térmicas e Insumos"
            };

            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(categorias);
            cboCategoria.SelectedIndex = 0;

            cboFiltroCategoria.Items.Clear();
            cboFiltroCategoria.Items.Add("Todas las Categorías");
            cboFiltroCategoria.Items.AddRange(categorias);
            cboFiltroCategoria.SelectedIndex = 0;

            _dtRefacciones = new DataTable();
            _dtRefacciones.Columns.Add("IdRefaccion", typeof(int));
            _dtRefacciones.Columns.Add("SKU", typeof(string));
            _dtRefacciones.Columns.Add("Categoria", typeof(string));
            _dtRefacciones.Columns.Add("Nombre", typeof(string));
            _dtRefacciones.Columns.Add("Costo", typeof(decimal));
            _dtRefacciones.Columns.Add("PrecioVenta", typeof(decimal));
            _dtRefacciones.Columns.Add("Existencia", typeof(int));
            _dtRefacciones.Columns.Add("StockMinimo", typeof(int));
            _dtRefacciones.Columns.Add("Descripcion", typeof(string));
            _dtRefacciones.Columns.Add("Activo", typeof(bool));

            _dtRefacciones.Rows.Add(1, "SSD-KING-480", "Almacenamiento (SSD / HDD)", "SSD Kingston A400 480GB SATA3", 480.00m, 790.00m, 14, 5, "Unidad de estado sólido 2.5 pulgadas", true);
            _dtRefacciones.Rows.Add(2, "SSD-NVME-1TB", "Almacenamiento (SSD / HDD)", "SSD Kingston NV2 1TB M.2 NVMe", 890.00m, 1380.00m, 8, 3, "PCIe 4.0 NVMe M.2 2280", true);
            _dtRefacciones.Rows.Add(3, "RAM-DDR4-8G", "Memoria RAM", "Memoria RAM Kingston Fury 8GB DDR4 3200MHz", 380.00m, 650.00m, 18, 5, "SO-DIMM para Laptop", true);
            _dtRefacciones.Rows.Add(4, "DSP-156-FHD", "Pantallas y Displays", "Display 15.6 Slim FHD 30 Pines IPS", 950.00m, 1650.00m, 3, 4, "Compatible con HP, Dell y Lenovo", true);
            _dtRefacciones.Rows.Add(5, "BAT-HP-HT03", "Baterías y Cargadores", "Batería Original HP HT03XL Pavilion 15", 620.00m, 1100.00m, 2, 3, "Li-Ion 11.55V 41.9Wh", true);
            _dtRefacciones.Rows.Add(6, "CRG-UNIV-65W", "Baterías y Cargadores", "Cargador USB-C 65W Multimarca", 320.00m, 580.00m, 10, 4, "Entrega de potencia PD 65W", true);
            _dtRefacciones.Rows.Add(7, "INS-MX4-4G", "Pastas Térmicas e Insumos", "Pasta Térmica Arctic MX-4 Jeringa 4g", 110.00m, 220.00m, 22, 6, "Alta conductividad térmica", true);

            dgvRefacciones.DataSource = _dtRefacciones;
            if (dgvRefacciones.Columns["IdRefaccion"] != null) dgvRefacciones.Columns["IdRefaccion"].Visible = false;
            if (dgvRefacciones.Columns["Descripcion"] != null) dgvRefacciones.Columns["Descripcion"].Visible = false;
            if (dgvRefacciones.Columns["Costo"] != null) dgvRefacciones.Columns["Costo"].DefaultCellStyle.Format = "C2";
            if (dgvRefacciones.Columns["PrecioVenta"] != null)
            {
                dgvRefacciones.Columns["PrecioVenta"].HeaderText = "Precio Venta";
                dgvRefacciones.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            }
            if (dgvRefacciones.Columns["StockMinimo"] != null) dgvRefacciones.Columns["StockMinimo"].HeaderText = "Mínimo";

            Limpiar();
        }

        private void dgvRefacciones_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvRefacciones.CurrentRow != null ? dgvRefacciones.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idSeleccionado = Convert.ToInt32(fila["IdRefaccion"]);
                txtSKU.Text = fila["SKU"].ToString();
                string cat = fila["Categoria"].ToString();
                if (cboCategoria.Items.Contains(cat)) cboCategoria.SelectedItem = cat;
                txtNombre.Text = fila["Nombre"].ToString();
                txtCosto.Text = Convert.ToDecimal(fila["Costo"]).ToString("0.00");
                txtPrecioVenta.Text = Convert.ToDecimal(fila["PrecioVenta"]).ToString("0.00");
                txtExistencia.Text = fila["Existencia"].ToString();
                txtStockMinimo.Text = fila["StockMinimo"].ToString();
                txtDescripcion.Text = fila["Descripcion"].ToString();
                chkActivo.Checked = Convert.ToBoolean(fila["Activo"]);
            }
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (_dtRefacciones == null) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");
            string cat = cboFiltroCategoria.SelectedItem != null ? cboFiltroCategoria.SelectedItem.ToString() : "Todas las Categorías";

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
                filtro = string.Format("(SKU LIKE '%{0}%' OR Nombre LIKE '%{0}%')", texto);

            if (cat != "Todas las Categorías")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Categoria = '{0}'", cat);
            }

            _dtRefacciones.DefaultView.RowFilter = filtro;
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            txtSKU.Text = string.Format("REF-00{0}", (_dtRefacciones != null ? _dtRefacciones.Rows.Count : 7) + 1);
            txtNombre.Clear();
            txtCosto.Text = "300.00";
            txtPrecioVenta.Text = "550.00";
            txtExistencia.Text = "5";
            txtStockMinimo.Text = "2";
            txtDescripcion.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSKU.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El SKU y el Nombre de la refacción son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal costo = 0, precio = 0;
            int existencia = 0, minimo = 0;
            decimal.TryParse(txtCosto.Text, out costo);
            decimal.TryParse(txtPrecioVenta.Text, out precio);
            int.TryParse(txtExistencia.Text, out existencia);
            int.TryParse(txtStockMinimo.Text, out minimo);

            if (_idSeleccionado == 0)
            {
                int nuevoId = _dtRefacciones.Rows.Count + 1;
                _dtRefacciones.Rows.Add(
                    nuevoId,
                    txtSKU.Text.Trim(),
                    cboCategoria.SelectedItem.ToString(),
                    txtNombre.Text.Trim(),
                    costo, precio, existencia, minimo,
                    txtDescripcion.Text.Trim(),
                    chkActivo.Checked);

                MessageBox.Show("Refacción agregada al inventario exitosamente.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                foreach (DataRow fila in _dtRefacciones.Rows)
                {
                    if (Convert.ToInt32(fila["IdRefaccion"]) == _idSeleccionado)
                    {
                        fila["SKU"] = txtSKU.Text.Trim();
                        fila["Categoria"] = cboCategoria.SelectedItem.ToString();
                        fila["Nombre"] = txtNombre.Text.Trim();
                        fila["Costo"] = costo;
                        fila["PrecioVenta"] = precio;
                        fila["Existencia"] = existencia;
                        fila["StockMinimo"] = minimo;
                        fila["Descripcion"] = txtDescripcion.Text.Trim();
                        fila["Activo"] = chkActivo.Checked;
                        break;
                    }
                }
                MessageBox.Show("Inventario de la refacción actualizado correctamente.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
