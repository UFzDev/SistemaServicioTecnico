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
            txtUsuario.Text = "admin";
            txtContrasena.Text = "admin123";
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
            catch (Exception)
            {
                // Si la base de datos SQL Server aún no está activa localmente,
                // permitimos entrar en Modo Diseño con las credenciales de prueba (admin / admin123).
                if (usuario == "admin" && contrasena == "admin123")
                {
                    UsuarioSesion sesionDemo = new UsuarioSesion
                    {
                        IdUsuario = 1,
                        NombreUsuario = "admin",
                        IdEmpleado = 1,
                        NombreEmpleado = "Uriel Flores Zárate",
                        Puesto = "Administrador",
                        IdRol = 1,
                        Rol = "Administrador"
                    };
                    AbrirMenuPrincipal(sesionDemo);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo conectar a SQL Server. Para probar el diseño sin base de datos activa, usa:\n\nUsuario: admin\nContraseña: admin123",
                        "Modo Diseño / Sin Conexión SQL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
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
