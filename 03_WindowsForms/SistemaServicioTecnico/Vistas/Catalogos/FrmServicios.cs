using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmServicios : Form
    {
        private readonly ServicioBLL _servicioBLL = new ServicioBLL();
        private DataTable _dtServicios;
        private int _idServicioSeleccionado = 0;

        public FrmServicios()
        {
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCategorias();
                CargarServicios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            DataTable dtCats = _servicioBLL.ObtenerCategorias();
            cboCategoria.DataSource = dtCats;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoriaServicio";

            DataTable dtFiltro = dtCats.Copy();
            DataRow filaTodas = dtFiltro.NewRow();
            filaTodas["IdCategoriaServicio"] = 0;
            filaTodas["Nombre"] = "Todas las Categorías";
            dtFiltro.Rows.InsertAt(filaTodas, 0);

            cboFiltroCategoria.DataSource = dtFiltro;
            cboFiltroCategoria.DisplayMember = "Nombre";
            cboFiltroCategoria.ValueMember = "IdCategoriaServicio";
            cboFiltroCategoria.SelectedIndex = 0;
        }

        private void CargarServicios()
        {
            _dtServicios = _servicioBLL.ObtenerServicios();
            dgvServicios.DataSource = _dtServicios;

            if (dgvServicios.Columns["IdCategoriaServicio"] != null)
            {
                dgvServicios.Columns["IdCategoriaServicio"].Visible = false;
            }
            if (dgvServicios.Columns["IdServicio"] != null)
            {
                dgvServicios.Columns["IdServicio"].HeaderText = "ID";
                dgvServicios.Columns["IdServicio"].FillWeight = 30;
            }
            if (dgvServicios.Columns["Categoria"] != null)
            {
                dgvServicios.Columns["Categoria"].HeaderText = "Categoría";
                dgvServicios.Columns["Categoria"].FillWeight = 90;
            }
            if (dgvServicios.Columns["Nombre"] != null)
            {
                dgvServicios.Columns["Nombre"].HeaderText = "Servicio";
                dgvServicios.Columns["Nombre"].FillWeight = 115;
            }
            if (dgvServicios.Columns["Descripcion"] != null)
            {
                dgvServicios.Columns["Descripcion"].HeaderText = "Descripción";
                dgvServicios.Columns["Descripcion"].FillWeight = 130;
            }
            if (dgvServicios.Columns["PrecioBase"] != null)
            {
                dgvServicios.Columns["PrecioBase"].HeaderText = "Precio Base";
                dgvServicios.Columns["PrecioBase"].DefaultCellStyle.Format = "C2";
                dgvServicios.Columns["PrecioBase"].FillWeight = 55;
            }
            if (dgvServicios.Columns["Activo"] != null)
            {
                dgvServicios.Columns["Activo"].FillWeight = 35;
            }
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvServicios.CurrentRow != null ? dgvServicios.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idServicioSeleccionado = Convert.ToInt32(fila["IdServicio"]);

                if (fila["IdCategoriaServicio"] != DBNull.Value)
                {
                    cboCategoria.SelectedValue = Convert.ToInt32(fila["IdCategoriaServicio"]);
                }

                txtNombreServicio.Text = fila["Nombre"].ToString();
                txtDescripcion.Text = fila["Descripcion"].ToString();
                txtPrecioBase.Text = Convert.ToDecimal(fila["PrecioBase"]).ToString("0.00");
                chkServicioActivo.Checked = Convert.ToBoolean(fila["Activo"]);

                lblEstadoEdicion.Text = string.Format("(Editando Servicio ID #{0})", _idServicioSeleccionado);
            }
        }

        private void FiltroServicios_Changed(object sender, EventArgs e)
        {
            if (_dtServicios == null) return;

            string texto = txtBuscarServicio.Text.Trim().Replace("'", "''");
            string categoria = cboFiltroCategoria.Text;

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                filtro = string.Format("(Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%')", texto);
            }

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todas las Categorías")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Categoria = '{0}'", categoria.Replace("'", "''"));
            }

            _dtServicios.DefaultView.RowFilter = filtro;
        }

        private void LimpiarFormulario()
        {
            _idServicioSeleccionado = 0;
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            txtNombreServicio.Clear();
            txtDescripcion.Clear();
            txtPrecioBase.Text = "0.00";
            chkServicioActivo.Checked = true;
            lblEstadoEdicion.Text = "(Modo: Nuevo Servicio)";
            txtNombreServicio.Focus();
        }

        private void btnLimpiarServicio_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreServicio.Text))
            {
                MessageBox.Show("El nombre del servicio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreServicio.Focus();
                return;
            }

            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precio = 0;
            if (!decimal.TryParse(txtPrecioBase.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio base válido mayor o igual a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioBase.Focus();
                return;
            }

            try
            {
                bool esNuevo = (_idServicioSeleccionado == 0);
                int idCat = Convert.ToInt32(cboCategoria.SelectedValue);

                _servicioBLL.GuardarServicio(
                    _idServicioSeleccionado,
                    idCat,
                    txtNombreServicio.Text,
                    txtDescripcion.Text,
                    precio,
                    chkServicioActivo.Checked);

                CargarServicios();
                if (esNuevo) LimpiarFormulario();

                MessageBox.Show(
                    esNuevo ? "Servicio agregado al catálogo correctamente." : "Datos del servicio actualizados correctamente.",
                    esNuevo ? "Servicio Registrado" : "Servicio Actualizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
