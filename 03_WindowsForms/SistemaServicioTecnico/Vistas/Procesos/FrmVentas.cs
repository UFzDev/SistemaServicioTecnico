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
            cboCliente.Items.AddRange(new object[] {
                "Público en General (Mostrador)",
                "Alejandro Gómez Ruiz",
                "Mariana Torres Domínguez",
                "Javier Herrera Bravo",
                "Sofía Camacho Solís"
            });
            cboCliente.SelectedIndex = 0;

            _preciosRefaccion["SSD Kingston A400 480GB SATA3"] = 790.00m;
            _preciosRefaccion["SSD Kingston NV2 1TB M.2 NVMe"] = 1380.00m;
            _preciosRefaccion["Memoria RAM Kingston Fury 8GB DDR4"] = 650.00m;
            _preciosRefaccion["Cargador USB-C 65W Multimarca"] = 580.00m;
            _preciosRefaccion["Pasta Térmica Arctic MX-4 4g"] = 220.00m;

            foreach (string pieza in _preciosRefaccion.Keys)
            {
                cboRefaccion.Items.Add(pieza);
            }
            if (cboRefaccion.Items.Count > 0) cboRefaccion.SelectedIndex = 0;

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

            _dtVentas.Rows.Add("VTA-2026-0001", "09/11/2026", "Alejandro Gómez Ruiz", "SSD Kingston A400 480GB SATA3", 1, 790.00m, "Efectivo", "Confirmada");
            _dtVentas.Rows.Add("VTA-2026-0002", "10/11/2026", "Público en General (Mostrador)", "Pasta Térmica Arctic MX-4 4g", 2, 440.00m, "Efectivo", "Confirmada");
            _dtVentas.Rows.Add("VTA-2026-0003", "11/11/2026", "Mariana Torres Domínguez", "Cargador USB-C 65W Multimarca", 1, 580.00m, "Tarjeta de Débito", "Confirmada");
            _dtVentas.Rows.Add("VTA-2026-0004", "11/11/2026", "Javier Herrera Bravo", "Memoria RAM Kingston Fury 8GB DDR4", 2, 1300.00m, "Transferencia SPEI", "Confirmada");

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
            int sig = (_dtVentas != null ? _dtVentas.Rows.Count : 4) + 1;
            txtFolio.Text = string.Format("VTA-2026-{0:D4}", sig);
            txtCantidad.Text = "1";
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
                cboCliente.SelectedItem.ToString(),
                cboRefaccion.SelectedItem.ToString(),
                cantidad,
                total,
                cboMetodoPago.SelectedItem.ToString(),
                "Confirmada");

            MessageBox.Show(string.Format("Venta [{0}] registrada por un total de {1:C2}.", folio, total), "Venta Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }
    }
}
