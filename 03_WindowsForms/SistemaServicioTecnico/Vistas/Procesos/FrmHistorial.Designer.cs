namespace SistemaServicioTecnico.Vistas.Procesos
{
    partial class FrmHistorial
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
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();

            this.pnlFiltros.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.lblClasificacion);
            this.pnlFiltros.Controls.Add(this.cboCliente);
            this.pnlFiltros.Controls.Add(this.lblCliente);
            this.pnlFiltros.Controls.Add(this.cboEstado);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Location = new System.Drawing.Point(12, 12);
            this.pnlFiltros.Size = new System.Drawing.Size(836, 95);

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(15, 14);
            this.lblBuscar.Text = "Buscar (Folio / Serie / Cliente):";

            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(18, 34);
            this.txtBuscar.Size = new System.Drawing.Size(240, 24);
            this.txtBuscar.TextChanged += new System.EventHandler(this.Filtros_Changed);

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.Location = new System.Drawing.Point(275, 14);
            this.lblEstado.Text = "Estado:";

            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.Location = new System.Drawing.Point(278, 34);
            this.cboEstado.Size = new System.Drawing.Size(175, 24);
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.Filtros_Changed);

            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.Location = new System.Drawing.Point(470, 14);
            this.lblCliente.Text = "Expediente por Cliente:";

            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCliente.Location = new System.Drawing.Point(473, 34);
            this.cboCliente.Size = new System.Drawing.Size(220, 24);
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);

            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClasificacion.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblClasificacion.Location = new System.Drawing.Point(705, 37);
            this.lblClasificacion.Text = "Nivel: -";

            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvHistorial);
            this.pnlGrid.Location = new System.Drawing.Point(12, 118);
            this.pnlGrid.Size = new System.Drawing.Size(836, 430);

            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvHistorial.ColumnHeadersHeight = 32;
            this.dgvHistorial.EnableHeadersVisualStyles = false;
            this.dgvHistorial.Location = new System.Drawing.Point(15, 15);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(806, 400);

            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "FrmHistorial";
            this.Text = "Historial y Búsquedas";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);

            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}
