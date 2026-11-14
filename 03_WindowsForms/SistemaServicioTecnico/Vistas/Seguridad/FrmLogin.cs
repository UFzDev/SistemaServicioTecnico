using System;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;
using SistemaServicioTecnico.Entidades;

namespace SistemaServicioTecnico.Vistas.Seguridad
{
    public partial class FrmLogin : Form
    {
        private readonly SeguridadBLL _seguridadBLL = new SeguridadBLL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            try
            {
                UsuarioSesion sesion = _seguridadBLL.IniciarSesion(usuario, contrasena);

                if (sesion != null)
                {
                    AbrirMenuPrincipal(sesion);
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos, o el usuario está inactivo.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtContrasena.Clear();
                    txtContrasena.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al conectar con la base de datos: " + ex.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AbrirMenuPrincipal(UsuarioSesion sesion)
        {
            this.Hide();
            FrmMenuPrincipal menu = new FrmMenuPrincipal(sesion);
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
