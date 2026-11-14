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

        public DataTable ObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            const string sql = @"
                SELECT 
                    u.IdUsuario,
                    (e.Nombre + ' ' + e.Apellidos) AS Empleado,
                    e.Puesto,
                    u.NombreUsuario AS Usuario,
                    r.Nombre AS Rol,
                    ISNULL(e.Correo, '') AS Correo,
                    u.Activo
                FROM dbo.Usuario u
                INNER JOIN dbo.Empleado e ON u.IdEmpleado = e.IdEmpleado
                INNER JOIN dbo.UsuarioRol ur ON u.IdUsuario = ur.IdUsuario
                INNER JOIN dbo.Rol r ON ur.IdRol = r.IdRol
                ORDER BY u.IdUsuario;";

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public void GuardarUsuario(int idUsuario, string nombreCompletoEmpleado, string puesto, string nombreUsuario, string contrasena, string rolNombre, string correo, bool activo)
        {
            string[] partes = nombreCompletoEmpleado.Trim().Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            string nombreEmp = partes.Length > 0 ? partes[0] : nombreCompletoEmpleado.Trim();
            string apellidosEmp = partes.Length > 1 ? partes[1] : "-";
            object correoParam = string.IsNullOrWhiteSpace(correo) ? (object)DBNull.Value : correo.Trim();

            using (SqlConnection con = ConexionBD.CrearConexion())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        int idRol;
                        using (SqlCommand cmdRol = new SqlCommand("SELECT IdRol FROM dbo.Rol WHERE Nombre = @Nombre;", con, tx))
                        {
                            cmdRol.Parameters.AddWithValue("@Nombre", rolNombre);
                            object resRol = cmdRol.ExecuteScalar();
                            if (resRol == null || resRol == DBNull.Value)
                                throw new InvalidOperationException("El rol seleccionado no existe en la base de datos.");
                            idRol = Convert.ToInt32(resRol);
                        }

                        if (idUsuario == 0)
                        {
                            int nuevoIdEmpleado;
                            const string sqlEmp = @"
                                INSERT INTO dbo.Empleado (Nombre, Apellidos, Puesto, Correo, Activo)
                                VALUES (@Nombre, @Apellidos, @Puesto, @Correo, @Activo);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            using (SqlCommand cmdEmp = new SqlCommand(sqlEmp, con, tx))
                            {
                                cmdEmp.Parameters.AddWithValue("@Nombre", nombreEmp);
                                cmdEmp.Parameters.AddWithValue("@Apellidos", apellidosEmp);
                                cmdEmp.Parameters.AddWithValue("@Puesto", puesto);
                                cmdEmp.Parameters.AddWithValue("@Correo", correoParam);
                                cmdEmp.Parameters.AddWithValue("@Activo", activo);
                                nuevoIdEmpleado = Convert.ToInt32(cmdEmp.ExecuteScalar());
                            }

                            int nuevoIdUsuario;
                            const string sqlUsr = @"
                                INSERT INTO dbo.Usuario (IdEmpleado, NombreUsuario, HashContrasena, Activo)
                                VALUES (@IdEmpleado, @NombreUsuario, HASHBYTES('SHA2_256', CAST(@Contrasena AS VARCHAR(100))), @Activo);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            using (SqlCommand cmdUsr = new SqlCommand(sqlUsr, con, tx))
                            {
                                cmdUsr.Parameters.AddWithValue("@IdEmpleado", nuevoIdEmpleado);
                                cmdUsr.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                                cmdUsr.Parameters.AddWithValue("@Contrasena", contrasena);
                                cmdUsr.Parameters.AddWithValue("@Activo", activo);
                                nuevoIdUsuario = Convert.ToInt32(cmdUsr.ExecuteScalar());
                            }

                            const string sqlUsrRol = "INSERT INTO dbo.UsuarioRol (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol);";
                            using (SqlCommand cmdUR = new SqlCommand(sqlUsrRol, con, tx))
                            {
                                cmdUR.Parameters.AddWithValue("@IdUsuario", nuevoIdUsuario);
                                cmdUR.Parameters.AddWithValue("@IdRol", idRol);
                                cmdUR.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            int idEmpleado;
                            using (SqlCommand cmdGetEmp = new SqlCommand("SELECT IdEmpleado FROM dbo.Usuario WHERE IdUsuario = @IdUsuario;", con, tx))
                            {
                                cmdGetEmp.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                object resEmp = cmdGetEmp.ExecuteScalar();
                                if (resEmp == null || resEmp == DBNull.Value)
                                    throw new InvalidOperationException("El usuario seleccionado no existe.");
                                idEmpleado = Convert.ToInt32(resEmp);
                            }

                            const string sqlUpdEmp = @"
                                UPDATE dbo.Empleado
                                SET Nombre = @Nombre,
                                    Apellidos = @Apellidos,
                                    Puesto = @Puesto,
                                    Correo = @Correo,
                                    Activo = @Activo
                                WHERE IdEmpleado = @IdEmpleado;";

                            using (SqlCommand cmdUpdEmp = new SqlCommand(sqlUpdEmp, con, tx))
                            {
                                cmdUpdEmp.Parameters.AddWithValue("@Nombre", nombreEmp);
                                cmdUpdEmp.Parameters.AddWithValue("@Apellidos", apellidosEmp);
                                cmdUpdEmp.Parameters.AddWithValue("@Puesto", puesto);
                                cmdUpdEmp.Parameters.AddWithValue("@Correo", correoParam);
                                cmdUpdEmp.Parameters.AddWithValue("@Activo", activo);
                                cmdUpdEmp.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                                cmdUpdEmp.ExecuteNonQuery();
                            }

                            bool cambiarPass = !string.IsNullOrWhiteSpace(contrasena);
                            string sqlUpdUsr = cambiarPass
                                ? @"UPDATE dbo.Usuario SET NombreUsuario = @NombreUsuario, HashContrasena = HASHBYTES('SHA2_256', CAST(@Contrasena AS VARCHAR(100))), Activo = @Activo WHERE IdUsuario = @IdUsuario;"
                                : @"UPDATE dbo.Usuario SET NombreUsuario = @NombreUsuario, Activo = @Activo WHERE IdUsuario = @IdUsuario;";

                            using (SqlCommand cmdUpdUsr = new SqlCommand(sqlUpdUsr, con, tx))
                            {
                                cmdUpdUsr.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                                if (cambiarPass) cmdUpdUsr.Parameters.AddWithValue("@Contrasena", contrasena);
                                cmdUpdUsr.Parameters.AddWithValue("@Activo", activo);
                                cmdUpdUsr.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                cmdUpdUsr.ExecuteNonQuery();
                            }

                            const string sqlUpdRol = @"
                                IF EXISTS (SELECT 1 FROM dbo.UsuarioRol WHERE IdUsuario = @IdUsuario)
                                    UPDATE dbo.UsuarioRol SET IdRol = @IdRol WHERE IdUsuario = @IdUsuario;
                                ELSE
                                    INSERT INTO dbo.UsuarioRol (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol);";

                            using (SqlCommand cmdUpdRol = new SqlCommand(sqlUpdRol, con, tx))
                            {
                                cmdUpdRol.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                cmdUpdRol.Parameters.AddWithValue("@IdRol", idRol);
                                cmdUpdRol.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
