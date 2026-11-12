using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmOrdenServicio : Form
    {
        private DataTable _dtOrdenes;
        private string _folioSeleccionado = null;
        private readonly Dictionary<string, string[]> _equiposPorCliente = new Dictionary<string, string[]>();
        private readonly Dictionary<string, decimal> _preciosServicio = new Dictionary<string, decimal>();

        public FrmOrdenServicio()
        {
            InitializeComponent();
        }

        private void FrmOrdenServicio_Load(object sender, EventArgs e)
        {
            InicializarCatalogos();
            InicializarTablaOrdenes();
            PrepararNuevaOrden();
        }

        private void InicializarCatalogos()
        {
            _equiposPorCliente["Alejandro Gómez Ruiz"] = new[] { "HP Pavilion 15-dk0020la (S/N: 5CD9321ABC)", "Samsung Galaxy S21 Ultra (S/N: R58M901XYZ)" };
            _equiposPorCliente["Mariana Torres Domínguez"] = new[] { "Dell Inspiron 3501 (S/N: 8HK2199KLM)", "Apple iPad Air 4ta Gen (S/N: DMPZ1990OPQ)" };
            _equiposPorCliente["Javier Herrera Bravo"] = new[] { "Asus ROG Strix G15 (S/N: K9N01234ASU)" };
            _equiposPorCliente["Sofía Camacho Solís"] = new[] { "Lenovo ThinkPad T14 Gen 2 (S/N: PF299901LEN)" };
            _equiposPorCliente["Ricardo Salazar Peña"] = new[] { "Sony PlayStation 5 Standard (S/N: FC102938475)" };

            cboCliente.Items.Clear();
            foreach (string cliente in _equiposPorCliente.Keys)
            {
                cboCliente.Items.Add(cliente);
            }

            string[] estados = {
                "Recibida",
                "En Diagnóstico",
                "Presupuestada",
                "Esperando Aprobación",
                "En Reparación",
                "Esperando Refacción",
                "Terminada / Lista",
                "Entregada",
                "Cancelada"
            };

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(estados);

            cboFiltroEstado.Items.Clear();
            cboFiltroEstado.Items.Add("Todos los Estados");
            cboFiltroEstado.Items.AddRange(estados);
            cboFiltroEstado.SelectedIndex = 0;

            _preciosServicio["Diagnóstico General en Banco"] = 150.00m;
            _preciosServicio["Mantenimiento Preventivo Básico Laptop"] = 350.00m;
            _preciosServicio["Formateo e Instalación de Sistema Operativo"] = 400.00m;
            _preciosServicio["Mantenimiento Correctivo con Reemplazo"] = 400.00m;
            _preciosServicio["Reparación de Centro de Carga Laptop"] = 550.00m;
            _preciosServicio["Mantenimiento Completo PC Gamer"] = 650.00m;
            _preciosServicio["Recuperación de Información en Disco"] = 800.00m;

            cboServicioRapido.Items.Clear();
            foreach (string srv in _preciosServicio.Keys)
            {
                cboServicioRapido.Items.Add(srv);
            }

            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboServicioRapido.Items.Count > 0) cboServicioRapido.SelectedIndex = 1;
        }

        private void InicializarTablaOrdenes()
        {
            _dtOrdenes = new DataTable();
            _dtOrdenes.Columns.Add("Folio", typeof(string));
            _dtOrdenes.Columns.Add("FechaRecepcion", typeof(string));
            _dtOrdenes.Columns.Add("Cliente", typeof(string));
            _dtOrdenes.Columns.Add("Equipo", typeof(string));
            _dtOrdenes.Columns.Add("FallaReportada", typeof(string));
            _dtOrdenes.Columns.Add("Diagnostico", typeof(string));
            _dtOrdenes.Columns.Add("Estado", typeof(string));
            _dtOrdenes.Columns.Add("Presupuesto", typeof(decimal));
            _dtOrdenes.Columns.Add("FechaPrometida", typeof(string));

            _dtOrdenes.Rows.Add(
                "OS-2026-0001", "10/11/2026", "Alejandro Gómez Ruiz",
                "HP Pavilion 15-dk0020la (S/N: 5CD9321ABC)",
                "Se calienta mucho y se apaga al abrir juegos.",
                "Ventilador obstruido por polvo y pasta térmica seca.",
                "En Reparación", 350.00m, "12/11/2026");

            _dtOrdenes.Rows.Add(
                "OS-2026-0002", "10/11/2026", "Mariana Torres Domínguez",
                "Dell Inspiron 3501 (S/N: 8HK2199KLM)",
                "Sistema operativo muy lento y pantallas azules al iniciar.",
                "Respaldo de información y formateo limpio con Windows 11.",
                "Terminada / Lista", 400.00m, "11/11/2026");

            _dtOrdenes.Rows.Add(
                "OS-2026-0003", "11/11/2026", "Javier Herrera Bravo",
                "Asus ROG Strix G15 (S/N: K9N01234ASU)",
                "No da video por HDMI y los ventiladores suenan fuerte.",
                "En revisión de GPU y limpieza ultrasónica.",
                "En Diagnóstico", 650.00m, "14/11/2026");

            _dtOrdenes.Rows.Add(
                "OS-2026-0004", "11/11/2026", "Sofía Camacho Solís",
                "Lenovo ThinkPad T14 Gen 2 (S/N: PF299901LEN)",
                "Falso contacto al conectar el cargador, no carga batería.",
                "Requiere reemplazo y soldadura de conector Jack DC.",
                "Esperando Refacción", 550.00m, "15/11/2026");

            _dtOrdenes.Rows.Add(
                "OS-2026-0005", "11/11/2026", "Ricardo Salazar Peña",
                "Sony PlayStation 5 Standard (S/N: FC102938475)",
                "Se apaga tras 20 minutos de juego por sobrecalentamiento.",
                "Recepción en mostrador para revisión de metal líquido.",
                "Recibida", 650.00m, "14/11/2026");

            dgvOrdenes.DataSource = _dtOrdenes;
            if (dgvOrdenes.Columns["Diagnostico"] != null) dgvOrdenes.Columns["Diagnostico"].Visible = false;
            if (dgvOrdenes.Columns["Folio"] != null) dgvOrdenes.Columns["Folio"].FillWeight = 65;
            if (dgvOrdenes.Columns["FechaRecepcion"] != null)
            {
                dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Recepción";
                dgvOrdenes.Columns["FechaRecepcion"].FillWeight = 55;
            }
            if (dgvOrdenes.Columns["FechaPrometida"] != null)
            {
                dgvOrdenes.Columns["FechaPrometida"].HeaderText = "Prometida";
                dgvOrdenes.Columns["FechaPrometida"].FillWeight = 55;
            }
            if (dgvOrdenes.Columns["Presupuesto"] != null)
            {
                dgvOrdenes.Columns["Presupuesto"].DefaultCellStyle.Format = "C2";
                dgvOrdenes.Columns["Presupuesto"].FillWeight = 55;
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEquipo.Items.Clear();
            if (cboCliente.SelectedItem != null && _equiposPorCliente.ContainsKey(cboCliente.SelectedItem.ToString()))
            {
                cboEquipo.Items.AddRange(_equiposPorCliente[cboCliente.SelectedItem.ToString()]);
                if (cboEquipo.Items.Count > 0)
                    cboEquipo.SelectedIndex = 0;
            }
        }

        private void cboServicioRapido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServicioRapido.SelectedItem != null)
            {
                string srv = cboServicioRapido.SelectedItem.ToString();
                if (_preciosServicio.ContainsKey(srv))
                {
                    txtPresupuesto.Text = _preciosServicio[srv].ToString("0.00");
                }
            }
        }

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView rowView = dgvOrdenes.CurrentRow != null ? dgvOrdenes.CurrentRow.DataBoundItem as DataRowView : null;
            if (rowView != null)
            {
                DataRow fila = rowView.Row;
                _folioSeleccionado = fila["Folio"].ToString();
                txtFolio.Text = _folioSeleccionado;

                string cliente = fila["Cliente"].ToString();
                if (cboCliente.Items.Contains(cliente))
                    cboCliente.SelectedItem = cliente;

                string equipo = fila["Equipo"].ToString();
                if (cboEquipo.Items.Contains(equipo))
                    cboEquipo.SelectedItem = equipo;

                string estado = fila["Estado"].ToString();
                if (cboEstado.Items.Contains(estado))
                    cboEstado.SelectedItem = estado;

                txtFallaReportada.Text = fila["FallaReportada"].ToString();
                txtDiagnostico.Text = fila["Diagnostico"].ToString();
                txtPresupuesto.Text = Convert.ToDecimal(fila["Presupuesto"]).ToString("0.00");
            }
        }

        private void FiltroOrdenes_Changed(object sender, EventArgs e)
        {
            if (_dtOrdenes == null) return;

            string texto = txtBuscarOrden.Text.Trim().Replace("'", "''");
            string estado = cboFiltroEstado.SelectedItem != null ? cboFiltroEstado.SelectedItem.ToString() : "Todos los Estados";

            string filtro = "";
            if (!string.IsNullOrEmpty(texto))
            {
                filtro = string.Format("(Folio LIKE '%{0}%' OR Cliente LIKE '%{0}%' OR Equipo LIKE '%{0}%')", texto);
            }

            if (estado != "Todos los Estados")
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += string.Format("Estado = '{0}'", estado);
            }

            _dtOrdenes.DefaultView.RowFilter = filtro;
        }

        private void PrepararNuevaOrden()
        {
            _folioSeleccionado = null;
            int siguienteNumero = (_dtOrdenes != null ? _dtOrdenes.Rows.Count : 5) + 1;
            txtFolio.Text = string.Format("OS-2026-{0:D4}", siguienteNumero);
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            dtpFechaPrometida.Value = DateTime.Now.AddDays(2);
            txtFallaReportada.Clear();
            txtDiagnostico.Clear();
            txtFallaReportada.Focus();
        }

        private void btnLimpiarOrden_Click(object sender, EventArgs e)
        {
            PrepararNuevaOrden();
        }

        private void btnRegistrarOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFallaReportada.Text))
            {
                MessageBox.Show("Debe capturar la falla reportada por el cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFallaReportada.Focus();
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            int siguienteNumero = _dtOrdenes.Rows.Count + 1;
            string nuevoFolio = string.Format("OS-2026-{0:D4}", siguienteNumero);

            _dtOrdenes.Rows.Add(
                nuevoFolio,
                DateTime.Now.ToString("dd/MM/yyyy"),
                cboCliente.SelectedItem != null ? cboCliente.SelectedItem.ToString() : "",
                cboEquipo.SelectedItem != null ? cboEquipo.SelectedItem.ToString() : "",
                txtFallaReportada.Text.Trim(),
                txtDiagnostico.Text.Trim(),
                cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Recibida",
                presupuesto,
                dtpFechaPrometida.Value.ToString("dd/MM/yyyy"));

            MessageBox.Show(
                string.Format("Orden de Servicio [{0}] registrada exitosamente.", nuevoFolio),
                "Orden Creada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            PrepararNuevaOrden();
        }

        private void btnActualizarOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_folioSeleccionado))
            {
                MessageBox.Show("Seleccione primero una orden de la bitácora inferior para actualizar su estado o diagnóstico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal presupuesto = 0;
            decimal.TryParse(txtPresupuesto.Text, out presupuesto);

            foreach (DataRow fila in _dtOrdenes.Rows)
            {
                if (fila["Folio"].ToString() == _folioSeleccionado)
                {
                    fila["Estado"] = cboEstado.SelectedItem.ToString();
                    fila["FallaReportada"] = txtFallaReportada.Text.Trim();
                    fila["Diagnostico"] = txtDiagnostico.Text.Trim();
                    fila["Presupuesto"] = presupuesto;
                    fila["FechaPrometida"] = dtpFechaPrometida.Value.ToString("dd/MM/yyyy");
                    break;
                }
            }

            MessageBox.Show(
                string.Format("Orden [{0}] actualizada al estado: {1}", _folioSeleccionado, cboEstado.SelectedItem),
                "Actualización Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
