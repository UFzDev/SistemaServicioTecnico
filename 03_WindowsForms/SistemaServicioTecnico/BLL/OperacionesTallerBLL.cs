using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class OperacionesTallerBLL
    {
        private readonly OperacionesTallerDAL _dal = new OperacionesTallerDAL();

        public DataTable ObtenerOrdenesParaTaller()
        {
            return _dal.ObtenerOrdenesParaTaller();
        }

        public void ObtenerTotalesOrden(int idOrdenServicio, out decimal costoTotal, out decimal saldoPendiente, out int diasGarantia)
        {
            _dal.ObtenerTotalesOrden(idOrdenServicio, out costoTotal, out saldoPendiente, out diasGarantia);
        }

        public DataTable ObtenerRefaccionesOrden(int idOrdenServicio)
        {
            return _dal.ObtenerRefaccionesOrden(idOrdenServicio);
        }

        public void ConsumirRefaccionEnOrden(int idOrdenServicio, int idRefaccion, int cantidad)
        {
            if (idOrdenServicio <= 0)
                throw new ArgumentException("Seleccione una orden de servicio activa.");

            if (idRefaccion <= 0)
                throw new ArgumentException("Seleccione una refacción.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            _dal.ConsumirRefaccionEnOrden(idOrdenServicio, idRefaccion, cantidad);
        }

        public void FinalizarYEntregarOrden(int idOrdenServicio, int idUsuario, int idMetodoPago)
        {
            if (idOrdenServicio <= 0)
                throw new ArgumentException("Seleccione una orden de servicio válida.");

            if (idMetodoPago <= 0)
                throw new ArgumentException("Seleccione un método de pago.");

            _dal.FinalizarYEntregarOrden(idOrdenServicio, idUsuario > 0 ? idUsuario : 1, idMetodoPago);
        }

        public void AjustarInventario(int idRefaccion, int cantidadAjuste, int idUsuario, string motivo)
        {
            if (idRefaccion <= 0)
                throw new ArgumentException("Seleccione una refacción.");

            if (cantidadAjuste == 0)
                throw new ArgumentException("La cantidad de ajuste no puede ser cero.");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("Debe capturar un motivo obligatorio para el ajuste.");

            _dal.AjustarInventario(idRefaccion, cantidadAjuste, idUsuario > 0 ? idUsuario : 1, motivo.Trim());
        }

        public DataTable ObtenerMovimientosInventario()
        {
            return _dal.ObtenerMovimientosInventario();
        }

        public DataTable ObtenerHistorialTickets()
        {
            return _dal.ObtenerHistorialTickets();
        }

        public string ObtenerClasificacionCliente(int idCliente)
        {
            return idCliente > 0 ? _dal.ObtenerClasificacionCliente(idCliente) : "ESTANDAR";
        }

        public DataTable ObtenerHistorialPorCliente(int idCliente)
        {
            return _dal.ObtenerHistorialPorCliente(idCliente);
        }
    }
}
