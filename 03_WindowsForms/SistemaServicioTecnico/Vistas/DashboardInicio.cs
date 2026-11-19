using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SistemaServicioTecnico.BLL;
using SistemaServicioTecnico.Vistas.Estilos;

namespace SistemaServicioTecnico.Vistas
{
    public sealed class DashboardInicio : UserControl
    {
        private readonly DashboardBLL servicio = new DashboardBLL();
        private readonly Label[] valores = new Label[4];
        private readonly Label estado = new Label();
        private readonly Button actualizar = new Button();
        private readonly FlowLayoutPanel estados = new FlowLayoutPanel();
        private readonly FlowLayoutPanel procesos = new FlowLayoutPanel();
        private readonly DataGridView ordenes = new DataGridView();
        private bool cargando;
        private readonly Chart graficaEstados = CrearGrafica(SeriesChartType.Doughnut);
        private readonly Chart graficaProcesos = CrearGrafica(SeriesChartType.Bar);
        private readonly Timer refresco = new Timer { Interval = 60000 };

        public DashboardInicio()
        {
            Dock = DockStyle.Fill;
            BackColor = TemaVisual.Fondo;
            Font = new Font("Segoe UI", 9F);
            AutoScroll = true;
            var contenido = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1, RowCount = 5, Padding = new Padding(0, 0, 0, 16), MinimumSize = new Size(710, 0) };
            contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
            var cabecera = new Panel { Dock = DockStyle.Fill, Height = 90, Width = 710, Margin = new Padding(0) };
            cabecera.Controls.Add(new Label { Text = "Resumen del taller", Font = new Font("Segoe UI",23,FontStyle.Bold), ForeColor = TemaVisual.Texto, AutoSize = true, Location = new Point(0,0) });
            estado.Text = "Consulta el estado general de tus órdenes y trabajos.";
            estado.AutoSize = false; estado.Location = new Point(2,47); estado.Size = new Size(540,36); estado.ForeColor = Color.SlateGray;
            estado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cabecera.Controls.Add(estado);
            actualizar.Text = "Actualizar"; actualizar.Name = "btnActualizarDashboard";
            actualizar.Size = new Size(115,36); actualizar.Location = new Point(580,4); actualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            actualizar.Click += async (s,e) => await ActualizarAsync();
            cabecera.Controls.Add(actualizar);
            contenido.Controls.Add(cabecera,0,0);
            var tarjetas = new TableLayoutPanel { Dock = DockStyle.Fill, Height = 145, ColumnCount = 4, RowCount = 1, Margin = new Padding(0,0,0,18) };
            string[] titulos = { "Órdenes activas", "En reparación", "Compromisos vencidos", "Listas para entregar" };
            string[] notas = { "Todos los estados no finales", "Equipos en reparación", "Fecha prometida anterior a hoy", "Pendientes de entrega" };
            Color[] colores = { TemaVisual.Primario, Color.FromArgb(46,101,190), Color.FromArgb(190,68,49), Color.FromArgb(126,80,170) };
            for (int i=0;i<4;i++)
            {
                tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25));
                var tarjeta = new TarjetaPanel { Dock = DockStyle.Fill, Acento=colores[i], Margin=new Padding(i==0 ? 0 : 6,0,i==3 ? 0 : 6,0) };
                tarjeta.Controls.Add(new Label { Text=titulos[i], Dock=DockStyle.Top, Height=25, ForeColor=TemaVisual.Texto, Font=new Font("Segoe UI",9,FontStyle.Bold) });
                valores[i] = new Label { Text="—", Dock=DockStyle.Bottom, Height=43, Font=new Font("Segoe UI",26,FontStyle.Bold), ForeColor=colores[i] };
                tarjeta.Controls.Add(valores[i]);
                tarjeta.Controls.Add(new Label { Text=notas[i], Dock=DockStyle.Bottom, Height=27, Font=new Font("Segoe UI",8), ForeColor=Color.SlateGray });
                tarjetas.Controls.Add(tarjeta,i,0);
            }
            contenido.Controls.Add(tarjetas,0,1);
            var intermedio = new TableLayoutPanel { Dock=DockStyle.Fill, Height=335, ColumnCount=2, RowCount=1, Margin=new Padding(0,0,0,18) };
            intermedio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,62)); intermedio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,38));
            estados.Dock=DockStyle.Fill; estados.FlowDirection=FlowDirection.TopDown; estados.WrapContents=false; estados.AutoScroll=true;
            procesos.Dock=DockStyle.Fill; procesos.FlowDirection=FlowDirection.TopDown; procesos.WrapContents=false; procesos.AutoScroll=true;
            var seccionEstados = Seccion("Órdenes por estado",graficaEstados);
            var selector = new ComboBox { Dock = DockStyle.Bottom, DropDownStyle = ComboBoxStyle.DropDownList };
            selector.Items.AddRange(new object[] { "Dona", "Columnas" });
            selector.SelectedIndex = 0;
            selector.SelectedIndexChanged += (s,e) => {
                graficaEstados.Series[0].ChartType = selector.SelectedIndex == 0 ? SeriesChartType.Doughnut : SeriesChartType.Column;
                graficaEstados.Legends[0].Enabled = selector.SelectedIndex == 0;
            };
            seccionEstados.Controls.Add(selector);
            intermedio.Controls.Add(seccionEstados,0,0);
            intermedio.Controls.Add(Seccion("Procesos y existencias",graficaProcesos),1,0);
            contenido.Controls.Add(intermedio,0,2);
            ordenes.Dock=DockStyle.Fill; ordenes.ReadOnly=true; ordenes.AllowUserToAddRows=false; ordenes.AllowUserToDeleteRows=false;
            ordenes.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; ordenes.SelectionMode=DataGridViewSelectionMode.FullRowSelect; ordenes.MultiSelect=false;
            TemaVisual.AplicarTabla(ordenes);
            var recientes=Seccion("Órdenes activas · vencidas primero, después las más recientes",ordenes); recientes.Height=325; recientes.Margin=new Padding(0);
            contenido.Controls.Add(recientes,0,3);
            contenido.Controls.Add(new Label { Text="Vista general · hasta 8 órdenes. Los contadores incluyen todo el taller; las vencidas pueden estar también en reparación o listas.", AutoSize=true, MaximumSize=new Size(900,0), ForeColor=Color.SlateGray, Margin=new Padding(0,12,0,0) },0,4);
            Controls.Add(contenido);
            refresco.Tick += async (s,e) => { if (Visible) await ActualizarAsync(); };
            refresco.Start();
            // Aplicar sólo al botón: las tarjetas conservan su jerarquía tipográfica.
            actualizar.FlatStyle = FlatStyle.Flat; actualizar.FlatAppearance.BorderColor = TemaVisual.Borde;
            actualizar.BackColor = Color.White; actualizar.ForeColor = TemaVisual.Texto; actualizar.Cursor = Cursors.Hand;
            actualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold); actualizar.FlatAppearance.MouseOverBackColor = TemaVisual.Suave;
        }

        private static Chart CrearGrafica(SeriesChartType tipo)
        {
            var chart = new Chart { Dock = DockStyle.Fill, BackColor = Color.White,
                Palette = ChartColorPalette.None,
                PaletteCustomColors = new[] { TemaVisual.Primario, Color.SteelBlue, Color.Goldenrod, Color.MediumPurple, Color.Coral, Color.CadetBlue } };
            var area = new ChartArea("Principal");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = TemaVisual.Borde;
            area.AxisY.Minimum = 0;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            chart.ChartAreas.Add(area);
            chart.Legends.Add(new Legend { Docking = Docking.Bottom, Font = new Font("Segoe UI", 8), Enabled = tipo == SeriesChartType.Doughnut });
            var serie = new Series("Cantidad") { ChartType = tipo, IsValueShownAsLabel = true,
                ToolTip = "#AXISLABEL: #VALY", LegendText = "#AXISLABEL",
                Label = "#VALY{N0}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            serie["DoughnutRadius"] = "65";
            serie["PieLabelStyle"] = "Inside";
            if (tipo == SeriesChartType.Bar)
                serie["BarLabelStyle"] = "Outside";
            chart.Series.Add(serie);
            chart.MouseMove += (s,e) => chart.Cursor = chart.HitTest(e.X,e.Y).ChartElementType == ChartElementType.DataPoint ? Cursors.Hand : Cursors.Default;
            return chart;
        }

        private static void LlenarGrafica(Chart chart, DataTable tabla, string etiqueta)
        {
            chart.Series[0].Points.Clear();
            long total = 0;
            int maximo = 0;
            foreach (DataRow fila in tabla.Rows) {
                int cantidad = Convert.ToInt32(fila["Total"]);
                string nombre = fila[etiqueta].ToString();
                int indice = chart.Series[0].Points.AddXY(nombre,cantidad);
                var punto = chart.Series[0].Points[indice];
                punto.AxisLabel = nombre;
                punto.LegendText = $"{nombre} ({cantidad:N0})";
                punto.ToolTip = nombre + ": " + cantidad.ToString("N0");
                total += cantidad;
                maximo = Math.Max(maximo, cantidad);
            }
            var ejeValores = chart.ChartAreas[0].AxisY;
            ejeValores.Maximum = maximo > 0 ? Math.Ceiling(maximo * 1.25) : double.NaN;
            ejeValores.Interval = maximo <= 4 ? 1 : 0;
            chart.Titles.Clear();
            if (total == 0) chart.Titles.Add("Sin datos para mostrar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                refresco.Stop();
                refresco.Dispose();
                var tabla = ordenes.DataSource as DataTable;
                ordenes.DataSource = null;
                if (tabla != null) tabla.Dispose();
                estados.Dispose();
                procesos.Dispose();
            }
            base.Dispose(disposing);
        }

        private static TarjetaPanel Seccion(string titulo, Control cuerpo)
        {
            var panel = new TarjetaPanel { Dock=DockStyle.Fill, Margin=new Padding(0,0,12,0) };
            var etiqueta = new Label { Text=titulo, Dock=DockStyle.Top, Height=40, Font=new Font("Segoe UI",10,FontStyle.Bold), ForeColor=TemaVisual.Texto };
            panel.Controls.Add(cuerpo); panel.Controls.Add(etiqueta);
            return panel;
        }

        private static void Limpiar(Control contenedor)
        {
            while (contenedor.Controls.Count>0) contenedor.Controls[0].Dispose();
        }

        public async Task ActualizarAsync()
        {
            if (cargando || IsDisposed) return;
            cargando=true; actualizar.Enabled=false; estado.Text="Actualizando reporte…";
            try
            {
                var datos = await Task.Run(() => servicio.ObtenerReporte());
                using (datos)
                {
                    if (IsDisposed) return;
                    var resumen=datos.Tables[0].Rows[0];
                    string[] campos={"Activas","Reparacion","Vencidas","Listas"};
                    for(int i=0;i<4;i++) valores[i].Text=Convert.ToInt32(resumen[campos[i]]).ToString("N0");
                    Limpiar(estados); Limpiar(procesos);
                    int total=Convert.ToInt32(resumen["Activas"]);
                    LlenarGrafica(graficaEstados, datos.Tables[1], "Estado");
                    LlenarGrafica(graficaProcesos, datos.Tables[3], "Proceso");
                    var anterior=ordenes.DataSource as DataTable;
                    ordenes.DataSource=datos.Tables[2].Copy(); if(anterior!=null) anterior.Dispose();
                    ordenes.Columns["Recepcion"].HeaderText="Recepción"; ordenes.Columns["Compromiso"].HeaderText="Fecha prometida";
                    ordenes.Columns["Recepcion"].DefaultCellStyle.Format="dd/MM/yyyy";
                    ordenes.Columns["Compromiso"].DefaultCellStyle.Format="dd/MM/yyyy";
                    ordenes.Columns["Compromiso"].DefaultCellStyle.NullValue="Sin fecha";
                    foreach(DataGridViewRow fila in ordenes.Rows)
                    {
                        var fecha=fila.Cells["Compromiso"].Value;
                        if(fecha!=DBNull.Value && fecha!=null && Convert.ToDateTime(fecha).Date<DateTime.Today)
                        { fila.Cells["Compromiso"].Style.ForeColor=Color.FromArgb(185,48,60); fila.Cells["Compromiso"].Style.BackColor=Color.FromArgb(255,241,237); }
                    }
                    estado.ForeColor=Color.SlateGray;
                    estado.Text="Actualizado: "+DateTime.Now.ToString("dd/MM/yyyy HH:mm")+(total==0 ? " · No hay órdenes activas." : " · Vista general del taller");
                }
            }
            catch(Exception)
            {
                if(IsDisposed) return;
                estado.ForeColor=Color.FromArgb(185,48,60);
                estado.Text="No se pudo actualizar. Revisa la conexión y pulsa Actualizar. Los datos anteriores pueden estar desactualizados.";
            }
            finally { cargando=false; if(!IsDisposed) actualizar.Enabled=true; }
        }
    }
}
