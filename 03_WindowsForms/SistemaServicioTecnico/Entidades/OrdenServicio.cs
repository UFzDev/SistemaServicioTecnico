using System;

namespace SistemaServicioTecnico.Entidades
{
    public class OrdenServicio
    {
        public int IdOrdenServicio { get; set; }
        public string Folio { get; set; }
        public int IdCliente { get; set; }
        public int IdEquipo { get; set; }
        public int IdEstadoOrden { get; set; }
        public int? IdUsuarioRecepcion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime? FechaPrometida { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string FallaReportada { get; set; }
        public string Observaciones { get; set; }
        public decimal? Presupuesto { get; set; }
        public bool? PresupuestoAutorizado { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public string DiagnosticoGeneral { get; set; }
    }
}
