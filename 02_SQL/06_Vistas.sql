USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Vistas operativas

-- Alimenta el tablero principal del taller con ordenes en curso, dias transcurridos y tecnico responsable.
IF OBJECT_ID('dbo.vw_OrdenesTallerActivas', 'V') IS NOT NULL
    DROP VIEW dbo.vw_OrdenesTallerActivas;
GO

CREATE VIEW dbo.vw_OrdenesTallerActivas
AS
SELECT 
    o.IdOrdenServicio,
    o.Folio,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    c.Telefono,
    te.Nombre AS TipoDispositivo,
    m.Nombre + ' ' + eq.Modelo AS Dispositivo,
    eq.NumeroSerie,
    eo.Nombre AS EstadoActual,
    o.FallaReportada,
    o.Presupuesto,
    o.FechaRecepcion,
    DATEDIFF(DAY, o.FechaRecepcion, GETDATE()) AS DiasEnTaller,
    ISNULL((
        SELECT TOP 1 emp.Nombre + ' ' + emp.Apellidos
        FROM dbo.OrdenTecnico ot
        INNER JOIN dbo.Empleado emp ON ot.IdEmpleado = emp.IdEmpleado
        WHERE ot.IdOrdenServicio = o.IdOrdenServicio AND ot.EsResponsable = 1 AND ot.FechaFin IS NULL
    ), 'Sin asignar') AS TecnicoAsignado
FROM dbo.OrdenServicio o
INNER JOIN dbo.Cliente c ON o.IdCliente = c.IdCliente
INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
INNER JOIN dbo.TipoEquipo te ON eq.IdTipoEquipo = te.IdTipoEquipo
INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden
WHERE eo.EsFinal = 0;
GO

-- Alimenta la pantalla de almacen y compras mostrando existencias con semaforo de alerta de stock.
IF OBJECT_ID('dbo.vw_InventarioStockAlerta', 'V') IS NOT NULL
    DROP VIEW dbo.vw_InventarioStockAlerta;
GO

CREATE VIEW dbo.vw_InventarioStockAlerta
AS
SELECT 
    r.IdRefaccion,
    r.SKU,
    r.Nombre AS Refaccion,
    (SELECT Nombre FROM dbo.CategoriaRefaccion c WHERE c.IdCategoriaRefaccion = r.IdCategoriaRefaccion) AS Categoria,
    r.CostoReferencia,
    r.PrecioVenta,
    ISNULL((SELECT Existencia FROM dbo.Inventario i WHERE i.IdRefaccion = r.IdRefaccion), 0) AS Existencia,
    r.StockMinimo,
    CASE 
        WHEN ISNULL((SELECT Existencia FROM dbo.Inventario i WHERE i.IdRefaccion = r.IdRefaccion), 0) <= 0 THEN 'AGOTADO'
        WHEN ISNULL((SELECT Existencia FROM dbo.Inventario i WHERE i.IdRefaccion = r.IdRefaccion), 0) <= r.StockMinimo THEN 'CRITICO'
        WHEN ISNULL((SELECT Existencia FROM dbo.Inventario i WHERE i.IdRefaccion = r.IdRefaccion), 0) <= (r.StockMinimo + 2) THEN 'BAJO'
        ELSE 'NORMAL'
    END AS EstadoStock,
    (r.PrecioVenta * ISNULL((SELECT Existencia FROM dbo.Inventario i WHERE i.IdRefaccion = r.IdRefaccion), 0)) AS ValorInventario
FROM dbo.Refaccion r
WHERE r.Activo = 1;
GO

-- 2. Vistas relacionales

-- Alimenta el expediente de clientes mostrando datos de contacto, total de equipos, reparaciones y saldo historico.
IF OBJECT_ID('dbo.vw_ExpedienteCliente', 'V') IS NOT NULL
    DROP VIEW dbo.vw_ExpedienteCliente;
GO

CREATE VIEW dbo.vw_ExpedienteCliente
AS
SELECT 
    c.IdCliente,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    c.Telefono,
    c.Correo,
    c.Direccion,
    c.FechaRegistro,
    c.Activo,
    (SELECT COUNT(*) FROM dbo.Equipo eq WHERE eq.IdCliente = c.IdCliente) AS TotalEquiposRegistrados,
    (SELECT COUNT(*) FROM dbo.OrdenServicio o WHERE o.IdCliente = c.IdCliente) AS TotalOrdenesServicio,
    ISNULL((
        SELECT SUM(p.Importe) 
        FROM dbo.Pago p 
        INNER JOIN dbo.OrdenServicio o ON p.IdOrdenServicio = o.IdOrdenServicio 
        WHERE o.IdCliente = c.IdCliente AND p.Estado = 'Aplicado'
    ), 0) AS TotalPagadoHistorico
