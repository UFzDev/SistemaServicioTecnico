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
            SistemaServicioTecnico.Vistas.Estilos.TemaVisual.Aplicar(this);
            ClientSize = new System.Drawing.Size(420, 350);
            Text = "Acceso al sistema";
            lblTitulo.Text = "Bienvenido al sistema";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(36, 32);
            var subtitulo = new Label { Text = "Gestiona tu taller desde un solo lugar.", AutoSize = true,
                Location = new System.Drawing.Point(39, 77), ForeColor = System.Drawing.Color.SlateGray };
            Controls.Add(subtitulo);
            lblUsuario.Location = new System.Drawing.Point(39, 119);
            txtUsuario.SetBounds(39, 143, 350, 28);
            lblContrasena.Location = new System.Drawing.Point(39, 192);
            txtContrasena.SetBounds(39, 216, 350, 28);
            txtContrasena.UseSystemPasswordChar = true;
            btnIngresar.SetBounds(39, 281, 230, 42);
            btnIngresar.Text = "Iniciar sesión";
            btnSalir.SetBounds(281, 281, 108, 42);
            txtUsuario.TabIndex = 0;
            txtContrasena.TabIndex = 1;
            btnIngresar.TabIndex = 2;
            btnSalir.TabIndex = 3;
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
