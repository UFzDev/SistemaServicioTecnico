namespace SistemaServicioTecnico.Vistas.Catalogos
{
    partial class FrmCatalogosBase
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
            this.tabCatalogos = new System.Windows.Forms.TabControl();
            this.tpTiposEquipo = new System.Windows.Forms.TabPage();
            this.tpMarcas = new System.Windows.Forms.TabPage();
            this.tpCategoriasServicio = new System.Windows.Forms.TabPage();
            this.tabCatalogos.SuspendLayout();
            this.SuspendLayout();

            this.tabCatalogos.Controls.Add(this.tpTiposEquipo);
            this.tabCatalogos.Controls.Add(this.tpMarcas);
            this.tabCatalogos.Controls.Add(this.tpCategoriasServicio);
            this.tabCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCatalogos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabCatalogos.Location = new System.Drawing.Point(0, 0);
            this.tabCatalogos.Name = "tabCatalogos";
            this.tabCatalogos.SelectedIndex = 0;
            this.tabCatalogos.Size = new System.Drawing.Size(860, 560);

            this.tpTiposEquipo.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tpTiposEquipo.Text = "Tipos de Equipo";

            this.tpMarcas.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tpMarcas.Text = "Marcas";

            this.tpCategoriasServicio.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tpCategoriasServicio.Text = "Categorías de Servicio";

            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.tabCatalogos);
            this.Name = "FrmCatalogosBase";
            this.Text = "Catálogos Base";
            this.Load += new System.EventHandler(this.FrmCatalogosBase_Load);

            this.tabCatalogos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabCatalogos;
        private System.Windows.Forms.TabPage tpTiposEquipo;
        private System.Windows.Forms.TabPage tpMarcas;
        private System.Windows.Forms.TabPage tpCategoriasServicio;
    }
}
