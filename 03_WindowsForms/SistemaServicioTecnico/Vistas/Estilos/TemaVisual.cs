using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaServicioTecnico.Vistas.Estilos
{
    public static class TemaVisual
    {
        public static readonly Color Fondo = Color.FromArgb(243, 246, 250);
        public static readonly Color Texto = Color.FromArgb(25, 42, 62);
        public static readonly Color Primario = Color.FromArgb(15, 118, 110);
        public static readonly Color Borde = Color.FromArgb(216, 225, 234);
        public static readonly Color Suave = Color.FromArgb(232, 245, 242);

        public static void Aplicar(Control raiz)
        {
            raiz.SuspendLayout();
            if (raiz is Form) { raiz.BackColor = Fondo; raiz.ForeColor = Texto; }
            foreach (Control c in raiz.Controls)
            {
                var boton = c as Button;
                if (boton != null)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 1;
                    boton.FlatAppearance.BorderColor = Borde;
                    boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    boton.Cursor = Cursors.Hand;
                    boton.UseVisualStyleBackColor = false;
                    string nombre = boton.Name.ToLowerInvariant();
                    bool secundario = nombre.Contains("limpiar") || nombre.Contains("cancelar") || nombre.Contains("salir") || nombre.Contains("buscar") || nombre.Contains("actualizar");
                    boton.BackColor = secundario ? Color.White : Primario;
                    boton.ForeColor = secundario ? Texto : Color.White;
                    boton.FlatAppearance.MouseOverBackColor = secundario ? Suave : Color.FromArgb(13, 98, 92);
                    boton.FlatAppearance.MouseDownBackColor = secundario ? Borde : Color.FromArgb(10, 79, 74);
                    if (nombre.Contains("eliminar")) { boton.BackColor = Color.FromArgb(185, 48, 60); boton.ForeColor = Color.White; }
                }
                else if (c is TextBox)
                {
                    var campo = (TextBox)c;
                    campo.BorderStyle = BorderStyle.FixedSingle;
                    campo.Font = new Font("Segoe UI", 9F);
                    campo.ForeColor = Texto;
                    campo.BackColor = campo.ReadOnly ? Fondo : Color.White;
                    campo.Enter += (s, e) => { if (!campo.ReadOnly) campo.BackColor = Suave; };
                    campo.Leave += (s, e) => campo.BackColor = campo.ReadOnly ? Fondo : Color.White;
                }
                else if (c is ComboBox)
                {
                    var combo = (ComboBox)c;
                    combo.FlatStyle = FlatStyle.Flat;
                    combo.BackColor = Color.White;
                    combo.ForeColor = Texto;
                    combo.Font = new Font("Segoe UI", 9F);
                }
                else if (c is DataGridView) AplicarTabla((DataGridView)c);
                else if (c is Label)
                {
                    c.ForeColor = Texto;
                    c.Font = new Font("Segoe UI", c.Font.Size >= 12 ? c.Font.Size : 9F, c.Font.Style);
                }
                else if (c is GroupBox || c is TabPage) { c.BackColor = Color.White; c.ForeColor = Texto; }
                else if (c is DateTimePicker || c is NumericUpDown || c is CheckBox)
                { c.Font = new Font("Segoe UI", 9F); c.ForeColor = Texto; }
                Aplicar(c);
            }
            raiz.ResumeLayout(true);
        }

        public static void AplicarTabla(DataGridView tabla)
        {
            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.EnableHeadersVisualStyles = false;
            tabla.GridColor = Borde;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 245);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Texto;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 239, 245);
            tabla.ColumnHeadersHeight = 38;
            tabla.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            tabla.DefaultCellStyle.ForeColor = Texto;
            tabla.DefaultCellStyle.BackColor = Color.White;
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(211, 237, 232);
            tabla.DefaultCellStyle.SelectionForeColor = Texto;
            tabla.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 252);
            tabla.RowTemplate.Height = 34;
            tabla.RowHeadersVisible = false;
        }
    }

    public class TarjetaPanel : Panel
    {
        public Color Acento { get; set; }
        private bool resaltado;
        public TarjetaPanel() {
            DoubleBuffered = true; BackColor = Color.White; Padding = new Padding(18);
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            RegistrarHover(e.Control);
        }
        private void RegistrarHover(Control control)
        {
            control.MouseEnter += (s,e) => Resaltar(true);
            control.MouseLeave += (s,e) => Resaltar(ClientRectangle.Contains(PointToClient(Cursor.Position)));
            foreach (Control hijo in control.Controls) RegistrarHover(hijo);
        }
        private void Resaltar(bool valor)
        {
            if (resaltado == valor) return;
            resaltado = valor;
            BackColor = valor ? Color.FromArgb(248,252,251) : Color.White;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); Resaltar(true); }
        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e); Resaltar(ClientRectangle.Contains(PointToClient(Cursor.Position)));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var lapiz = new Pen(resaltado ? TemaVisual.Primario : TemaVisual.Borde, resaltado ? 2 : 1))
                e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
            if (Acento != Color.Empty)
                using (var pincel = new SolidBrush(Acento)) e.Graphics.FillRectangle(pincel, 0, 0, 4, Height);
        }
    }
}
