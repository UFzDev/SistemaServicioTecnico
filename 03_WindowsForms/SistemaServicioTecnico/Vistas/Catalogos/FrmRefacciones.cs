using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmRefacciones : Form
    {
        private readonly RefaccionBLL _refaccionBLL = new RefaccionBLL();
        private readonly int _idUsuarioActual;
        private DataTable _dtRefacciones;
        private int _idSeleccionado = 0;

        public FrmRefacciones() : this(1)
        {
        }

        public FrmRefacciones(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
        }

        private void FrmRefacciones_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCategorias();
                CargarRefacciones();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar refacciones: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            DataTable dtCats = _refaccionBLL.ObtenerCategorias();
            cboCategoria.DataSource = dtCats;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoriaRefaccion";

            DataTable dtFiltro = dtCats.Copy();
            DataRow filaTodas = dtFiltro.NewRow();
            filaTodas["IdCategoriaRefaccion"] = 0;
            filaTodas["Nombre"] = "Todas las Categorías";
            dtFiltro.Rows.InsertAt(filaTodas, 0);

            cboFiltroCategoria.DataSource = dtFiltro;
            cboFiltroCategoria.DisplayMember = "Nombre";
            cboFiltroCategoria.ValueMember = "IdCategoriaRefaccion";
            cboFiltroCategoria.SelectedIndex = 0;
        }

        private void CargarRefacciones()
        {
            _dtRefacciones = _refaccionBLL.ObtenerRefacciones();
            dgvRefacciones.DataSource = _dtRefacciones;

            if (dgvRefacciones.Columns["IdRefaccion"] != null) dgvRefacciones.Columns["IdRefaccion"].Visible = false;
            if (dgvRefacciones.Columns["IdCategoriaRefaccion"] != null) dgvRefacciones.Columns["IdCategoriaRefaccion"].Visible = false;
            if (dgvRefacciones.Columns["Descripcion"] != null) dgvRefacciones.Columns["Descripcion"].Visible = false;
            if (dgvRefacciones.Columns["Costo"] != null) dgvRefacciones.Columns["Costo"].DefaultCellStyle.Format = "C2";
            if (dgvRefacciones.Columns["PrecioVenta"] != null)
            {
                dgvRefacciones.Columns["PrecioVenta"].HeaderText = "Precio Venta";
                dgvRefacciones.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            }
            if (dgvRefacciones.Columns["StockMinimo"] != null) dgvRefacciones.Columns["StockMinimo"].HeaderText = "Mínimo";
        }

        private void dgvRefacciones_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvRefacciones.CurrentRow != null ? dgvRefacciones.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idSeleccionado = Convert.ToInt32(fila["IdRefaccion"]);
                txtSKU.Text = fila["SKU"].ToString();
                if (fila["IdCategoriaRefaccion"] != DBNull.Value)
                {
                    cboCategoria.SelectedValue = Convert.ToInt32(fila["IdCategoriaRefaccion"]);
                }
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
            string cat = cboFiltroCategoria.Text;

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
                filtro = string.Format("(SKU LIKE '%{0}%' OR Nombre LIKE '%{0}%')", texto);

            if (!string.IsNullOrEmpty(cat) && cat != "Todas las Categorías")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Categoria = '{0}'", cat.Replace("'", "''"));
            }

            _dtRefacciones.DefaultView.RowFilter = filtro;
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            txtSKU.Clear();
            txtNombre.Clear();
            txtCosto.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            txtExistencia.Text = "0";
            txtStockMinimo.Text = "0";
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

            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal costo = 0, precio = 0;
            int existencia = 0, minimo = 0;
            decimal.TryParse(txtCosto.Text, out costo);
            decimal.TryParse(txtPrecioVenta.Text, out precio);
            int.TryParse(txtExistencia.Text, out existencia);
            int.TryParse(txtStockMinimo.Text, out minimo);

            try
            {
                bool esNuevo = (_idSeleccionado == 0);
                int idCat = Convert.ToInt32(cboCategoria.SelectedValue);

                _refaccionBLL.GuardarRefaccion(
                    _idSeleccionado,
                    idCat,
                    txtSKU.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    costo,
                    precio,
                    minimo,
                    existencia,
                    chkActivo.Checked,
                    _idUsuarioActual);

                CargarRefacciones();
                if (esNuevo) Limpiar();

                MessageBox.Show(
                    esNuevo ? "Refacción agregada al inventario exitosamente." : "Inventario de la refacción actualizado correctamente.",
                    "Inventario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar refacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