FROM dbo.Cliente c;
GO

-- Alimenta la pantalla de cobro y emision de recibos desglosando servicios, refacciones usadas y saldo pendiente.
IF OBJECT_ID('dbo.vw_TicketOrdenCompleto', 'V') IS NOT NULL
    DROP VIEW dbo.vw_TicketOrdenCompleto;
GO

CREATE VIEW dbo.vw_TicketOrdenCompleto
AS
SELECT 
    o.IdOrdenServicio,
    o.Folio,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    c.Telefono,
    m.Nombre + ' ' + eq.Modelo AS Dispositivo,
    eq.NumeroSerie,
    eo.Nombre AS EstadoOrden,
    o.FechaRecepcion,
    o.FechaEntrega,
    o.DiagnosticoGeneral,
    ISNULL((
        SELECT SUM(dos.Cantidad * dos.PrecioUnitario) 
        FROM dbo.DetalleOrdenServicio dos 
        WHERE dos.IdOrdenServicio = o.IdOrdenServicio
    ), 0) AS TotalServicios,
    ISNULL((
        SELECT SUM(orf.Cantidad * orf.PrecioUnitario) 
        FROM dbo.OrdenRefaccion orf 
        WHERE orf.IdOrdenServicio = o.IdOrdenServicio
    ), 0) AS TotalRefacciones,
    (
        ISNULL((SELECT SUM(dos.Cantidad * dos.PrecioUnitario) FROM dbo.DetalleOrdenServicio dos WHERE dos.IdOrdenServicio = o.IdOrdenServicio), 0) +
        ISNULL((SELECT SUM(orf.Cantidad * orf.PrecioUnitario) FROM dbo.OrdenRefaccion orf WHERE orf.IdOrdenServicio = o.IdOrdenServicio), 0)
    ) AS TotalCostoCalculado,
    ISNULL((
        SELECT SUM(p.Importe) 
        FROM dbo.Pago p 
        WHERE p.IdOrdenServicio = o.IdOrdenServicio AND p.Estado = 'Aplicado'
    ), 0) AS TotalPagado,
    (
        (
            ISNULL((SELECT SUM(dos.Cantidad * dos.PrecioUnitario) FROM dbo.DetalleOrdenServicio dos WHERE dos.IdOrdenServicio = o.IdOrdenServicio), 0) +
            ISNULL((SELECT SUM(orf.Cantidad * orf.PrecioUnitario) FROM dbo.OrdenRefaccion orf WHERE orf.IdOrdenServicio = o.IdOrdenServicio), 0)
        ) -
        ISNULL((SELECT SUM(p.Importe) FROM dbo.Pago p WHERE p.IdOrdenServicio = o.IdOrdenServicio AND p.Estado = 'Aplicado'), 0)
    ) AS SaldoPendiente
FROM dbo.OrdenServicio o
INNER JOIN dbo.Cliente c ON o.IdCliente = c.IdCliente
INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden;
GO

-- Alimenta la consulta de caja diaria de ventas en mostrador con vendedor, piezas, importe y forma de pago.
IF OBJECT_ID('dbo.vw_VentasMostradorDetalladas', 'V') IS NOT NULL
    DROP VIEW dbo.vw_VentasMostradorDetalladas;
GO

CREATE VIEW dbo.vw_VentasMostradorDetalladas
AS
SELECT 
    v.IdVentaRefaccion,
    v.Folio,
    v.FechaVenta,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    (SELECT u.NombreUsuario FROM dbo.Usuario u WHERE u.IdUsuario = v.IdUsuario) AS Vendedor,
    v.Estado,
    (SELECT COUNT(*) FROM dbo.DetalleVenta dv WHERE dv.IdVentaRefaccion = v.IdVentaRefaccion) AS PartidasVendidas,
    ISNULL((SELECT SUM(dv.Cantidad) FROM dbo.DetalleVenta dv WHERE dv.IdVentaRefaccion = v.IdVentaRefaccion), 0) AS TotalPiezas,
    ISNULL((SELECT SUM(dv.Cantidad * dv.PrecioUnitario) FROM dbo.DetalleVenta dv WHERE dv.IdVentaRefaccion = v.IdVentaRefaccion), 0) AS TotalVenta,
    ISNULL((SELECT TOP 1 p.Importe FROM dbo.Pago p WHERE p.IdVentaRefaccion = v.IdVentaRefaccion AND p.Estado = 'Aplicado'), 0) AS MontoPagado,
    ISNULL((
        SELECT TOP 1 mp.Nombre 
        FROM dbo.Pago p 
        INNER JOIN dbo.MetodoPago mp ON p.IdMetodoPago = mp.IdMetodoPago 
        WHERE p.IdVentaRefaccion = v.IdVentaRefaccion AND p.Estado = 'Aplicado'
    ), 'Pendiente') AS MetodoPago
