using System;

namespace SistemaServicioTecnico.Entidades
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoEquipo { get; set; }
        public int IdMarca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public string Caracteristicas { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
