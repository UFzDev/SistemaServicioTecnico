namespace SistemaServicioTecnico.Vistas.Seguridad
{
    partial class FrmAuditoria
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
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cboOperacion = new System.Windows.Forms.ComboBox();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.cboTabla = new System.Windows.Forms.ComboBox();
            this.lblTabla = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();

            this.pnlFiltros.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.SuspendLayout();

            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.btnRefrescar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.cboOperacion);
            this.pnlFiltros.Controls.Add(this.lblOperacion);
            this.pnlFiltros.Controls.Add(this.cboTabla);
            this.pnlFiltros.Controls.Add(this.lblTabla);
            this.pnlFiltros.Location = new System.Drawing.Point(12, 12);
            this.pnlFiltros.Size = new System.Drawing.Size(836, 85);

            this.lblTabla.AutoSize = true;
            this.lblTabla.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTabla.Location = new System.Drawing.Point(15, 14);
            this.lblTabla.Text = "Tabla Afectada:";

            this.cboTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTabla.Location = new System.Drawing.Point(18, 34);
            this.cboTabla.Size = new System.Drawing.Size(160, 24);
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.Filtros_Changed);

            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOperacion.Location = new System.Drawing.Point(195, 14);
            this.lblOperacion.Text = "Operación:";

            this.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacion.Location = new System.Drawing.Point(198, 34);
            this.cboOperacion.Size = new System.Drawing.Size(140, 24);
            this.cboOperacion.SelectedIndexChanged += new System.EventHandler(this.Filtros_Changed);

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(355, 14);
            this.lblBuscar.Text = "Buscar en valores:";

            this.txtBuscar.Location = new System.Drawing.Point(358, 34);
            this.txtBuscar.Size = new System.Drawing.Size(260, 24);
            this.txtBuscar.TextChanged += new System.EventHandler(this.Filtros_Changed);

            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(635, 30);
            this.btnRefrescar.Size = new System.Drawing.Size(120, 32);
            this.btnRefrescar.Text = "Actualizar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvAuditoria);
            this.pnlGrid.Location = new System.Drawing.Point(12, 108);
            this.pnlGrid.Size = new System.Drawing.Size(836, 440);

            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            this.dgvAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditoria.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvAuditoria.ColumnHeadersHeight = 32;
            this.dgvAuditoria.EnableHeadersVisualStyles = false;
            this.dgvAuditoria.Location = new System.Drawing.Point(15, 15);
            this.dgvAuditoria.MultiSelect = false;
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoria.Size = new System.Drawing.Size(806, 410);

            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "FrmAuditoria";
            this.Text = "Bitácora de Auditoría";
            this.Load += new System.EventHandler(this.FrmAuditoria_Load);

            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.ComboBox cboTabla;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.ComboBox cboOperacion;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAuditoria;
    }
}
