namespace SistemaServicioTecnico.Vistas.Procesos
{
    partial class FrmCompras
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
            System.Windows.Forms.DataGridViewCellStyle dgvStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlProveedor = new System.Windows.Forms.Panel();
            this.btnGuardarProveedor = new System.Windows.Forms.Button();
            this.txtTelProv = new System.Windows.Forms.TextBox();
            this.lblTelProv = new System.Windows.Forms.Label();
            this.txtContactoProv = new System.Windows.Forms.TextBox();
            this.lblContactoProv = new System.Windows.Forms.Label();
            this.txtRFCProv = new System.Windows.Forms.TextBox();
            this.lblRFCProv = new System.Windows.Forms.Label();
            this.txtNombreProv = new System.Windows.Forms.TextBox();
            this.lblNombreProv = new System.Windows.Forms.Label();
            this.lblTituloProv = new System.Windows.Forms.Label();
            this.pnlCompra = new System.Windows.Forms.Panel();
            this.btnRegistrarCompra = new System.Windows.Forms.Button();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.lblCostoUnitario = new System.Windows.Forms.Label();
            this.txtCantidadCompra = new System.Windows.Forms.TextBox();
            this.lblCantidadCompra = new System.Windows.Forms.Label();
            this.cboRefaccionCompra = new System.Windows.Forms.ComboBox();
            this.lblRefaccionCompra = new System.Windows.Forms.Label();
            this.cboProveedorCompra = new System.Windows.Forms.ComboBox();
            this.lblProvCompra = new System.Windows.Forms.Label();
            this.txtFolioCompra = new System.Windows.Forms.TextBox();
            this.lblFolioCompra = new System.Windows.Forms.Label();
            this.lblTituloCompra = new System.Windows.Forms.Label();
            this.pnlTablas = new System.Windows.Forms.Panel();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.lblSubCompras = new System.Windows.Forms.Label();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.lblSubProveedores = new System.Windows.Forms.Label();
            this.pnlProveedor.SuspendLayout();
            this.pnlCompra.SuspendLayout();
            this.pnlTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProveedor
            // 
            this.pnlProveedor.BackColor = System.Drawing.Color.White;
            this.pnlProveedor.Controls.Add(this.btnGuardarProveedor);
            this.pnlProveedor.Controls.Add(this.txtTelProv);
            this.pnlProveedor.Controls.Add(this.lblTelProv);
            this.pnlProveedor.Controls.Add(this.txtContactoProv);
            this.pnlProveedor.Controls.Add(this.lblContactoProv);
            this.pnlProveedor.Controls.Add(this.txtRFCProv);
            this.pnlProveedor.Controls.Add(this.lblRFCProv);
            this.pnlProveedor.Controls.Add(this.txtNombreProv);
            this.pnlProveedor.Controls.Add(this.lblNombreProv);
            this.pnlProveedor.Controls.Add(this.lblTituloProv);
            this.pnlProveedor.Location = new System.Drawing.Point(15, 12);
            this.pnlProveedor.Name = "pnlProveedor";
            this.pnlProveedor.Size = new System.Drawing.Size(415, 210);
            this.pnlProveedor.TabIndex = 0;
            // 
            // lblTituloProv
            // 
            this.lblTituloProv.AutoSize = true;
            this.lblTituloProv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloProv.Location = new System.Drawing.Point(15, 12);
            this.lblTituloProv.Name = "lblTituloProv";
            this.lblTituloProv.Size = new System.Drawing.Size(185, 20);
            this.lblTituloProv.TabIndex = 0;
            this.lblTituloProv.Text = "🏢 Alta de Proveedores";
            // 
            // lblNombreProv
            // 
            this.lblNombreProv.AutoSize = true;
            this.lblNombreProv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNombreProv.Location = new System.Drawing.Point(15, 42);
            this.lblNombreProv.Name = "lblNombreProv";
            this.lblNombreProv.Size = new System.Drawing.Size(156, 15);
            this.lblNombreProv.TabIndex = 1;
            this.lblNombreProv.Text = "Empresa / Razón Social: *";
            // 
            // txtNombreProv
            // 
            this.txtNombreProv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreProv.Location = new System.Drawing.Point(18, 60);
            this.txtNombreProv.Name = "txtNombreProv";
            this.txtNombreProv.Size = new System.Drawing.Size(245, 24);
            this.txtNombreProv.TabIndex = 2;
            // 
            // lblRFCProv
            // 
            this.lblRFCProv.AutoSize = true;
            this.lblRFCProv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRFCProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRFCProv.Location = new System.Drawing.Point(272, 42);
            this.lblRFCProv.Name = "lblRFCProv";
            this.lblRFCProv.Size = new System.Drawing.Size(32, 15);
            this.lblRFCProv.TabIndex = 3;
            this.lblRFCProv.Text = "RFC:";
            // 
            // txtRFCProv
            // 
            this.txtRFCProv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRFCProv.Location = new System.Drawing.Point(275, 60);
            this.txtRFCProv.Name = "txtRFCProv";
            this.txtRFCProv.Size = new System.Drawing.Size(122, 24);
            this.txtRFCProv.TabIndex = 4;
            // 
            // lblContactoProv
            // 
            this.lblContactoProv.AutoSize = true;
            this.lblContactoProv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContactoProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblContactoProv.Location = new System.Drawing.Point(15, 95);
            this.lblContactoProv.Name = "lblContactoProv";
            this.lblContactoProv.Size = new System.Drawing.Size(121, 15);
            this.lblContactoProv.TabIndex = 5;
            this.lblContactoProv.Text = "Nombre de Contacto:";
            // 
            // txtContactoProv
            // 
            this.txtContactoProv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContactoProv.Location = new System.Drawing.Point(18, 113);
            this.txtContactoProv.Name = "txtContactoProv";
            this.txtContactoProv.Size = new System.Drawing.Size(215, 24);
            this.txtContactoProv.TabIndex = 6;
            // 
            // lblTelProv
            // 
            this.lblTelProv.AutoSize = true;
            this.lblTelProv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTelProv.Location = new System.Drawing.Point(242, 95);
            this.lblTelProv.Name = "lblTelProv";
            this.lblTelProv.Size = new System.Drawing.Size(55, 15);
            this.lblTelProv.TabIndex = 7;
            this.lblTelProv.Text = "Teléfono:";
            // 
            // txtTelProv
            // 
            this.txtTelProv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelProv.Location = new System.Drawing.Point(245, 113);
            this.txtTelProv.Name = "txtTelProv";
            this.txtTelProv.Size = new System.Drawing.Size(152, 24);
            this.txtTelProv.TabIndex = 8;
            // 
            // btnGuardarProveedor
            // 
            this.btnGuardarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuardarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarProveedor.FlatAppearance.BorderSize = 0;
            this.btnGuardarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnGuardarProveedor.Location = new System.Drawing.Point(222, 155);
            this.btnGuardarProveedor.Name = "btnGuardarProveedor";
            this.btnGuardarProveedor.Size = new System.Drawing.Size(175, 34);
            this.btnGuardarProveedor.TabIndex = 9;
            this.btnGuardarProveedor.Text = "💾 Guardar Proveedor";
            this.btnGuardarProveedor.UseVisualStyleBackColor = false;
            this.btnGuardarProveedor.Click += new System.EventHandler(this.btnGuardarProveedor_Click);
            // 
            // pnlCompra
            // 
            this.pnlCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCompra.BackColor = System.Drawing.Color.White;
            this.pnlCompra.Controls.Add(this.btnRegistrarCompra);
            this.pnlCompra.Controls.Add(this.txtCostoUnitario);
            this.pnlCompra.Controls.Add(this.lblCostoUnitario);
            this.pnlCompra.Controls.Add(this.txtCantidadCompra);
            this.pnlCompra.Controls.Add(this.lblCantidadCompra);
            this.pnlCompra.Controls.Add(this.cboRefaccionCompra);
            this.pnlCompra.Controls.Add(this.lblRefaccionCompra);
            this.pnlCompra.Controls.Add(this.cboProveedorCompra);
            this.pnlCompra.Controls.Add(this.lblProvCompra);
            this.pnlCompra.Controls.Add(this.txtFolioCompra);
            this.pnlCompra.Controls.Add(this.lblFolioCompra);
            this.pnlCompra.Controls.Add(this.lblTituloCompra);
            this.pnlCompra.Location = new System.Drawing.Point(442, 12);
            this.pnlCompra.Name = "pnlCompra";
            this.pnlCompra.Size = new System.Drawing.Size(430, 210);
            this.pnlCompra.TabIndex = 1;
            // 
            // lblTituloCompra
            // 
            this.lblTituloCompra.AutoSize = true;
            this.lblTituloCompra.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloCompra.Location = new System.Drawing.Point(15, 12);
            this.lblTituloCompra.Name = "lblTituloCompra";
            this.lblTituloCompra.Size = new System.Drawing.Size(265, 20);
            this.lblTituloCompra.TabIndex = 0;
            this.lblTituloCompra.Text = "🚚 Orden de Compra / Resurtido";
            // 
            // lblFolioCompra
            // 
            this.lblFolioCompra.AutoSize = true;
            this.lblFolioCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolioCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFolioCompra.Location = new System.Drawing.Point(15, 42);
            this.lblFolioCompra.Name = "lblFolioCompra";
            this.lblFolioCompra.Size = new System.Drawing.Size(36, 15);
            this.lblFolioCompra.TabIndex = 1;
            this.lblFolioCompra.Text = "Folio:";
            // 
            // txtFolioCompra
            // 
            this.txtFolioCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtFolioCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtFolioCompra.Location = new System.Drawing.Point(18, 60);
            this.txtFolioCompra.Name = "txtFolioCompra";
            this.txtFolioCompra.ReadOnly = true;
            this.txtFolioCompra.Size = new System.Drawing.Size(120, 24);
            this.txtFolioCompra.TabIndex = 2;
            // 
            // lblProvCompra
            // 
            this.lblProvCompra.AutoSize = true;
            this.lblProvCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProvCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProvCompra.Location = new System.Drawing.Point(150, 42);
            this.lblProvCompra.Name = "lblProvCompra";
            this.lblProvCompra.Size = new System.Drawing.Size(65, 15);
            this.lblProvCompra.TabIndex = 3;
            this.lblProvCompra.Text = "Proveedor:";
            // 
            // cboProveedorCompra
            // 
            this.cboProveedorCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedorCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboProveedorCompra.FormattingEnabled = true;
            this.cboProveedorCompra.Location = new System.Drawing.Point(152, 60);
            this.cboProveedorCompra.Name = "cboProveedorCompra";
            this.cboProveedorCompra.Size = new System.Drawing.Size(260, 24);
            this.cboProveedorCompra.TabIndex = 4;
            // 
            // lblRefaccionCompra
            // 
            this.lblRefaccionCompra.AutoSize = true;
            this.lblRefaccionCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRefaccionCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRefaccionCompra.Location = new System.Drawing.Point(15, 95);
            this.lblRefaccionCompra.Name = "lblRefaccionCompra";
            this.lblRefaccionCompra.Size = new System.Drawing.Size(62, 15);
            this.lblRefaccionCompra.TabIndex = 5;
            this.lblRefaccionCompra.Text = "Refacción:";
            // 
            // cboRefaccionCompra
            // 
            this.cboRefaccionCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefaccionCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRefaccionCompra.FormattingEnabled = true;
            this.cboRefaccionCompra.Location = new System.Drawing.Point(18, 113);
            this.cboRefaccionCompra.Name = "cboRefaccionCompra";
            this.cboRefaccionCompra.Size = new System.Drawing.Size(210, 24);
            this.cboRefaccionCompra.TabIndex = 6;
            // 
            // lblCantidadCompra
            // 
            this.lblCantidadCompra.AutoSize = true;
            this.lblCantidadCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidadCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCantidadCompra.Location = new System.Drawing.Point(238, 95);
            this.lblCantidadCompra.Name = "lblCantidadCompra";
            this.lblCantidadCompra.Size = new System.Drawing.Size(37, 15);
            this.lblCantidadCompra.TabIndex = 7;
            this.lblCantidadCompra.Text = "Cant.:";
            // 
            // txtCantidadCompra
            // 
            this.txtCantidadCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCantidadCompra.Location = new System.Drawing.Point(240, 113);
            this.txtCantidadCompra.Name = "txtCantidadCompra";
            this.txtCantidadCompra.Size = new System.Drawing.Size(65, 24);
            this.txtCantidadCompra.TabIndex = 8;
            this.txtCantidadCompra.Text = "5";
            // 
            // lblCostoUnitario
            // 
            this.lblCostoUnitario.AutoSize = true;
            this.lblCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCostoUnitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCostoUnitario.Location = new System.Drawing.Point(315, 95);
            this.lblCostoUnitario.Name = "lblCostoUnitario";
            this.lblCostoUnitario.Size = new System.Drawing.Size(90, 15);
            this.lblCostoUnitario.TabIndex = 9;
            this.lblCostoUnitario.Text = "Costo Unit. ($):";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtCostoUnitario.Location = new System.Drawing.Point(317, 113);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(95, 24);
            this.txtCostoUnitario.TabIndex = 10;
            this.txtCostoUnitario.Text = "450.00";
            // 
            // btnRegistrarCompra
            // 
            this.btnRegistrarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRegistrarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarCompra.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCompra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarCompra.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCompra.Location = new System.Drawing.Point(222, 155);
            this.btnRegistrarCompra.Name = "btnRegistrarCompra";
            this.btnRegistrarCompra.Size = new System.Drawing.Size(190, 34);
            this.btnRegistrarCompra.TabIndex = 11;
            this.btnRegistrarCompra.Text = "🚚 Registrar Compra";
            this.btnRegistrarCompra.UseVisualStyleBackColor = false;
            this.btnRegistrarCompra.Click += new System.EventHandler(this.btnRegistrarCompra_Click);
            // 
            // pnlTablas
            // 
            this.pnlTablas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTablas.BackColor = System.Drawing.Color.White;
            this.pnlTablas.Controls.Add(this.dgvCompras);
            this.pnlTablas.Controls.Add(this.lblSubCompras);
            this.pnlTablas.Controls.Add(this.dgvProveedores);
            this.pnlTablas.Controls.Add(this.lblSubProveedores);
            this.pnlTablas.Location = new System.Drawing.Point(15, 234);
            this.pnlTablas.Name = "pnlTablas";
            this.pnlTablas.Size = new System.Drawing.Size(857, 348);
            this.pnlTablas.TabIndex = 2;
            // 
            // lblSubProveedores
            // 
            this.lblSubProveedores.AutoSize = true;
            this.lblSubProveedores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubProveedores.Location = new System.Drawing.Point(15, 14);
            this.lblSubProveedores.Name = "lblSubProveedores";
            this.lblSubProveedores.Size = new System.Drawing.Size(185, 19);
            this.lblSubProveedores.TabIndex = 0;
            this.lblSubProveedores.Text = "🏢 Padrón de Proveedores";
            // 
            // lblSubCompras
            // 
            this.lblSubCompras.AutoSize = true;
            this.lblSubCompras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubCompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubCompras.Location = new System.Drawing.Point(435, 14);
            this.lblSubCompras.Name = "lblSubCompras";
            this.lblSubCompras.Size = new System.Drawing.Size(218, 19);
            this.lblSubCompras.TabIndex = 1;
            this.lblSubCompras.Text = "📦 Compras y Entradas a Stock";
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvProveedores.ColumnHeadersDefaultCellStyle = dgvStyle1;
            this.dgvProveedores.ColumnHeadersHeight = 32;
            this.dgvProveedores.EnableHeadersVisualStyles = false;
            this.dgvProveedores.Location = new System.Drawing.Point(15, 42);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(405, 290);
            this.dgvProveedores.TabIndex = 2;
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvCompras.ColumnHeadersDefaultCellStyle = dgvStyle2;
            this.dgvCompras.ColumnHeadersHeight = 32;
            this.dgvCompras.EnableHeadersVisualStyles = false;
            this.dgvCompras.Location = new System.Drawing.Point(435, 42);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(407, 290);
            this.dgvCompras.TabIndex = 3;
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlTablas);
            this.Controls.Add(this.pnlCompra);
            this.Controls.Add(this.pnlProveedor);
            this.Name = "FrmCompras";
            this.Text = "Compras y Proveedores";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            this.pnlProveedor.ResumeLayout(false);
            this.pnlProveedor.PerformLayout();
            this.pnlCompra.ResumeLayout(false);
            this.pnlCompra.PerformLayout();
            this.pnlTablas.ResumeLayout(false);
            this.pnlTablas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlProveedor;
        private System.Windows.Forms.Label lblTituloProv;
        private System.Windows.Forms.Label lblNombreProv;
        private System.Windows.Forms.TextBox txtNombreProv;
        private System.Windows.Forms.Label lblRFCProv;
        private System.Windows.Forms.TextBox txtRFCProv;
        private System.Windows.Forms.Label lblContactoProv;
        private System.Windows.Forms.TextBox txtContactoProv;
        private System.Windows.Forms.Label lblTelProv;
        private System.Windows.Forms.TextBox txtTelProv;
        private System.Windows.Forms.Button btnGuardarProveedor;
        private System.Windows.Forms.Panel pnlCompra;
        private System.Windows.Forms.Label lblTituloCompra;
        private System.Windows.Forms.Label lblFolioCompra;
        private System.Windows.Forms.TextBox txtFolioCompra;
        private System.Windows.Forms.Label lblProvCompra;
        private System.Windows.Forms.ComboBox cboProveedorCompra;
        private System.Windows.Forms.Label lblRefaccionCompra;
        private System.Windows.Forms.ComboBox cboRefaccionCompra;
        private System.Windows.Forms.Label lblCantidadCompra;
        private System.Windows.Forms.TextBox txtCantidadCompra;
        private System.Windows.Forms.Label lblCostoUnitario;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Button btnRegistrarCompra;
        private System.Windows.Forms.Panel pnlTablas;
        private System.Windows.Forms.Label lblSubProveedores;
        private System.Windows.Forms.Label lblSubCompras;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridView dgvCompras;
    }
}
