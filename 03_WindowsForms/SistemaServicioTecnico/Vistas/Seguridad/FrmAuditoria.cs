using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Seguridad
{
    public partial class FrmAuditoria : Form
    {
        private readonly ReporteAuditoriaBLL _bll = new ReporteAuditoriaBLL();
        private DataTable _dtAuditoria;

        public FrmAuditoria()
        {
            InitializeComponent();
        }

        private void FrmAuditoria_Load(object sender, EventArgs e)
        {
            cboTabla.Items.AddRange(new object[] { "Todas", "Refaccion", "Usuario" });
            cboTabla.SelectedIndex = 0;

            cboOperacion.Items.AddRange(new object[] { "Todas", "INSERT", "UPDATE", "DELETE" });
            cboOperacion.SelectedIndex = 0;

            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            try
            {
                _dtAuditoria = _bll.ObtenerAuditoria();
                dgvAuditoria.DataSource = _dtAuditoria;
                if (dgvAuditoria.Columns["ID"] != null) dgvAuditoria.Columns["ID"].FillWeight = 30;
                if (dgvAuditoria.Columns["Registro"] != null) dgvAuditoria.Columns["Registro"].FillWeight = 40;
                if (dgvAuditoria.Columns["Operacion"] != null) dgvAuditoria.Columns["Operacion"].FillWeight = 50;
                Filtros_Changed(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditoría: " + ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            if (_dtAuditoria == null) return;

            string tabla = cboTabla.SelectedItem != null ? cboTabla.SelectedItem.ToString() : "Todas";
            string op = cboOperacion.SelectedItem != null ? cboOperacion.SelectedItem.ToString() : "Todas";
            string texto = txtBuscar.Text.Trim().Replace("'", "''");

            string filtro = "";
            if (tabla != "Todas")
            {
                filtro = string.Format("Tabla = '{0}'", tabla);
            }
            if (op != "Todas")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Operacion = '{0}'", op);
            }
            if (!string.IsNullOrEmpty(texto))
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("(ValorAnterior LIKE '%{0}%' OR ValorNuevo LIKE '%{0}%' OR Usuario LIKE '%{0}%')", texto);
            }

            _dtAuditoria.DefaultView.RowFilter = filtro;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }
    }
}
