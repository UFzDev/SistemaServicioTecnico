namespace SistemaServicioTecnico.Vistas.Procesos
{
    partial class FrmOrdenServicio
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
            this.pnlCapturaOrden = new System.Windows.Forms.Panel();
            this.btnLimpiarOrden = new System.Windows.Forms.Button();
            this.btnActualizarOrden = new System.Windows.Forms.Button();
            this.btnRegistrarOrden = new System.Windows.Forms.Button();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.cboServicioRapido = new System.Windows.Forms.ComboBox();
            this.lblServicioRapido = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtFallaReportada = new System.Windows.Forms.TextBox();
            this.lblFallaReportada = new System.Windows.Forms.Label();
            this.dtpFechaPrometida = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPrometida = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEquipo = new System.Windows.Forms.ComboBox();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblTituloCaptura = new System.Windows.Forms.Label();
            this.pnlListadoOrdenes = new System.Windows.Forms.Panel();
            this.cboFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.txtBuscarOrden = new System.Windows.Forms.TextBox();
            this.lblBuscarOrden = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.lblSubtituloOrdenes = new System.Windows.Forms.Label();
            this.pnlCapturaOrden.SuspendLayout();
            this.pnlListadoOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCapturaOrden
            // 
            this.pnlCapturaOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCapturaOrden.BackColor = System.Drawing.Color.White;
            this.pnlCapturaOrden.Controls.Add(this.btnLimpiarOrden);
            this.pnlCapturaOrden.Controls.Add(this.btnActualizarOrden);
            this.pnlCapturaOrden.Controls.Add(this.btnRegistrarOrden);
            this.pnlCapturaOrden.Controls.Add(this.txtPresupuesto);
            this.pnlCapturaOrden.Controls.Add(this.lblPresupuesto);
            this.pnlCapturaOrden.Controls.Add(this.cboServicioRapido);
            this.pnlCapturaOrden.Controls.Add(this.lblServicioRapido);
            this.pnlCapturaOrden.Controls.Add(this.txtDiagnostico);
            this.pnlCapturaOrden.Controls.Add(this.lblDiagnostico);
            this.pnlCapturaOrden.Controls.Add(this.txtFallaReportada);
            this.pnlCapturaOrden.Controls.Add(this.lblFallaReportada);
            this.pnlCapturaOrden.Controls.Add(this.dtpFechaPrometida);
            this.pnlCapturaOrden.Controls.Add(this.lblFechaPrometida);
            this.pnlCapturaOrden.Controls.Add(this.cboEstado);
            this.pnlCapturaOrden.Controls.Add(this.lblEstado);
            this.pnlCapturaOrden.Controls.Add(this.cboEquipo);
            this.pnlCapturaOrden.Controls.Add(this.lblEquipo);
            this.pnlCapturaOrden.Controls.Add(this.cboCliente);
            this.pnlCapturaOrden.Controls.Add(this.lblCliente);
            this.pnlCapturaOrden.Controls.Add(this.txtFolio);
            this.pnlCapturaOrden.Controls.Add(this.lblFolio);
            this.pnlCapturaOrden.Controls.Add(this.lblTituloCaptura);
            this.pnlCapturaOrden.Location = new System.Drawing.Point(15, 12);
            this.pnlCapturaOrden.Name = "pnlCapturaOrden";
            this.pnlCapturaOrden.Size = new System.Drawing.Size(857, 250);
            this.pnlCapturaOrden.TabIndex = 0;
            // 
            // lblTituloCaptura
            // 
            this.lblTituloCaptura.AutoSize = true;
            this.lblTituloCaptura.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloCaptura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloCaptura.Location = new System.Drawing.Point(15, 12);
            this.lblTituloCaptura.Name = "lblTituloCaptura";
            this.lblTituloCaptura.Size = new System.Drawing.Size(288, 20);
            this.lblTituloCaptura.TabIndex = 0;
            this.lblTituloCaptura.Text = "📋 Recepción y Control de Orden Técnica";
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
            this.txtFolio.Size = new System.Drawing.Size(120, 24);
            this.txtFolio.TabIndex = 2;
            this.txtFolio.Text = "OS-2026-0006";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCliente.Location = new System.Drawing.Point(148, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(55, 15);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente: *";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(150, 60);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(215, 24);
            this.cboCliente.TabIndex = 4;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEquipo.Location = new System.Drawing.Point(15, 92);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(116, 15);
            this.lblEquipo.TabIndex = 5;
            this.lblEquipo.Text = "Equipo a Reparar: *";
            // 
            // cboEquipo
            // 
            this.cboEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.Location = new System.Drawing.Point(18, 110);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(347, 24);
            this.cboEquipo.TabIndex = 6;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEstado.Location = new System.Drawing.Point(15, 142);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(96, 15);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado de Orden:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(18, 160);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(185, 24);
            this.cboEstado.TabIndex = 8;
            // 
            // lblFechaPrometida
            // 
            this.lblFechaPrometida.AutoSize = true;
            this.lblFechaPrometida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaPrometida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFechaPrometida.Location = new System.Drawing.Point(215, 142);
            this.lblFechaPrometida.Name = "lblFechaPrometida";
            this.lblFechaPrometida.Size = new System.Drawing.Size(99, 15);
            this.lblFechaPrometida.TabIndex = 9;
            this.lblFechaPrometida.Text = "Fecha Prometida:";
            // 
            // dtpFechaPrometida
            // 
            this.dtpFechaPrometida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaPrometida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPrometida.Location = new System.Drawing.Point(218, 160);
            this.dtpFechaPrometida.Name = "dtpFechaPrometida";
            this.dtpFechaPrometida.Size = new System.Drawing.Size(147, 24);
            this.dtpFechaPrometida.TabIndex = 10;
            // 
            // lblServicioRapido
            // 
            this.lblServicioRapido.AutoSize = true;
            this.lblServicioRapido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServicioRapido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblServicioRapido.Location = new System.Drawing.Point(15, 192);
            this.lblServicioRapido.Name = "lblServicioRapido";
            this.lblServicioRapido.Size = new System.Drawing.Size(134, 15);
            this.lblServicioRapido.TabIndex = 11;
            this.lblServicioRapido.Text = "Servicio / Mano de Obra:";
            // 
            // cboServicioRapido
            // 
            this.cboServicioRapido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicioRapido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboServicioRapido.FormattingEnabled = true;
            this.cboServicioRapido.Location = new System.Drawing.Point(18, 210);
            this.cboServicioRapido.Name = "cboServicioRapido";
            this.cboServicioRapido.Size = new System.Drawing.Size(235, 23);
            this.cboServicioRapido.TabIndex = 12;
            this.cboServicioRapido.SelectedIndexChanged += new System.EventHandler(this.cboServicioRapido_SelectedIndexChanged);
            // 
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPresupuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPresupuesto.Location = new System.Drawing.Point(262, 192);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(96, 15);
            this.lblPresupuesto.TabIndex = 13;
            this.lblPresupuesto.Text = "Presupuesto ($):";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtPresupuesto.Location = new System.Drawing.Point(265, 210);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(100, 24);
            this.txtPresupuesto.TabIndex = 14;
            this.txtPresupuesto.Text = "350.00";
            // 
            // lblFallaReportada
            // 
            this.lblFallaReportada.AutoSize = true;
            this.lblFallaReportada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFallaReportada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFallaReportada.Location = new System.Drawing.Point(385, 42);
            this.lblFallaReportada.Name = "lblFallaReportada";
            this.lblFallaReportada.Size = new System.Drawing.Size(173, 15);
            this.lblFallaReportada.TabIndex = 15;
            this.lblFallaReportada.Text = "Falla Reportada por el Cliente: *";
            // 
            // txtFallaReportada
            // 
            this.txtFallaReportada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFallaReportada.Location = new System.Drawing.Point(388, 60);
            this.txtFallaReportada.Multiline = true;
            this.txtFallaReportada.Name = "txtFallaReportada";
            this.txtFallaReportada.Size = new System.Drawing.Size(450, 52);
            this.txtFallaReportada.TabIndex = 16;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDiagnostico.Location = new System.Drawing.Point(385, 118);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(218, 15);
            this.lblDiagnostico.TabIndex = 17;
            this.lblDiagnostico.Text = "Diagnóstico Técnico / Observaciones:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiagnostico.Location = new System.Drawing.Point(388, 136);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(450, 50);
            this.txtDiagnostico.TabIndex = 18;
            // 
            // btnRegistrarOrden
            // 
            this.btnRegistrarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRegistrarOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarOrden.FlatAppearance.BorderSize = 0;
            this.btnRegistrarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarOrden.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarOrden.Location = new System.Drawing.Point(388, 200);
            this.btnRegistrarOrden.Name = "btnRegistrarOrden";
            this.btnRegistrarOrden.Size = new System.Drawing.Size(160, 35);
            this.btnRegistrarOrden.TabIndex = 19;
            this.btnRegistrarOrden.Text = "➕ Registrar Orden";
            this.btnRegistrarOrden.UseVisualStyleBackColor = false;
            this.btnRegistrarOrden.Click += new System.EventHandler(this.btnRegistrarOrden_Click);
            // 
            // btnActualizarOrden
            // 
            this.btnActualizarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnActualizarOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarOrden.FlatAppearance.BorderSize = 0;
            this.btnActualizarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizarOrden.ForeColor = System.Drawing.Color.White;
            this.btnActualizarOrden.Location = new System.Drawing.Point(558, 200);
            this.btnActualizarOrden.Name = "btnActualizarOrden";
            this.btnActualizarOrden.Size = new System.Drawing.Size(165, 35);
            this.btnActualizarOrden.TabIndex = 20;
            this.btnActualizarOrden.Text = "🔄 Actualizar Orden";
            this.btnActualizarOrden.UseVisualStyleBackColor = false;
            this.btnActualizarOrden.Click += new System.EventHandler(this.btnActualizarOrden_Click);
            // 
            // btnLimpiarOrden
            // 
            this.btnLimpiarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiarOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarOrden.FlatAppearance.BorderSize = 0;
            this.btnLimpiarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarOrden.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiarOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiarOrden.Location = new System.Drawing.Point(733, 200);
            this.btnLimpiarOrden.Name = "btnLimpiarOrden";
            this.btnLimpiarOrden.Size = new System.Drawing.Size(105, 35);
            this.btnLimpiarOrden.TabIndex = 21;
            this.btnLimpiarOrden.Text = "🧹 Limpiar";
            this.btnLimpiarOrden.UseVisualStyleBackColor = false;
            this.btnLimpiarOrden.Click += new System.EventHandler(this.btnLimpiarOrden_Click);
            // 
            // pnlListadoOrdenes
            // 
            this.pnlListadoOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListadoOrdenes.BackColor = System.Drawing.Color.White;
            this.pnlListadoOrdenes.Controls.Add(this.cboFiltroEstado);
            this.pnlListadoOrdenes.Controls.Add(this.lblFiltroEstado);
            this.pnlListadoOrdenes.Controls.Add(this.txtBuscarOrden);
            this.pnlListadoOrdenes.Controls.Add(this.lblBuscarOrden);
            this.pnlListadoOrdenes.Controls.Add(this.dgvOrdenes);
            this.pnlListadoOrdenes.Controls.Add(this.lblSubtituloOrdenes);
            this.pnlListadoOrdenes.Location = new System.Drawing.Point(15, 272);
            this.pnlListadoOrdenes.Name = "pnlListadoOrdenes";
            this.pnlListadoOrdenes.Size = new System.Drawing.Size(857, 310);
            this.pnlListadoOrdenes.TabIndex = 1;
            // 
            // lblSubtituloOrdenes
            // 
            this.lblSubtituloOrdenes.AutoSize = true;
            this.lblSubtituloOrdenes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtituloOrdenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSubtituloOrdenes.Location = new System.Drawing.Point(15, 14);
            this.lblSubtituloOrdenes.Name = "lblSubtituloOrdenes";
            this.lblSubtituloOrdenes.Size = new System.Drawing.Size(230, 19);
            this.lblSubtituloOrdenes.TabIndex = 0;
            this.lblSubtituloOrdenes.Text = "🛠️ Bitácora de Órdenes en Taller";
            // 
            // lblBuscarOrden
            // 
            this.lblBuscarOrden.AutoSize = true;
            this.lblBuscarOrden.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscarOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBuscarOrden.Location = new System.Drawing.Point(270, 16);
            this.lblBuscarOrden.Name = "lblBuscarOrden";
            this.lblBuscarOrden.Size = new System.Drawing.Size(118, 15);
            this.lblBuscarOrden.TabIndex = 1;
            this.lblBuscarOrden.Text = "🔍 Folio o Cliente:";
            // 
            // txtBuscarOrden
            // 
            this.txtBuscarOrden.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarOrden.Location = new System.Drawing.Point(392, 12);
            this.txtBuscarOrden.Name = "txtBuscarOrden";
            this.txtBuscarOrden.Size = new System.Drawing.Size(185, 23);
            this.txtBuscarOrden.TabIndex = 2;
            this.txtBuscarOrden.TextChanged += new System.EventHandler(this.FiltroOrdenes_Changed);
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFiltroEstado.Location = new System.Drawing.Point(595, 16);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(76, 15);
            this.lblFiltroEstado.TabIndex = 3;
            this.lblFiltroEstado.Text = "Filtrar Estado:";
            // 
            // cboFiltroEstado
            // 
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroEstado.FormattingEnabled = true;
            this.cboFiltroEstado.Location = new System.Drawing.Point(677, 12);
            this.cboFiltroEstado.Name = "cboFiltroEstado";
            this.cboFiltroEstado.Size = new System.Drawing.Size(165, 23);
            this.cboFiltroEstado.TabIndex = 4;
            this.cboFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.FiltroOrdenes_Changed);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvOrdenes.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvOrdenes.ColumnHeadersHeight = 32;
            this.dgvOrdenes.EnableHeadersVisualStyles = false;
            this.dgvOrdenes.Location = new System.Drawing.Point(15, 42);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(827, 255);
            this.dgvOrdenes.TabIndex = 5;
            this.dgvOrdenes.SelectionChanged += new System.EventHandler(this.dgvOrdenes_SelectionChanged);
            // 
            // FrmOrdenServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.pnlListadoOrdenes);
            this.Controls.Add(this.pnlCapturaOrden);
            this.Name = "FrmOrdenServicio";
            this.Text = "Gestión de Órdenes de Servicio";
            this.Load += new System.EventHandler(this.FrmOrdenServicio_Load);
            this.pnlCapturaOrden.ResumeLayout(false);
            this.pnlCapturaOrden.PerformLayout();
            this.pnlListadoOrdenes.ResumeLayout(false);
            this.pnlListadoOrdenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCapturaOrden;
        private System.Windows.Forms.Label lblTituloCaptura;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cboEquipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblFechaPrometida;
        private System.Windows.Forms.DateTimePicker dtpFechaPrometida;
        private System.Windows.Forms.Label lblServicioRapido;
        private System.Windows.Forms.ComboBox cboServicioRapido;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Label lblFallaReportada;
        private System.Windows.Forms.TextBox txtFallaReportada;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Button btnRegistrarOrden;
        private System.Windows.Forms.Button btnActualizarOrden;
        private System.Windows.Forms.Button btnLimpiarOrden;
        private System.Windows.Forms.Panel pnlListadoOrdenes;
        private System.Windows.Forms.Label lblSubtituloOrdenes;
        private System.Windows.Forms.Label lblBuscarOrden;
        private System.Windows.Forms.TextBox txtBuscarOrden;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}
