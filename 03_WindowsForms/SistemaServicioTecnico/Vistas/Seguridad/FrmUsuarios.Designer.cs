namespace SistemaServicioTecnico.Vistas.Seguridad
{
    partial class FrmUsuarios
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
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cboPuesto = new System.Windows.Forms.ComboBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlFormulario.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
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
            this.pnlFormulario.Controls.Add(this.txtCorreo);
            this.pnlFormulario.Controls.Add(this.lblCorreo);
            this.pnlFormulario.Controls.Add(this.cboRol);
            this.pnlFormulario.Controls.Add(this.lblRol);
            this.pnlFormulario.Controls.Add(this.txtContrasena);
            this.pnlFormulario.Controls.Add(this.lblContrasena);
            this.pnlFormulario.Controls.Add(this.txtUsuario);
            this.pnlFormulario.Controls.Add(this.lblUsuario);
            this.pnlFormulario.Controls.Add(this.cboPuesto);
            this.pnlFormulario.Controls.Add(this.lblPuesto);
            this.pnlFormulario.Controls.Add(this.txtEmpleado);
            this.pnlFormulario.Controls.Add(this.lblEmpleado);
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
            this.lblTitulo.Size = new System.Drawing.Size(320, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🔐 Administración de Usuarios, Roles y Personal";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmpleado.Location = new System.Drawing.Point(15, 42);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(145, 15);
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Nombre del Empleado: *";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmpleado.Location = new System.Drawing.Point(18, 60);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(270, 24);
            this.txtEmpleado.TabIndex = 2;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPuesto.Location = new System.Drawing.Point(302, 42);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(96, 15);
            this.lblPuesto.TabIndex = 3;
            this.lblPuesto.Text = "Puesto Laboral:";
            // 
            // cboPuesto
            // 
            this.cboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuesto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPuesto.FormattingEnabled = true;
            this.cboPuesto.Location = new System.Drawing.Point(305, 60);
            this.cboPuesto.Name = "cboPuesto";
            this.cboPuesto.Size = new System.Drawing.Size(185, 24);
            this.cboPuesto.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblUsuario.Location = new System.Drawing.Point(502, 42);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(118, 15);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario de Acceso: *";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.Location = new System.Drawing.Point(505, 60);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(160, 24);
            this.txtUsuario.TabIndex = 6;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblContrasena.Location = new System.Drawing.Point(678, 42);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(70, 15);
            this.lblContrasena.TabIndex = 7;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContrasena.Location = new System.Drawing.Point(680, 60);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(158, 24);
            this.txtContrasena.TabIndex = 8;
            this.txtContrasena.Text = "admin123";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRol.Location = new System.Drawing.Point(15, 95);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(92, 15);
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol del Sistema:";
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(18, 113);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(200, 24);
            this.cboRol.TabIndex = 10;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCorreo.Location = new System.Drawing.Point(230, 95);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(113, 15);
            this.lblCorreo.TabIndex = 11;
            this.lblCorreo.Text = "Correo Corporativo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorreo.Location = new System.Drawing.Point(232, 113);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(258, 24);
            this.txtCorreo.TabIndex = 12;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location = new System.Drawing.Point(505, 115);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(145, 21);
            this.chkActivo.TabIndex = 13;
            this.chkActivo.Text = "Cuenta Habilitada";
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
            this.btnGuardar.Location = new System.Drawing.Point(505, 155);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(185, 36);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "💾 Guardar Usuario";
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
            this.btnLimpiar.Location = new System.Drawing.Point(700, 155);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(138, 36);
            this.btnLimpiar.TabIndex = 15;
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
            this.pnlListado.Controls.Add(this.txtBuscar);
            this.pnlListado.Controls.Add(this.lblBuscar);
            this.pnlListado.Controls.Add(this.dgvUsuarios);
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
            this.lblSubtitulo.Size = new System.Drawing.Size(268, 19);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "👥 Plantilla de Usuarios y Nivel de Acceso";
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
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvUsuarios.ColumnHeadersHeight = 32;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(15, 42);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(827, 290);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFormulario);
            this.Name = "FrmUsuarios";
            this.Text = "Seguridad, Roles y Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            this.pnlListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cboPuesto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}
