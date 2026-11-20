using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;
using SistemaServicioTecnico.Entidades;
using SistemaServicioTecnico.Vistas.Catalogos;
using SistemaServicioTecnico.Vistas.Procesos;
using SistemaServicioTecnico.Vistas.Reportes;
using SistemaServicioTecnico.Vistas.Seguridad;

namespace SistemaServicioTecnico.Vistas
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly UsuarioSesion _usuarioSesion;
        private DashboardInicio _dashboardInicio;
        private Form _formularioActivo = null;
        private Button _botonSeleccionado = null;

        public FrmMenuPrincipal() : this(null)
        {
        }

        public FrmMenuPrincipal(UsuarioSesion usuarioSesion)
        {
            _usuarioSesion = usuarioSesion;
            InitializeComponent();
            PrepararInterfaz();
            ConfigurarSesion();
            CrearMenuDesplegable();
            CargarResumenDashboard();
            SeleccionarBoton(btnDashboard);
        }

        private void CrearMenuDesplegable()
        {
            var menu = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true,
                WrapContents = false, FlowDirection = FlowDirection.TopDown,
                BackColor = pnlSidebar.BackColor, Padding = new Padding(8) };
            pnlSidebar.Controls.Add(menu);
            AgregarGrupo(menu, "Taller", new[] { btnOrdenes, btnClientes, btnAjustes, btnHistorial }, true);
            AgregarGrupo(menu, "Catálogos e inventario", new[] { btnServicios, btnRefacciones, btnCatalogos }, false);
            AgregarGrupo(menu, "Operaciones", new[] { btnVentas, btnCompras, btnReportes }, false);
            AgregarGrupo(menu, "Administración", new[] { btnAuditoria, btnUsuarios }, false);
            pnlLogo.BringToFront();
            btnCerrarSesion.BringToFront();
            btnDashboard.BringToFront();
            menu.BringToFront();
        }

        private bool AccesoMenu(Button boton)
        {
            string rol = _usuarioSesion == null ? "" : _usuarioSesion.Rol;
            if (rol == "Tecnico" && (boton == btnCatalogos || boton == btnVentas || boton == btnCompras || boton == btnReportes || boton == btnAuditoria || boton == btnUsuarios)) return false;
            if (rol == "Recepcionista" && (boton == btnCatalogos || boton == btnCompras || boton == btnAuditoria || boton == btnUsuarios)) return false;
            if (rol == "Supervisor" && (boton == btnAuditoria || boton == btnUsuarios)) return false;
            return true;
        }

        private void AgregarGrupo(FlowLayoutPanel menu, string titulo, Button[] botones, bool abierto)
        {
            var permitidos = Array.FindAll(botones, AccesoMenu);
            if (permitidos.Length == 0) return;
            var grupo = new FlowLayoutPanel { Width = 202, Height = permitidos.Length * 40,
                FlowDirection = FlowDirection.TopDown, WrapContents = false,
                Visible = abierto, Margin = new Padding(0) };
            var cabecera = new Button { Text = titulo + (abierto ? "   ▾" : "   ▸"),
                Width = 202, Height = 42, FlatStyle = FlatStyle.Flat,
                BackColor = pnlSidebar.BackColor, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft, Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold), Margin = new Padding(0,6,0,0) };
            cabecera.FlatAppearance.BorderSize = 0;
            cabecera.FlatAppearance.MouseOverBackColor = Color.FromArgb(37,64,82);
            bool expandido = abierto;
            cabecera.Click += (s,e) => {
                expandido = !expandido;
                grupo.Visible = expandido;
                cabecera.Text = titulo + (expandido ? "   ▾" : "   ▸");
            };
            foreach (var boton in permitidos) {
                boton.Dock = DockStyle.None;
                boton.Size = new Size(202,38);
                boton.Margin = new Padding(0,0,0,2);
                boton.Padding = new Padding(26,0,0,0);
                grupo.Controls.Add(boton);
            }
            menu.Controls.Add(cabecera);
            menu.Controls.Add(grupo);
        }

        private int ObtenerIdUsuarioActual()
        {
            return _usuarioSesion != null ? _usuarioSesion.IdUsuario : 1;
        }

        private async void CargarResumenDashboard()
        {
            if (_dashboardInicio != null) await _dashboardInicio.ActualizarAsync();
        }

        private void PrepararInterfaz()
        {
            Text = "Servicio Técnico";
            MinimumSize = new Size(1100, 720);
            pnlSidebar.BackColor = Color.FromArgb(20, 38, 55);
            pnlSidebar.AutoScroll = true;
            lblLogo.Text = "Servicio Técnico";
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.Location = new Point(18, 7);
            lblSubLogo.Location = new Point(20, 52);
            lblSubLogo.Text = "GESTIÓN DE SERVICIO TÉCNICO";
            lblSubLogo.Font = new Font("Segoe UI", 8F);
            foreach (Control control in pnlSidebar.Controls)
            {
                var boton = control as Button;
                if (boton == null) continue;
                boton.BackColor = pnlSidebar.BackColor;
                boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 64, 82);
                boton.FlatAppearance.MouseDownBackColor = Estilos.TemaVisual.Primario;
                boton.Font = new Font("Segoe UI", 10F);
                boton.Padding = new Padding(22, 0, 0, 0);
            }
            lblTituloVista.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTituloVista.Text = "Inicio / Resumen del taller";
            lblUsuarioSesion.AutoSize = false;
            lblUsuarioSesion.TextAlign = ContentAlignment.MiddleRight;
            lblUsuarioSesion.Width = 330;
            lblUsuarioSesion.Left = pnlHeader.ClientSize.Width - 350;
            pnlContenedor.BackColor = Estilos.TemaVisual.Fondo;
            pnlContenedor.Padding = new Padding(24);
            while (pnlDashboardHome.Controls.Count > 0) pnlDashboardHome.Controls[0].Dispose();
            _dashboardInicio = new DashboardInicio();
            pnlDashboardHome.Controls.Add(_dashboardInicio);
        }
        private void ConfigurarSesion()
        {
            if (_usuarioSesion != null)
            {
                lblUsuarioSesion.Text = string.Format("👤 {0} ({1})", _usuarioSesion.NombreEmpleado, _usuarioSesion.Rol);
                
                // Restricciones visuales según el rol
                if (_usuarioSesion.Rol == "Tecnico")
                {
                    btnCatalogos.Visible = false;
                    btnVentas.Visible = false;
                    btnCompras.Visible = false;
                    btnReportes.Visible = false;
                    btnAuditoria.Visible = false;
                    btnUsuarios.Visible = false;
                }
                else if (_usuarioSesion.Rol == "Recepcionista")
                {
                    btnCatalogos.Visible = false;
                    btnCompras.Visible = false;
                    btnAuditoria.Visible = false;
                    btnUsuarios.Visible = false;
                }
                else if (_usuarioSesion.Rol == "Supervisor")
                {
                    btnAuditoria.Visible = false;
                    btnUsuarios.Visible = false;
                }
            }
            else
            {
                lblUsuarioSesion.Text = "👤 Modo Diseño / Administrador";
            }
        }

        private void SeleccionarBoton(Button boton)
        {
            // Restaurar color del botón previo
            if (_botonSeleccionado != null)
            {
                _botonSeleccionado.BackColor = pnlSidebar.BackColor;
                _botonSeleccionado.ForeColor = Color.Gainsboro;
            }

            _botonSeleccionado = boton;
            if (_botonSeleccionado != null)
            {
                _botonSeleccionado.BackColor = Estilos.TemaVisual.Primario;
                _botonSeleccionado.ForeColor = Color.White;
            }
        }

        public void AbrirFormularioHijo(Form formHijo, string tituloVista)
        {
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
                _formularioActivo = null;
            }

            lblTituloVista.Text = tituloVista;

            if (formHijo == null)
            {
                // Regresar a la vista de Inicio / Dashboard
                CargarResumenDashboard();
                pnlDashboardHome.Visible = true;
                return;
            }

            pnlDashboardHome.Visible = false;
            _formularioActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnDashboard);
            AbrirFormularioHijo(null, "Inicio / Resumen del taller");
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnOrdenes);
            AbrirFormularioHijo(new FrmOrdenServicio(ObtenerIdUsuarioActual()), "Gestión de Órdenes de Servicio");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnClientes);
            AbrirFormularioHijo(new FrmClientes(), "Gestión de Clientes y Equipos");
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnServicios);
            AbrirFormularioHijo(new FrmServicios(), "Catálogo de Servicios de Taller");
        }

        private void btnRefacciones_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnRefacciones);
            AbrirFormularioHijo(new FrmRefacciones(ObtenerIdUsuarioActual()), "Inventario y Refacciones");
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnVentas);
            AbrirFormularioHijo(new FrmVentas(ObtenerIdUsuarioActual()), "Venta de Refacciones y Mostrador");
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCompras);
            AbrirFormularioHijo(new FrmCompras(ObtenerIdUsuarioActual()), "Compras y Proveedores");
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCatalogos);
            AbrirFormularioHijo(new FrmCatalogosBase(), "Catálogos Base");
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnAjustes);
            AbrirFormularioHijo(new FrmAjustes(ObtenerIdUsuarioActual()), "Operaciones de Taller y Ajustes");
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnHistorial);
            AbrirFormularioHijo(new FrmHistorial(), "Historial y Búsquedas");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnReportes);
            AbrirFormularioHijo(new FrmReportes(), "Reportes Gerenciales");
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnAuditoria);
            AbrirFormularioHijo(new FrmAuditoria(), "Bitácora de Auditoría");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnUsuarios);
            AbrirFormularioHijo(new FrmUsuarios(), "Seguridad, Roles y Usuarios");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
