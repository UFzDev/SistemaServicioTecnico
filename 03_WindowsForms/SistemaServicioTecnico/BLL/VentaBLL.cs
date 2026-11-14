using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL = new VentaDAL();

        public DataTable ObtenerMetodosPago()
        {
            return _ventaDAL.ObtenerMetodosPago();
        }

        public DataTable ObtenerVentas()
        {
            return _ventaDAL.ObtenerVentas();
        }

        public string ObtenerSiguienteFolio()
        {
            return _ventaDAL.ObtenerSiguienteFolio();
        }

        public int RegistrarVenta(int idCliente, int idUsuario, int idRefaccion, int cantidad, int idMetodoPago)
        {
            if (idCliente <= 0)
                throw new ArgumentException("Debe seleccionar un cliente.");

            if (idRefaccion <= 0)
                throw new ArgumentException("Debe seleccionar una refacción.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            if (idMetodoPago <= 0)
                throw new ArgumentException("Seleccione un método de pago válido.");

            return _ventaDAL.RegistrarVenta(
                idCliente,
                idUsuario > 0 ? idUsuario : 1,
                idRefaccion,
                cantidad,
                idMetodoPago);
        }
    }
}
