USE ServicioTecnicoBD;
GO

-- 1. Filtros WHERE compuestos
SELECT Folio, IdCliente, IdEquipo, Presupuesto, FechaRecepcion, FechaEntrega
FROM dbo.OrdenServicio
WHERE (IdEstadoOrden = 8 OR IdEstadoOrden = 10) AND Presupuesto > 500.00;
GO

SELECT IdCliente, Nombre + ' ' + Apellidos AS Cliente, Telefono, Correo, FechaRegistro
FROM dbo.Cliente
WHERE Activo = 1 
  AND Correo LIKE '%@gmail.com' 
  AND (FechaRegistro >= '2026-02-01' AND FechaRegistro < '2026-03-01');
GO

SELECT SKU, Nombre, PrecioVenta, StockMinimo, Activo
FROM dbo.Refaccion
WHERE Activo = 1 AND (PrecioVenta >= 1000.00 OR StockMinimo >= 4);
GO

SELECT IdEmpleado, Nombre + ' ' + Apellidos AS Empleado, Puesto, Correo, FechaIngreso
FROM dbo.Empleado
WHERE Activo = 1 
  AND (Puesto = 'Tecnico' OR Puesto = 'Supervisor') 
  AND FechaIngreso < '2026-03-01';
GO

SELECT IdPago, IdOrdenServicio, IdVentaRefaccion, Importe, FechaPago, Referencia
FROM dbo.Pago
WHERE Estado = 'Aplicado' 
  AND (IdMetodoPago = 1 OR IdMetodoPago = 2) 
  AND Importe >= 500.00;
GO

-- 2. Busquedas con LIKE
SELECT Folio, FallaReportada, DiagnosticoGeneral
FROM dbo.OrdenServicio
WHERE FallaReportada LIKE '%calentamiento%' 
   OR FallaReportada LIKE '%pantalla%' 
   OR FallaReportada LIKE '%virus%';
GO

SELECT SKU, Nombre, Descripcion, PrecioVenta
FROM dbo.Refaccion
WHERE Nombre LIKE '%Kingston%' OR Descripcion LIKE '%SSD%';
GO

SELECT IdProveedor, Nombre, Contacto, Telefono, Correo
FROM dbo.Proveedor
WHERE Nombre LIKE '%México%' OR Nombre LIKE '%Tecnológico%';
GO

-- 3. Rangos de fecha
SELECT Folio, FechaRecepcion, FallaReportada, Presupuesto
FROM dbo.OrdenServicio
WHERE FechaRecepcion BETWEEN '2026-02-01 00:00:00' AND '2026-02-28 23:59:59'
ORDER BY FechaRecepcion;
GO

SELECT Folio, FechaVenta, Estado, Observaciones
FROM dbo.VentaRefaccion
WHERE FechaVenta >= '2026-03-01' AND FechaVenta <= '2026-04-30 23:59:59'
ORDER BY FechaVenta DESC;
GO

SELECT IdOrdenServicio, IdEstadoNuevo, FechaCambio, Motivo
FROM dbo.HistorialEstadoOrden
WHERE FechaCambio BETWEEN '2026-02-01' AND '2026-02-15 23:59:59'
ORDER BY FechaCambio;
GO

-- 4. Agrupaciones con GROUP BY
SELECT 
    m.Nombre AS MetodoPago,
    COUNT(p.IdPago) AS CantidadTransacciones,
    SUM(p.Importe) AS TotalRecaudado,
    AVG(p.Importe) AS TicketPromedio
FROM dbo.MetodoPago m
INNER JOIN dbo.Pago p ON m.IdMetodoPago = p.IdMetodoPago
WHERE p.Estado = 'Aplicado'
GROUP BY m.Nombre;
GO

SELECT 
    e.Nombre AS Estado,
    COUNT(o.IdOrdenServicio) AS TotalOrdenes,
    ISNULL(SUM(o.Presupuesto), 0) AS PresupuestoTotal
FROM dbo.EstadoOrden e
LEFT JOIN dbo.OrdenServicio o ON e.IdEstadoOrden = o.IdEstadoOrden
GROUP BY e.Nombre, e.IdEstadoOrden
ORDER BY TotalOrdenes DESC;
GO

SELECT 
    c.Nombre AS Categoria,
    COUNT(r.IdRefaccion) AS TotalItems,
    SUM(i.Existencia) AS PiezasEnStock,
    SUM(r.PrecioVenta * i.Existencia) AS ValorVentaTotal
FROM dbo.CategoriaRefaccion c
INNER JOIN dbo.Refaccion r ON c.IdCategoriaRefaccion = r.IdCategoriaRefaccion
INNER JOIN dbo.Inventario i ON r.IdRefaccion = i.IdRefaccion
GROUP BY c.Nombre;
GO

