using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class CompraBLL
    {
        private readonly CompraDAL _compraDAL = new CompraDAL();

        public DataTable ObtenerProveedores()
        {
            return _compraDAL.ObtenerProveedores();
        }

        public int GuardarProveedor(string nombre, string rfc, string contacto, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la empresa proveedora es obligatorio.");

            string rfcLimpio = rfc != null ? rfc.Trim().ToUpperInvariant() : string.Empty;
            if (!string.IsNullOrEmpty(rfcLimpio) && (rfcLimpio.Length < 12 || rfcLimpio.Length > 13))
                throw new ArgumentException("El RFC debe tener entre 12 y 13 caracteres (o dejarse vacío).");

            return _compraDAL.GuardarProveedor(
                nombre.Trim(),
                rfcLimpio,
                contacto != null ? contacto.Trim() : null,
                telefono != null ? telefono.Trim() : null);
        }

        public DataTable ObtenerCompras()
        {
            return _compraDAL.ObtenerCompras();
        }

        public string ObtenerSiguienteFolio()
        {
            return _compraDAL.ObtenerSiguienteFolio();
        }

        public int RegistrarCompra(int idProveedor, int idUsuario, int idRefaccion, int cantidad, decimal costoUnitario)
        {
            if (idProveedor <= 0)
                throw new ArgumentException("Seleccione un proveedor válido.");

            if (idRefaccion <= 0)
                throw new ArgumentException("Seleccione una refacción válida.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad comprada debe ser mayor a cero.");

            if (costoUnitario <= 0)
                throw new ArgumentException("El costo unitario debe ser mayor a cero.");

            return _compraDAL.RegistrarCompra(
                idProveedor,
                idUsuario > 0 ? idUsuario : 1,
                idRefaccion,
                cantidad,
                costoUnitario);
        }
    }
}
