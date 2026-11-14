using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class ReporteAuditoriaBLL
    {
        private readonly ReporteAuditoriaDAL _dal = new ReporteAuditoriaDAL();

        public DataTable ObtenerReporteIngresosMensuales()
        {
            return _dal.ObtenerReporteIngresosMensuales();
        }

        public DataTable ObtenerReporteIngresosPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaFin < fechaInicio)
                throw new ArgumentException("La fecha final no puede ser menor a la fecha inicial.");

            return _dal.ObtenerReporteIngresosPeriodo(fechaInicio, fechaFin);
        }

        public DataTable ObtenerTopServicios()
        {
            return _dal.ObtenerTopServicios();
        }

        public DataTable ObtenerRendimientoTecnicos()
        {
            return _dal.ObtenerRendimientoTecnicos();
        }

        public DataTable ObtenerStockAlerta()
        {
            return _dal.ObtenerStockAlerta();
        }

        public DataTable ObtenerExpedienteClientes()
        {
            return _dal.ObtenerExpedienteClientes();
        }

        public DataTable ObtenerAuditoria()
        {
            return _dal.ObtenerAuditoria();
        }
    }
}
