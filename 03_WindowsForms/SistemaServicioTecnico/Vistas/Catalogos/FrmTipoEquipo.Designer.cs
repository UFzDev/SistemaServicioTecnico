namespace SistemaServicioTecnico.Vistas.Catalogos
{
    partial class FrmTipoEquipo
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
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.pnlFormulario.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();

            this.pnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.btnLimpiar);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.chkActivo);
            this.pnlFormulario.Controls.Add(this.txtDescripcion);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.lblTitulo);
            this.pnlFormulario.Location = new System.Drawing.Point(12, 12);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(816, 135);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Text = "Catálogo de Tipos de Equipo";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNombre.Location = new System.Drawing.Point(15, 42);
            this.lblNombre.Text = "Nombre: *";

            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(18, 60);
            this.txtNombre.Size = new System.Drawing.Size(230, 24);

            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDescripcion.Location = new System.Drawing.Point(265, 42);
            this.lblDescripcion.Text = "Descripción:";

            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.Location = new System.Drawing.Point(268, 60);
            this.txtDescripcion.Size = new System.Drawing.Size(340, 24);

            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location = new System.Drawing.Point(625, 62);
            this.chkActivo.Text = "Activo";

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(18, 94);
            this.btnGuardar.Size = new System.Drawing.Size(130, 32);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(158, 94);
            this.btnLimpiar.Size = new System.Drawing.Size(110, 32);
            this.btnLimpiar.Text = "Nuevo";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.White;
            this.pnlListado.Controls.Add(this.txtBuscar);
            this.pnlListado.Controls.Add(this.lblBuscar);
            this.pnlListado.Controls.Add(this.dgvDatos);
            this.pnlListado.Location = new System.Drawing.Point(12, 158);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(816, 360);

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscar.Location = new System.Drawing.Point(15, 14);
            this.lblBuscar.Text = "Buscar:";

            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(70, 11);
            this.txtBuscar.Size = new System.Drawing.Size(260, 24);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDatos.ColumnHeadersHeight = 32;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(15, 45);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(786, 300);
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);

            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(840, 530);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFormulario);
            this.Name = "FrmTipoEquipo";
            this.Text = "Tipos de Equipo";
            this.Load += new System.EventHandler(this.FrmTipoEquipo_Load);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            this.pnlListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}
