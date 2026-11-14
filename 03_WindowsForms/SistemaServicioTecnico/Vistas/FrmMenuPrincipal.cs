using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;
using SistemaServicioTecnico.Entidades;
using SistemaServicioTecnico.Vistas.Catalogos;
using SistemaServicioTecnico.Vistas.Procesos;
using SistemaServicioTecnico.Vistas.Seguridad;

namespace SistemaServicioTecnico.Vistas
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly UsuarioSesion _usuarioSesion;
        private readonly DashboardBLL _dashboardBLL = new DashboardBLL();
        private Form _formularioActivo = null;
        private Button _botonSeleccionado = null;

        public FrmMenuPrincipal() : this(null)
        {
        }

        public FrmMenuPrincipal(UsuarioSesion usuarioSesion)
        {
            _usuarioSesion = usuarioSesion;
            InitializeComponent();
            ConfigurarSesion();
            CargarResumenDashboard();
            SeleccionarBoton(btnDashboard);
        }

        private int ObtenerIdUsuarioActual()
        {
            return _usuarioSesion != null ? _usuarioSesion.IdUsuario : 1;
        }

        private void CargarResumenDashboard()
        {
            try
            {
                int ordenesActivas;
                int enReparacion;
                int totalClientes;
                int stockAlerta;
                _dashboardBLL.ObtenerResumen(out ordenesActivas, out enReparacion, out totalClientes, out stockAlerta);

                lblCard1Valor.Text = ordenesActivas.ToString();
                lblCard2Valor.Text = enReparacion.ToString();
                lblCard3Valor.Text = totalClientes.ToString();
                lblCard4Valor.Text = stockAlerta.ToString();
            }
            catch
            {
                // Mantener valores actuales si falla la consulta de resumen
            }
        }

        private void ConfigurarSesion()
        {
            if (_usuarioSesion != null)
            {
                lblUsuarioSesion.Text = string.Format("👤 {0} ({1})", _usuarioSesion.NombreEmpleado, _usuarioSesion.Rol);
                
                // Restricciones visuales según el rol (si aplica)
                if (_usuarioSesion.Rol == "Tecnico")
                {
                    btnCompras.Visible = false;
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
                _botonSeleccionado.BackColor = Color.FromArgb(30, 41, 59);
                _botonSeleccionado.ForeColor = Color.Gainsboro;
            }

            _botonSeleccionado = boton;
            if (_botonSeleccionado != null)
            {
                _botonSeleccionado.BackColor = Color.FromArgb(51, 65, 85);
                _botonSeleccionado.ForeColor = Color.White;
            }
        }

        public void AbrirFormularioHijo(Form formHijo, string tituloVista)
        {
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
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
            AbrirFormularioHijo(null, "Panel Principal / Resumen");
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
