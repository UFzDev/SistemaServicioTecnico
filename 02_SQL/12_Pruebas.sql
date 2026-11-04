USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Pruebas de violacion de restricciones CHECK, UNIQUE y FOREIGN KEY

-- Prueba 01: Intentar registrar un cliente con nombre en blanco (viola CK_Cliente_Nombre).
BEGIN TRY
    INSERT INTO dbo.Cliente (Nombre, Apellidos, Telefono) VALUES (N'   ', N'Pérez', N'5550001111');
END TRY
BEGIN CATCH
    SELECT 1 AS CasoPrueba, N'CK_Cliente_Nombre' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 02: Intentar registrar un cliente con correo duplicado (viola indice unico UX_Cliente_Correo).
BEGIN TRY
    DECLARE @CorreoExistente NVARCHAR(254) = (SELECT TOP 1 Correo FROM dbo.Cliente WHERE Correo IS NOT NULL);
    INSERT INTO dbo.Cliente (Nombre, Apellidos, Correo) VALUES (N'Duplicado', N'Test', @CorreoExistente);
END TRY
BEGIN CATCH
    SELECT 2 AS CasoPrueba, N'UX_Cliente_Correo' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 03: Intentar registrar un empleado con puesto no permitido (viola CK_Empleado_Puesto).
BEGIN TRY
    INSERT INTO dbo.Empleado (Nombre, Apellidos, Puesto) VALUES (N'Pedro', N'Gómez', N'GerenteGeneral');
END TRY
BEGIN CATCH
    SELECT 3 AS CasoPrueba, N'CK_Empleado_Puesto' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 04: Intentar registrar un servicio con precio base negativo (viola CK_Servicio_PrecioBase).
BEGIN TRY
    INSERT INTO dbo.Servicio (IdCategoriaServicio, Nombre, PrecioBase) VALUES (1, N'Servicio Inválido', -150.00);
END TRY
BEGIN CATCH
    SELECT 4 AS CasoPrueba, N'CK_Servicio_PrecioBase' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 05: Intentar registrar una refaccion con SKU duplicado (viola UQ_Refaccion_SKU).
BEGIN TRY
    DECLARE @SKUExistente NVARCHAR(60) = (SELECT TOP 1 SKU FROM dbo.Refaccion);
    INSERT INTO dbo.Refaccion (IdCategoriaRefaccion, SKU, Nombre, CostoReferencia, PrecioVenta)
    VALUES (1, @SKUExistente, N'Refacción Duplicada', 100, 200);
END TRY
BEGIN CATCH
    SELECT 5 AS CasoPrueba, N'UQ_Refaccion_SKU' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 06: Intentar insertar una orden con un equipo que pertenece a otro cliente (viola FK_Orden_EquipoCliente).
BEGIN TRY
    INSERT INTO dbo.OrdenServicio (Folio, IdCliente, IdEquipo, IdEstadoOrden, FallaReportada)
    VALUES (N'ORD-ERR-0001', 2, 1, 1, N'Falla de prueba con cliente cruzado');
END TRY
BEGIN CATCH
    SELECT 6 AS CasoPrueba, N'FK_Orden_EquipoCliente' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 07: Intentar insertar una orden con fecha de entrega anterior a la recepcion (viola CK_Orden_Fechas).
BEGIN TRY
    INSERT INTO dbo.OrdenServicio (Folio, IdCliente, IdEquipo, IdEstadoOrden, FechaRecepcion, FechaEntrega, FallaReportada)
    VALUES (N'ORD-ERR-0002', 1, 1, 1, '2026-05-10', '2026-05-01', N'Falla de prueba con fechas invertidas');
END TRY
BEGIN CATCH
    SELECT 7 AS CasoPrueba, N'CK_Orden_Fechas' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 08: Intentar registrar un pago sin asociarlo ni a orden ni a venta (viola CK_Pago_Destino).
BEGIN TRY
    INSERT INTO dbo.Pago (IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, Importe)
    VALUES (NULL, NULL, 1, 500.00);
END TRY
BEGIN CATCH
    SELECT 8 AS CasoPrueba, N'CK_Pago_Destino' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 09: Intentar registrar un pago con importe cero o negativo (viola CK_Pago_Importe).
BEGIN TRY
    INSERT INTO dbo.Pago (IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, Importe)
    VALUES (1, NULL, 1, -50.00);
END TRY
BEGIN CATCH
    SELECT 9 AS CasoPrueba, N'CK_Pago_Importe' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 10: Intentar dejar una existencia negativa en inventario directamente (viola CK_Inventario_Existencia).
BEGIN TRY
    UPDATE dbo.Inventario SET Existencia = -5 WHERE IdRefaccion = 1;
END TRY
BEGIN CATCH
    SELECT 10 AS CasoPrueba, N'CK_Inventario_Existencia' AS RestriccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- 2. Pruebas de Funciones, Vistas y Procedimientos Almacenados

-- Prueba 11: Validar inicio de sesion exitoso para el usuario administrador mediante usp_ValidarLogin.
EXEC dbo.usp_ValidarLogin @NombreUsuario = N'admin', @Contrasena = 'admin123';
GO

