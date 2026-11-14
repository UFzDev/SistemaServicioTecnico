namespace SistemaServicioTecnico.Entidades
{
    public class TipoEquipo
    {
        public int IdTipoEquipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class EstadoOrden
    {
        public int IdEstadoOrden { get; set; }
        public string Nombre { get; set; }
        public bool EsFinal { get; set; }
        public bool Activo { get; set; }
    }

    public class CategoriaServicio
    {
        public int IdCategoriaServicio { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class CategoriaRefaccion
    {
        public int IdCategoriaRefaccion { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
