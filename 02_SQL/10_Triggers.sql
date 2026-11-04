USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Disparadores de auditoria

-- Registra en la tabla Auditoria los cambios de precio o costo en el catalogo de refacciones.
IF OBJECT_ID('dbo.trg_Auditoria_Refaccion', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_Auditoria_Refaccion;
GO

CREATE TRIGGER dbo.trg_Auditoria_Refaccion
ON dbo.Refaccion
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(PrecioVenta) OR UPDATE(CostoReferencia)
    BEGIN
        INSERT INTO dbo.Auditoria (IdUsuario, TablaAfectada, IdRegistro, Operacion, ValorAnterior, ValorNuevo, FechaEvento)
        SELECT 
            NULL,
            N'Refaccion',
            CAST(i.IdRefaccion AS NVARCHAR(100)),
            N'UPDATE',
            N'PrecioVenta: ' + CAST(d.PrecioVenta AS NVARCHAR(30)) + N', Costo: ' + CAST(d.CostoReferencia AS NVARCHAR(30)),
            N'PrecioVenta: ' + CAST(i.PrecioVenta AS NVARCHAR(30)) + N', Costo: ' + CAST(i.CostoReferencia AS NVARCHAR(30)),
            SYSDATETIME()
        FROM inserted i
        INNER JOIN deleted d ON i.IdRefaccion = d.IdRefaccion
        WHERE i.PrecioVenta <> d.PrecioVenta OR i.CostoReferencia <> d.CostoReferencia;
    END
END;
GO

-- Registra en la tabla Auditoria la creacion, modificacion o baja logica de cuentas de usuario.
IF OBJECT_ID('dbo.trg_Auditoria_Usuario', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_Auditoria_Usuario;
GO

CREATE TRIGGER dbo.trg_Auditoria_Usuario
ON dbo.Usuario
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.Auditoria (IdUsuario, TablaAfectada, IdRegistro, Operacion, ValorAnterior, ValorNuevo, FechaEvento)
        SELECT 
            NULL,
            N'Usuario',
            CAST(i.IdUsuario AS NVARCHAR(100)),
            N'INSERT',
            NULL,
            N'Usuario: ' + i.NombreUsuario + N', IdEmpleado: ' + CAST(i.IdEmpleado AS NVARCHAR(20)),
            SYSDATETIME()
        FROM inserted i;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.Auditoria (IdUsuario, TablaAfectada, IdRegistro, Operacion, ValorAnterior, ValorNuevo, FechaEvento)
        SELECT 
            NULL,
            N'Usuario',
            CAST(i.IdUsuario AS NVARCHAR(100)),
            N'UPDATE',
            N'Usuario: ' + d.NombreUsuario + N', Activo: ' + CAST(d.Activo AS NVARCHAR(1)),
            N'Usuario: ' + i.NombreUsuario + N', Activo: ' + CAST(i.Activo AS NVARCHAR(1)),
            SYSDATETIME()
        FROM inserted i
        INNER JOIN deleted d ON i.IdUsuario = d.IdUsuario;
    END

    IF NOT EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.Auditoria (IdUsuario, TablaAfectada, IdRegistro, Operacion, ValorAnterior, ValorNuevo, FechaEvento)
        SELECT 
            NULL,
            N'Usuario',
            CAST(d.IdUsuario AS NVARCHAR(100)),
            N'DELETE',
            N'Usuario: ' + d.NombreUsuario,
            NULL,
            SYSDATETIME()
        FROM deleted d;
    END
END;
GO

-- 2. Disparadores de automatizacion e inventario

-- Descuenta automaticamente del inventario y genera el movimiento de salida al consumir una refaccion en taller.
IF OBJECT_ID('dbo.trg_DescontarStock_OrdenRefaccion', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_DescontarStock_OrdenRefaccion;
GO

CREATE TRIGGER dbo.trg_DescontarStock_OrdenRefaccion
ON dbo.OrdenRefaccion
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE inv
    SET inv.Existencia = inv.Existencia - ins.CantidadTotal,
        inv.FechaActualizacion = SYSDATETIME()
    FROM dbo.Inventario inv
    INNER JOIN (
        SELECT IdRefaccion, SUM(Cantidad) AS CantidadTotal
        FROM inserted
        GROUP BY IdRefaccion
    ) ins ON inv.IdRefaccion = ins.IdRefaccion;

    INSERT INTO dbo.MovimientoInventario (
        IdRefaccion, IdCompra, IdVentaRefaccion, IdOrdenServicio, IdUsuario, 
        TipoMovimiento, Cantidad, Motivo, FechaMovimiento
    )
    SELECT 
        i.IdRefaccion,
        NULL,
        NULL,
        i.IdOrdenServicio,
        NULL,
        N'Salida',
        -i.Cantidad,
        N'Consumo en orden de servicio',
        SYSDATETIME()
    FROM inserted i;
END;
GO

-- Descuenta existencias y genera movimiento de salida al confirmar una venta de mostrador.
IF OBJECT_ID('dbo.trg_DescontarStock_DetalleVenta', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_DescontarStock_DetalleVenta;
GO

CREATE TRIGGER dbo.trg_DescontarStock_DetalleVenta
ON dbo.DetalleVenta
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE inv
    SET inv.Existencia = inv.Existencia - ins.CantidadTotal,
        inv.FechaActualizacion = SYSDATETIME()
    FROM dbo.Inventario inv
    INNER JOIN (
        SELECT IdRefaccion, SUM(Cantidad) AS CantidadTotal
        FROM inserted
        GROUP BY IdRefaccion
    ) ins ON inv.IdRefaccion = ins.IdRefaccion;

    INSERT INTO dbo.MovimientoInventario (
        IdRefaccion, IdCompra, IdVentaRefaccion, IdOrdenServicio, IdUsuario, 
        TipoMovimiento, Cantidad, Motivo, FechaMovimiento
    )
    SELECT 
        i.IdRefaccion,
        NULL,
        i.IdVentaRefaccion,
        NULL,
        NULL,
        N'Salida',
        -i.Cantidad,
        N'Venta mostrador de refacción',
        SYSDATETIME()
    FROM inserted i;
END;
GO

-- 3. Disparador de integridad de negocio

-- Impide eliminar un cliente o un equipo si tiene ordenes de servicio o historial asociado.
IF OBJECT_ID('dbo.trg_PrevenirEliminar_ClienteConOrdenes', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_PrevenirEliminar_ClienteConOrdenes;
GO

CREATE TRIGGER dbo.trg_PrevenirEliminar_ClienteConOrdenes
ON dbo.Cliente
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 
        FROM deleted d
        INNER JOIN dbo.OrdenServicio o ON d.IdCliente = o.IdCliente
    )
    BEGIN
        RAISERROR(N'No se puede eliminar el cliente porque tiene órdenes de servicio en el historial. Utilice baja lógica (Activo = 0).', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    DELETE FROM dbo.Cliente
    WHERE IdCliente IN (SELECT IdCliente FROM deleted);
END;
GO

-- 4. Disparador de historial de estados

-- Registra automaticamente en HistorialEstadoOrden cualquier cambio de estado en OrdenServicio si no fue asentado en el mismo instante.
IF OBJECT_ID('dbo.trg_HistorialEstado_OrdenServicio', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_HistorialEstado_OrdenServicio;
GO

CREATE TRIGGER dbo.trg_HistorialEstado_OrdenServicio
ON dbo.OrdenServicio
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(IdEstadoOrden)
    BEGIN
        INSERT INTO dbo.HistorialEstadoOrden (IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo)
        SELECT 
            i.IdOrdenServicio,
            d.IdEstadoOrden,
            i.IdEstadoOrden,
            i.IdUsuarioRecepcion,
            SYSDATETIME(),
            N'Actualización automática de estado'
        FROM inserted i
        INNER JOIN deleted d ON i.IdOrdenServicio = d.IdOrdenServicio
        WHERE i.IdEstadoOrden <> d.IdEstadoOrden
          AND NOT EXISTS (
              SELECT 1 
              FROM dbo.HistorialEstadoOrden h 
              WHERE h.IdOrdenServicio = i.IdOrdenServicio 
                AND h.IdEstadoAnterior = d.IdEstadoOrden 
                AND h.IdEstadoNuevo = i.IdEstadoOrden
                AND DATEDIFF(SECOND, h.FechaCambio, SYSDATETIME()) <= 2
          );
    END
END;
GO
