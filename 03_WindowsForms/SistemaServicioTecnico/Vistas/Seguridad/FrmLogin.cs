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
            try
            {
                string usuario = txtUsuario.Text;
                string contrasena = txtContrasena.Text;

                UsuarioSesion sesion = _seguridadBLL.IniciarSesion(usuario, contrasena);

                if (sesion != null)
                {
                    string mensaje = string.Format(
                        "Bienvenido al sistema:\n\nEmpleado: {0}\nPuesto: {1}\nRol: {2}",
                        sesion.NombreEmpleado,
                        sesion.Puesto,
                        sesion.Rol);

                    MessageBox.Show(
                        mensaje,
                        "Acceso Concedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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
                    "Error al intentar iniciar sesión: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
