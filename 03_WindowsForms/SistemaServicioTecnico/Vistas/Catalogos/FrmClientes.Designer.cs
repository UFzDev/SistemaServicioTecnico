namespace SistemaServicioTecnico.Vistas.Catalogos
{
    partial class FrmClientes
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFormularioCliente = new System.Windows.Forms.Panel();
            this.btnLimpiarCliente = new System.Windows.Forms.Button();
            this.btnGuardarCliente = new System.Windows.Forms.Button();
            this.chkClienteActivo = new System.Windows.Forms.CheckBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTituloCliente = new System.Windows.Forms.Label();
            this.pnlFormularioEquipo = new System.Windows.Forms.Panel();
            this.btnGuardarEquipo = new System.Windows.Forms.Button();
            this.txtCaracteristicas = new System.Windows.Forms.TextBox();
            this.lblCaracteristicas = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cboTipoEquipo = new System.Windows.Forms.ComboBox();
            this.lblTipoEquipo = new System.Windows.Forms.Label();
            this.lblClienteSeleccionadoEquipo = new System.Windows.Forms.Label();
            this.lblTituloEquipo = new System.Windows.Forms.Label();
            this.pnlTablas = new System.Windows.Forms.Panel();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.lblSubtituloEquipos = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblSubtituloClientes = new System.Windows.Forms.Label();
            this.pnlFormularioCliente.SuspendLayout();
            this.pnlFormularioEquipo.SuspendLayout();
            this.pnlTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormularioCliente
            // 
            this.pnlFormularioCliente.BackColor = System.Drawing.Color.White;
            this.pnlFormularioCliente.Controls.Add(this.btnLimpiarCliente);
            this.pnlFormularioCliente.Controls.Add(this.btnGuardarCliente);
            this.pnlFormularioCliente.Controls.Add(this.chkClienteActivo);
            this.pnlFormularioCliente.Controls.Add(this.txtDireccion);
            this.pnlFormularioCliente.Controls.Add(this.lblDireccion);
            this.pnlFormularioCliente.Controls.Add(this.txtCorreo);
            this.pnlFormularioCliente.Controls.Add(this.lblCorreo);
            this.pnlFormularioCliente.Controls.Add(this.txtTelefono);
            this.pnlFormularioCliente.Controls.Add(this.lblTelefono);
            this.pnlFormularioCliente.Controls.Add(this.txtApellidos);
            this.pnlFormularioCliente.Controls.Add(this.lblApellidos);
            this.pnlFormularioCliente.Controls.Add(this.txtNombre);
            this.pnlFormularioCliente.Controls.Add(this.lblNombre);
            this.pnlFormularioCliente.Controls.Add(this.lblTituloCliente);
            this.pnlFormularioCliente.Location = new System.Drawing.Point(15, 12);
            this.pnlFormularioCliente.Name = "pnlFormularioCliente";
            this.pnlFormularioCliente.Size = new System.Drawing.Size(425, 235);
            this.pnlFormularioCliente.TabIndex = 0;
            // 
            // lblTituloCliente
            // 
            this.lblTituloCliente.AutoSize = true;
            this.lblTituloCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloCliente.Location = new System.Drawing.Point(15, 12);
            this.lblTituloCliente.Name = "lblTituloCliente";
            this.lblTituloCliente.Size = new System.Drawing.Size(175, 20);
            this.lblTituloCliente.TabIndex = 0;
            this.lblTituloCliente.Text = "👤 Datos del Cliente";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNombre.Location = new System.Drawing.Point(15, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 15);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre(s): *";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(18, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(190, 24);
            this.txtNombre.TabIndex = 2;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblApellidos.Location = new System.Drawing.Point(220, 42);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(57, 15);
            this.lblApellidos.TabIndex = 3;
            this.lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellidos.Location = new System.Drawing.Point(222, 60);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(188, 24);
            this.txtApellidos.TabIndex = 4;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTelefono.Location = new System.Drawing.Point(15, 92);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 15);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location = new System.Drawing.Point(18, 110);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(145, 24);
            this.txtTelefono.TabIndex = 6;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCorreo.Location = new System.Drawing.Point(175, 92);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(108, 15);
            this.lblCorreo.TabIndex = 7;
            this.lblCorreo.Text = "Correo Electrónico:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorreo.Location = new System.Drawing.Point(177, 110);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(233, 24);
            this.txtCorreo.TabIndex = 8;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDireccion.Location = new System.Drawing.Point(15, 142);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 15);
            this.lblDireccion.TabIndex = 9;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location = new System.Drawing.Point(18, 160);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(392, 24);
            this.txtDireccion.TabIndex = 10;
            // 
            // chkClienteActivo
            // 
            this.chkClienteActivo.AutoSize = true;
            this.chkClienteActivo.Checked = true;
            this.chkClienteActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClienteActivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkClienteActivo.Location = new System.Drawing.Point(18, 198);
            this.chkClienteActivo.Name = "chkClienteActivo";
            this.chkClienteActivo.Size = new System.Drawing.Size(60, 19);
            this.chkClienteActivo.TabIndex = 11;
            this.chkClienteActivo.Text = "Activo";
            this.chkClienteActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCliente
            // 
            this.btnGuardarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuardarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCliente.FlatAppearance.BorderSize = 0;
            this.btnGuardarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCliente.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCliente.Location = new System.Drawing.Point(165, 192);
            this.btnGuardarCliente.Name = "btnGuardarCliente";
            this.btnGuardarCliente.Size = new System.Drawing.Size(145, 32);
            this.btnGuardarCliente.TabIndex = 12;
            this.btnGuardarCliente.Text = "💾 Guardar Cliente";
            this.btnGuardarCliente.UseVisualStyleBackColor = false;
            this.btnGuardarCliente.Click += new System.EventHandler(this.btnGuardarCliente_Click);
            // 
            // btnLimpiarCliente
            // 
            this.btnLimpiarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCliente.FlatAppearance.BorderSize = 0;
            this.btnLimpiarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiarCliente.Location = new System.Drawing.Point(318, 192);
            this.btnLimpiarCliente.Name = "btnLimpiarCliente";
            this.btnLimpiarCliente.Size = new System.Drawing.Size(92, 32);
            this.btnLimpiarCliente.TabIndex = 13;
            this.btnLimpiarCliente.Text = "🧹 Nuevo";
            this.btnLimpiarCliente.UseVisualStyleBackColor = false;
            this.btnLimpiarCliente.Click += new System.EventHandler(this.btnLimpiarCliente_Click);
            // 
            // pnlFormularioEquipo
            // 
            this.pnlFormularioEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormularioEquipo.BackColor = System.Drawing.Color.White;
            this.pnlFormularioEquipo.Controls.Add(this.btnGuardarEquipo);
            this.pnlFormularioEquipo.Controls.Add(this.txtCaracteristicas);
            this.pnlFormularioEquipo.Controls.Add(this.lblCaracteristicas);
            this.pnlFormularioEquipo.Controls.Add(this.txtSerie);
            this.pnlFormularioEquipo.Controls.Add(this.lblSerie);
            this.pnlFormularioEquipo.Controls.Add(this.txtModelo);
            this.pnlFormularioEquipo.Controls.Add(this.lblModelo);
            this.pnlFormularioEquipo.Controls.Add(this.cboMarca);
            this.pnlFormularioEquipo.Controls.Add(this.lblMarca);
            this.pnlFormularioEquipo.Controls.Add(this.cboTipoEquipo);
            this.pnlFormularioEquipo.Controls.Add(this.lblTipoEquipo);
            this.pnlFormularioEquipo.Controls.Add(this.lblClienteSeleccionadoEquipo);
            this.pnlFormularioEquipo.Controls.Add(this.lblTituloEquipo);
            this.pnlFormularioEquipo.Location = new System.Drawing.Point(452, 12);
            this.pnlFormularioEquipo.Name = "pnlFormularioEquipo";
            this.pnlFormularioEquipo.Size = new System.Drawing.Size(420, 235);
            this.pnlFormularioEquipo.TabIndex = 1;
            // 
            // lblTituloEquipo
            // 
            this.lblTituloEquipo.AutoSize = true;
            this.lblTituloEquipo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloEquipo.Location = new System.Drawing.Point(15, 12);
            this.lblTituloEquipo.Name = "lblTituloEquipo";
            this.lblTituloEquipo.Size = new System.Drawing.Size(196, 20);
            this.lblTituloEquipo.TabIndex = 0;
            this.lblTituloEquipo.Text = "💻 Registrar Equipo a Cliente";
            // 
            // lblClienteSeleccionadoEquipo
            // 
            this.lblClienteSeleccionadoEquipo.AutoSize = true;
            this.lblClienteSeleccionadoEquipo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblClienteSeleccionadoEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblClienteSeleccionadoEquipo.Location = new System.Drawing.Point(225, 15);
            this.lblClienteSeleccionadoEquipo.Name = "lblClienteSeleccionadoEquipo";
            this.lblClienteSeleccionadoEquipo.Size = new System.Drawing.Size(170, 15);
            this.lblClienteSeleccionadoEquipo.TabIndex = 1;
            this.lblClienteSeleccionadoEquipo.Text = "(Seleccione un cliente abajo)";
            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTipoEquipo.Location = new System.Drawing.Point(15, 42);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(91, 15);
            this.lblTipoEquipo.TabIndex = 2;
            this.lblTipoEquipo.Text = "Tipo de Equipo:";
            // 
            // cboTipoEquipo
            // 
            this.cboTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTipoEquipo.FormattingEnabled = true;
            this.cboTipoEquipo.Location = new System.Drawing.Point(18, 60);
            this.cboTipoEquipo.Name = "cboTipoEquipo";
            this.cboTipoEquipo.Size = new System.Drawing.Size(185, 24);
            this.cboTipoEquipo.TabIndex = 3;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMarca.Location = new System.Drawing.Point(215, 42);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(42, 15);
            this.lblMarca.TabIndex = 4;
            this.lblMarca.Text = "Marca:";
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(218, 60);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(185, 24);
            this.cboMarca.TabIndex = 5;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblModelo.Location = new System.Drawing.Point(15, 92);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(59, 15);
            this.lblModelo.TabIndex = 6;
            this.lblModelo.Text = "Modelo: *";
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtModelo.Location = new System.Drawing.Point(18, 110);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(185, 24);
            this.txtModelo.TabIndex = 7;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSerie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSerie.Location = new System.Drawing.Point(215, 92);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(99, 15);
            this.lblSerie.TabIndex = 8;
            this.lblSerie.Text = "Número de Serie:";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSerie.Location = new System.Drawing.Point(218, 110);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(185, 24);
            this.txtSerie.TabIndex = 9;
            // 
            // lblCaracteristicas
            // 
            this.lblCaracteristicas.AutoSize = true;
            this.lblCaracteristicas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaracteristicas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCaracteristicas.Location = new System.Drawing.Point(15, 142);
            this.lblCaracteristicas.Name = "lblCaracteristicas";
            this.lblCaracteristicas.Size = new System.Drawing.Size(218, 15);
            this.lblCaracteristicas.TabIndex = 10;
            this.lblCaracteristicas.Text = "Características (RAM, Color, Accesorios):";
            // 
            // txtCaracteristicas
            // 
            this.txtCaracteristicas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCaracteristicas.Location = new System.Drawing.Point(18, 160);
            this.txtCaracteristicas.Name = "txtCaracteristicas";
            this.txtCaracteristicas.Size = new System.Drawing.Size(385, 24);
            this.txtCaracteristicas.TabIndex = 11;
            // 
            // btnGuardarEquipo
            // 
            this.btnGuardarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnGuardarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEquipo.FlatAppearance.BorderSize = 0;
            this.btnGuardarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEquipo.Location = new System.Drawing.Point(218, 192);
            this.btnGuardarEquipo.Name = "btnGuardarEquipo";
            this.btnGuardarEquipo.Size = new System.Drawing.Size(185, 32);
            this.btnGuardarEquipo.TabIndex = 12;
            this.btnGuardarEquipo.Text = "➕ Agregar Equipo";
            this.btnGuardarEquipo.UseVisualStyleBackColor = false;
            this.btnGuardarEquipo.Click += new System.EventHandler(this.btnGuardarEquipo_Click);
            // 
            // pnlTablas
            // 
            this.pnlTablas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTablas.BackColor = System.Drawing.Color.White;
            this.pnlTablas.Controls.Add(this.dgvEquipos);
            this.pnlTablas.Controls.Add(this.lblSubtituloEquipos);
            this.pnlTablas.Controls.Add(this.txtBuscar);
            this.pnlTablas.Controls.Add(this.lblBuscar);
            this.pnlTablas.Controls.Add(this.dgvClientes);
            this.pnlTablas.Controls.Add(this.lblSubtituloClientes);
            this.pnlTablas.Location = new System.Drawing.Point(15, 258);
            this.pnlTablas.Name = "pnlTablas";
            this.pnlTablas.Size = new System.Drawing.Size(857, 325);
            this.pnlTablas.TabIndex = 2;
            // 
            // lblSubtituloClientes
            // 
            this.lblSubtituloClientes.AutoSize = true;
            this.lblSubtituloClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtituloClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubtituloClientes.Location = new System.Drawing.Point(15, 14);
            this.lblSubtituloClientes.Name = "lblSubtituloClientes";
            this.lblSubtituloClientes.Size = new System.Drawing.Size(159, 19);
            this.lblSubtituloClientes.TabIndex = 0;
            this.lblSubtituloClientes.Text = "📋 Padrón de Clientes";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBuscar.Location = new System.Drawing.Point(185, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 15);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "🔍 Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(248, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(190, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblSubtituloEquipos
            // 
            this.lblSubtituloEquipos.AutoSize = true;
            this.lblSubtituloEquipos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtituloEquipos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubtituloEquipos.Location = new System.Drawing.Point(455, 14);
            this.lblSubtituloEquipos.Name = "lblSubtituloEquipos";
            this.lblSubtituloEquipos.Size = new System.Drawing.Size(218, 19);
            this.lblSubtituloEquipos.TabIndex = 3;
            this.lblSubtituloEquipos.Text = "📱 Equipos del Cliente Elegido";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dgvHeaderStyle1;
            this.dgvClientes.ColumnHeadersHeight = 32;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.Location = new System.Drawing.Point(15, 42);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(425, 268);
            this.dgvClientes.TabIndex = 4;
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dgvHeaderStyle2;
            this.dgvEquipos.ColumnHeadersHeight = 32;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.Location = new System.Drawing.Point(455, 42);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(387, 268);
            this.dgvEquipos.TabIndex = 5;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlTablas);
            this.Controls.Add(this.pnlFormularioEquipo);
            this.Controls.Add(this.pnlFormularioCliente);
            this.Name = "FrmClientes";
            this.Text = "Gestión de Clientes y Equipos";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.pnlFormularioCliente.ResumeLayout(false);
            this.pnlFormularioCliente.PerformLayout();
            this.pnlFormularioEquipo.ResumeLayout(false);
            this.pnlFormularioEquipo.PerformLayout();
            this.pnlTablas.ResumeLayout(false);
            this.pnlTablas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormularioCliente;
        private System.Windows.Forms.Label lblTituloCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.CheckBox chkClienteActivo;
        private System.Windows.Forms.Button btnGuardarCliente;
        private System.Windows.Forms.Button btnLimpiarCliente;
        private System.Windows.Forms.Panel pnlFormularioEquipo;
        private System.Windows.Forms.Label lblTituloEquipo;
        private System.Windows.Forms.Label lblClienteSeleccionadoEquipo;
        private System.Windows.Forms.Label lblTipoEquipo;
        private System.Windows.Forms.ComboBox cboTipoEquipo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblCaracteristicas;
        private System.Windows.Forms.TextBox txtCaracteristicas;
        private System.Windows.Forms.Button btnGuardarEquipo;
        private System.Windows.Forms.Panel pnlTablas;
        private System.Windows.Forms.Label lblSubtituloClientes;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblSubtituloEquipos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridView dgvEquipos;
    }
}
