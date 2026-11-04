USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Autenticacion y seguridad

-- Valida credenciales de acceso comparando hash SHA-256, actualiza ultimo acceso y retorna datos de sesion y rol.
IF OBJECT_ID('dbo.usp_ValidarLogin', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_ValidarLogin;
GO

CREATE PROCEDURE dbo.usp_ValidarLogin
    @NombreUsuario NVARCHAR(80),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HashIngresado VARBINARY(256) = HASHBYTES('SHA2_256', @Contrasena);
    DECLARE @IdUsuario INT;

    SELECT @IdUsuario = u.IdUsuario
    FROM dbo.Usuario u
    WHERE u.NombreUsuario = @NombreUsuario
      AND u.HashContrasena = @HashIngresado
      AND u.Activo = 1;

    IF @IdUsuario IS NOT NULL
    BEGIN
        UPDATE dbo.Usuario
        SET UltimoAcceso = SYSDATETIME()
        WHERE IdUsuario = @IdUsuario;

        SELECT 
            u.IdUsuario,
            u.NombreUsuario,
            e.IdEmpleado,
            e.Nombre + ' ' + e.Apellidos AS NombreEmpleado,
            e.Puesto,
            r.IdRol,
            r.Nombre AS Rol
        FROM dbo.Usuario u
        INNER JOIN dbo.Empleado e ON u.IdEmpleado = e.IdEmpleado
        INNER JOIN dbo.UsuarioRol ur ON u.IdUsuario = ur.IdUsuario
        INNER JOIN dbo.Rol r ON ur.IdRol = r.IdRol
        WHERE u.IdUsuario = @IdUsuario;
    END
END;
GO
