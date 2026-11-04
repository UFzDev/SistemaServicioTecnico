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

-- 2. Procedimientos de catalogos

-- Inserta o actualiza un cliente validando nombre obligatorio y duplicidad de correo.
IF OBJECT_ID('dbo.usp_ClienteGuardar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_ClienteGuardar;
GO

CREATE PROCEDURE dbo.usp_ClienteGuardar
    @IdCliente INT = 0,
    @Nombre NVARCHAR(120),
    @Apellidos NVARCHAR(150) = NULL,
    @Telefono NVARCHAR(25) = NULL,
    @Correo NVARCHAR(254) = NULL,
    @Direccion NVARCHAR(300) = NULL,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
        THROW 50001, 'El nombre del cliente es obligatorio.', 1;

    IF @IdCliente = 0
    BEGIN
        INSERT INTO dbo.Cliente (Nombre, Apellidos, Telefono, Correo, Direccion, Activo)
        VALUES (@Nombre, @Apellidos, @Telefono, @Correo, @Direccion, @Activo);

        SELECT SCOPE_IDENTITY() AS IdGenerado;
    END
    ELSE
    BEGIN
        UPDATE dbo.Cliente
        SET Nombre = @Nombre,
            Apellidos = @Apellidos,
            Telefono = @Telefono,
            Correo = @Correo,
            Direccion = @Direccion,
            Activo = @Activo
        WHERE IdCliente = @IdCliente;

        SELECT @IdCliente AS IdGenerado;
    END
END;
GO

-- Inserta o actualiza una refaccion validando sku unico, costos y stock minimo.
IF OBJECT_ID('dbo.usp_RefaccionGuardar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_RefaccionGuardar;
GO

CREATE PROCEDURE dbo.usp_RefaccionGuardar
    @IdRefaccion INT = 0,
    @IdCategoriaRefaccion INT,
    @SKU NVARCHAR(60),
    @Nombre NVARCHAR(160),
    @Descripcion NVARCHAR(500) = NULL,
    @CostoReferencia DECIMAL(12,2) = 0,
    @PrecioVenta DECIMAL(12,2) = 0,
    @StockMinimo INT = 0,
    @StockInicial INT = 0,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @SKU IS NULL OR LEN(LTRIM(RTRIM(@SKU))) = 0
        THROW 50002, 'El SKU es obligatorio.', 1;

    IF @PrecioVenta < 0 OR @CostoReferencia < 0
        THROW 50003, 'Los precios y costos no pueden ser negativos.', 1;

    IF @IdRefaccion = 0
    BEGIN
        INSERT INTO dbo.Refaccion (IdCategoriaRefaccion, SKU, Nombre, Descripcion, CostoReferencia, PrecioVenta, StockMinimo, Activo)
        VALUES (@IdCategoriaRefaccion, @SKU, @Nombre, @Descripcion, @CostoReferencia, @PrecioVenta, @StockMinimo, @Activo);

        DECLARE @NuevoId INT = SCOPE_IDENTITY();

        INSERT INTO dbo.Inventario (IdRefaccion, Existencia, FechaActualizacion)
        VALUES (@NuevoId, ISNULL(@StockInicial, 0), SYSDATETIME());

        SELECT @NuevoId AS IdGenerado;
    END
    ELSE
    BEGIN
        UPDATE dbo.Refaccion
        SET IdCategoriaRefaccion = @IdCategoriaRefaccion,
            SKU = @SKU,
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            CostoReferencia = @CostoReferencia,
            PrecioVenta = @PrecioVenta,
            StockMinimo = @StockMinimo,
            Activo = @Activo
        WHERE IdRefaccion = @IdRefaccion;

        SELECT @IdRefaccion AS IdGenerado;
    END
END;
GO

-- Inserta o actualiza un proveedor validando su nombre comercial y formato de RFC.
IF OBJECT_ID('dbo.usp_ProveedorGuardar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_ProveedorGuardar;
GO

CREATE PROCEDURE dbo.usp_ProveedorGuardar
    @IdProveedor INT = 0,
    @Nombre NVARCHAR(180),
    @RFC NVARCHAR(13) = NULL,
    @Contacto NVARCHAR(120) = NULL,
    @Telefono NVARCHAR(25) = NULL,
    @Correo NVARCHAR(254) = NULL,
    @Direccion NVARCHAR(300) = NULL,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
        THROW 50004, 'El nombre del proveedor es obligatorio.', 1;

    IF @IdProveedor = 0
    BEGIN
        INSERT INTO dbo.Proveedor (Nombre, RFC, Contacto, Telefono, Correo, Direccion, Activo)
        VALUES (@Nombre, @RFC, @Contacto, @Telefono, @Correo, @Direccion, @Activo);

        SELECT SCOPE_IDENTITY() AS IdGenerado;
    END
    ELSE
    BEGIN
        UPDATE dbo.Proveedor
        SET Nombre = @Nombre,
            RFC = @RFC,
            Contacto = @Contacto,
            Telefono = @Telefono,
            Correo = @Correo,
            Direccion = @Direccion,
            Activo = @Activo
        WHERE IdProveedor = @IdProveedor;

        SELECT @IdProveedor AS IdGenerado;
    END
END;
GO

-- Inserta o actualiza un servicio del catalogo de taller validando categoria y precio base.
IF OBJECT_ID('dbo.usp_ServicioGuardar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_ServicioGuardar;
GO

CREATE PROCEDURE dbo.usp_ServicioGuardar
    @IdServicio INT = 0,
    @IdCategoriaServicio INT,
    @Nombre NVARCHAR(160),
    @Descripcion NVARCHAR(400) = NULL,
    @PrecioBase DECIMAL(12,2) = 0,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
        THROW 50005, 'El nombre del servicio es obligatorio.', 1;

    IF @PrecioBase < 0
        THROW 50006, 'El precio base del servicio no puede ser negativo.', 1;

    IF @IdServicio = 0
    BEGIN
        INSERT INTO dbo.Servicio (IdCategoriaServicio, Nombre, Descripcion, PrecioBase, Activo)
        VALUES (@IdCategoriaServicio, @Nombre, @Descripcion, @PrecioBase, @Activo);

        SELECT SCOPE_IDENTITY() AS IdGenerado;
    END
    ELSE
    BEGIN
        UPDATE dbo.Servicio
        SET IdCategoriaServicio = @IdCategoriaServicio,
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            PrecioBase = @PrecioBase,
            Activo = @Activo
        WHERE IdServicio = @IdServicio;

        SELECT @IdServicio AS IdGenerado;
    END
END;
GO

-- Inserta o actualiza un equipo asociado a un cliente para recepcion en taller.
IF OBJECT_ID('dbo.usp_EquipoGuardar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_EquipoGuardar;
GO

CREATE PROCEDURE dbo.usp_EquipoGuardar
    @IdEquipo INT = 0,
    @IdCliente INT,
    @IdTipoEquipo INT,
    @IdMarca INT,
    @Modelo NVARCHAR(130),
    @NumeroSerie NVARCHAR(120) = NULL,
    @Caracteristicas NVARCHAR(500) = NULL,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @Modelo IS NULL OR LEN(LTRIM(RTRIM(@Modelo))) = 0
        THROW 50007, 'El modelo del equipo es obligatorio.', 1;

    IF @IdEquipo = 0
    BEGIN
        INSERT INTO dbo.Equipo (IdCliente, IdTipoEquipo, IdMarca, Modelo, NumeroSerie, Caracteristicas, Activo)
        VALUES (@IdCliente, @IdTipoEquipo, @IdMarca, @Modelo, @NumeroSerie, @Caracteristicas, @Activo);

        SELECT SCOPE_IDENTITY() AS IdGenerado;
    END
    ELSE
    BEGIN
        UPDATE dbo.Equipo
        SET IdCliente = @IdCliente,
            IdTipoEquipo = @IdTipoEquipo,
            IdMarca = @IdMarca,
            Modelo = @Modelo,
            NumeroSerie = @NumeroSerie,
            Caracteristicas = @Caracteristicas,
            Activo = @Activo
        WHERE IdEquipo = @IdEquipo;

        SELECT @IdEquipo AS IdGenerado;
    END
END;
GO

-- 3. Procedimientos transaccionales de procesos

-- Registra una nueva orden de servicio con su estado inicial y trazabilidad en historial.
IF OBJECT_ID('dbo.usp_RegistrarOrdenServicio', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_RegistrarOrdenServicio;
GO

CREATE PROCEDURE dbo.usp_RegistrarOrdenServicio
    @Folio NVARCHAR(40),
    @IdCliente INT,
    @IdEquipo INT,
    @IdUsuarioRecepcion INT,
    @FallaReportada NVARCHAR(1000),
    @Observaciones NVARCHAR(1000) = NULL,
    @Presupuesto DECIMAL(12,2) = NULL,
    @FechaPrometida DATETIME2(0) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Equipo WHERE IdEquipo = @IdEquipo AND IdCliente = @IdCliente)
            THROW 50010, 'El equipo seleccionado no pertenece al cliente especificado.', 1;

        DECLARE @IdEstadoInicial INT = (SELECT TOP 1 IdEstadoOrden FROM dbo.EstadoOrden WHERE Nombre = N'Recibida');

        INSERT INTO dbo.OrdenServicio (
            Folio, IdCliente, IdEquipo, IdEstadoOrden, IdUsuarioRecepcion, 
            FechaRecepcion, FechaPrometida, FallaReportada, Observaciones, Presupuesto
        )
        VALUES (
            @Folio, @IdCliente, @IdEquipo, @IdEstadoInicial, @IdUsuarioRecepcion, 
            SYSDATETIME(), @FechaPrometida, @FallaReportada, @Observaciones, @Presupuesto
        );

        DECLARE @IdOrdenGenerada INT = SCOPE_IDENTITY();

        INSERT INTO dbo.HistorialEstadoOrden (IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo)
        VALUES (@IdOrdenGenerada, NULL, @IdEstadoInicial, @IdUsuarioRecepcion, SYSDATETIME(), N'Recepción de equipo en taller');

        COMMIT TRANSACTION;

        SELECT @IdOrdenGenerada AS IdOrdenServicio, @Folio AS Folio;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Aplica un cobro a una orden o venta actualizando saldo y registrando en caja.
IF OBJECT_ID('dbo.usp_RegistrarPago', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_RegistrarPago;
GO

CREATE PROCEDURE dbo.usp_RegistrarPago
    @IdOrdenServicio INT = NULL,
    @IdVentaRefaccion INT = NULL,
    @IdMetodoPago INT,
    @IdUsuario INT,
    @Importe DECIMAL(12,2),
    @Referencia NVARCHAR(120) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF (@IdOrdenServicio IS NULL AND @IdVentaRefaccion IS NULL) OR (@IdOrdenServicio IS NOT NULL AND @IdVentaRefaccion IS NOT NULL)
            THROW 50020, 'El pago debe pertenecer a una Orden de Servicio o a una Venta, no a ambas ni a ninguna.', 1;

        IF @Importe <= 0
            THROW 50021, 'El importe a pagar debe ser mayor a cero.', 1;

        INSERT INTO dbo.Pago (IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, IdUsuario, Importe, FechaPago, Referencia, Estado)
        VALUES (@IdOrdenServicio, @IdVentaRefaccion, @IdMetodoPago, @IdUsuario, @Importe, SYSDATETIME(), @Referencia, N'Aplicado');

        DECLARE @IdPagoGenerado INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        SELECT @IdPagoGenerado AS IdPago;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 4. Procedimientos administrativos y de ajuste

-- Cambia el estado de una orden registrando el motivo en historial y validando entrega.
IF OBJECT_ID('dbo.usp_CambiarEstadoOrden', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_CambiarEstadoOrden;
GO

CREATE PROCEDURE dbo.usp_CambiarEstadoOrden
    @IdOrdenServicio INT,
    @IdNuevoEstado INT,
    @IdUsuario INT,
    @Motivo NVARCHAR(400) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IdEstadoActual INT = (SELECT IdEstadoOrden FROM dbo.OrdenServicio WHERE IdOrdenServicio = @IdOrdenServicio);

        IF @IdEstadoActual IS NULL
            THROW 50030, 'La orden de servicio especificada no existe.', 1;

        IF @IdEstadoActual = @IdNuevoEstado
            THROW 50031, 'La orden ya se encuentra en el estado indicado.', 1;

        UPDATE dbo.OrdenServicio
        SET IdEstadoOrden = @IdNuevoEstado,
            FechaEntrega = CASE WHEN @IdNuevoEstado = 8 THEN SYSDATETIME() ELSE FechaEntrega END
        WHERE IdOrdenServicio = @IdOrdenServicio;

        INSERT INTO dbo.HistorialEstadoOrden (IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo)
        VALUES (@IdOrdenServicio, @IdEstadoActual, @IdNuevoEstado, @IdUsuario, SYSDATETIME(), @Motivo);

        COMMIT TRANSACTION;

        SELECT @IdOrdenServicio AS IdOrdenServicio, @IdNuevoEstado AS NuevoEstado;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Realiza un ajuste manual de inventario con motivo obligatorio para control de perdidas o resurtidos.
IF OBJECT_ID('dbo.usp_AjustarInventario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_AjustarInventario;
GO

CREATE PROCEDURE dbo.usp_AjustarInventario
    @IdRefaccion INT,
    @CantidadAjuste INT,
    @IdUsuario INT,
    @Motivo NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @CantidadAjuste = 0
            THROW 50040, 'La cantidad de ajuste no puede ser cero.', 1;

        IF @Motivo IS NULL OR LEN(LTRIM(RTRIM(@Motivo))) = 0
            THROW 50041, 'Debe especificar el motivo del ajuste de inventario.', 1;

        DECLARE @ExistenciaActual INT = (SELECT Existencia FROM dbo.Inventario WHERE IdRefaccion = @IdRefaccion);

        IF @ExistenciaActual IS NULL
            THROW 50042, 'La refacción no tiene registro en inventario.', 1;

        IF (@ExistenciaActual + @CantidadAjuste) < 0
            THROW 50043, 'El ajuste dejaría la existencia en número negativo.', 1;

        UPDATE dbo.Inventario
        SET Existencia = Existencia + @CantidadAjuste,
            FechaActualizacion = SYSDATETIME()
        WHERE IdRefaccion = @IdRefaccion;

        INSERT INTO dbo.MovimientoInventario (
            IdRefaccion, IdCompra, IdVentaRefaccion, IdOrdenServicio, IdUsuario, 
            TipoMovimiento, Cantidad, Motivo, FechaMovimiento
        )
        VALUES (
            @IdRefaccion, NULL, NULL, NULL, @IdUsuario, 
            N'Ajuste', @CantidadAjuste, @Motivo, SYSDATETIME()
        );

        COMMIT TRANSACTION;

        SELECT @IdRefaccion AS IdRefaccion, (@ExistenciaActual + @CantidadAjuste) AS NuevaExistencia;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 5. Procedimientos analiticos y de reportes

-- Reporte de ingresos entre fechas con parametros opcionales de estado y cliente.
IF OBJECT_ID('dbo.usp_ReporteIngresosPeriodo', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_ReporteIngresosPeriodo;
GO

CREATE PROCEDURE dbo.usp_ReporteIngresosPeriodo
    @FechaInicio DATETIME2(0) = '2020-01-01',
    @FechaFin DATETIME2(0) = '2099-12-31',
    @IdMetodoPago INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.IdPago,
        p.FechaPago,
        mp.Nombre AS MetodoPago,
        p.Importe,
        p.Referencia,
        CASE 
            WHEN p.IdOrdenServicio IS NOT NULL THEN 'Orden de Servicio: ' + o.Folio
            ELSE 'Venta Mostrador: ' + v.Folio
        END AS Concepto,
        u.NombreUsuario AS CobradoPor
    FROM dbo.Pago p
    INNER JOIN dbo.MetodoPago mp ON p.IdMetodoPago = mp.IdMetodoPago
    LEFT JOIN dbo.Usuario u ON p.IdUsuario = u.IdUsuario
    LEFT JOIN dbo.OrdenServicio o ON p.IdOrdenServicio = o.IdOrdenServicio
    LEFT JOIN dbo.VentaRefaccion v ON p.IdVentaRefaccion = v.IdVentaRefaccion
    WHERE p.Estado = 'Aplicado'
      AND p.FechaPago BETWEEN @FechaInicio AND @FechaFin
      AND (@IdMetodoPago IS NULL OR p.IdMetodoPago = @IdMetodoPago)
    ORDER BY p.FechaPago DESC;
END;
GO
