using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmVentas : Form
    {
        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly OrdenServicioBLL _ordenBLL = new OrdenServicioBLL();
        private readonly RefaccionBLL _refaccionBLL = new RefaccionBLL();
        private readonly int _idUsuarioActual;
        private DataTable _dtVentas;

        public FrmVentas() : this(1)
        {
        }

        public FrmVentas(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarVentas();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            DataTable dtClientes = _ordenBLL.ObtenerClientesCombo();
            cboCliente.DataSource = dtClientes;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "IdCliente";

            DataTable dtRef = _refaccionBLL.ObtenerRefacciones();
            DataView dvActivas = new DataView(dtRef);
            dvActivas.RowFilter = "Activo = true";

            cboRefaccion.DataSource = dvActivas;
            cboRefaccion.DisplayMember = "Nombre";
            cboRefaccion.ValueMember = "IdRefaccion";

            DataTable dtMetodos = _ventaBLL.ObtenerMetodosPago();
            cboMetodoPago.DataSource = dtMetodos;
            cboMetodoPago.DisplayMember = "Nombre";
            cboMetodoPago.ValueMember = "IdMetodoPago";
        }

        private void CargarVentas()
        {
            _dtVentas = _ventaBLL.ObtenerVentas();
            dgvVentas.DataSource = _dtVentas;
            if (dgvVentas.Columns["Total"] != null) dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            if (dgvVentas.Columns["MetodoPago"] != null) dgvVentas.Columns["MetodoPago"].HeaderText = "Método Pago";
        }

        private void cboRefaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = cboRefaccion.SelectedItem as DataRowView;
            if (drv != null && drv.Row["PrecioVenta"] != DBNull.Value)
            {
                txtPrecioUnitario.Text = Convert.ToDecimal(drv.Row["PrecioVenta"]).ToString("0.00");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtVentas == null) return;
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            _dtVentas.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                ? ""
                : string.Format("Folio LIKE '%{0}%' OR Cliente LIKE '%{0}%' OR Refaccion LIKE '%{0}%'", filtro);
        }

        private void Limpiar()
        {
            txtFolio.Text = _ventaBLL.ObtenerSiguienteFolio();
            txtCantidad.Text = "1";
            txtObservaciones.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue == null || cboRefaccion.SelectedValue == null || cboMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione cliente, refacción y método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = 0;
            decimal precio = 0;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal.TryParse(txtPrecioUnitario.Text, out precio);
            decimal total = cantidad * precio;

            try
            {
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                int idRefaccion = Convert.ToInt32(cboRefaccion.SelectedValue);
                int idMetodo = Convert.ToInt32(cboMetodoPago.SelectedValue);
                string folioMostrado = txtFolio.Text;

                _ventaBLL.RegistrarVenta(idCliente, _idUsuarioActual, idRefaccion, cantidad, idMetodo);

                CargarVentas();
                Limpiar();

                MessageBox.Show(
                    string.Format("Venta [{0}] registrada por un total de {1:C2} en SQL Server.", folioMostrado, total),
                    "Venta Confirmada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