-- Prueba 12: Evaluar funciones escalares de costo total, saldo pendiente, garantia y clasificacion de cliente.
SELECT 
    1 AS IdOrdenEvaluada,
    dbo.fn_CostoTotalOrden(1) AS CostoTotalOrden,
    dbo.fn_SaldoPendienteOrden(1) AS SaldoPendiente,
    dbo.fn_DiasGarantiaRestantes(1) AS DiasGarantiaRestantes,
    dbo.fn_ClasificacionCliente(1) AS ClasificacionCliente1;
GO

-- Prueba 13: Consultar funciones con valores de tabla para historial de cliente y catalogo por categoria.
SELECT TOP 3 * FROM dbo.fn_HistorialOrdenesCliente(1);
SELECT TOP 3 * FROM dbo.fn_RefaccionesPorCategoria(1);
GO

-- Prueba 14: Consultar vistas operativas, relacionales y gerenciales.
SELECT TOP 3 IdOrdenServicio, Folio, Cliente, EstadoActual, TecnicoAsignado FROM dbo.vw_OrdenesTallerActivas;
SELECT TOP 3 SKU, Refaccion, Existencia, EstadoStock FROM dbo.vw_InventarioStockAlerta;
SELECT TOP 3 Anio, MesNombre, IngresoTotal FROM dbo.vw_ReporteIngresosMensuales;
GO

-- 3. Pruebas de Triggers y Transacciones (Exito y Rollback)

-- Prueba 15: Verificar el disparo del trigger de auditoria al actualizar el precio de una refaccion.
BEGIN TRANSACTION;
    UPDATE dbo.Refaccion SET PrecioVenta = PrecioVenta + 10.00 WHERE IdRefaccion = 1;
    SELECT TOP 1 IdAuditoria, TablaAfectada, Operacion, ValorAnterior, ValorNuevo, FechaEvento
    FROM dbo.Auditoria
    WHERE TablaAfectada = N'Refaccion'
    ORDER BY IdAuditoria DESC;
ROLLBACK TRANSACTION;
GO

-- Prueba 16: Verificar que el trigger trg_PrevenirEliminar_ClienteConOrdenes bloquee el borrado de un cliente con historial.
BEGIN TRY
    DELETE FROM dbo.Cliente WHERE IdCliente = 1;
END TRY
BEGIN CATCH
    SELECT 16 AS CasoPrueba, N'trg_PrevenirEliminar_ClienteConOrdenes' AS TriggerProbado, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 17: Ejecutar transaccion exitosa de recepcion completa de orden y revertir al final para no ensuciar datos demo.
BEGIN TRANSACTION;
    DECLARE @IdOrdenNueva INT;
    EXEC dbo.usp_Tx_RegistrarOrdenCompleta
        @IdCliente = 1,
        @IdEquipo = 1,
        @IdUsuarioRecepcion = 3,
        @IdTecnicoResponsable = 5,
        @FallaReportada = N'Prueba transaccional de apertura de orden completa',
        @Observaciones = N'Cargador incluido',
        @Presupuesto = 850.00,
        @NuevoIdOrdenServicio = @IdOrdenNueva OUTPUT;

    SELECT @IdOrdenNueva AS IdOrdenCreadaEnTransaccion, Folio, IdEstadoOrden
    FROM dbo.OrdenServicio
    WHERE IdOrdenServicio = @IdOrdenNueva;
ROLLBACK TRANSACTION;
GO

-- Prueba 18: Provocar ROLLBACK en usp_Tx_ConsumirRefaccionEnOrden solicitando mas stock del existente.
BEGIN TRY
    EXEC dbo.usp_Tx_ConsumirRefaccionEnOrden @IdOrdenServicio = 2, @IdRefaccion = 1, @Cantidad = 99999;
END TRY
BEGIN CATCH
    SELECT 18 AS CasoPrueba, N'usp_Tx_ConsumirRefaccionEnOrden (Sin Stock)' AS TransaccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO

-- Prueba 19: Ejecutar transaccion exitosa de compra a proveedor verificando incremento de stock y kardex.
BEGIN TRANSACTION;
    DECLARE @StockAntes INT = (SELECT Existencia FROM dbo.Inventario WHERE IdRefaccion = 2);
    DECLARE @IdCompraNueva INT;

    EXEC dbo.usp_Tx_RegistrarCompraProveedor
        @IdProveedor = 1,
        @IdUsuario = 1,
        @IdRefaccion = 2,
        @Cantidad = 5,
        @CostoUnitario = 320.00,
        @Observaciones = N'Abastecimiento de prueba transaccional',
        @NuevoIdCompra = @IdCompraNueva OUTPUT;

    DECLARE @StockDespues INT = (SELECT Existencia FROM dbo.Inventario WHERE IdRefaccion = 2);

    SELECT 19 AS CasoPrueba, @IdCompraNueva AS IdCompraGenerada, @StockAntes AS StockAntes, @StockDespues AS StockDespues;
ROLLBACK TRANSACTION;
GO

-- Prueba 20: Provocar ROLLBACK en usp_Tx_FinalizarYEntregarOrden intentando entregar una orden ya entregada (Orden 1).
BEGIN TRY
    EXEC dbo.usp_Tx_FinalizarYEntregarOrden @IdOrdenServicio = 1, @IdUsuario = 3, @IdMetodoPago = 1;
END TRY
BEGIN CATCH
    SELECT 20 AS CasoPrueba, N'usp_Tx_FinalizarYEntregarOrden (Orden ya entregada)' AS TransaccionProbada, ERROR_NUMBER() AS CodigoError, ERROR_MESSAGE() AS MensajeError;
END CATCH;
GO
