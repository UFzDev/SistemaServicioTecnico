namespace SistemaServicioTecnico.Entidades
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public int IdCategoriaServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public bool Activo { get; set; }
    }
}
