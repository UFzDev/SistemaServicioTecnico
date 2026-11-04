namespace SistemaServicioTecnico.Entidades
{
    public class UsuarioSesion
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Puesto { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
    }
}
