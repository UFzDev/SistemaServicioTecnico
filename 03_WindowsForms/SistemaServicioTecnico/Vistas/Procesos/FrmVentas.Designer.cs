namespace SistemaServicioTecnico.Vistas.Procesos
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cboRefaccion = new System.Windows.Forms.ComboBox();
            this.lblRefaccion = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlFormulario.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.btnLimpiar);
            this.pnlFormulario.Controls.Add(this.btnRegistrar);
            this.pnlFormulario.Controls.Add(this.txtObservaciones);
            this.pnlFormulario.Controls.Add(this.lblObservaciones);
            this.pnlFormulario.Controls.Add(this.cboMetodoPago);
            this.pnlFormulario.Controls.Add(this.lblMetodoPago);
            this.pnlFormulario.Controls.Add(this.txtPrecioUnitario);
            this.pnlFormulario.Controls.Add(this.lblPrecioUnitario);
            this.pnlFormulario.Controls.Add(this.txtCantidad);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.cboRefaccion);
            this.pnlFormulario.Controls.Add(this.lblRefaccion);
            this.pnlFormulario.Controls.Add(this.cboCliente);
            this.pnlFormulario.Controls.Add(this.lblCliente);
            this.pnlFormulario.Controls.Add(this.txtFolio);
            this.pnlFormulario.Controls.Add(this.lblFolio);
            this.pnlFormulario.Controls.Add(this.lblTitulo);
            this.pnlFormulario.Location = new System.Drawing.Point(15, 12);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(857, 210);
            this.pnlFormulario.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(277, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🛒 Punto de Venta de Refacciones";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFolio.Location = new System.Drawing.Point(15, 42);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(36, 15);
            this.lblFolio.TabIndex = 1;
            this.lblFolio.Text = "Folio:";
            // 
            // txtFolio
            // 
            this.txtFolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtFolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtFolio.Location = new System.Drawing.Point(18, 60);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(130, 24);
            this.txtFolio.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCliente.Location = new System.Drawing.Point(160, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(162, 60);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(240, 24);
            this.cboCliente.TabIndex = 4;
            // 
            // lblRefaccion
            // 
            this.lblRefaccion.AutoSize = true;
            this.lblRefaccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRefaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRefaccion.Location = new System.Drawing.Point(415, 42);
            this.lblRefaccion.Name = "lblRefaccion";
            this.lblRefaccion.Size = new System.Drawing.Size(113, 15);
            this.lblRefaccion.TabIndex = 5;
            this.lblRefaccion.Text = "Refacción a Vender:";
            // 
            // cboRefaccion
            // 
            this.cboRefaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefaccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRefaccion.FormattingEnabled = true;
            this.cboRefaccion.Location = new System.Drawing.Point(418, 60);
            this.cboRefaccion.Name = "cboRefaccion";
            this.cboRefaccion.Size = new System.Drawing.Size(420, 24);
            this.cboRefaccion.TabIndex = 6;
            this.cboRefaccion.SelectedIndexChanged += new System.EventHandler(this.cboRefaccion_SelectedIndexChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCantidad.Location = new System.Drawing.Point(15, 95);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtCantidad.Location = new System.Drawing.Point(18, 113);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(90, 24);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.Text = "1";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioUnitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrecioUnitario.Location = new System.Drawing.Point(120, 95);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(110, 15);
            this.lblPrecioUnitario.TabIndex = 9;
            this.lblPrecioUnitario.Text = "Precio Unitario ($):";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(122, 113);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(115, 24);
            this.txtPrecioUnitario.TabIndex = 10;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(250, 95);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(98, 15);
            this.lblMetodoPago.TabIndex = 11;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(252, 113);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(180, 24);
            this.cboMetodoPago.TabIndex = 12;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblObservaciones.Location = new System.Drawing.Point(445, 95);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(150, 15);
            this.lblObservaciones.TabIndex = 13;
            this.lblObservaciones.Text = "Observaciones / Garantía:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservaciones.Location = new System.Drawing.Point(448, 113);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(390, 24);
            this.txtObservaciones.TabIndex = 14;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(510, 155);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(180, 36);
            this.btnRegistrar.TabIndex = 15;
            this.btnRegistrar.Text = "🛒 Confirmar Venta";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiar.Location = new System.Drawing.Point(700, 155);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(138, 36);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "🧹 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.White;
            this.pnlListado.Controls.Add(this.txtBuscar);
            this.pnlListado.Controls.Add(this.lblBuscar);
            this.pnlListado.Controls.Add(this.dgvVentas);
            this.pnlListado.Controls.Add(this.lblSubtitulo);
            this.pnlListado.Location = new System.Drawing.Point(15, 234);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(857, 348);
            this.pnlListado.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(15, 14);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(230, 19);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "📋 Historial de Ventas de Mostrador";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBuscar.Location = new System.Drawing.Point(555, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 15);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "🔍 Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(618, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(224, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvVentas.ColumnHeadersHeight = 32;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.Location = new System.Drawing.Point(15, 42);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(827, 290);
            this.dgvVentas.TabIndex = 3;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFormulario);
            this.Name = "FrmVentas";
            this.Text = "Venta de Refacciones";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            this.pnlListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblRefaccion;
        private System.Windows.Forms.ComboBox cboRefaccion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvVentas;
    }
}