SELECT 
    c.Nombre AS CategoriaServicio,
    COUNT(d.IdDetalleOrdenServicio) AS ServiciosRealizados,
    SUM(d.PrecioUnitario * d.Cantidad) AS FacturacionServicios
FROM dbo.CategoriaServicio c
INNER JOIN dbo.Servicio s ON c.IdCategoriaServicio = s.IdCategoriaServicio
INNER JOIN dbo.DetalleOrdenServicio d ON s.IdServicio = d.IdServicio
GROUP BY c.Nombre;
GO

-- 5. Filtros con HAVING
SELECT 
    c.IdCliente,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    COUNT(o.IdOrdenServicio) AS TotalOrdenes,
    SUM(o.Presupuesto) AS GastoTotalPresupuestado
FROM dbo.Cliente c
INNER JOIN dbo.OrdenServicio o ON c.IdCliente = o.IdCliente
GROUP BY c.IdCliente, c.Nombre, c.Apellidos
HAVING COUNT(o.IdOrdenServicio) > 1;
GO

SELECT 
    m.Nombre AS MetodoPago,
    COUNT(p.IdPago) AS PagosRealizados,
    SUM(p.Importe) AS MontoTotal
FROM dbo.MetodoPago m
INNER JOIN dbo.Pago p ON m.IdMetodoPago = p.IdMetodoPago
WHERE p.Estado = 'Aplicado'
GROUP BY m.Nombre
HAVING SUM(p.Importe) > 1500.00;
GO

-- 6. Funciones de fecha, texto y conversion
SELECT 
    Folio,
    CONVERT(VARCHAR(10), FechaRecepcion, 103) AS FechaRecepcionFormat,
    CONVERT(VARCHAR(10), FechaEntrega, 103) AS FechaEntregaFormat,
    DATEDIFF(DAY, FechaRecepcion, FechaEntrega) AS DiasEnTaller
FROM dbo.OrdenServicio
WHERE FechaEntrega IS NOT NULL;
GO

SELECT 
    UPPER(Nombre + ' ' + Apellidos) AS EmpleadoMayusculas,
    Puesto,
    DATEDIFF(DAY, FechaIngreso, GETDATE()) AS DiasEnEmpresa,
    LEN(Correo) AS LongitudCorreo
FROM dbo.Empleado;
GO

SELECT 
    Folio,
    YEAR(FechaVenta) AS AnioVenta,
    DATENAME(MONTH, FechaVenta) AS MesVenta,
    FORMAT(FechaVenta, 'dd/MM/yyyy HH:mm') AS FechaFormateada
FROM dbo.VentaRefaccion;
GO

SELECT 
    Nombre,
    Telefono,
    '***-***-' + SUBSTRING(Telefono, 7, 4) AS TelefonoProtegido,
    REPLACE(Correo, '@gmail.com', ' [CORREO GMAIL]') AS CorreoEtiquetado
FROM dbo.Cliente
WHERE Telefono IS NOT NULL;
GO

-- 7. Consultas INNER JOIN
SELECT 
    o.Folio,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    m.Nombre + ' ' + eq.Modelo AS Dispositivo,
    e.Nombre AS EstadoOrden,
    o.Presupuesto
FROM dbo.OrdenServicio o
INNER JOIN dbo.Cliente c ON o.IdCliente = c.IdCliente
INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
INNER JOIN dbo.EstadoOrden e ON o.IdEstadoOrden = e.IdEstadoOrden;
GO

SELECT 
    u.NombreUsuario,
    emp.Nombre + ' ' + emp.Apellidos AS Empleado,
    emp.Puesto,
    r.Nombre AS Rol
FROM dbo.Usuario u
INNER JOIN dbo.Empleado emp ON u.IdEmpleado = emp.IdEmpleado
INNER JOIN dbo.UsuarioRol ur ON u.IdUsuario = ur.IdUsuario
INNER JOIN dbo.Rol r ON ur.IdRol = r.IdRol;
GO

SELECT 
    v.Folio AS FolioVenta,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    r.Nombre AS Refaccion,
    dv.Cantidad,
    dv.PrecioUnitario,
    (dv.Cantidad * dv.PrecioUnitario) AS Subtotal
FROM dbo.VentaRefaccion v
INNER JOIN dbo.Cliente c ON v.IdCliente = c.IdCliente
INNER JOIN dbo.DetalleVenta dv ON v.IdVentaRefaccion = dv.IdVentaRefaccion
INNER JOIN dbo.Refaccion r ON dv.IdRefaccion = r.IdRefaccion;
GO

SELECT 
    com.Folio,
    p.Nombre AS Proveedor,
    r.SKU,
    r.Nombre AS Refaccion,
    dc.Cantidad,
    dc.CostoUnitario,
    (dc.Cantidad * dc.CostoUnitario) AS TotalCompra