FROM dbo.VentaRefaccion v
INNER JOIN dbo.Cliente c ON v.IdCliente = c.IdCliente;
GO

-- 3. Vistas analiticas para reportes

-- Alimenta el Reporte Gerencial 1 mostrando ingresos mensuales divididos entre taller y mostrador.
IF OBJECT_ID('dbo.vw_ReporteIngresosMensuales', 'V') IS NOT NULL
    DROP VIEW dbo.vw_ReporteIngresosMensuales;
GO

CREATE VIEW dbo.vw_ReporteIngresosMensuales
AS
SELECT 
    YEAR(FechaPago) AS Anio,
    MONTH(FechaPago) AS MesNumero,
    DATENAME(MONTH, FechaPago) AS MesNombre,
    COUNT(IdPago) AS TotalTransacciones,
    SUM(CASE WHEN IdOrdenServicio IS NOT NULL THEN Importe ELSE 0 END) AS IngresosServiciosTaller,
    SUM(CASE WHEN IdVentaRefaccion IS NOT NULL THEN Importe ELSE 0 END) AS IngresosVentasMostrador,
    SUM(Importe) AS IngresoTotal
FROM dbo.Pago
WHERE Estado = 'Aplicado'
GROUP BY YEAR(FechaPago), MONTH(FechaPago), DATENAME(MONTH, FechaPago);
GO

-- Alimenta el Reporte Gerencial 2 identificando los servicios mas demandados y su recaudacion total.
IF OBJECT_ID('dbo.vw_TopServiciosSolicitados', 'V') IS NOT NULL
    DROP VIEW dbo.vw_TopServiciosSolicitados;
GO

CREATE VIEW dbo.vw_TopServiciosSolicitados
AS
SELECT 
    s.IdServicio,
    s.Nombre AS Servicio,
    (SELECT cs.Nombre FROM dbo.CategoriaServicio cs WHERE cs.IdCategoriaServicio = s.IdCategoriaServicio) AS Categoria,
    s.PrecioBase,
    ISNULL((SELECT COUNT(*) FROM dbo.DetalleOrdenServicio dos WHERE dos.IdServicio = s.IdServicio), 0) AS VecesSolicitado,
    ISNULL((SELECT SUM(dos.Cantidad) FROM dbo.DetalleOrdenServicio dos WHERE dos.IdServicio = s.IdServicio), 0) AS CantidadTotal,
    ISNULL((SELECT SUM(dos.Cantidad * dos.PrecioUnitario) FROM dbo.DetalleOrdenServicio dos WHERE dos.IdServicio = s.IdServicio), 0) AS TotalRecaudado
FROM dbo.Servicio s;
GO

-- Alimenta el Reporte Gerencial 3 midiendo la productividad de los tecnicos en ordenes cerradas y facturacion.
IF OBJECT_ID('dbo.vw_RendimientoTecnicos', 'V') IS NOT NULL
    DROP VIEW dbo.vw_RendimientoTecnicos;
GO

CREATE VIEW dbo.vw_RendimientoTecnicos
AS
SELECT 
    e.IdEmpleado,
    e.Nombre + ' ' + e.Apellidos AS Tecnico,
    e.Puesto,
    (SELECT COUNT(*) FROM dbo.OrdenTecnico ot WHERE ot.IdEmpleado = e.IdEmpleado) AS TotalOrdenesAsignadas,
    (
        SELECT COUNT(*) 
        FROM dbo.OrdenTecnico ot 
        INNER JOIN dbo.OrdenServicio o ON ot.IdOrdenServicio = o.IdOrdenServicio 
        WHERE ot.IdEmpleado = e.IdEmpleado AND o.IdEstadoOrden = 8
    ) AS OrdenesEntregadas,
    (
        SELECT COUNT(*) 
        FROM dbo.OrdenTecnico ot 
        INNER JOIN dbo.OrdenServicio o ON ot.IdOrdenServicio = o.IdOrdenServicio 
        INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden
        WHERE ot.IdEmpleado = e.IdEmpleado AND eo.EsFinal = 0
    ) AS OrdenesEnProceso,
    ISNULL((
        SELECT SUM(o.Presupuesto) 
        FROM dbo.OrdenTecnico ot 
        INNER JOIN dbo.OrdenServicio o ON ot.IdOrdenServicio = o.IdOrdenServicio 
        WHERE ot.IdEmpleado = e.IdEmpleado
    ), 0) AS MontoTotalPresupuestado
FROM dbo.Empleado e
WHERE e.Puesto = 'Tecnico';
GO
