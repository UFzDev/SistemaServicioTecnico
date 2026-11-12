namespace SistemaServicioTecnico.Vistas.Catalogos
{
    partial class FrmServicios
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
            this.pnlFormularioServicio = new System.Windows.Forms.Panel();
            this.btnLimpiarServicio = new System.Windows.Forms.Button();
            this.btnGuardarServicio = new System.Windows.Forms.Button();
            this.chkServicioActivo = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.lblNombreServicio = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblEstadoEdicion = new System.Windows.Forms.Label();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.pnlListadoServicios = new System.Windows.Forms.Panel();
            this.cboFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.lblFiltroCategoria = new System.Windows.Forms.Label();
            this.txtBuscarServicio = new System.Windows.Forms.TextBox();
            this.lblBuscarServicio = new System.Windows.Forms.Label();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.lblSubtituloServicios = new System.Windows.Forms.Label();
            this.pnlFormularioServicio.SuspendLayout();
            this.pnlListadoServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormularioServicio
            // 
            this.pnlFormularioServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormularioServicio.BackColor = System.Drawing.Color.White;
            this.pnlFormularioServicio.Controls.Add(this.btnLimpiarServicio);
            this.pnlFormularioServicio.Controls.Add(this.btnGuardarServicio);
            this.pnlFormularioServicio.Controls.Add(this.chkServicioActivo);
            this.pnlFormularioServicio.Controls.Add(this.txtDescripcion);
            this.pnlFormularioServicio.Controls.Add(this.lblDescripcion);
            this.pnlFormularioServicio.Controls.Add(this.txtPrecioBase);
            this.pnlFormularioServicio.Controls.Add(this.lblPrecioBase);
            this.pnlFormularioServicio.Controls.Add(this.txtNombreServicio);
            this.pnlFormularioServicio.Controls.Add(this.lblNombreServicio);
            this.pnlFormularioServicio.Controls.Add(this.cboCategoria);
            this.pnlFormularioServicio.Controls.Add(this.lblCategoria);
            this.pnlFormularioServicio.Controls.Add(this.lblEstadoEdicion);
            this.pnlFormularioServicio.Controls.Add(this.lblTituloFormulario);
            this.pnlFormularioServicio.Location = new System.Drawing.Point(15, 12);
            this.pnlFormularioServicio.Name = "pnlFormularioServicio";
            this.pnlFormularioServicio.Size = new System.Drawing.Size(857, 210);
            this.pnlFormularioServicio.TabIndex = 0;
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(15, 12);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(294, 20);
            this.lblTituloFormulario.TabIndex = 0;
            this.lblTituloFormulario.Text = "🛠️ Registro y Edición de Servicio de Taller";
            // 
            // lblEstadoEdicion
            // 
            this.lblEstadoEdicion.AutoSize = true;
            this.lblEstadoEdicion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblEstadoEdicion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblEstadoEdicion.Location = new System.Drawing.Point(320, 15);
            this.lblEstadoEdicion.Name = "lblEstadoEdicion";
            this.lblEstadoEdicion.Size = new System.Drawing.Size(150, 15);
            this.lblEstadoEdicion.TabIndex = 1;
            this.lblEstadoEdicion.Text = "(Modo: Nuevo Servicio)";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCategoria.Location = new System.Drawing.Point(15, 45);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(134, 15);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría del Servicio: *";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(18, 63);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(270, 24);
            this.cboCategoria.TabIndex = 3;
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.AutoSize = true;
            this.lblNombreServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNombreServicio.Location = new System.Drawing.Point(302, 45);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(128, 15);
            this.lblNombreServicio.TabIndex = 4;
            this.lblNombreServicio.Text = "Nombre del Servicio: *";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreServicio.Location = new System.Drawing.Point(305, 63);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(370, 24);
            this.txtNombreServicio.TabIndex = 5;
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrecioBase.Location = new System.Drawing.Point(688, 45);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(96, 15);
            this.lblPrecioBase.TabIndex = 6;
            this.lblPrecioBase.Text = "Precio Base ($): *";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtPrecioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.txtPrecioBase.Location = new System.Drawing.Point(690, 63);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(148, 24);
            this.txtPrecioBase.TabIndex = 7;
            this.txtPrecioBase.Text = "350.00";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescripcion.Location = new System.Drawing.Point(15, 100);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(277, 15);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción detallada de las actividades incluidas:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.Location = new System.Drawing.Point(18, 118);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(445, 68);
            this.txtDescripcion.TabIndex = 9;
            // 
            // chkServicioActivo
            // 
            this.chkServicioActivo.AutoSize = true;
            this.chkServicioActivo.Checked = true;
            this.chkServicioActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkServicioActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkServicioActivo.Location = new System.Drawing.Point(480, 120);
            this.chkServicioActivo.Name = "chkServicioActivo";
            this.chkServicioActivo.Size = new System.Drawing.Size(183, 21);
            this.chkServicioActivo.TabIndex = 10;
            this.chkServicioActivo.Text = "Servicio Activo en Catálogo";
            this.chkServicioActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardarServicio
            // 
            this.btnGuardarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuardarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarServicio.FlatAppearance.BorderSize = 0;
            this.btnGuardarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarServicio.ForeColor = System.Drawing.Color.White;
            this.btnGuardarServicio.Location = new System.Drawing.Point(480, 150);
            this.btnGuardarServicio.Name = "btnGuardarServicio";
            this.btnGuardarServicio.Size = new System.Drawing.Size(195, 36);
            this.btnGuardarServicio.TabIndex = 11;
            this.btnGuardarServicio.Text = "💾 Guardar Servicio";
            this.btnGuardarServicio.UseVisualStyleBackColor = false;
            this.btnGuardarServicio.Click += new System.EventHandler(this.btnGuardarServicio_Click);
            // 
            // btnLimpiarServicio
            // 
            this.btnLimpiarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarServicio.FlatAppearance.BorderSize = 0;
            this.btnLimpiarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiarServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiarServicio.Location = new System.Drawing.Point(688, 150);
            this.btnLimpiarServicio.Name = "btnLimpiarServicio";
            this.btnLimpiarServicio.Size = new System.Drawing.Size(150, 36);
            this.btnLimpiarServicio.TabIndex = 12;
            this.btnLimpiarServicio.Text = "🧹 Nuevo / Limpiar";
            this.btnLimpiarServicio.UseVisualStyleBackColor = false;
            this.btnLimpiarServicio.Click += new System.EventHandler(this.btnLimpiarServicio_Click);
            // 
            // pnlListadoServicios
            // 
            this.pnlListadoServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListadoServicios.BackColor = System.Drawing.Color.White;
            this.pnlListadoServicios.Controls.Add(this.cboFiltroCategoria);
            this.pnlListadoServicios.Controls.Add(this.lblFiltroCategoria);
            this.pnlListadoServicios.Controls.Add(this.txtBuscarServicio);
            this.pnlListadoServicios.Controls.Add(this.lblBuscarServicio);
            this.pnlListadoServicios.Controls.Add(this.dgvServicios);
            this.pnlListadoServicios.Controls.Add(this.lblSubtituloServicios);
            this.pnlListadoServicios.Location = new System.Drawing.Point(15, 234);
            this.pnlListadoServicios.Name = "pnlListadoServicios";
            this.pnlListadoServicios.Size = new System.Drawing.Size(857, 348);
            this.pnlListadoServicios.TabIndex = 1;
            // 
            // lblSubtituloServicios
            // 
            this.lblSubtituloServicios.AutoSize = true;
            this.lblSubtituloServicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtituloServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubtituloServicios.Location = new System.Drawing.Point(15, 14);
            this.lblSubtituloServicios.Name = "lblSubtituloServicios";
            this.lblSubtituloServicios.Size = new System.Drawing.Size(262, 19);
            this.lblSubtituloServicios.TabIndex = 0;
            this.lblSubtituloServicios.Text = "📋 Catálogo de Servicios y Tarifas Base";
            // 
            // lblBuscarServicio
            // 
            this.lblBuscarServicio.AutoSize = true;
            this.lblBuscarServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscarServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBuscarServicio.Location = new System.Drawing.Point(295, 16);
            this.lblBuscarServicio.Name = "lblBuscarServicio";
            this.lblBuscarServicio.Size = new System.Drawing.Size(58, 15);
            this.lblBuscarServicio.TabIndex = 1;
            this.lblBuscarServicio.Text = "🔍 Buscar:";
            // 
            // txtBuscarServicio
            // 
            this.txtBuscarServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarServicio.Location = new System.Drawing.Point(358, 12);
            this.txtBuscarServicio.Name = "txtBuscarServicio";
            this.txtBuscarServicio.Size = new System.Drawing.Size(185, 23);
            this.txtBuscarServicio.TabIndex = 2;
            this.txtBuscarServicio.TextChanged += new System.EventHandler(this.FiltroServicios_Changed);
            // 
            // lblFiltroCategoria
            // 
            this.lblFiltroCategoria.AutoSize = true;
            this.lblFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFiltroCategoria.Location = new System.Drawing.Point(558, 16);
            this.lblFiltroCategoria.Name = "lblFiltroCategoria";
            this.lblFiltroCategoria.Size = new System.Drawing.Size(60, 15);
            this.lblFiltroCategoria.TabIndex = 3;
            this.lblFiltroCategoria.Text = "Categoría:";
            // 
            // cboFiltroCategoria
            // 
            this.cboFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroCategoria.FormattingEnabled = true;
            this.cboFiltroCategoria.Location = new System.Drawing.Point(622, 12);
            this.cboFiltroCategoria.Name = "cboFiltroCategoria";
            this.cboFiltroCategoria.Size = new System.Drawing.Size(220, 23);
            this.cboFiltroCategoria.TabIndex = 4;
            this.cboFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.FiltroServicios_Changed);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvServicios.ColumnHeadersHeight = 32;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.Location = new System.Drawing.Point(15, 42);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(827, 290);
            this.dgvServicios.TabIndex = 5;
            this.dgvServicios.SelectionChanged += new System.EventHandler(this.dgvServicios_SelectionChanged);
            // 
            // FrmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlListadoServicios);
            this.Controls.Add(this.pnlFormularioServicio);
            this.Name = "FrmServicios";
            this.Text = "Catálogo de Servicios";
            this.Load += new System.EventHandler(this.FrmServicios_Load);
            this.pnlFormularioServicio.ResumeLayout(false);
            this.pnlFormularioServicio.PerformLayout();
            this.pnlListadoServicios.ResumeLayout(false);
            this.pnlListadoServicios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormularioServicio;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label lblEstadoEdicion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblNombreServicio;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkServicioActivo;
        private System.Windows.Forms.Button btnGuardarServicio;
        private System.Windows.Forms.Button btnLimpiarServicio;
        private System.Windows.Forms.Panel pnlListadoServicios;
        private System.Windows.Forms.Label lblSubtituloServicios;
        private System.Windows.Forms.Label lblBuscarServicio;
        private System.Windows.Forms.TextBox txtBuscarServicio;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private System.Windows.Forms.ComboBox cboFiltroCategoria;
        private System.Windows.Forms.DataGridView dgvServicios;
    }
}
