using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmTipoEquipo : Form
    {
        private readonly CatalogosBaseBLL _bll = new CatalogosBaseBLL();
        private DataTable _dtDatos;
        private int _idSeleccionado = 0;

        public FrmTipoEquipo()
        {
            InitializeComponent();
        }

        private void FrmTipoEquipo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de equipo: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            _dtDatos = _bll.ObtenerTiposEquipo();
            dgvDatos.DataSource = _dtDatos;
            if (dgvDatos.Columns["IdTipoEquipo"] != null)
            {
                dgvDatos.Columns["IdTipoEquipo"].HeaderText = "ID";
                dgvDatos.Columns["IdTipoEquipo"].FillWeight = 25;
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvDatos.CurrentRow != null ? dgvDatos.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _idSeleccionado = Convert.ToInt32(fila["IdTipoEquipo"]);
                txtNombre.Text = fila["Nombre"].ToString();
                txtDescripcion.Text = fila["Descripcion"].ToString();
                chkActivo.Checked = Convert.ToBoolean(fila["Activo"]);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtDatos == null) return;
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            _dtDatos.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                ? ""
                : string.Format("Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", filtro);
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
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
            try
            {
                bool esNuevo = (_idSeleccionado == 0);
                _bll.GuardarTipoEquipo(_idSeleccionado, txtNombre.Text, txtDescripcion.Text, chkActivo.Checked);
                CargarDatos();
                if (esNuevo) Limpiar();
                MessageBox.Show(
                    esNuevo ? "Tipo de equipo registrado correctamente." : "Tipo de equipo actualizado correctamente.",
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
