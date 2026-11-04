USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Transaccion para recepcion integral de orden de servicio y asignacion de tecnico

-- Registra de forma atomica la recepcion de un equipo, la orden de servicio y la asignacion del tecnico responsable.
IF OBJECT_ID('dbo.usp_Tx_RegistrarOrdenCompleta', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Tx_RegistrarOrdenCompleta;
GO

CREATE PROCEDURE dbo.usp_Tx_RegistrarOrdenCompleta
    @IdCliente INT,
    @IdEquipo INT,
    @IdUsuarioRecepcion INT,
    @IdTecnicoResponsable INT,
    @FallaReportada NVARCHAR(500),
    @Observaciones NVARCHAR(500) = NULL,
    @Presupuesto DECIMAL(10,2) = 0.00,
    @FechaPrometida DATETIME2 = NULL,
    @NuevoIdOrdenServicio INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Cliente WHERE IdCliente = @IdCliente AND Activo = 1)
            THROW 50001, N'El cliente especificado no existe o se encuentra inactivo.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Equipo WHERE IdEquipo = @IdEquipo AND IdCliente = @IdCliente AND Activo = 1)
            THROW 50002, N'El equipo no pertenece al cliente o se encuentra inactivo.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE IdUsuario = @IdUsuarioRecepcion AND Activo = 1)
            THROW 50003, N'El usuario que recibe la orden no es válido o está inactivo.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Empleado WHERE IdEmpleado = @IdTecnicoResponsable AND Activo = 1)
            THROW 50004, N'El técnico responsable asignado no es válido o está inactivo.', 1;

        DECLARE @SiguienteConsecutivo INT = ISNULL((SELECT MAX(IdOrdenServicio) FROM dbo.OrdenServicio WITH (UPDLOCK, HOLDLOCK)), 0) + 1;
        DECLARE @Folio NVARCHAR(40) = N'ORD-' + CAST(YEAR(SYSDATETIME()) AS NVARCHAR(4)) + N'-' + RIGHT(N'0000' + CAST(@SiguienteConsecutivo AS NVARCHAR(10)), 4);

        INSERT INTO dbo.OrdenServicio (
            Folio, IdCliente, IdEquipo, IdEstadoOrden, IdUsuarioRecepcion,
            FechaRecepcion, FechaPrometida, FallaReportada, Observaciones, Presupuesto
        )
        VALUES (
            @Folio, @IdCliente, @IdEquipo, 1, @IdUsuarioRecepcion,
            SYSDATETIME(), @FechaPrometida, @FallaReportada, @Observaciones, @Presupuesto
        );

        SET @NuevoIdOrdenServicio = SCOPE_IDENTITY();

        INSERT INTO dbo.OrdenTecnico (IdOrdenServicio, IdEmpleado, FechaAsignacion, EsResponsable)
        VALUES (@NuevoIdOrdenServicio, @IdTecnicoResponsable, SYSDATETIME(), 1);

        INSERT INTO dbo.HistorialEstadoOrden (IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo)
        VALUES (@NuevoIdOrdenServicio, NULL, 1, @IdUsuarioRecepcion, SYSDATETIME(), N'Recepción de equipo y apertura de orden.');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 2. Transaccion para consumo de refacciones con verificacion de stock disponible

