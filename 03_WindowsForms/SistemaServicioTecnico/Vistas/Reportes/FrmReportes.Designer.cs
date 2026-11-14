namespace SistemaServicioTecnico.Vistas.Reportes
{
    partial class FrmReportes
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.cboReporte = new System.Windows.Forms.ComboBox();
            this.lblReporte = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReporte = new System.Windows.Forms.DataGridView();

            this.pnlFiltros.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.lblResumen);
            this.pnlFiltros.Controls.Add(this.btnGenerar);
            this.pnlFiltros.Controls.Add(this.dtpFechaFin);
            this.pnlFiltros.Controls.Add(this.lblFechaFin);
            this.pnlFiltros.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltros.Controls.Add(this.lblFechaInicio);
            this.pnlFiltros.Controls.Add(this.cboReporte);
            this.pnlFiltros.Controls.Add(this.lblReporte);
            this.pnlFiltros.Location = new System.Drawing.Point(12, 12);
            this.pnlFiltros.Size = new System.Drawing.Size(836, 110);

            this.lblReporte.AutoSize = true;
            this.lblReporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReporte.Location = new System.Drawing.Point(15, 14);
            this.lblReporte.Text = "Seleccione Reporte Analítico:";

            this.cboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboReporte.Location = new System.Drawing.Point(18, 34);
            this.cboReporte.Size = new System.Drawing.Size(310, 24);
            this.cboReporte.SelectedIndexChanged += new System.EventHandler(this.cboReporte_SelectedIndexChanged);

            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaInicio.Location = new System.Drawing.Point(345, 14);
            this.lblFechaInicio.Text = "Desde:";

            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(348, 34);
            this.dtpFechaInicio.Size = new System.Drawing.Size(115, 24);

            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaFin.Location = new System.Drawing.Point(478, 14);
            this.lblFechaFin.Text = "Hasta:";

            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(481, 34);
            this.dtpFechaFin.Size = new System.Drawing.Size(115, 24);

            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(615, 28);
            this.btnGenerar.Size = new System.Drawing.Size(150, 34);
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblResumen.Location = new System.Drawing.Point(18, 74);
            this.lblResumen.Text = "Registros: 0";

            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvReporte);
            this.pnlGrid.Location = new System.Drawing.Point(12, 132);
            this.pnlGrid.Size = new System.Drawing.Size(836, 416);

            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvReporte.ColumnHeadersHeight = 32;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.Location = new System.Drawing.Point(15, 15);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(806, 386);

            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "FrmReportes";
            this.Text = "Reportes Gerenciales";
            this.Load += new System.EventHandler(this.FrmReportes_Load);

            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cboReporte;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReporte;
    }
}
