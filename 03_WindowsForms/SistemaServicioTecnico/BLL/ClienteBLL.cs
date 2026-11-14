using System;
using System.Data;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico.BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();

        public DataTable ObtenerTiposEquipo()
        {
            return _clienteDAL.ObtenerTiposEquipo();
        }

        public DataTable ObtenerMarcas()
        {
            return _clienteDAL.ObtenerMarcas();
        }

        public DataTable ObtenerClientes()
        {
            return _clienteDAL.ObtenerClientes();
        }

        public DataTable ObtenerEquipos()
        {
            return _clienteDAL.ObtenerEquipos();
        }

        public int GuardarCliente(int idCliente, string nombre, string apellidos, string telefono, string correo, string direccion, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            return _clienteDAL.GuardarCliente(
                idCliente,
                nombre.Trim(),
                apellidos != null ? apellidos.Trim() : null,
                telefono != null ? telefono.Trim() : null,
                correo != null ? correo.Trim() : null,
                direccion != null ? direccion.Trim() : null,
                activo);
        }

        public int GuardarEquipo(int idEquipo, int idCliente, int idTipoEquipo, int idMarca, string modelo, string numeroSerie, string caracteristicas, bool activo)
        {
            if (idCliente <= 0)
                throw new ArgumentException("Debe seleccionar un cliente válido.");

            if (idTipoEquipo <= 0 || idMarca <= 0)
                throw new ArgumentException("Debe seleccionar tipo de equipo y marca.");

            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo del equipo es obligatorio.");

            return _clienteDAL.GuardarEquipo(
                idEquipo,
                idCliente,
                idTipoEquipo,
                idMarca,
                modelo.Trim(),
                numeroSerie != null ? numeroSerie.Trim() : null,
                caracteristicas != null ? caracteristicas.Trim() : null,
                activo);
        }
    }
}