-- Asigna una refaccion a la orden de servicio validando existencia fisica en inventario de forma atomica.
IF OBJECT_ID('dbo.usp_Tx_ConsumirRefaccionEnOrden', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Tx_ConsumirRefaccionEnOrden;
GO

CREATE PROCEDURE dbo.usp_Tx_ConsumirRefaccionEnOrden
    @IdOrdenServicio INT,
    @IdRefaccion INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @Cantidad <= 0
            THROW 50010, N'La cantidad de refacciones a consumir debe ser mayor a cero.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.OrdenServicio WHERE IdOrdenServicio = @IdOrdenServicio AND IdEstadoOrden NOT IN (8, 9))
            THROW 50011, N'La orden de servicio no existe, ya fue entregada o está cancelada.', 1;

        DECLARE @StockActual INT;
        DECLARE @PrecioUnitario DECIMAL(10,2);

        SELECT @StockActual = Existencia
        FROM dbo.Inventario WITH (UPDLOCK, HOLDLOCK)
        WHERE IdRefaccion = @IdRefaccion;

        IF @StockActual IS NULL
            THROW 50012, N'La refacción no tiene registro en el inventario.', 1;

        IF @StockActual < @Cantidad
            THROW 50013, N'Existencia insuficiente en inventario para cubrir la solicitud.', 1;

        SELECT @PrecioUnitario = PrecioVenta
        FROM dbo.Refaccion
        WHERE IdRefaccion = @IdRefaccion;

        INSERT INTO dbo.OrdenRefaccion (IdOrdenServicio, IdRefaccion, Cantidad, PrecioUnitario)
        VALUES (@IdOrdenServicio, @IdRefaccion, @Cantidad, @PrecioUnitario);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 3. Transaccion para compras a proveedor y recepcion de inventario

-- Registra de forma atomica la compra a un proveedor, sus renglones y la actualizacion de stock y costos.
IF OBJECT_ID('dbo.usp_Tx_RegistrarCompraProveedor', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Tx_RegistrarCompraProveedor;
GO

CREATE PROCEDURE dbo.usp_Tx_RegistrarCompraProveedor
    @IdProveedor INT,
    @IdUsuario INT,
    @IdRefaccion INT,
    @Cantidad INT,
    @CostoUnitario DECIMAL(10,2),
    @Observaciones NVARCHAR(500) = NULL,
    @NuevoIdCompra INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @Cantidad <= 0 OR @CostoUnitario <= 0
            THROW 50020, N'La cantidad y el costo unitario de la compra deben ser mayores a cero.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor WHERE IdProveedor = @IdProveedor AND Activo = 1)
            THROW 50021, N'El proveedor especificado no existe o se encuentra inactivo.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Refaccion WHERE IdRefaccion = @IdRefaccion AND Activo = 1)
            THROW 50022, N'La refacción especificada no existe o se encuentra inactiva.', 1;

        DECLARE @SiguienteCompra INT = ISNULL((SELECT MAX(IdCompra) FROM dbo.Compra WITH (UPDLOCK, HOLDLOCK)), 0) + 1;
        DECLARE @Folio NVARCHAR(40) = N'COM-' + CAST(YEAR(SYSDATETIME()) AS NVARCHAR(4)) + N'-' + RIGHT(N'0000' + CAST(@SiguienteCompra AS NVARCHAR(10)), 4);

        INSERT INTO dbo.Compra (Folio, IdProveedor, IdUsuario, FechaCompra, Estado, Observaciones)
        VALUES (@Folio, @IdProveedor, @IdUsuario, SYSDATETIME(), N'Confirmada', @Observaciones);

        SET @NuevoIdCompra = SCOPE_IDENTITY();

        INSERT INTO dbo.DetalleCompra (IdCompra, IdRefaccion, Cantidad, CostoUnitario)
        VALUES (@NuevoIdCompra, @IdRefaccion, @Cantidad, @CostoUnitario);

        UPDATE dbo.Inventario
        SET Existencia = Existencia + @Cantidad,
            FechaActualizacion = SYSDATETIME()
        WHERE IdRefaccion = @IdRefaccion;

        UPDATE dbo.Refaccion
        SET CostoReferencia = @CostoUnitario
        WHERE IdRefaccion = @IdRefaccion;

        INSERT INTO dbo.MovimientoInventario (
            IdRefaccion, IdCompra, IdVentaRefaccion, IdOrdenServicio, IdUsuario,
            TipoMovimiento, Cantidad, Motivo, FechaMovimiento
        )
        VALUES (
            @IdRefaccion, @NuevoIdCompra, NULL, NULL, @IdUsuario,
            N'Entrada', @Cantidad, N'Compra a proveedor ' + @Folio, SYSDATETIME()
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 4. Transaccion para venta directa de refaccion en mostrador

-- Registra de manera atomica una venta de refacciones en mostrador descontando stock y registrando su pago.
IF OBJECT_ID('dbo.usp_Tx_RegistrarVentaMostrador', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Tx_RegistrarVentaMostrador;
GO

CREATE PROCEDURE dbo.usp_Tx_RegistrarVentaMostrador
    @IdCliente INT,
    @IdUsuario INT,
    @IdRefaccion INT,
    @Cantidad INT,
    @IdMetodoPago INT,
    @NuevoIdVenta INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @Cantidad <= 0
            THROW 50030, N'La cantidad de refacciones a vender debe ser mayor a cero.', 1;

        DECLARE @StockActual INT;
        DECLARE @PrecioUnitario DECIMAL(10,2);

        SELECT @StockActual = Existencia
        FROM dbo.Inventario WITH (UPDLOCK, HOLDLOCK)
        WHERE IdRefaccion = @IdRefaccion;

        IF @StockActual IS NULL OR @StockActual < @Cantidad
            THROW 50031, N'Stock insuficiente para concretar la venta de mostrador.', 1;

        SELECT @PrecioUnitario = PrecioVenta
        FROM dbo.Refaccion
        WHERE IdRefaccion = @IdRefaccion;

        DECLARE @SiguienteVenta INT = ISNULL((SELECT MAX(IdVentaRefaccion) FROM dbo.VentaRefaccion WITH (UPDLOCK, HOLDLOCK)), 0) + 1;
        DECLARE @Folio NVARCHAR(40) = N'VTA-' + CAST(YEAR(SYSDATETIME()) AS NVARCHAR(4)) + N'-' + RIGHT(N'0000' + CAST(@SiguienteVenta AS NVARCHAR(10)), 4);

        INSERT INTO dbo.VentaRefaccion (Folio, IdCliente, IdUsuario, FechaVenta, Estado, Observaciones)
        VALUES (@Folio, @IdCliente, @IdUsuario, SYSDATETIME(), N'Confirmada', N'Venta mostrador de refacción');

        SET @NuevoIdVenta = SCOPE_IDENTITY();

        INSERT INTO dbo.DetalleVenta (IdVentaRefaccion, IdRefaccion, Cantidad, PrecioUnitario)
        VALUES (@NuevoIdVenta, @IdRefaccion, @Cantidad, @PrecioUnitario);

        DECLARE @TotalVenta DECIMAL(10,2) = @Cantidad * @PrecioUnitario;

        INSERT INTO dbo.Pago (
            IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, IdUsuario,
            Importe, FechaPago, Referencia, Estado
        )
        VALUES (
            NULL, @NuevoIdVenta, @IdMetodoPago, @IdUsuario,
            @TotalVenta, SYSDATETIME(), N'Pago en caja ' + @Folio, N'Aplicado'
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 5. Transaccion para liquidacion y entrega de orden de servicio

-- Finaliza la orden de servicio validando o cobrando el saldo total pendiente y sellando el historial.
IF OBJECT_ID('dbo.usp_Tx_FinalizarYEntregarOrden', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Tx_FinalizarYEntregarOrden;
GO

CREATE PROCEDURE dbo.usp_Tx_FinalizarYEntregarOrden
    @IdOrdenServicio INT,
    @IdUsuario INT,
    @IdMetodoPago INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @EstadoActual INT;
        SELECT @EstadoActual = IdEstadoOrden
        FROM dbo.OrdenServicio
        WHERE IdOrdenServicio = @IdOrdenServicio;

        IF @EstadoActual IS NULL
            THROW 50040, N'La orden de servicio especificada no existe.', 1;

        IF @EstadoActual = 8
            THROW 50041, N'La orden de servicio ya fue entregada anteriormente.', 1;

        IF @EstadoActual = 9
            THROW 50042, N'La orden de servicio está cancelada.', 1;

        DECLARE @SaldoPendiente DECIMAL(10,2) = dbo.fn_SaldoPendienteOrden(@IdOrdenServicio);

        IF @SaldoPendiente > 0.00
        BEGIN
            INSERT INTO dbo.Pago (
                IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, IdUsuario,
                Importe, FechaPago, Referencia, Estado
            )
            VALUES (
                @IdOrdenServicio, NULL, @IdMetodoPago, @IdUsuario,
                @SaldoPendiente, SYSDATETIME(), N'Finiquito de orden al entregar', N'Aplicado'
            );
        END

        UPDATE dbo.OrdenServicio
        SET IdEstadoOrden = 8,
            FechaEntrega = SYSDATETIME()
        WHERE IdOrdenServicio = @IdOrdenServicio;

        INSERT INTO dbo.HistorialEstadoOrden (
            IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo
        )
        VALUES (
            @IdOrdenServicio, @EstadoActual, 8, @IdUsuario, SYSDATETIME(), N'Equipo liquidado y entregado al cliente satisfactoriamente.'
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
