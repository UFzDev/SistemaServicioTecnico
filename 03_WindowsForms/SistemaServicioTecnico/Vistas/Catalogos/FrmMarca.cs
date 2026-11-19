using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmMarca : Form
    {
        private readonly CatalogosBaseBLL _bll = new CatalogosBaseBLL();
        private DataTable _dtDatos;
        private int _idSeleccionado = 0;

        public FrmMarca()
        {
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar marcas: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            _dtDatos = _bll.ObtenerMarcas();
            dgvDatos.DataSource = _dtDatos;
            if (dgvDatos.Columns["IdMarca"] != null)
            {
                dgvDatos.Columns["IdMarca"].HeaderText = "ID";
                dgvDatos.Columns["IdMarca"].FillWeight = 25;
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvDatos.CurrentRow != null ? dgvDatos.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idSeleccionado = Convert.ToInt32(fila["IdMarca"]);
                txtNombre.Text = fila["Nombre"].ToString();
                chkActivo.Checked = Convert.ToBoolean(fila["Activo"]);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtDatos == null) return;
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            _dtDatos.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                ? ""
                : string.Format("Nombre LIKE '%{0}%'", filtro);
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool esNuevo = (_idSeleccionado == 0);
                _bll.GuardarMarca(_idSeleccionado, txtNombre.Text, chkActivo.Checked);
                CargarDatos();
                if (esNuevo) Limpiar();
                MessageBox.Show(
                    esNuevo ? "Marca registrada correctamente." : "Marca actualizada correctamente.",
                    "Catálogo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Validación / Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
