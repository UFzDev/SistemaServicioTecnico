USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Funciones escalares de calculo

-- Calcula el importe total acumulado de una orden sumando servicios brindados y refacciones consumidas.
IF OBJECT_ID('dbo.fn_CostoTotalOrden', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_CostoTotalOrden;
GO

CREATE FUNCTION dbo.fn_CostoTotalOrden (@IdOrdenServicio INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @TotalServicios DECIMAL(12,2) = 0;
    DECLARE @TotalRefacciones DECIMAL(12,2) = 0;

    SELECT @TotalServicios = ISNULL(SUM(Cantidad * PrecioUnitario), 0)
    FROM dbo.DetalleOrdenServicio
    WHERE IdOrdenServicio = @IdOrdenServicio;

    SELECT @TotalRefacciones = ISNULL(SUM(Cantidad * PrecioUnitario), 0)
    FROM dbo.OrdenRefaccion
    WHERE IdOrdenServicio = @IdOrdenServicio;

    RETURN (@TotalServicios + @TotalRefacciones);
END;
GO

-- Calcula el saldo pendiente por pagar de una orden restando los pagos aplicados al costo total.
IF OBJECT_ID('dbo.fn_SaldoPendienteOrden', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_SaldoPendienteOrden;
GO

CREATE FUNCTION dbo.fn_SaldoPendienteOrden (@IdOrdenServicio INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @CostoTotal DECIMAL(12,2) = dbo.fn_CostoTotalOrden(@IdOrdenServicio);
    DECLARE @TotalPagado DECIMAL(12,2) = 0;

    SELECT @TotalPagado = ISNULL(SUM(Importe), 0)
    FROM dbo.Pago
    WHERE IdOrdenServicio = @IdOrdenServicio AND Estado = 'Aplicado';

    RETURN (@CostoTotal - @TotalPagado);
END;
GO

-- Calcula los dias de garantia restantes de un equipo entregado comparando la fecha de entrega con la configuracion del taller.
IF OBJECT_ID('dbo.fn_DiasGarantiaRestantes', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_DiasGarantiaRestantes;
GO

CREATE FUNCTION dbo.fn_DiasGarantiaRestantes (@IdOrdenServicio INT)
RETURNS INT
AS
BEGIN
    DECLARE @FechaEntrega DATETIME2(0);
    DECLARE @DiasConfig INT = 30;

    SELECT @FechaEntrega = FechaEntrega
    FROM dbo.OrdenServicio
    WHERE IdOrdenServicio = @IdOrdenServicio AND IdEstadoOrden = 8;

    IF @FechaEntrega IS NULL
        RETURN 0;

    SELECT @DiasConfig = TRY_CAST(Valor AS INT)
    FROM dbo.Configuracion
    WHERE Clave = 'DIAS_GARANTIA_DEFAULT';

    DECLARE @DiasTranscurridos INT = DATEDIFF(DAY, @FechaEntrega, GETDATE());
    DECLARE @Restantes INT = @DiasConfig - @DiasTranscurridos;

    RETURN CASE WHEN @Restantes > 0 THEN @Restantes ELSE 0 END;
END;
GO

-- Clasifica el nivel de un cliente segun su volumen historico de gasto en el taller.
IF OBJECT_ID('dbo.fn_ClasificacionCliente', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_ClasificacionCliente;
GO

CREATE FUNCTION dbo.fn_ClasificacionCliente (@IdCliente INT)
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @GastoTotal DECIMAL(12,2) = 0;

    SELECT @GastoTotal = ISNULL(SUM(p.Importe), 0)
    FROM dbo.Pago p
    LEFT JOIN dbo.OrdenServicio o ON p.IdOrdenServicio = o.IdOrdenServicio
    LEFT JOIN dbo.VentaRefaccion v ON p.IdVentaRefaccion = v.IdVentaRefaccion
    WHERE p.Estado = 'Aplicado'
      AND (o.IdCliente = @IdCliente OR v.IdCliente = @IdCliente);

    RETURN CASE 
        WHEN @GastoTotal >= 3000.00 THEN 'VIP'
        WHEN @GastoTotal >= 1000.00 THEN 'FRECUENTE'
        WHEN @GastoTotal > 0 THEN 'REGULAR'
        ELSE 'NUEVO'
    END;
END;
GO

-- 2. Funciones de tabla (Inline Table-Valued Functions)

-- Devuelve la lista tabular de todas las ordenes registradas de un cliente con su estado y costo calculado.
IF OBJECT_ID('dbo.fn_HistorialOrdenesCliente', 'IF') IS NOT NULL
    DROP FUNCTION dbo.fn_HistorialOrdenesCliente;
GO

CREATE FUNCTION dbo.fn_HistorialOrdenesCliente (@IdCliente INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        o.IdOrdenServicio,
        o.Folio,
        m.Nombre + ' ' + eq.Modelo AS Dispositivo,
        eq.NumeroSerie,
        eo.Nombre AS EstadoOrden,
        o.FechaRecepcion,
        o.FechaEntrega,
        dbo.fn_CostoTotalOrden(o.IdOrdenServicio) AS TotalCalculado,
        dbo.fn_SaldoPendienteOrden(o.IdOrdenServicio) AS SaldoPendiente
    FROM dbo.OrdenServicio o
    INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
    INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
    INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden
    WHERE o.IdCliente = @IdCliente
);
GO

-- Devuelve el listado tabular de refacciones con existencia actual y valor de inventario por categoria.
IF OBJECT_ID('dbo.fn_RefaccionesPorCategoria', 'IF') IS NOT NULL
    DROP FUNCTION dbo.fn_RefaccionesPorCategoria;
GO

CREATE FUNCTION dbo.fn_RefaccionesPorCategoria (@IdCategoriaRefaccion INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        r.IdRefaccion,
        r.SKU,
        r.Nombre AS Refaccion,
        r.PrecioVenta,
        i.Existencia,
        (r.PrecioVenta * i.Existencia) AS ValorInventario
    FROM dbo.Refaccion r
    INNER JOIN dbo.Inventario i ON r.IdRefaccion = i.IdRefaccion
    WHERE r.Activo = 1
      AND (@IdCategoriaRefaccion IS NULL OR r.IdCategoriaRefaccion = @IdCategoriaRefaccion)
);
GO
