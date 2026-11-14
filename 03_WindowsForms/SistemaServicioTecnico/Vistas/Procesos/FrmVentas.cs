using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmVentas : Form
    {
        private DataTable _dtVentas;
        private readonly Dictionary<string, decimal> _preciosRefaccion = new Dictionary<string, decimal>();

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            cboCliente.Items.Clear();
            _preciosRefaccion.Clear();
            cboRefaccion.Items.Clear();

            cboMetodoPago.Items.AddRange(new object[] {
                "Efectivo",
                "Tarjeta de Débito",
                "Tarjeta de Crédito",
                "Transferencia SPEI"
            });
            cboMetodoPago.SelectedIndex = 0;

            _dtVentas = new DataTable();
            _dtVentas.Columns.Add("Folio", typeof(string));
            _dtVentas.Columns.Add("Fecha", typeof(string));
            _dtVentas.Columns.Add("Cliente", typeof(string));
            _dtVentas.Columns.Add("Refaccion", typeof(string));
            _dtVentas.Columns.Add("Cantidad", typeof(int));
            _dtVentas.Columns.Add("Total", typeof(decimal));
            _dtVentas.Columns.Add("MetodoPago", typeof(string));
            _dtVentas.Columns.Add("Estado", typeof(string));

            dgvVentas.DataSource = _dtVentas;
            if (dgvVentas.Columns["Total"] != null) dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            if (dgvVentas.Columns["MetodoPago"] != null) dgvVentas.Columns["MetodoPago"].HeaderText = "Método Pago";

            Limpiar();
        }

        private void cboRefaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRefaccion.SelectedItem != null && _preciosRefaccion.ContainsKey(cboRefaccion.SelectedItem.ToString()))
            {
                txtPrecioUnitario.Text = _preciosRefaccion[cboRefaccion.SelectedItem.ToString()].ToString("0.00");
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
            int sig = (_dtVentas != null ? _dtVentas.Rows.Count : 0) + 1;
            txtFolio.Text = string.Format("VTA-2026-{0:D4}", sig);
            txtCantidad.Text = "1";
            txtPrecioUnitario.Text = "0.00";
            txtObservaciones.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            decimal precio = 0;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal.TryParse(txtPrecioUnitario.Text, out precio);
            decimal total = cantidad * precio;

            string folio = txtFolio.Text;
            _dtVentas.Rows.Add(
                folio,
                DateTime.Now.ToString("dd/MM/yyyy"),
                cboCliente.SelectedItem != null ? cboCliente.SelectedItem.ToString() : "",
                cboRefaccion.SelectedItem != null ? cboRefaccion.SelectedItem.ToString() : "",
                cantidad,
                total,
                cboMetodoPago.SelectedItem != null ? cboMetodoPago.SelectedItem.ToString() : "",
                "Confirmada");

            MessageBox.Show(string.Format("Venta [{0}] registrada por un total de {1:C2}.", folio, total), "Venta Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }
    }
}
