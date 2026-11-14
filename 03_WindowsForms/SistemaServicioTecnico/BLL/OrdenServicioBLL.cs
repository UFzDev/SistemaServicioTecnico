using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class OrdenServicioBLL
    {
        private readonly OrdenServicioDAL _ordenDAL = new OrdenServicioDAL();

        public DataTable ObtenerClientesCombo()
        {
            return _ordenDAL.ObtenerClientesCombo();
        }

        public DataTable ObtenerEquiposPorClienteCombo(int idCliente)
        {
            return _ordenDAL.ObtenerEquiposPorClienteCombo(idCliente);
        }

        public DataTable ObtenerEstadosOrden()
        {
            return _ordenDAL.ObtenerEstadosOrden();
        }

        public DataTable ObtenerServiciosRapidos()
        {
            return _ordenDAL.ObtenerServiciosRapidos();
        }

        public DataTable ObtenerOrdenes()
        {
            return _ordenDAL.ObtenerOrdenes();
        }

        public string ObtenerSiguienteFolio()
        {
            return _ordenDAL.ObtenerSiguienteFolio();
        }

        public int RegistrarOrden(string folio, int idCliente, int idEquipo, int idUsuario, string falla, string diagnostico, decimal presupuesto, DateTime fechaPrometida)
        {
            if (idCliente <= 0)
                throw new ArgumentException("Debe seleccionar un cliente.");

            if (idEquipo <= 0)
                throw new ArgumentException("Debe seleccionar un equipo del cliente.");

            if (string.IsNullOrWhiteSpace(falla))
                throw new ArgumentException("Debe capturar la falla reportada por el cliente.");

            if (presupuesto < 0)
                throw new ArgumentException("El presupuesto no puede ser negativo.");

            DateTime fechaPrometidaValida = fechaPrometida < DateTime.Now ? DateTime.Now.AddDays(1) : fechaPrometida;

            return _ordenDAL.RegistrarOrden(
                string.IsNullOrWhiteSpace(folio) ? ObtenerSiguienteFolio() : folio.Trim(),
                idCliente,
                idEquipo,
                idUsuario > 0 ? idUsuario : 1,
                falla.Trim(),
                diagnostico != null ? diagnostico.Trim() : null,
                presupuesto,
                fechaPrometidaValida);
        }

        public void ActualizarOrden(int idOrdenServicio, int idNuevoEstado, int idUsuario, string falla, string diagnostico, decimal presupuesto, DateTime fechaPrometida)
        {
            if (idOrdenServicio <= 0)
                throw new ArgumentException("Seleccione una orden de servicio válida.");

            if (idNuevoEstado <= 0)
                throw new ArgumentException("Seleccione un estado válido.");

            if (string.IsNullOrWhiteSpace(falla))
                throw new ArgumentException("La falla reportada no puede quedar vacía.");

            if (presupuesto < 0)
                throw new ArgumentException("El presupuesto no puede ser negativo.");

            _ordenDAL.ActualizarOrden(
                idOrdenServicio,
                idNuevoEstado,
                idUsuario > 0 ? idUsuario : 1,
                falla.Trim(),
                diagnostico != null ? diagnostico.Trim() : null,
                presupuesto,
                fechaPrometida);
        }
    }
}
