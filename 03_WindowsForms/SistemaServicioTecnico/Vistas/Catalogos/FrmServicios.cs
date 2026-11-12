using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmServicios : Form
    {
        private DataTable _dtServicios;
        private int _idServicioSeleccionado = 0;

        public FrmServicios()
        {
            InitializeComponent();
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            InicializarTablaServicios();
            LimpiarFormulario();
        }

        private void CargarCategorias()
        {
            string[] categorias = {
                "Mantenimiento Preventivo",
                "Mantenimiento Correctivo",
                "Diagnóstico y Revisión",
                "Instalación de Software y SO",
                "Recuperación de Información",
                "Microsoldadura y Placa Base",
                "Limpieza y Cambio de Pasta Térmica",
                "Configuración de Redes y Servidores"
            };

            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(categorias);
            cboCategoria.SelectedIndex = 0;

            cboFiltroCategoria.Items.Clear();
            cboFiltroCategoria.Items.Add("Todas las Categorías");
            cboFiltroCategoria.Items.AddRange(categorias);
            cboFiltroCategoria.SelectedIndex = 0;
        }

        private void InicializarTablaServicios()
        {
            _dtServicios = new DataTable();
            _dtServicios.Columns.Add("IdServicio", typeof(int));
            _dtServicios.Columns.Add("Categoria", typeof(string));
            _dtServicios.Columns.Add("Nombre", typeof(string));
            _dtServicios.Columns.Add("Descripcion", typeof(string));
            _dtServicios.Columns.Add("PrecioBase", typeof(decimal));
            _dtServicios.Columns.Add("Activo", typeof(bool));

            // Datos exactos de 04_DatosIniciales.sql
            _dtServicios.Rows.Add(1, "Mantenimiento Preventivo", "Mantenimiento Preventivo Básico Laptop", "Limpieza interna, soplado y cambio de pasta térmica", 350.00m, true);
            _dtServicios.Rows.Add(2, "Mantenimiento Preventivo", "Mantenimiento Preventivo Completo PC Gamer", "Desarme total, limpieza ultrasónica y pasta de alto rendimiento", 650.00m, true);
            _dtServicios.Rows.Add(3, "Mantenimiento Correctivo", "Mantenimiento Correctivo con Reemplazo de Pieza", "Mano de obra por reemplazo de componente interno dañado", 400.00m, true);
            _dtServicios.Rows.Add(4, "Diagnóstico y Revisión", "Diagnóstico General en Banco", "Revisión eléctrica y pruebas de componentes para cotización", 150.00m, true);
            _dtServicios.Rows.Add(5, "Instalación de Software y SO", "Formateo e Instalación de Sistema Operativo", "Instalación limpia de Windows con drivers y paquetería básica", 400.00m, true);
            _dtServicios.Rows.Add(6, "Instalación de Software y SO", "Limpieza y Desinfección de Malware / Virus", "Eliminación de programas espía, adware y optimización de arranque", 300.00m, true);
            _dtServicios.Rows.Add(7, "Recuperación de Información", "Recuperación de Información en Disco Dañado", "Extracción lógica de archivos en HDD o memorias USB", 800.00m, true);
            _dtServicios.Rows.Add(8, "Microsoldadura y Placa Base", "Reparación de Centro de Carga Laptop", "Desoldadura y reemplazo de conector Jack DC", 550.00m, true);
            _dtServicios.Rows.Add(9, "Limpieza y Cambio de Pasta Térmica", "Limpieza Química y Mantenimiento de Impresora", "Destapado de cabezales y purgado de mangueras de tinta", 450.00m, true);
            _dtServicios.Rows.Add(10, "Configuración de Redes y Servidores", "Configuración de Red Local y Servidor de Archivos", "Instalación de almacenamiento NAS y compartición segura", 950.00m, true);

            dgvServicios.DataSource = _dtServicios;

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

                string cat = fila["Categoria"].ToString();
                if (cboCategoria.Items.Contains(cat))
                    cboCategoria.SelectedItem = cat;

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
            string categoria = cboFiltroCategoria.SelectedItem != null ? cboFiltroCategoria.SelectedItem.ToString() : "Todas las Categorías";

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                filtro = string.Format("(Nombre LIKE '%{0}%' OR Descripcion LIKE '%{0}%')", texto);
            }

            if (categoria != "Todas las Categorías")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Categoria = '{0}'", categoria);
            }

            _dtServicios.DefaultView.RowFilter = filtro;
        }

        private void LimpiarFormulario()
        {
            _idServicioSeleccionado = 0;
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            txtNombreServicio.Clear();
            txtDescripcion.Clear();
            txtPrecioBase.Text = "350.00";
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

            decimal precio = 0;
            if (!decimal.TryParse(txtPrecioBase.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio base válido mayor o igual a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioBase.Focus();
                return;
            }

            if (_idServicioSeleccionado == 0)
            {
                int nuevoId = _dtServicios.Rows.Count + 1;
                _dtServicios.Rows.Add(
                    nuevoId,
                    cboCategoria.SelectedItem.ToString(),
                    txtNombreServicio.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    precio,
                    chkServicioActivo.Checked);

                MessageBox.Show("Servicio agregado al catálogo correctamente.", "Servicio Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                foreach (DataRow fila in _dtServicios.Rows)
                {
                    if (Convert.ToInt32(fila["IdServicio"]) == _idServicioSeleccionado)
                    {
                        fila["Categoria"] = cboCategoria.SelectedItem.ToString();
                        fila["Nombre"] = txtNombreServicio.Text.Trim();
                        fila["Descripcion"] = txtDescripcion.Text.Trim();
                        fila["PrecioBase"] = precio;
                        fila["Activo"] = chkServicioActivo.Checked;
                        break;
                    }
                }

                MessageBox.Show("Datos del servicio actualizados correctamente.", "Servicio Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
