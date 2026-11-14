using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmAjustes : Form
    {
        private readonly OperacionesTallerBLL _tallerBLL = new OperacionesTallerBLL();
        private readonly RefaccionBLL _refaccionBLL = new RefaccionBLL();
        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly int _idUsuarioActual;

        public FrmAjustes() : this(1)
        {
        }

        public FrmAjustes(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
        }

        private void FrmAjustes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCatalogos();
                CargarOrdenesActivas();
                CargarKardex();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar módulo de ajustes: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCatalogos()
        {
            DataTable dtRef = _refaccionBLL.ObtenerRefacciones();
            DataView dvActivas1 = new DataView(dtRef);
            dvActivas1.RowFilter = "Activo = true";

            cboRefaccion.DataSource = dvActivas1;
            cboRefaccion.DisplayMember = "Nombre";
            cboRefaccion.ValueMember = "IdRefaccion";

            DataView dvActivas2 = new DataView(dtRef.Copy());
            dvActivas2.RowFilter = "Activo = true";

            cboRefaccionAjuste.DataSource = dvActivas2;
            cboRefaccionAjuste.DisplayMember = "Nombre";
            cboRefaccionAjuste.ValueMember = "IdRefaccion";

            cboMetodoPago.DataSource = _ventaBLL.ObtenerMetodosPago();
            cboMetodoPago.DisplayMember = "Nombre";
            cboMetodoPago.ValueMember = "IdMetodoPago";
        }

        private void CargarOrdenesActivas()
        {
            DataTable dtOrdenes = _tallerBLL.ObtenerOrdenesParaTaller();
            cboOrdenActiva.DataSource = dtOrdenes;
            cboOrdenActiva.DisplayMember = "DescripcionOrden";
            cboOrdenActiva.ValueMember = "IdOrdenServicio";

            if (dtOrdenes.Rows.Count == 0)
            {
                lblCostoTotal.Text = "Costo Total: $0.00";
                lblSaldoPendiente.Text = "Saldo Pendiente: $0.00";
                dgvRefaccionesOrden.DataSource = null;
            }
            else
            {
                ActualizarDetalleOrden();
            }
        }

        private void cboOrdenActiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrdenActiva.SelectedValue == null || cboOrdenActiva.SelectedValue is DataRowView)
                return;

            ActualizarDetalleOrden();
        }

        private void ActualizarDetalleOrden()
        {
            if (cboOrdenActiva.SelectedValue == null || cboOrdenActiva.SelectedValue is DataRowView)
                return;

            int idOrden = Convert.ToInt32(cboOrdenActiva.SelectedValue);
            decimal costoTotal;
            decimal saldoPendiente;
            int diasGarantia;

            _tallerBLL.ObtenerTotalesOrden(idOrden, out costoTotal, out saldoPendiente, out diasGarantia);
            lblCostoTotal.Text = string.Format("Costo Total: {0:C2}", costoTotal);
            lblSaldoPendiente.Text = string.Format("Saldo Pendiente: {0:C2}", saldoPendiente);

            DataTable dtRefOrd = _tallerBLL.ObtenerRefaccionesOrden(idOrden);
            dgvRefaccionesOrden.DataSource = dtRefOrd;
            if (dgvRefaccionesOrden.Columns["IdOrdenRefaccion"] != null)
                dgvRefaccionesOrden.Columns["IdOrdenRefaccion"].Visible = false;
            if (dgvRefaccionesOrden.Columns["PrecioUnitario"] != null)
                dgvRefaccionesOrden.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            if (dgvRefaccionesOrden.Columns["Subtotal"] != null)
                dgvRefaccionesOrden.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void CargarKardex()
        {
            dgvKardex.DataSource = _tallerBLL.ObtenerMovimientosInventario();
        }

        private void btnConsumirRefaccion_Click(object sender, EventArgs e)
        {
            if (cboOrdenActiva.SelectedValue == null || cboRefaccion.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden activa y una refacción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idOrden = Convert.ToInt32(cboOrdenActiva.SelectedValue);
                int idRef = Convert.ToInt32(cboRefaccion.SelectedValue);

                _tallerBLL.ConsumirRefaccionEnOrden(idOrden, idRef, cantidad);
                ActualizarDetalleOrden();
                CargarKardex();
                txtCantidad.Text = "1";

                MessageBox.Show("Refacción agregada a la orden y descontada de inventario.", "Consumo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consumir refacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEntregarOrden_Click(object sender, EventArgs e)
        {
            if (cboOrdenActiva.SelectedValue == null || cboMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden activa y método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea liquidar el saldo pendiente (si existe) y marcar la orden como Entregada?",
                "Confirmar Entrega",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int idOrden = Convert.ToInt32(cboOrdenActiva.SelectedValue);
                int idMetodo = Convert.ToInt32(cboMetodoPago.SelectedValue);

                _tallerBLL.FinalizarYEntregarOrden(idOrden, _idUsuarioActual, idMetodo);
                CargarOrdenesActivas();

                MessageBox.Show("Orden liquidada y entregada exitosamente.", "Entrega Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar y entregar orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            if (cboRefaccionAjuste.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una refacción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidadAjuste.Text, out cantidad) || cantidad == 0)
            {
                MessageBox.Show("Ingrese un ajuste numérico distinto de cero (ej. +5 o -2).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivoAjuste.Text))
            {
                MessageBox.Show("El motivo del ajuste es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoAjuste.Focus();
                return;
            }

            try
            {
                int idRef = Convert.ToInt32(cboRefaccionAjuste.SelectedValue);
                _tallerBLL.AjustarInventario(idRef, cantidad, _idUsuarioActual, txtMotivoAjuste.Text);

                txtCantidadAjuste.Clear();
                txtMotivoAjuste.Clear();
                CargarKardex();

                MessageBox.Show("Ajuste de inventario aplicado y registrado en kardex.", "Ajuste Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar ajuste: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
