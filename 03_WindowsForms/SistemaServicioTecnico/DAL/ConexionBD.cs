using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaServicioTecnico.DAL
{
    public static class ConexionBD
    {
        private static readonly string _cadenaConexion;

        static ConexionBD()
        {
            var config = ConfigurationManager.ConnectionStrings["CadenaConexion"];
            if (config == null || string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'CadenaConexion' en App.config.");
            }
            _cadenaConexion = config.ConnectionString;
        }

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
