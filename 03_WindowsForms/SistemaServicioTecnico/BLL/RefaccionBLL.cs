using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class RefaccionBLL
    {
        private readonly RefaccionDAL _refaccionDAL = new RefaccionDAL();

        public DataTable ObtenerCategorias()
        {
            return _refaccionDAL.ObtenerCategorias();
        }

        public DataTable ObtenerRefacciones()
        {
            return _refaccionDAL.ObtenerRefacciones();
        }

        public int GuardarRefaccion(int idRefaccion, int idCategoria, string sku, string nombre, string descripcion, decimal costo, decimal precioVenta, int stockMinimo, int existenciaDeseada, bool activo, int idUsuario)
        {
            if (idCategoria <= 0)
                throw new ArgumentException("Debe seleccionar una categoría válida.");

            if (string.IsNullOrWhiteSpace(sku) || string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El SKU y el Nombre de la refacción son obligatorios.");

            if (costo < 0 || precioVenta < 0)
                throw new ArgumentException("Los precios y costos no pueden ser negativos.");

            if (stockMinimo < 0 || existenciaDeseada < 0)
                throw new ArgumentException("La existencia y el stock mínimo no pueden ser negativos.");

            return _refaccionDAL.GuardarRefaccion(
                idRefaccion,
                idCategoria,
                sku.Trim(),
                nombre.Trim(),
                descripcion != null ? descripcion.Trim() : null,
                costo,
                precioVenta,
                stockMinimo,
                existenciaDeseada,
                activo,
                idUsuario > 0 ? idUsuario : 1);
        }
    }
}
