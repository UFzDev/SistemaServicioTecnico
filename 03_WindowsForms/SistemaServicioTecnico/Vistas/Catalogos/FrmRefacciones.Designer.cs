namespace SistemaServicioTecnico.Vistas.Catalogos
{
    partial class FrmRefacciones
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.lblExistencia = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.lblSKU = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.cboFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.lblFiltroCat = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvRefacciones = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlFormulario.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.btnLimpiar);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.chkActivo);
            this.pnlFormulario.Controls.Add(this.txtDescripcion);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtStockMinimo);
            this.pnlFormulario.Controls.Add(this.lblStockMinimo);
            this.pnlFormulario.Controls.Add(this.txtExistencia);
            this.pnlFormulario.Controls.Add(this.lblExistencia);
            this.pnlFormulario.Controls.Add(this.txtPrecioVenta);
            this.pnlFormulario.Controls.Add(this.lblPrecioVenta);
            this.pnlFormulario.Controls.Add(this.txtCosto);
            this.pnlFormulario.Controls.Add(this.lblCosto);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.cboCategoria);
            this.pnlFormulario.Controls.Add(this.lblCategoria);
            this.pnlFormulario.Controls.Add(this.txtSKU);
            this.pnlFormulario.Controls.Add(this.lblSKU);
            this.pnlFormulario.Controls.Add(this.lblTitulo);
            this.pnlFormulario.Location = new System.Drawing.Point(15, 12);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(857, 215);
            this.pnlFormulario.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📦 Control de Refacciones e Inventario";
            // 
            // lblSKU
            // 
            this.lblSKU.AutoSize = true;
            this.lblSKU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSKU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSKU.Location = new System.Drawing.Point(15, 42);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(81, 15);
            this.lblSKU.TabIndex = 1;
            this.lblSKU.Text = "Código SKU: *";
            // 
            // txtSKU
            // 
            this.txtSKU.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtSKU.Location = new System.Drawing.Point(18, 60);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(130, 24);
            this.txtSKU.TabIndex = 2;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCategoria.Location = new System.Drawing.Point(160, 42);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(60, 15);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(162, 60);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(220, 24);
            this.cboCategoria.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNombre.Location = new System.Drawing.Point(395, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(152, 15);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre de la Refacción: *";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(398, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(440, 24);
            this.txtNombre.TabIndex = 6;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCosto.Location = new System.Drawing.Point(15, 95);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(83, 15);
            this.lblCosto.TabIndex = 7;
            this.lblCosto.Text = "Costo Ref. ($):";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCosto.Location = new System.Drawing.Point(18, 113);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(105, 24);
            this.txtCosto.TabIndex = 8;
            this.txtCosto.Text = "450.00";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrecioVenta.Location = new System.Drawing.Point(135, 95);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(96, 15);
            this.lblPrecioVenta.TabIndex = 9;
            this.lblPrecioVenta.Text = "Precio Venta ($):";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.txtPrecioVenta.Location = new System.Drawing.Point(138, 113);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(105, 24);
            this.txtPrecioVenta.TabIndex = 10;
            this.txtPrecioVenta.Text = "750.00";
            // 
            // lblExistencia
            // 
            this.lblExistencia.AutoSize = true;
            this.lblExistencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExistencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblExistencia.Location = new System.Drawing.Point(255, 95);
            this.lblExistencia.Name = "lblExistencia";
            this.lblExistencia.Size = new System.Drawing.Size(78, 15);
            this.lblExistencia.TabIndex = 11;
            this.lblExistencia.Text = "Stock Actual:";
            // 
            // txtExistencia
            // 
            this.txtExistencia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtExistencia.Location = new System.Drawing.Point(258, 113);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(80, 24);
            this.txtExistencia.TabIndex = 12;
            this.txtExistencia.Text = "10";
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStockMinimo.Location = new System.Drawing.Point(350, 95);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(85, 15);
            this.lblStockMinimo.TabIndex = 13;
            this.lblStockMinimo.Text = "Stock Mínimo:";
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtStockMinimo.Location = new System.Drawing.Point(352, 113);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(80, 24);
            this.txtStockMinimo.TabIndex = 14;
            this.txtStockMinimo.Text = "3";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(445, 95);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(173, 15);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción / Compatibilidad:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.Location = new System.Drawing.Point(448, 113);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(390, 24);
            this.txtDescripcion.TabIndex = 16;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location = new System.Drawing.Point(18, 165);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(123, 21);
            this.chkActivo.TabIndex = 17;
            this.chkActivo.Text = "Refacción Activa";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(510, 158);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 36);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "💾 Guardar Refacción";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiar.Location = new System.Drawing.Point(700, 158);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(138, 36);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "🧹 Nuevo / Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.White;
            this.pnlListado.Controls.Add(this.cboFiltroCategoria);
            this.pnlListado.Controls.Add(this.lblFiltroCat);
            this.pnlListado.Controls.Add(this.txtBuscar);
            this.pnlListado.Controls.Add(this.lblBuscar);
            this.pnlListado.Controls.Add(this.dgvRefacciones);
            this.pnlListado.Controls.Add(this.lblSubtitulo);
            this.pnlListado.Location = new System.Drawing.Point(15, 238);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(857, 344);
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
            this.lblSubtitulo.Text = "📋 Existencias Actuales en Almacén";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBuscar.Location = new System.Drawing.Point(280, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(90, 15);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "🔍 SKU / Pieza:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(375, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(175, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // lblFiltroCat
            // 
            this.lblFiltroCat.AutoSize = true;
            this.lblFiltroCat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFiltroCat.Location = new System.Drawing.Point(565, 16);
            this.lblFiltroCat.Name = "lblFiltroCat";
            this.lblFiltroCat.Size = new System.Drawing.Size(60, 15);
            this.lblFiltroCat.TabIndex = 3;
            this.lblFiltroCat.Text = "Categoría:";
            // 
            // cboFiltroCategoria
            // 
            this.cboFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroCategoria.FormattingEnabled = true;
            this.cboFiltroCategoria.Location = new System.Drawing.Point(628, 12);
            this.cboFiltroCategoria.Name = "cboFiltroCategoria";
            this.cboFiltroCategoria.Size = new System.Drawing.Size(214, 23);
            this.cboFiltroCategoria.TabIndex = 4;
            this.cboFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // dgvRefacciones
            // 
            this.dgvRefacciones.AllowUserToAddRows = false;
            this.dgvRefacciones.AllowUserToDeleteRows = false;
            this.dgvRefacciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefacciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRefacciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvRefacciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvRefacciones.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvRefacciones.ColumnHeadersHeight = 32;
            this.dgvRefacciones.EnableHeadersVisualStyles = false;
            this.dgvRefacciones.Location = new System.Drawing.Point(15, 42);
            this.dgvRefacciones.MultiSelect = false;
            this.dgvRefacciones.Name = "dgvRefacciones";
            this.dgvRefacciones.ReadOnly = true;
            this.dgvRefacciones.RowHeadersVisible = false;
            this.dgvRefacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefacciones.Size = new System.Drawing.Size(827, 286);
            this.dgvRefacciones.TabIndex = 5;
            this.dgvRefacciones.SelectionChanged += new System.EventHandler(this.dgvRefacciones_SelectionChanged);
            // 
            // FrmRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFormulario);
            this.Name = "FrmRefacciones";
            this.Text = "Inventario y Refacciones";
            this.Load += new System.EventHandler(this.FrmRefacciones_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            this.pnlListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefacciones)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblExistencia;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroCat;
        private System.Windows.Forms.ComboBox cboFiltroCategoria;
        private System.Windows.Forms.DataGridView dgvRefacciones;
    }
}
