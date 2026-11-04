using System;
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
    }
}
