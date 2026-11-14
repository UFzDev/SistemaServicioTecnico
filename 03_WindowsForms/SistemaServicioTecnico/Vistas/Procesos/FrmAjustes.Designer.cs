namespace SistemaServicioTecnico.Vistas.Procesos
{
    partial class FrmAjustes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabAjustes = new System.Windows.Forms.TabControl();
            this.tpTaller = new System.Windows.Forms.TabPage();
            this.pnlTallerTop = new System.Windows.Forms.Panel();
            this.btnEntregarOrden = new System.Windows.Forms.Button();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.btnConsumirRefaccion = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cboRefaccion = new System.Windows.Forms.ComboBox();
            this.lblRefaccion = new System.Windows.Forms.Label();
            this.lblSaldoPendiente = new System.Windows.Forms.Label();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.cboOrdenActiva = new System.Windows.Forms.ComboBox();
            this.lblOrdenActiva = new System.Windows.Forms.Label();
            this.pnlTallerGrid = new System.Windows.Forms.Panel();
            this.lblRefOrden = new System.Windows.Forms.Label();
            this.dgvRefaccionesOrden = new System.Windows.Forms.DataGridView();
            this.tpInventario = new System.Windows.Forms.TabPage();
            this.pnlInvTop = new System.Windows.Forms.Panel();
            this.btnAplicarAjuste = new System.Windows.Forms.Button();
            this.txtMotivoAjuste = new System.Windows.Forms.TextBox();
            this.lblMotivoAjuste = new System.Windows.Forms.Label();
            this.txtCantidadAjuste = new System.Windows.Forms.TextBox();
            this.lblCantidadAjuste = new System.Windows.Forms.Label();
            this.cboRefaccionAjuste = new System.Windows.Forms.ComboBox();
            this.lblRefaccionAjuste = new System.Windows.Forms.Label();
            this.pnlInvGrid = new System.Windows.Forms.Panel();
            this.lblKardex = new System.Windows.Forms.Label();
            this.dgvKardex = new System.Windows.Forms.DataGridView();

            this.tabAjustes.SuspendLayout();
            this.tpTaller.SuspendLayout();
            this.pnlTallerTop.SuspendLayout();
            this.pnlTallerGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefaccionesOrden)).BeginInit();
            this.tpInventario.SuspendLayout();
            this.pnlInvTop.SuspendLayout();
            this.pnlInvGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.SuspendLayout();

            this.tabAjustes.Controls.Add(this.tpTaller);
            this.tabAjustes.Controls.Add(this.tpInventario);
            this.tabAjustes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAjustes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabAjustes.Size = new System.Drawing.Size(860, 560);

            this.tpTaller.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tpTaller.Controls.Add(this.pnlTallerGrid);
            this.tpTaller.Controls.Add(this.pnlTallerTop);
            this.tpTaller.Text = "Taller: Refacciones y Entrega de Orden";

            this.pnlTallerTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTallerTop.BackColor = System.Drawing.Color.White;
            this.pnlTallerTop.Controls.Add(this.btnEntregarOrden);
            this.pnlTallerTop.Controls.Add(this.cboMetodoPago);
            this.pnlTallerTop.Controls.Add(this.lblMetodoPago);
            this.pnlTallerTop.Controls.Add(this.btnConsumirRefaccion);
            this.pnlTallerTop.Controls.Add(this.txtCantidad);
            this.pnlTallerTop.Controls.Add(this.lblCantidad);
            this.pnlTallerTop.Controls.Add(this.cboRefaccion);
            this.pnlTallerTop.Controls.Add(this.lblRefaccion);
            this.pnlTallerTop.Controls.Add(this.lblSaldoPendiente);
            this.pnlTallerTop.Controls.Add(this.lblCostoTotal);
            this.pnlTallerTop.Controls.Add(this.cboOrdenActiva);
            this.pnlTallerTop.Controls.Add(this.lblOrdenActiva);
            this.pnlTallerTop.Location = new System.Drawing.Point(12, 12);
            this.pnlTallerTop.Size = new System.Drawing.Size(828, 175);

            this.lblOrdenActiva.AutoSize = true;
            this.lblOrdenActiva.Location = new System.Drawing.Point(15, 14);
            this.lblOrdenActiva.Text = "Orden Activa en Taller:";

            this.cboOrdenActiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenActiva.Location = new System.Drawing.Point(18, 34);
            this.cboOrdenActiva.Size = new System.Drawing.Size(480, 24);
            this.cboOrdenActiva.SelectedIndexChanged += new System.EventHandler(this.cboOrdenActiva_SelectedIndexChanged);

            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCostoTotal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCostoTotal.Location = new System.Drawing.Point(518, 18);
            this.lblCostoTotal.Text = "Costo Total: $0.00";

            this.lblSaldoPendiente.AutoSize = true;
            this.lblSaldoPendiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldoPendiente.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblSaldoPendiente.Location = new System.Drawing.Point(518, 42);
            this.lblSaldoPendiente.Text = "Saldo Pendiente: $0.00";

            this.lblRefaccion.AutoSize = true;
            this.lblRefaccion.Location = new System.Drawing.Point(15, 72);
            this.lblRefaccion.Text = "Refacción a Consumir:";

            this.cboRefaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefaccion.Location = new System.Drawing.Point(18, 92);
            this.cboRefaccion.Size = new System.Drawing.Size(340, 24);

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(375, 72);
            this.lblCantidad.Text = "Cant:";

            this.txtCantidad.Location = new System.Drawing.Point(378, 92);
            this.txtCantidad.Size = new System.Drawing.Size(70, 24);
            this.txtCantidad.Text = "1";

            this.btnConsumirRefaccion.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnConsumirRefaccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumirRefaccion.FlatAppearance.BorderSize = 0;
            this.btnConsumirRefaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumirRefaccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConsumirRefaccion.ForeColor = System.Drawing.Color.White;
            this.btnConsumirRefaccion.Location = new System.Drawing.Point(465, 88);
            this.btnConsumirRefaccion.Size = new System.Drawing.Size(185, 32);
            this.btnConsumirRefaccion.Text = "Agregar Pieza a Orden";
            this.btnConsumirRefaccion.UseVisualStyleBackColor = false;
            this.btnConsumirRefaccion.Click += new System.EventHandler(this.btnConsumirRefaccion_Click);

            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 134);
            this.lblMetodoPago.Text = "Método Pago Liquidación:";

            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Location = new System.Drawing.Point(185, 131);
            this.cboMetodoPago.Size = new System.Drawing.Size(210, 24);

            this.btnEntregarOrden.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnEntregarOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregarOrden.FlatAppearance.BorderSize = 0;
            this.btnEntregarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregarOrden.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEntregarOrden.ForeColor = System.Drawing.Color.White;
            this.btnEntregarOrden.Location = new System.Drawing.Point(410, 128);
            this.btnEntregarOrden.Size = new System.Drawing.Size(240, 32);
            this.btnEntregarOrden.Text = "Liquidar Saldo y Entregar Orden";
            this.btnEntregarOrden.UseVisualStyleBackColor = false;
            this.btnEntregarOrden.Click += new System.EventHandler(this.btnEntregarOrden_Click);

            this.pnlTallerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTallerGrid.BackColor = System.Drawing.Color.White;
            this.pnlTallerGrid.Controls.Add(this.dgvRefaccionesOrden);
            this.pnlTallerGrid.Controls.Add(this.lblRefOrden);
            this.pnlTallerGrid.Location = new System.Drawing.Point(12, 198);
            this.pnlTallerGrid.Size = new System.Drawing.Size(828, 320);

            this.lblRefOrden.AutoSize = true;
            this.lblRefOrden.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRefOrden.Location = new System.Drawing.Point(15, 12);
            this.lblRefOrden.Text = "Refacciones Consumidas en la Orden";

            this.dgvRefaccionesOrden.AllowUserToAddRows = false;
            this.dgvRefaccionesOrden.AllowUserToDeleteRows = false;
            this.dgvRefaccionesOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefaccionesOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRefaccionesOrden.BackgroundColor = System.Drawing.Color.White;
            this.dgvRefaccionesOrden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRefaccionesOrden.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvRefaccionesOrden.ColumnHeadersHeight = 32;
            this.dgvRefaccionesOrden.EnableHeadersVisualStyles = false;
            this.dgvRefaccionesOrden.Location = new System.Drawing.Point(15, 42);
            this.dgvRefaccionesOrden.MultiSelect = false;
            this.dgvRefaccionesOrden.ReadOnly = true;
            this.dgvRefaccionesOrden.RowHeadersVisible = false;
            this.dgvRefaccionesOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefaccionesOrden.Size = new System.Drawing.Size(798, 265);

            this.tpInventario.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tpInventario.Controls.Add(this.pnlInvGrid);
            this.tpInventario.Controls.Add(this.pnlInvTop);
            this.tpInventario.Text = "Almacén: Ajuste de Inventario y Kardex";

            this.pnlInvTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInvTop.BackColor = System.Drawing.Color.White;
            this.pnlInvTop.Controls.Add(this.btnAplicarAjuste);
            this.pnlInvTop.Controls.Add(this.txtMotivoAjuste);
            this.pnlInvTop.Controls.Add(this.lblMotivoAjuste);
            this.pnlInvTop.Controls.Add(this.txtCantidadAjuste);
            this.pnlInvTop.Controls.Add(this.lblCantidadAjuste);
            this.pnlInvTop.Controls.Add(this.cboRefaccionAjuste);
            this.pnlInvTop.Controls.Add(this.lblRefaccionAjuste);
            this.pnlInvTop.Location = new System.Drawing.Point(12, 12);
            this.pnlInvTop.Size = new System.Drawing.Size(828, 130);

            this.lblRefaccionAjuste.AutoSize = true;
            this.lblRefaccionAjuste.Location = new System.Drawing.Point(15, 14);
            this.lblRefaccionAjuste.Text = "Refacción:";

            this.cboRefaccionAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefaccionAjuste.Location = new System.Drawing.Point(18, 34);
            this.cboRefaccionAjuste.Size = new System.Drawing.Size(340, 24);

            this.lblCantidadAjuste.AutoSize = true;
            this.lblCantidadAjuste.Location = new System.Drawing.Point(375, 14);
            this.lblCantidadAjuste.Text = "Ajuste (+/-):";

            this.txtCantidadAjuste.Location = new System.Drawing.Point(378, 34);
            this.txtCantidadAjuste.Size = new System.Drawing.Size(90, 24);

            this.lblMotivoAjuste.AutoSize = true;
            this.lblMotivoAjuste.Location = new System.Drawing.Point(15, 68);
            this.lblMotivoAjuste.Text = "Motivo Obligatorio del Ajuste:";

            this.txtMotivoAjuste.Location = new System.Drawing.Point(18, 88);
            this.txtMotivoAjuste.Size = new System.Drawing.Size(450, 24);

            this.btnAplicarAjuste.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnAplicarAjuste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarAjuste.FlatAppearance.BorderSize = 0;
            this.btnAplicarAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarAjuste.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAplicarAjuste.ForeColor = System.Drawing.Color.White;
            this.btnAplicarAjuste.Location = new System.Drawing.Point(485, 84);
            this.btnAplicarAjuste.Size = new System.Drawing.Size(180, 32);
            this.btnAplicarAjuste.Text = "Aplicar Ajuste";
            this.btnAplicarAjuste.UseVisualStyleBackColor = false;
            this.btnAplicarAjuste.Click += new System.EventHandler(this.btnAplicarAjuste_Click);

            this.pnlInvGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInvGrid.BackColor = System.Drawing.Color.White;
            this.pnlInvGrid.Controls.Add(this.dgvKardex);
            this.pnlInvGrid.Controls.Add(this.lblKardex);
            this.pnlInvGrid.Location = new System.Drawing.Point(12, 152);
            this.pnlInvGrid.Size = new System.Drawing.Size(828, 366);

            this.lblKardex.AutoSize = true;
            this.lblKardex.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKardex.Location = new System.Drawing.Point(15, 12);
            this.lblKardex.Text = "Kardex Reciente de Movimientos de Inventario";

            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToDeleteRows = false;
            this.dgvKardex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKardex.BackgroundColor = System.Drawing.Color.White;
            this.dgvKardex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKardex.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvKardex.ColumnHeadersHeight = 32;
            this.dgvKardex.EnableHeadersVisualStyles = false;
            this.dgvKardex.Location = new System.Drawing.Point(15, 42);
            this.dgvKardex.MultiSelect = false;
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardex.Size = new System.Drawing.Size(798, 310);

            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.tabAjustes);
            this.Name = "FrmAjustes";
            this.Text = "Operaciones de Taller y Ajustes";
            this.Load += new System.EventHandler(this.FrmAjustes_Load);

            this.tabAjustes.ResumeLayout(false);
            this.tpTaller.ResumeLayout(false);
            this.pnlTallerTop.ResumeLayout(false);
            this.pnlTallerTop.PerformLayout();
            this.pnlTallerGrid.ResumeLayout(false);
            this.pnlTallerGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefaccionesOrden)).EndInit();
            this.tpInventario.ResumeLayout(false);
            this.pnlInvTop.ResumeLayout(false);
            this.pnlInvTop.PerformLayout();
            this.pnlInvGrid.ResumeLayout(false);
            this.pnlInvGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabAjustes;
        private System.Windows.Forms.TabPage tpTaller;
        private System.Windows.Forms.Panel pnlTallerTop;
        private System.Windows.Forms.Label lblOrdenActiva;
        private System.Windows.Forms.ComboBox cboOrdenActiva;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.Label lblSaldoPendiente;
        private System.Windows.Forms.Label lblRefaccion;
        private System.Windows.Forms.ComboBox cboRefaccion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnConsumirRefaccion;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Button btnEntregarOrden;
        private System.Windows.Forms.Panel pnlTallerGrid;
        private System.Windows.Forms.Label lblRefOrden;
        private System.Windows.Forms.DataGridView dgvRefaccionesOrden;
        private System.Windows.Forms.TabPage tpInventario;
        private System.Windows.Forms.Panel pnlInvTop;
        private System.Windows.Forms.Label lblRefaccionAjuste;
        private System.Windows.Forms.ComboBox cboRefaccionAjuste;
        private System.Windows.Forms.Label lblCantidadAjuste;
        private System.Windows.Forms.TextBox txtCantidadAjuste;
        private System.Windows.Forms.Label lblMotivoAjuste;
        private System.Windows.Forms.TextBox txtMotivoAjuste;
        private System.Windows.Forms.Button btnAplicarAjuste;
        private System.Windows.Forms.Panel pnlInvGrid;
        private System.Windows.Forms.Label lblKardex;
        private System.Windows.Forms.DataGridView dgvKardex;
    }
}
