using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class ServicioBLL
    {
        private readonly ServicioDAL _servicioDAL = new ServicioDAL();

        public DataTable ObtenerCategorias()
        {
            return _servicioDAL.ObtenerCategorias();
        }

        public DataTable ObtenerServicios()
        {
            return _servicioDAL.ObtenerServicios();
        }

        public int GuardarServicio(int idServicio, int idCategoriaServicio, string nombre, string descripcion, decimal precioBase, bool activo)
        {
            if (idCategoriaServicio <= 0)
                throw new ArgumentException("Debe seleccionar una categoría válida.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del servicio es obligatorio.");

            if (precioBase < 0)
                throw new ArgumentException("El precio base no puede ser negativo.");

            return _servicioDAL.GuardarServicio(
                idServicio,
                idCategoriaServicio,
                nombre.Trim(),
                descripcion != null ? descripcion.Trim() : null,
                precioBase,
                activo);
        }
    }
}
