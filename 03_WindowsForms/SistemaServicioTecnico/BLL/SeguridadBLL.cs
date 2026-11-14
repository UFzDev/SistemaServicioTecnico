using System;
using System.Data;
using SistemaServicioTecnico.DAL;
using SistemaServicioTecnico.Entidades;

namespace SistemaServicioTecnico.BLL
{
    public class SeguridadBLL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public UsuarioSesion IniciarSesion(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña es obligatoria.");

            return _usuarioDAL.ValidarLogin(usuario.Trim(), contrasena);
        }

        public DataTable ObtenerUsuarios()
        {
            return _usuarioDAL.ObtenerUsuarios();
        }

        public void GuardarUsuario(int idUsuario, string nombreCompletoEmpleado, string puesto, string nombreUsuario, string contrasena, string rolNombre, string correo, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombreCompletoEmpleado))
                throw new ArgumentException("El nombre completo del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(nombreUsuario) || nombreUsuario.Trim().Length < 3)
                throw new ArgumentException("El nombre de usuario debe tener al menos 3 caracteres.");

            if (idUsuario == 0 && string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña es obligatorio al registrar un usuario nuevo.");

            if (string.IsNullOrWhiteSpace(puesto) || string.IsNullOrWhiteSpace(rolNombre))
                throw new ArgumentException("Debe seleccionar un puesto y un rol.");

            _usuarioDAL.GuardarUsuario(
                idUsuario,
                nombreCompletoEmpleado.Trim(),
                puesto.Trim(),
                nombreUsuario.Trim(),
                contrasena,
                rolNombre.Trim(),
                correo,
                activo);
        }
    }
}