FROM dbo.Compra com
INNER JOIN dbo.Proveedor p ON com.IdProveedor = p.IdProveedor
INNER JOIN dbo.DetalleCompra dc ON com.IdCompra = dc.IdCompra
INNER JOIN dbo.Refaccion r ON dc.IdRefaccion = r.IdRefaccion;
GO

SELECT 
    r.SKU,
    r.Nombre AS Refaccion,
    p.Nombre AS Proveedor,
    rp.CodigoProveedor,
    rp.UltimoCosto
FROM dbo.Refaccion r
INNER JOIN dbo.RefaccionProveedor rp ON r.IdRefaccion = rp.IdRefaccion
INNER JOIN dbo.Proveedor p ON rp.IdProveedor = p.IdProveedor;
GO

-- 8. Consultas LEFT JOIN
SELECT 
    c.IdCliente,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    c.Telefono,
    c.Correo,
    o.Folio AS OrdenAsociada
FROM dbo.Cliente c
LEFT JOIN dbo.OrdenServicio o ON c.IdCliente = o.IdCliente
WHERE o.IdOrdenServicio IS NULL;
GO

SELECT 
    eq.IdEquipo,
    m.Nombre AS Marca,
    eq.Modelo,
    eq.NumeroSerie,
    c.Nombre + ' ' + c.Apellidos AS Propietario
FROM dbo.Equipo eq
INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
INNER JOIN dbo.Cliente c ON eq.IdCliente = c.IdCliente
LEFT JOIN dbo.OrdenServicio o ON eq.IdEquipo = o.IdEquipo
WHERE o.IdOrdenServicio IS NULL;
GO

-- 9. Consultas con 5 o mas tablas
SELECT 
    o.Folio,
    c.Nombre + ' ' + c.Apellidos AS Cliente,
    te.Nombre AS CategoriaDispositivo,
    m.Nombre AS Marca,
    eq.Modelo,
    eo.Nombre AS EstadoActual,
    emp.Nombre + ' ' + emp.Apellidos AS Recepcionista,
    o.Presupuesto
FROM dbo.OrdenServicio o
INNER JOIN dbo.Cliente c ON o.IdCliente = c.IdCliente
INNER JOIN dbo.Equipo eq ON o.IdEquipo = eq.IdEquipo
INNER JOIN dbo.TipoEquipo te ON eq.IdTipoEquipo = te.IdTipoEquipo
INNER JOIN dbo.Marca m ON eq.IdMarca = m.IdMarca
INNER JOIN dbo.EstadoOrden eo ON o.IdEstadoOrden = eo.IdEstadoOrden
LEFT JOIN dbo.Usuario u ON o.IdUsuarioRecepcion = u.IdUsuario
LEFT JOIN dbo.Empleado emp ON u.IdEmpleado = emp.IdEmpleado;
GO

SELECT 
    p.IdPago,
    o.Folio AS FolioOrden,
    mp.Nombre AS MetodoPago,
    p.Importe,
    s.Nombre AS ServicioRealizado,
    cs.Nombre AS CategoriaServicio
FROM dbo.Pago p
INNER JOIN dbo.OrdenServicio o ON p.IdOrdenServicio = o.IdOrdenServicio
INNER JOIN dbo.MetodoPago mp ON p.IdMetodoPago = mp.IdMetodoPago
INNER JOIN dbo.DetalleOrdenServicio dos ON o.IdOrdenServicio = dos.IdOrdenServicio
INNER JOIN dbo.Servicio s ON dos.IdServicio = s.IdServicio
INNER JOIN dbo.CategoriaServicio cs ON s.IdCategoriaServicio = cs.IdCategoriaServicio;
GO

-- 10. Subconsultas
SELECT SKU, Nombre, PrecioVenta
FROM dbo.Refaccion
WHERE PrecioVenta > (SELECT AVG(PrecioVenta) FROM dbo.Refaccion);
GO

SELECT c.IdCliente, c.Nombre + ' ' + c.Apellidos AS Cliente
FROM dbo.Cliente c
WHERE EXISTS (
    SELECT 1 
    FROM dbo.OrdenServicio o 
    WHERE o.IdCliente = c.IdCliente AND o.IdEstadoOrden = 8
);
GO

-- 11. Operadores SET
SELECT Nombre + ' ' + Apellidos AS Persona, Telefono, 'Cliente' AS Tipo
FROM dbo.Cliente
WHERE Telefono IS NOT NULL
UNION
SELECT Nombre + ' ' + Apellidos AS Persona, Telefono, 'Empleado' AS Tipo
FROM dbo.Empleado
WHERE Telefono IS NOT NULL;
GO

SELECT IdCliente FROM dbo.OrdenServicio
EXCEPT
SELECT IdCliente FROM dbo.VentaRefaccion;
GO

SELECT IdCliente FROM dbo.OrdenServicio
INTERSECT
SELECT IdCliente FROM dbo.VentaRefaccion;
GO
