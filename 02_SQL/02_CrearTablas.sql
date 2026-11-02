USE ServicioTecnicoBD;
GO

-- Crear las tablas en orden para respetar sus dependencias y relaciones.
SET XACT_ABORT ON;
GO

-- 1-6. CATÁLOGOS
CREATE TABLE dbo.TipoEquipo (
 IdTipoEquipo INT IDENTITY(1,1) CONSTRAINT PK_TipoEquipo PRIMARY KEY,
 Nombre NVARCHAR(80) NOT NULL CONSTRAINT UQ_TipoEquipo_Nombre UNIQUE,
 Descripcion NVARCHAR(250) NULL,
 Activo BIT NOT NULL CONSTRAINT DF_TipoEquipo_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.Marca (
 IdMarca INT IDENTITY(1,1) CONSTRAINT PK_Marca PRIMARY KEY,
 Nombre NVARCHAR(100) NOT NULL CONSTRAINT UQ_Marca_Nombre UNIQUE,
 Activo BIT NOT NULL CONSTRAINT DF_Marca_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.EstadoOrden (
 IdEstadoOrden INT IDENTITY(1,1) CONSTRAINT PK_EstadoOrden PRIMARY KEY,
 Nombre NVARCHAR(80) NOT NULL CONSTRAINT UQ_EstadoOrden_Nombre UNIQUE,
 EsFinal BIT NOT NULL CONSTRAINT DF_EstadoOrden_EsFinal DEFAULT (0),
 Activo BIT NOT NULL CONSTRAINT DF_EstadoOrden_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.CategoriaServicio (
 IdCategoriaServicio INT IDENTITY(1,1) CONSTRAINT PK_CategoriaServicio PRIMARY KEY,
 Nombre NVARCHAR(100) NOT NULL CONSTRAINT UQ_CategoriaServicio_Nombre UNIQUE,
 Activo BIT NOT NULL CONSTRAINT DF_CategoriaServicio_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.MetodoPago (
 IdMetodoPago INT IDENTITY(1,1) CONSTRAINT PK_MetodoPago PRIMARY KEY,
 Nombre NVARCHAR(70) NOT NULL CONSTRAINT UQ_MetodoPago_Nombre UNIQUE,
 Activo BIT NOT NULL CONSTRAINT DF_MetodoPago_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.CategoriaRefaccion (
 IdCategoriaRefaccion INT IDENTITY(1,1) CONSTRAINT PK_CategoriaRefaccion PRIMARY KEY,
 Nombre NVARCHAR(100) NOT NULL CONSTRAINT UQ_CategoriaRefaccion_Nombre UNIQUE,
 Activo BIT NOT NULL CONSTRAINT DF_CategoriaRefaccion_Activo DEFAULT (1)
);
GO

-- 7-14. ENTIDADES PRINCIPALES
CREATE TABLE dbo.Cliente (
 IdCliente INT IDENTITY(1,1) CONSTRAINT PK_Cliente PRIMARY KEY,
 Nombre NVARCHAR(120) NOT NULL,
 Apellidos NVARCHAR(150) NULL,
 Telefono NVARCHAR(25) NULL,
 Correo NVARCHAR(254) NULL,
 Direccion NVARCHAR(300) NULL,
 FechaRegistro DATETIME2(0) NOT NULL CONSTRAINT DF_Cliente_FechaRegistro DEFAULT (SYSDATETIME()),
 Activo BIT NOT NULL CONSTRAINT DF_Cliente_Activo DEFAULT (1),
 CONSTRAINT CK_Cliente_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
);
GO
CREATE UNIQUE INDEX UX_Cliente_Correo ON dbo.Cliente(Correo) WHERE Correo IS NOT NULL;
GO
CREATE TABLE dbo.Empleado (
 IdEmpleado INT IDENTITY(1,1) CONSTRAINT PK_Empleado PRIMARY KEY,
 Nombre NVARCHAR(120) NOT NULL,
 Apellidos NVARCHAR(150) NOT NULL,
 Puesto NVARCHAR(25) NOT NULL,
 Telefono NVARCHAR(25) NULL,
 Correo NVARCHAR(254) NULL,
 FechaIngreso DATE NOT NULL CONSTRAINT DF_Empleado_FechaIngreso DEFAULT (CONVERT(DATE, GETDATE())),
 Activo BIT NOT NULL CONSTRAINT DF_Empleado_Activo DEFAULT (1),
 CONSTRAINT CK_Empleado_Puesto CHECK (Puesto IN (N'Tecnico', N'Recepcionista', N'Supervisor', N'Administrador', N'Auditor'))
);
GO
CREATE UNIQUE INDEX UX_Empleado_Correo ON dbo.Empleado(Correo) WHERE Correo IS NOT NULL;
GO
CREATE TABLE dbo.Proveedor (
 IdProveedor INT IDENTITY(1,1) CONSTRAINT PK_Proveedor PRIMARY KEY,
 Nombre NVARCHAR(180) NOT NULL,
 RFC NVARCHAR(13) NULL,
 Contacto NVARCHAR(120) NULL,
 Telefono NVARCHAR(25) NULL,
 Correo NVARCHAR(254) NULL,
 Direccion NVARCHAR(300) NULL,
 Activo BIT NOT NULL CONSTRAINT DF_Proveedor_Activo DEFAULT (1)
);
GO
CREATE UNIQUE INDEX UX_Proveedor_RFC ON dbo.Proveedor(RFC) WHERE RFC IS NOT NULL;
GO
CREATE TABLE dbo.Rol (
 IdRol INT IDENTITY(1,1) CONSTRAINT PK_Rol PRIMARY KEY,
 Nombre NVARCHAR(70) NOT NULL CONSTRAINT UQ_Rol_Nombre UNIQUE,
 Descripcion NVARCHAR(250) NULL,
 Activo BIT NOT NULL CONSTRAINT DF_Rol_Activo DEFAULT (1)
);
GO
CREATE TABLE dbo.Usuario (
 IdUsuario INT IDENTITY(1,1) CONSTRAINT PK_Usuario PRIMARY KEY,
 IdEmpleado INT NOT NULL,
 NombreUsuario NVARCHAR(80) NOT NULL CONSTRAINT UQ_Usuario_NombreUsuario UNIQUE,
 HashContrasena VARBINARY(256) NOT NULL,
 SaltContrasena VARBINARY(64) NULL,
 FechaAlta DATETIME2(0) NOT NULL CONSTRAINT DF_Usuario_FechaAlta DEFAULT (SYSDATETIME()),
 UltimoAcceso DATETIME2(0) NULL,
 Activo BIT NOT NULL CONSTRAINT DF_Usuario_Activo DEFAULT (1),
 CONSTRAINT FK_Usuario_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleado(IdEmpleado),
 CONSTRAINT UQ_Usuario_Empleado UNIQUE (IdEmpleado)
);
GO
CREATE TABLE dbo.Equipo (
 IdEquipo INT IDENTITY(1,1) CONSTRAINT PK_Equipo PRIMARY KEY,
 IdCliente INT NOT NULL,
 IdTipoEquipo INT NOT NULL,
 IdMarca INT NOT NULL,
 Modelo NVARCHAR(130) NOT NULL,
 NumeroSerie NVARCHAR(120) NULL,
 Caracteristicas NVARCHAR(500) NULL,
 FechaRegistro DATETIME2(0) NOT NULL CONSTRAINT DF_Equipo_FechaRegistro DEFAULT (SYSDATETIME()),
 Activo BIT NOT NULL CONSTRAINT DF_Equipo_Activo DEFAULT (1),
 CONSTRAINT FK_Equipo_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IdCliente),
 CONSTRAINT FK_Equipo_TipoEquipo FOREIGN KEY (IdTipoEquipo) REFERENCES dbo.TipoEquipo(IdTipoEquipo),
 CONSTRAINT FK_Equipo_Marca FOREIGN KEY (IdMarca) REFERENCES dbo.Marca(IdMarca),
 CONSTRAINT UQ_Equipo_IdCliente UNIQUE (IdEquipo, IdCliente)
);
GO
CREATE TABLE dbo.Servicio (
 IdServicio INT IDENTITY(1,1) CONSTRAINT PK_Servicio PRIMARY KEY,
 IdCategoriaServicio INT NOT NULL,
 Nombre NVARCHAR(160) NOT NULL,
 Descripcion NVARCHAR(400) NULL,
 PrecioBase DECIMAL(12,2) NOT NULL CONSTRAINT DF_Servicio_PrecioBase DEFAULT (0),
 Activo BIT NOT NULL CONSTRAINT DF_Servicio_Activo DEFAULT (1),
 CONSTRAINT FK_Servicio_CategoriaServicio FOREIGN KEY (IdCategoriaServicio) REFERENCES dbo.CategoriaServicio(IdCategoriaServicio),
 CONSTRAINT CK_Servicio_PrecioBase CHECK (PrecioBase >= 0),
 CONSTRAINT UQ_Servicio_CategoriaNombre UNIQUE (IdCategoriaServicio, Nombre)
);
GO
CREATE TABLE dbo.Refaccion (
 IdRefaccion INT IDENTITY(1,1) CONSTRAINT PK_Refaccion PRIMARY KEY,
 IdCategoriaRefaccion INT NOT NULL,
 SKU NVARCHAR(60) NOT NULL CONSTRAINT UQ_Refaccion_SKU UNIQUE,
 Nombre NVARCHAR(160) NOT NULL,
 Descripcion NVARCHAR(500) NULL,
 CostoReferencia DECIMAL(12,2) NOT NULL CONSTRAINT DF_Refaccion_Costo DEFAULT (0),
 PrecioVenta DECIMAL(12,2) NOT NULL CONSTRAINT DF_Refaccion_Precio DEFAULT (0),
 StockMinimo INT NOT NULL CONSTRAINT DF_Refaccion_StockMinimo DEFAULT (0),
 Activo BIT NOT NULL CONSTRAINT DF_Refaccion_Activo DEFAULT (1),
 CONSTRAINT FK_Refaccion_CategoriaRefaccion FOREIGN KEY (IdCategoriaRefaccion) REFERENCES dbo.CategoriaRefaccion(IdCategoriaRefaccion),
 CONSTRAINT CK_Refaccion_Costos CHECK (CostoReferencia >= 0 AND PrecioVenta >= 0),
 CONSTRAINT CK_Refaccion_StockMinimo CHECK (StockMinimo >= 0)
);
GO

-- 15-20. PROCESOS MAESTRO-DETALLE
CREATE TABLE dbo.OrdenServicio (
 IdOrdenServicio INT IDENTITY(1,1) CONSTRAINT PK_OrdenServicio PRIMARY KEY,
 Folio NVARCHAR(40) NOT NULL CONSTRAINT UQ_OrdenServicio_Folio UNIQUE,
 IdCliente INT NOT NULL,
 IdEquipo INT NOT NULL,
 IdEstadoOrden INT NOT NULL,
 IdUsuarioRecepcion INT NULL,
 FechaRecepcion DATETIME2(0) NOT NULL CONSTRAINT DF_Orden_FechaRecepcion DEFAULT (SYSDATETIME()),
 FechaPrometida DATETIME2(0) NULL,
 FechaEntrega DATETIME2(0) NULL,
 FallaReportada NVARCHAR(1000) NOT NULL,
 Observaciones NVARCHAR(1000) NULL,
 Presupuesto DECIMAL(12,2) NULL,
 PresupuestoAutorizado BIT NULL,
 FechaAutorizacion DATETIME2(0) NULL,
 DiagnosticoGeneral NVARCHAR(1000) NULL,
 CONSTRAINT FK_Orden_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IdCliente),
 CONSTRAINT FK_Orden_EquipoCliente FOREIGN KEY (IdEquipo,IdCliente) REFERENCES dbo.Equipo(IdEquipo,IdCliente),
 CONSTRAINT FK_Orden_Estado FOREIGN KEY (IdEstadoOrden) REFERENCES dbo.EstadoOrden(IdEstadoOrden),
 CONSTRAINT FK_Orden_UsuarioRecepcion FOREIGN KEY (IdUsuarioRecepcion) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_Orden_Presupuesto CHECK (Presupuesto IS NULL OR Presupuesto >= 0),
 CONSTRAINT CK_Orden_Fechas CHECK ((FechaEntrega IS NULL OR FechaEntrega >= FechaRecepcion) AND (FechaPrometida IS NULL OR FechaPrometida >= FechaRecepcion)),
 CONSTRAINT CK_Orden_Autorizacion CHECK (FechaAutorizacion IS NULL OR PresupuestoAutorizado = 1)
);
GO
CREATE TABLE dbo.DetalleOrdenServicio (
 IdDetalleOrdenServicio INT IDENTITY(1,1) CONSTRAINT PK_DetalleOrdenServicio PRIMARY KEY,
 IdOrdenServicio INT NOT NULL,
 IdServicio INT NOT NULL,
 DescripcionTrabajo NVARCHAR(600) NULL,
 Cantidad INT NOT NULL CONSTRAINT DF_DetalleOrden_Cantidad DEFAULT (1),
 PrecioUnitario DECIMAL(12,2) NOT NULL,
 EstadoActividad NVARCHAR(20) NOT NULL CONSTRAINT DF_DetalleOrden_Estado DEFAULT (N'Pendiente'),
 Obligatoria BIT NOT NULL CONSTRAINT DF_DetalleOrden_Obligatoria DEFAULT (1),
 FechaFinalizacion DATETIME2(0) NULL,
 CONSTRAINT FK_DetalleOrden_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_DetalleOrden_Servicio FOREIGN KEY (IdServicio) REFERENCES dbo.Servicio(IdServicio),
 CONSTRAINT CK_DetalleOrden_Cantidad CHECK (Cantidad > 0),
 CONSTRAINT CK_DetalleOrden_Precio CHECK (PrecioUnitario >= 0),
 CONSTRAINT CK_DetalleOrden_Estado CHECK (EstadoActividad IN (N'Pendiente', N'EnProceso', N'Completada', N'Cancelada'))
);
GO
CREATE TABLE dbo.Compra (
 IdCompra INT IDENTITY(1,1) CONSTRAINT PK_Compra PRIMARY KEY,
 Folio NVARCHAR(40) NOT NULL CONSTRAINT UQ_Compra_Folio UNIQUE,
 IdProveedor INT NOT NULL,
 IdUsuario INT NULL,
 FechaCompra DATETIME2(0) NOT NULL CONSTRAINT DF_Compra_Fecha DEFAULT (SYSDATETIME()),
 Estado NVARCHAR(20) NOT NULL CONSTRAINT DF_Compra_Estado DEFAULT (N'Borrador'),
 Observaciones NVARCHAR(500) NULL,
 CONSTRAINT FK_Compra_Proveedor FOREIGN KEY (IdProveedor) REFERENCES dbo.Proveedor(IdProveedor),
 CONSTRAINT FK_Compra_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_Compra_Estado CHECK (Estado IN (N'Borrador', N'Confirmada', N'Cancelada'))
);
GO
CREATE TABLE dbo.DetalleCompra (
 IdDetalleCompra INT IDENTITY(1,1) CONSTRAINT PK_DetalleCompra PRIMARY KEY,
 IdCompra INT NOT NULL,
 IdRefaccion INT NOT NULL,
 Cantidad INT NOT NULL,
 CostoUnitario DECIMAL(12,2) NOT NULL,
 CONSTRAINT FK_DetalleCompra_Compra FOREIGN KEY (IdCompra) REFERENCES dbo.Compra(IdCompra),
 CONSTRAINT FK_DetalleCompra_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT CK_DetalleCompra_Cantidad CHECK (Cantidad > 0),
 CONSTRAINT CK_DetalleCompra_Costo CHECK (CostoUnitario >= 0)
);
GO
CREATE TABLE dbo.VentaRefaccion (
 IdVentaRefaccion INT IDENTITY(1,1) CONSTRAINT PK_VentaRefaccion PRIMARY KEY,
 Folio NVARCHAR(40) NOT NULL CONSTRAINT UQ_Venta_Folio UNIQUE,
 IdCliente INT NOT NULL,
 IdUsuario INT NULL,
 FechaVenta DATETIME2(0) NOT NULL CONSTRAINT DF_Venta_Fecha DEFAULT (SYSDATETIME()),
 Estado NVARCHAR(20) NOT NULL CONSTRAINT DF_Venta_Estado DEFAULT (N'Borrador'),
 Observaciones NVARCHAR(500) NULL,
 CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IdCliente),
 CONSTRAINT FK_Venta_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_Venta_Estado CHECK (Estado IN (N'Borrador', N'Confirmada', N'Cancelada'))
);
GO
CREATE TABLE dbo.DetalleVenta (
 IdDetalleVenta INT IDENTITY(1,1) CONSTRAINT PK_DetalleVenta PRIMARY KEY,
 IdVentaRefaccion INT NOT NULL,
 IdRefaccion INT NOT NULL,
 Cantidad INT NOT NULL,
 PrecioUnitario DECIMAL(12,2) NOT NULL,
 CONSTRAINT FK_DetalleVenta_Venta FOREIGN KEY (IdVentaRefaccion) REFERENCES dbo.VentaRefaccion(IdVentaRefaccion),
 CONSTRAINT FK_DetalleVenta_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
 CONSTRAINT CK_DetalleVenta_Precio CHECK (PrecioUnitario >= 0)
);
GO

-- 21-24. RELACIONES N:M
CREATE TABLE dbo.OrdenTecnico (
 IdOrdenTecnico INT IDENTITY(1,1) CONSTRAINT PK_OrdenTecnico PRIMARY KEY,
 IdOrdenServicio INT NOT NULL,
 IdEmpleado INT NOT NULL,
 FechaAsignacion DATETIME2(0) NOT NULL CONSTRAINT DF_OrdenTecnico_Fecha DEFAULT (SYSDATETIME()),
 FechaFin DATETIME2(0) NULL,
 EsResponsable BIT NOT NULL CONSTRAINT DF_OrdenTecnico_Responsable DEFAULT (0),
 CONSTRAINT FK_OrdenTecnico_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_OrdenTecnico_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleado(IdEmpleado),
 CONSTRAINT UQ_OrdenTecnico_Asignacion UNIQUE (IdOrdenServicio, IdEmpleado, FechaAsignacion),
 CONSTRAINT CK_OrdenTecnico_Fechas CHECK (FechaFin IS NULL OR FechaFin >= FechaAsignacion)
);
GO
CREATE UNIQUE INDEX UX_OrdenTecnico_Activo ON dbo.OrdenTecnico(IdOrdenServicio,IdEmpleado) WHERE FechaFin IS NULL;
GO
CREATE TABLE dbo.RefaccionProveedor (
 IdRefaccionProveedor INT IDENTITY(1,1) CONSTRAINT PK_RefaccionProveedor PRIMARY KEY,
 IdRefaccion INT NOT NULL,
 IdProveedor INT NOT NULL,
 CodigoProveedor NVARCHAR(80) NULL,
 UltimoCosto DECIMAL(12,2) NULL,
 Activo BIT NOT NULL CONSTRAINT DF_RefaccionProveedor_Activo DEFAULT (1),
 CONSTRAINT FK_RefaccionProveedor_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT FK_RefaccionProveedor_Proveedor FOREIGN KEY (IdProveedor) REFERENCES dbo.Proveedor(IdProveedor),
 CONSTRAINT UQ_RefaccionProveedor_Par UNIQUE (IdRefaccion,IdProveedor),
 CONSTRAINT CK_RefaccionProveedor_Costo CHECK (UltimoCosto IS NULL OR UltimoCosto >= 0)
);
GO
CREATE TABLE dbo.UsuarioRol (
 IdUsuarioRol INT IDENTITY(1,1) CONSTRAINT PK_UsuarioRol PRIMARY KEY,
 IdUsuario INT NOT NULL,
 IdRol INT NOT NULL,
 FechaAsignacion DATETIME2(0) NOT NULL CONSTRAINT DF_UsuarioRol_Fecha DEFAULT (SYSDATETIME()),
 CONSTRAINT FK_UsuarioRol_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT FK_UsuarioRol_Rol FOREIGN KEY (IdRol) REFERENCES dbo.Rol(IdRol),
 CONSTRAINT UQ_UsuarioRol_Par UNIQUE (IdUsuario,IdRol)
);
GO
CREATE TABLE dbo.OrdenRefaccion (
 IdOrdenRefaccion INT IDENTITY(1,1) CONSTRAINT PK_OrdenRefaccion PRIMARY KEY,
 IdOrdenServicio INT NOT NULL,
 IdRefaccion INT NOT NULL,
 Cantidad INT NOT NULL,
 PrecioUnitario DECIMAL(12,2) NOT NULL,
 FechaConsumo DATETIME2(0) NOT NULL CONSTRAINT DF_OrdenRefaccion_Fecha DEFAULT (SYSDATETIME()),
 CONSTRAINT FK_OrdenRefaccion_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_OrdenRefaccion_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT CK_OrdenRefaccion_Cantidad CHECK (Cantidad > 0),
 CONSTRAINT CK_OrdenRefaccion_Precio CHECK (PrecioUnitario >= 0)
);
GO

-- 25-30. CONTROL, HISTORIAL Y SOPORTE
CREATE TABLE dbo.Pago (
 IdPago INT IDENTITY(1,1) CONSTRAINT PK_Pago PRIMARY KEY,
 IdOrdenServicio INT NULL,
 IdVentaRefaccion INT NULL,
 IdMetodoPago INT NOT NULL,
 IdUsuario INT NULL,
 Importe DECIMAL(12,2) NOT NULL,
 FechaPago DATETIME2(0) NOT NULL CONSTRAINT DF_Pago_Fecha DEFAULT (SYSDATETIME()),
 Referencia NVARCHAR(120) NULL,
 Estado NVARCHAR(20) NOT NULL CONSTRAINT DF_Pago_Estado DEFAULT (N'Aplicado'),
 CONSTRAINT FK_Pago_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_Pago_Venta FOREIGN KEY (IdVentaRefaccion) REFERENCES dbo.VentaRefaccion(IdVentaRefaccion),
 CONSTRAINT FK_Pago_Metodo FOREIGN KEY (IdMetodoPago) REFERENCES dbo.MetodoPago(IdMetodoPago),
 CONSTRAINT FK_Pago_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_Pago_Destino CHECK ((IdOrdenServicio IS NOT NULL AND IdVentaRefaccion IS NULL) OR (IdOrdenServicio IS NULL AND IdVentaRefaccion IS NOT NULL)),
 CONSTRAINT CK_Pago_Importe CHECK (Importe > 0),
 CONSTRAINT CK_Pago_Estado CHECK (Estado IN (N'Aplicado', N'Anulado'))
);
GO
CREATE TABLE dbo.Inventario (
 IdInventario INT IDENTITY(1,1) CONSTRAINT PK_Inventario PRIMARY KEY,
 IdRefaccion INT NOT NULL CONSTRAINT UQ_Inventario_Refaccion UNIQUE,
 Existencia INT NOT NULL CONSTRAINT DF_Inventario_Existencia DEFAULT (0),
 FechaActualizacion DATETIME2(0) NOT NULL CONSTRAINT DF_Inventario_Fecha DEFAULT (SYSDATETIME()),
 CONSTRAINT FK_Inventario_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT CK_Inventario_Existencia CHECK (Existencia >= 0)
);
GO
CREATE TABLE dbo.MovimientoInventario (
 IdMovimientoInventario BIGINT IDENTITY(1,1) CONSTRAINT PK_MovimientoInventario PRIMARY KEY,
 IdRefaccion INT NOT NULL,
 IdCompra INT NULL,
 IdVentaRefaccion INT NULL,
 IdOrdenServicio INT NULL,
 IdUsuario INT NULL,
 TipoMovimiento NVARCHAR(10) NOT NULL,
 Cantidad INT NOT NULL,
 Motivo NVARCHAR(300) NOT NULL,
 FechaMovimiento DATETIME2(0) NOT NULL CONSTRAINT DF_MovInventario_Fecha DEFAULT (SYSDATETIME()),
 CONSTRAINT FK_MovInv_Refaccion FOREIGN KEY (IdRefaccion) REFERENCES dbo.Refaccion(IdRefaccion),
 CONSTRAINT FK_MovInv_Compra FOREIGN KEY (IdCompra) REFERENCES dbo.Compra(IdCompra),
 CONSTRAINT FK_MovInv_Venta FOREIGN KEY (IdVentaRefaccion) REFERENCES dbo.VentaRefaccion(IdVentaRefaccion),
 CONSTRAINT FK_MovInv_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_MovInv_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_MovInv_Tipo CHECK (TipoMovimiento IN (N'Entrada', N'Salida', N'Ajuste')),
 CONSTRAINT CK_MovInv_Cantidad CHECK (Cantidad <> 0),
 CONSTRAINT CK_MovInv_Signo CHECK ((TipoMovimiento = N'Entrada' AND Cantidad > 0) OR (TipoMovimiento = N'Salida' AND Cantidad < 0) OR (TipoMovimiento = N'Ajuste')),
 CONSTRAINT CK_MovInv_Origen CHECK ((CASE WHEN IdCompra IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN IdVentaRefaccion IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN IdOrdenServicio IS NOT NULL THEN 1 ELSE 0 END) <= 1)
);
GO
CREATE TABLE dbo.HistorialEstadoOrden (
 IdHistorialEstadoOrden BIGINT IDENTITY(1,1) CONSTRAINT PK_HistorialEstadoOrden PRIMARY KEY,
 IdOrdenServicio INT NOT NULL,
 IdEstadoAnterior INT NULL,
 IdEstadoNuevo INT NOT NULL,
 IdUsuario INT NULL,
 FechaCambio DATETIME2(0) NOT NULL CONSTRAINT DF_HistEstado_Fecha DEFAULT (SYSDATETIME()),
 Motivo NVARCHAR(400) NULL,
 CONSTRAINT FK_HistEstado_Orden FOREIGN KEY (IdOrdenServicio) REFERENCES dbo.OrdenServicio(IdOrdenServicio),
 CONSTRAINT FK_HistEstado_Anterior FOREIGN KEY (IdEstadoAnterior) REFERENCES dbo.EstadoOrden(IdEstadoOrden),
 CONSTRAINT FK_HistEstado_Nuevo FOREIGN KEY (IdEstadoNuevo) REFERENCES dbo.EstadoOrden(IdEstadoOrden),
 CONSTRAINT FK_HistEstado_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_HistEstado_Diferente CHECK (IdEstadoAnterior IS NULL OR IdEstadoAnterior <> IdEstadoNuevo)
);
GO
CREATE TABLE dbo.Auditoria (
 IdAuditoria BIGINT IDENTITY(1,1) CONSTRAINT PK_Auditoria PRIMARY KEY,
 IdUsuario INT NULL,
 TablaAfectada NVARCHAR(128) NOT NULL,
 IdRegistro NVARCHAR(100) NOT NULL,
 Operacion NVARCHAR(10) NOT NULL,
 ValorAnterior NVARCHAR(MAX) NULL,
 ValorNuevo NVARCHAR(MAX) NULL,
 FechaEvento DATETIME2(0) NOT NULL CONSTRAINT DF_Auditoria_Fecha DEFAULT (SYSDATETIME()),
 CONSTRAINT FK_Auditoria_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario(IdUsuario),
 CONSTRAINT CK_Auditoria_Operacion CHECK (Operacion IN (N'INSERT', N'UPDATE', N'DELETE'))
);
GO
CREATE TABLE dbo.Configuracion (
 IdConfiguracion INT IDENTITY(1,1) CONSTRAINT PK_Configuracion PRIMARY KEY,
 Clave NVARCHAR(100) NOT NULL CONSTRAINT UQ_Configuracion_Clave UNIQUE,
 Valor NVARCHAR(1000) NOT NULL,
 Descripcion NVARCHAR(350) NULL,
 FechaModificacion DATETIME2(0) NOT NULL CONSTRAINT DF_Configuracion_Fecha DEFAULT (SYSDATETIME()),
 IdUsuarioModifico INT NULL,
 CONSTRAINT FK_Configuracion_Usuario FOREIGN KEY (IdUsuarioModifico) REFERENCES dbo.Usuario(IdUsuario)
);
GO

-- Índices operativos para búsquedas frecuentes y JOIN.
CREATE INDEX IX_Equipo_Cliente ON dbo.Equipo(IdCliente);
CREATE INDEX IX_Orden_Cliente_Fecha ON dbo.OrdenServicio(IdCliente, FechaRecepcion);
CREATE INDEX IX_Orden_Equipo ON dbo.OrdenServicio(IdEquipo);
CREATE INDEX IX_Orden_Estado ON dbo.OrdenServicio(IdEstadoOrden);
CREATE INDEX IX_DetalleOrden_Orden ON dbo.DetalleOrdenServicio(IdOrdenServicio);
CREATE INDEX IX_Compra_Proveedor ON dbo.Compra(IdProveedor);
CREATE INDEX IX_DetalleCompra_Compra ON dbo.DetalleCompra(IdCompra);
CREATE INDEX IX_Venta_Cliente ON dbo.VentaRefaccion(IdCliente);
CREATE INDEX IX_DetalleVenta_Venta ON dbo.DetalleVenta(IdVentaRefaccion);
CREATE INDEX IX_OrdenTecnico_Empleado ON dbo.OrdenTecnico(IdEmpleado);
CREATE INDEX IX_OrdenRefaccion_Orden ON dbo.OrdenRefaccion(IdOrdenServicio);
CREATE INDEX IX_Pago_Orden ON dbo.Pago(IdOrdenServicio) WHERE IdOrdenServicio IS NOT NULL;
CREATE INDEX IX_Pago_Venta ON dbo.Pago(IdVentaRefaccion) WHERE IdVentaRefaccion IS NOT NULL;
CREATE INDEX IX_MovInv_Refaccion_Fecha ON dbo.MovimientoInventario(IdRefaccion,FechaMovimiento);
CREATE INDEX IX_HistEstado_Orden_Fecha ON dbo.HistorialEstadoOrden(IdOrdenServicio,FechaCambio);
CREATE INDEX IX_Auditoria_Fecha ON dbo.Auditoria(FechaEvento);
GO
PRINT N'Modelo inicial: 30 tablas creadas.';
GO
