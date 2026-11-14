using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class CatalogosBaseBLL
    {
        private readonly CatalogosBaseDAL _dal = new CatalogosBaseDAL();

        public DataTable ObtenerTiposEquipo()
        {
            return _dal.ObtenerTiposEquipo();
        }

        public void GuardarTipoEquipo(int id, string nombre, string descripcion, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del tipo de equipo es obligatorio.");

            _dal.GuardarTipoEquipo(id, nombre.Trim(), descripcion != null ? descripcion.Trim() : null, activo);
        }

        public DataTable ObtenerMarcas()
        {
            return _dal.ObtenerMarcas();
        }

        public void GuardarMarca(int id, string nombre, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la marca es obligatorio.");

            _dal.GuardarMarca(id, nombre.Trim(), activo);
        }

        public DataTable ObtenerCategoriasServicio()
        {
            return _dal.ObtenerCategoriasServicio();
        }

        public void GuardarCategoriaServicio(int id, string nombre, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la categoría es obligatorio.");

            _dal.GuardarCategoriaServicio(id, nombre.Trim(), activo);
        }
    }
}
