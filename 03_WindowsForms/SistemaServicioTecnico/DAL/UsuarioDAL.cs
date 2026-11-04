using System;
using System.Data;
using System.Data.SqlClient;
using SistemaServicioTecnico.Entidades;

namespace SistemaServicioTecnico.DAL
{
    public class UsuarioDAL
    {
        public UsuarioSesion ValidarLogin(string usuario, string contrasena)
        {
            UsuarioSesion sesion = null;

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.usp_ValidarLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            sesion = new UsuarioSesion
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                NombreUsuario = dr["NombreUsuario"].ToString(),
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                NombreEmpleado = dr["NombreEmpleado"].ToString(),
                                Puesto = dr["Puesto"].ToString(),
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Rol = dr["Rol"].ToString()
                            };
                        }
                    }
                }
            }

            return sesion;
        }
    }
}
