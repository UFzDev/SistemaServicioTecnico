using System;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Catalogos
{
    public partial class FrmCatalogosBase : Form
    {
        public FrmCatalogosBase()
        {
            InitializeComponent();
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
        }

        private void FrmCatalogosBase_Load(object sender, EventArgs e)
        {
            EmbeberFormulario(new FrmTipoEquipo(), tpTiposEquipo);
            EmbeberFormulario(new FrmMarca(), tpMarcas);
            EmbeberFormulario(new FrmCategoriaServicio(), tpCategoriasServicio);
        }

        private void EmbeberFormulario(Form hijo, TabPage destino)
        {
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            destino.Controls.Add(hijo);
            hijo.Show();
        }
    }
}
