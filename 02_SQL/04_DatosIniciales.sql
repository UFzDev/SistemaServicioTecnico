USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON;
GO

-- 1. Catálogos base
IF NOT EXISTS (SELECT 1 FROM dbo.TipoEquipo)
BEGIN
    INSERT INTO dbo.TipoEquipo (Nombre, Descripcion, Activo) VALUES
    (N'Laptop', N'Computadoras portátiles de uso doméstico o empresarial', 1),
    (N'PC de Escritorio', N'Computadoras fijas, estaciones de trabajo o torres gamer', 1),
    (N'Smartphone', N'Teléfonos inteligentes Android y iOS', 1),
    (N'Tablet', N'Tabletas electrónicas y dispositivos tipo iPad', 1),
    (N'Consola de Videojuegos', N'PlayStation, Xbox, Nintendo Switch, etc.', 1),
    (N'Impresora Multifuncional', N'Impresoras láser, inyección de tinta y térmicas', 1),
    (N'Monitor', N'Monitores LCD, LED, IPS y curvados', 1),
    (N'Servidor', N'Servidores rack o torre para pequeñas empresas', 1),
    (N'Fuente de Poder / No-Break', N'Sistemas UPS y reguladores de voltaje', 1),
    (N'Proyector', N'Proyectores multimedia y de alta definición', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Marca)
BEGIN
    INSERT INTO dbo.Marca (Nombre, Activo) VALUES
    (N'HP', 1),
    (N'Dell', 1),
    (N'Lenovo', 1),
    (N'Apple', 1),
    (N'Samsung', 1),
    (N'Asus', 1),
    (N'Acer', 1),
    (N'Sony', 1),
    (N'Toshiba', 1),
    (N'Kingston', 1),
    (N'Adata', 1),
    (N'Corsair', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.EstadoOrden)
BEGIN
    INSERT INTO dbo.EstadoOrden (Nombre, EsFinal, Activo) VALUES
    (N'Recibida', 0, 1),
    (N'En Diagnóstico', 0, 1),
    (N'Presupuestada', 0, 1),
    (N'Esperando Aprobación', 0, 1),
    (N'En Reparación', 0, 1),
    (N'Esperando Refacción', 0, 1),
    (N'Terminada / Lista', 0, 1),
    (N'Entregada', 1, 1),
    (N'Cancelada', 1, 1),
    (N'Garantía', 0, 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.CategoriaServicio)
BEGIN
    INSERT INTO dbo.CategoriaServicio (Nombre, Activo) VALUES
    (N'Mantenimiento Preventivo', 1),
    (N'Mantenimiento Correctivo', 1),
    (N'Diagnóstico y Revisión', 1),
    (N'Instalación de Software y SO', 1),
    (N'Recuperación de Información', 1),
    (N'Microsoldadura y Placa Base', 1),
    (N'Limpieza y Cambio de Pasta Térmica', 1),
    (N'Configuración de Redes y Servidores', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.MetodoPago)
BEGIN
    INSERT INTO dbo.MetodoPago (Nombre, Activo) VALUES
    (N'Efectivo', 1),
    (N'Tarjeta de Débito', 1),
    (N'Tarjeta de Crédito', 1),
    (N'Transferencia SPEI', 1),
    (N'Depósito Bancario', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.CategoriaRefaccion)
BEGIN
    INSERT INTO dbo.CategoriaRefaccion (Nombre, Activo) VALUES
    (N'Almacenamiento (SSD / HDD)', 1),
    (N'Memoria RAM', 1),
    (N'Pantallas y Displays', 1),
    (N'Baterías y Cargadores', 1),
    (N'Teclados y Touchpads', 1),
    (N'Fuentes de Poder', 1),
    (N'Ventiladores y Disipadores', 1),
    (N'Pastas Térmicas e Insumos', 1);
END
GO

-- 2. Roles del Sistema
IF NOT EXISTS (SELECT 1 FROM dbo.Rol)
BEGIN
    INSERT INTO dbo.Rol (Nombre, Descripcion, Activo) VALUES
    (N'Administrador', N'Acceso total a todos los módulos, auditoría, configuración y seguridad', 1),
    (N'Supervisor', N'Supervisión técnica, reportes analíticos y autorización de presupuestos', 1),
    (N'Recepcionista', N'Atención a clientes, recepción de equipos, entrega y cobro', 1),
    (N'Tecnico', N'Diagnóstico, reparación de órdenes y solicitud de refacciones', 1);
END
GO

-- 3. Empleados (10 empleados con puestos reales)
IF NOT EXISTS (SELECT 1 FROM dbo.Empleado)
BEGIN
    INSERT INTO dbo.Empleado (Nombre, Apellidos, Puesto, Telefono, Correo, FechaIngreso, Activo) VALUES
    (N'Uriel', N'Flores Zárate', N'Administrador', N'7711000001', N'admin@serviciotecnico.com', '2026-01-10', 1),
    (N'Carlos', N'Mendoza Morales', N'Supervisor', N'7711000002', N'cmendoza@serviciotecnico.com', '2026-02-01', 1),
    (N'Ana', N'Sánchez Gómez', N'Recepcionista', N'7711000003', N'asanchez@serviciotecnico.com', '2026-02-15', 1),
    (N'Paola', N'Ríos Valencia', N'Recepcionista', N'7711000004', N'prios@serviciotecnico.com', '2026-03-01', 1),
    (N'Jorge', N'Martínez Castillo', N'Tecnico', N'7711000005', N'jmartinez@serviciotecnico.com', '2026-01-20', 1),
    (N'Luis', N'García Hernández', N'Tecnico', N'7711000006', N'lgarcia@serviciotecnico.com', '2026-02-10', 1),
    (N'David', N'Pérez López', N'Tecnico', N'7711000007', N'dperez@serviciotecnico.com', '2026-03-05', 1),
    (N'Elena', N'Navarro Ortiz', N'Tecnico', N'7711000008', N'enavarro@serviciotecnico.com', '2026-03-20', 1),
    (N'Roberto', N'Cruz Estrada', N'Auditor', N'7711000009', N'rcruz@serviciotecnico.com', '2026-04-01', 1),
    (N'Fernando', N'Vega Luna', N'Tecnico', N'7711000010', N'fvega@serviciotecnico.com', '2026-04-15', 0);
END
GO

-- 4. Usuarios del Sistema (asociados a empleados con roles)
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario)
BEGIN
    DECLARE @HashComun VARBINARY(256) = HASHBYTES('SHA2_256', 'admin123');

    INSERT INTO dbo.Usuario (IdEmpleado, NombreUsuario, HashContrasena, SaltContrasena, FechaAlta, Activo)
    SELECT IdEmpleado, 
           LOWER(SUBSTRING(Nombre,1,1) + Apellidos), 
           @HashComun, 
           NULL, 
           SYSDATETIME(), 
           Activo
    FROM dbo.Empleado;

    -- Asignar roles correspondientes
    INSERT INTO dbo.UsuarioRol (IdUsuario, IdRol, FechaAsignacion)
    SELECT u.IdUsuario, r.IdRol, SYSDATETIME()
    FROM dbo.Usuario u
    INNER JOIN dbo.Empleado e ON u.IdEmpleado = e.IdEmpleado
    INNER JOIN dbo.Rol r ON (
        (e.Puesto = N'Administrador' AND r.Nombre = N'Administrador') OR
        (e.Puesto = N'Supervisor' AND r.Nombre = N'Supervisor') OR
        (e.Puesto = N'Recepcionista' AND r.Nombre = N'Recepcionista') OR
        (e.Puesto IN (N'Tecnico', N'Auditor') AND r.Nombre = N'Tecnico')
    );

    -- Asegurar usuario exacto 'admin'
    UPDATE dbo.Usuario SET NombreUsuario = N'admin' WHERE IdEmpleado = (SELECT TOP 1 IdEmpleado FROM dbo.Empleado WHERE Correo = N'admin@serviciotecnico.com');
END
GO

-- 5. Proveedores (10 proveedores de tecnología con RFCs válidos)
IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor)
BEGIN
    INSERT INTO dbo.Proveedor (Nombre, RFC, Contacto, Telefono, Correo, Direccion, Activo) VALUES
    (N'Mayorista Tecnológico de México SA de CV', N'MTM120315ABC', N'Roberto Fuentes', N'5551234501', N'ventas@mayotec.mx', N'CDMX', 1),
    (N'CT Internacional del Noroeste', N'CIN940212XYZ', N'Laura Bernal', N'5551234502', N'contacto@ctonline.mx', N'Hermosillo, Son.', 1),
    (N'Ingram Micro México', N'IMM980614123', N'Mauricio Garza', N'5551234503', N'soporte@ingrammicro.mx', N'Tlalnepantla, Edomex', 1),
    (N'Grupo CVA Mayorista', N'CVA010520890', N'Estela Rivas', N'5551234504', N'atencion@grupocva.com', N'Guadalajara, Jal.', 1),
    (N'Importadora y Refacciones Digitales SA', N'IRD150822KLM', N'Hugo Santillán', N'5551234505', N'refacciones@ird.com.mx', N'Puebla, Pue.', 1),
    (N'Suministros Globales de Computo', N'SGC110910QWE', N'Diana Trejo', N'5551234506', N'dtrejo@suministros.mx', N'Querétaro, Qro.', 1),
    (N'Distribuidora de Pantallas y Displays', N'DPD160418RTY', N'Miguel Ángel León', N'5551234507', N'ventas@displaysmex.com', N'Monterrey, NL', 1),
    (N'Electrónica y Microcomponentes del Centro', N'EMC171105UIO', N'Beatriz Salazar', N'5551234508', N'bsalazar@microcentro.mx', N'Pachuca, Hgo.', 1),
    (N'Kingston Technology Direct', N'KTD050303PAS', N'Ernesto Valle', N'5551234509', N'contacto@kingstondirect.mx', N'CDMX', 1),
    (N'Proveedora de Herramientas y Químicos Taller', N'PHQ190707DFG', N'Clara Medina', N'5551234510', N'taller@quimicostools.mx', N'Toluca, Edomex', 1);
END
GO

-- 6. Clientes (25 clientes: 20 activos con órdenes/ventas y 5 inactivos o sin movimientos para pruebas)
IF NOT EXISTS (SELECT 1 FROM dbo.Cliente)
BEGIN
    INSERT INTO dbo.Cliente (Nombre, Apellidos, Telefono, Correo, Direccion, FechaRegistro, Activo) VALUES
    (N'Alejandro', N'Gómez Ruiz', N'7712010001', N'agomez@gmail.com', N'Col. Centro, Pachuca, Hgo.', '2026-01-15', 1),
    (N'Mariana', N'Torres Domínguez', N'7712010002', N'mtorres@gmail.com', N'Fracc. Constitución, Pachuca', '2026-01-18', 1),
    (N'Javier', N'Herrera Bravo', N'7712010003', N'jherrera@hotmail.com', N'Col. Morelos, Pachuca', '2026-01-22', 1),
    (N'Sofía', N'Camacho Solís', N'7712010004', N'scamacho@yahoo.com', N'Col. Periodistas, Pachuca', '2026-01-29', 1),
    (N'Ricardo', N'Salazar Peña', N'7712010005', N'rsalazar@gmail.com', N'Real del Monte, Hgo.', '2026-02-03', 1),
    (N'Gabriela', N'Fuentes Meza', N'7712010006', N'gfuentes@outlook.com', N'Col. Venta Prieta, Pachuca', '2026-02-07', 1),
    (N'Manuel', N'Vargas Ibarra', N'7712010007', N'mvargas@gmail.com', N'Mineral de la Reforma, Hgo.', '2026-02-12', 1),
    (N'Valeria', N'Lara Orozco', N'7712010008', N'vlara@hotmail.com', N'Fracc. Los Tuzos, Pachuca', '2026-02-17', 1),
    (N'Eduardo', N'Paredes Gil', N'7712010009', N'eparedes@gmail.com', N'Col. Plutarco, Pachuca', '2026-02-21', 1),
    (N'Daniela', N'Montesinos Cruz', N'7712010010', N'dmontes@yahoo.com', N'Col. Santa Julia, Pachuca', '2026-02-25', 1),
    (N'Héctor', N'Benítez Rojo', N'7712010011', N'hbenitez@gmail.com', N'Tulancingo, Hgo.', '2026-03-01', 1),
    (N'Fernanda', N'Delgado Nava', N'7712010012', N'fdelgado@gmail.com', N'Actopan, Hgo.', '2026-03-04', 1),
    (N'Adrián', N'Mora Cordero', N'7712010013', N'amora@outlook.com', N'Col. Piracantos, Pachuca', '2026-03-08', 1),
    (N'Lorena', N'Cervantes Parra', N'7712010014', N'lcervantes@gmail.com', N'Col. San Antonio, Pachuca', '2026-03-12', 1),
    (N'Guillermo', N'Rosas Villalobos', N'7712010015', N'grosas@hotmail.com', N'Zempoala, Hgo.', '2026-03-15', 1),
    (N'Claudia', N'Zavala Quintero', N'7712010016', N'czavala@gmail.com', N'Tula, Hgo.', '2026-03-18', 1),
    (N'Arturo', N'Rangel Cano', N'7712010017', N'arangel@gmail.com', N'Col. Doctores, Pachuca', '2026-03-22', 1),
    (N'Patricia', N'Aguilar Tapia', N'7712010018', N'paguilar@yahoo.com', N'Col. Maestranza, Pachuca', '2026-03-25', 1),
    (N'Hugo', N'Espinoza Miranda', N'7712010019', N'hespinoza@gmail.com', N'Tizayuca, Hgo.', '2026-03-28', 1),
    (N'Teresa', N'Galindo Becerra', N'7712010020', N'tgalindo@outlook.com', N'Col. Palmar, Pachuca', '2026-04-01', 1),
    -- Clientes sin compras ni movimientos (para pruebas de LEFT JOIN y filtros de inactivos)
    (N'Ignacio', N'Ponce Serrano', N'7712010021', N'iponce@gmail.com', N'Pachuca, Hgo.', '2026-04-05', 1),
    (N'Mónica', N'Cárdenas Lugo', N'7712010022', N'mcardenas@hotmail.com', N'Mineral del Chico, Hgo.', '2026-04-08', 1),
    (N'Raúl', N'Santana Ponce', N'7712010023', N'rsantana@gmail.com', N'Pachuca, Hgo.', '2026-04-10', 1),
    (N'Beatriz', N'Soto Figueroa', N'7712010024', N'bsoto@yahoo.com', N'Real del Monte, Hgo.', '2026-04-12', 0),
    (N'Felipe', N'Corona Lozano', N'7712010025', N'fcorona@outlook.com', N'Pachuca, Hgo.', '2026-04-14', 0);
END
GO

-- 7. Equipos de Clientes (25 dispositivos registrados)
IF NOT EXISTS (SELECT 1 FROM dbo.Equipo)
BEGIN
    INSERT INTO dbo.Equipo (IdCliente, IdTipoEquipo, IdMarca, Modelo, NumeroSerie, Caracteristicas, FechaRegistro, Activo) VALUES
    (1, 1, 1, N'Pavilion 15-dk0020la', N'5CD9321ABC', N'Intel Core i5 9th, 8GB RAM, GTX 1050', '2026-01-16', 1),
    (1, 3, 5, N'Galaxy S21 Ultra', N'R58M901XYZ', N'128GB Negro Fantasma, pantalla curva', '2026-02-10', 1),
    (2, 1, 2, N'Inspiron 3501', N'8HK2199KLM', N'Intel Core i3 10th, 4GB RAM, SSD 256GB', '2026-01-19', 1),
    (2, 4, 4, N'iPad Air 4ta Gen', N'DMPZ1990OPQ', N'64GB Wi-Fi Gris Espacial', '2026-03-01', 1),
    (3, 2, 6, N'ROG Strix G15', N'K9N01234ASU', N'Ryzen 7 5800X, 16GB RAM, RTX 3060', '2026-01-23', 1),
    (4, 1, 3, N'ThinkPad T14 Gen 2', N'PF299901LEN', N'Intel Core i7 11th, 16GB RAM, SSD 512GB', '2026-01-30', 1),
    (5, 5, 8, N'PlayStation 5 Standard', N'FC102938475', N'Edición disco 825GB con control DualSense', '2026-02-04', 1),
    (6, 1, 4, N'MacBook Air M1 2020', N'C02F9812APL', N'Chip M1, 8GB RAM Unificada, 256GB SSD', '2026-02-08', 1),
    (7, 3, 5, N'Galaxy A54 5G', N'RF8T2991SAM', N'128GB Verde Lima', '2026-02-13', 1),
    (8, 1, 1, N'Omen 16', N'4CE10928HPP', N'Ryzen 9 6900HX, 32GB RAM, RTX 3070 Ti', '2026-02-18', 1),
    (9, 2, 2, N'OptiPlex 7070 SFF', N'9JL0192DEL', N'Core i5 9500, 8GB RAM, HDD 1TB', '2026-02-22', 1),
    (10, 1, 7, N'Aspire 5 A515', N'NXA84019ACE', N'Core i5 11th, 8GB RAM, SSD 512GB', '2026-02-26', 1),
    (11, 5, 8, N'PlayStation 4 Slim', N'MB991827461', N'1TB Negro Azabache con 2 controles', '2026-03-02', 1),
    (12, 1, 3, N'IdeaPad 3 14ALC6', N'MP20199LENO', N'Ryzen 5 5500U, 8GB RAM, SSD 256GB', '2026-03-05', 1),
    (13, 6, 1, N'HP LaserJet Pro M404n', N'VNB3C10928H', N'Impresora láser monocromática', '2026-03-09', 1),
    (14, 1, 6, N'TUF Gaming F15', N'M4NRC019ASU', N'Core i5 10th, 16GB RAM, GTX 1650', '2026-03-13', 1),
    (15, 3, 4, N'iPhone 13 Pro', N'G6TC1902APL', N'128GB Azul Sierra', '2026-03-16', 1),
    (16, 2, 1, N'HP ProDesk 400 G6', N'CZC10928HP1', N'Core i3 10100, 8GB RAM', '2026-03-19', 1),
    (17, 1, 2, N'Dell Vostro 3400', N'2HK0192DEL1', N'Core i5 11th, 8GB RAM, SSD 256GB', '2026-03-23', 1),
    (18, 4, 5, N'Galaxy Tab S7 FE', N'R52N1092SAM', N'64GB con S-Pen Mystic Black', '2026-03-26', 1),
    (19, 1, 7, N'Nitro 5 AN515', N'NHQBC019ACE', N'Core i5 10th, 8GB RAM, GTX 1650', '2026-03-29', 1),
    (20, 1, 1, N'Envy x360 Convertible', N'8CC10928HPE', N'Ryzen 7 4700U, 16GB RAM táctil 2-en-1', '2026-04-02', 1),
    -- Equipos sin órdenes de servicio vinculadas
    (21, 1, 2, N'Latitude 3420', N'6BC0192DEL', N'Core i5 11th, 16GB RAM', '2026-04-06', 1),
    (22, 3, 5, N'Galaxy A14', N'RF9T1092SAM', N'64GB Negro', '2026-04-09', 1),
    (23, 1, 3, N'Legion 5 15ACH6', N'PF30192LENO', N'Ryzen 7 5800H, 16GB RAM, RTX 3050Ti', '2026-04-11', 1);
END
GO

-- 8. Servicios (10 servicios de catálogo)
IF NOT EXISTS (SELECT 1 FROM dbo.Servicio)
BEGIN
    INSERT INTO dbo.Servicio (IdCategoriaServicio, Nombre, Descripcion, PrecioBase, Activo) VALUES
    (1, N'Mantenimiento Preventivo Básico Laptop', N'Limpieza interna, soplado y cambio de pasta térmica', 350.00, 1),
    (1, N'Mantenimiento Preventivo Completo PC Gamer', N'Desarme total, limpieza ultrasónica y pasta de alto rendimiento', 650.00, 1),
    (2, N'Mantenimiento Correctivo con Reemplazo de Pieza', N'Mano de obra por reemplazo de componente interno dañado', 400.00, 1),
    (3, N'Diagnóstico General en Banco', N'Revisión eléctrica y pruebas de componentes para cotización', 150.00, 1),
    (4, N'Formateo e Instalación de Sistema Operativo', N'Instalación limpia de Windows con drivers y paquetería básica', 400.00, 1),
    (4, N'Limpieza y Desinfección de Malware / Virus', N'Eliminación de programas espía, adware y optimización de arranque', 300.00, 1),
    (5, N'Recuperación de Información en Disco Dañado', N'Extracción lógica de archivos en HDD o memorias USB', 800.00, 1),
    (6, N'Reparación de Centro de Carga Laptop', N'Desoldadura y reemplazo de conector Jack DC', 550.00, 1),
    (7, N'Limpieza Química y Mantenimiento de Impresora', N'Destapado de cabezales y purgado de mangueras de tinta', 450.00, 1),
    (8, N'Configuración de Red Local y Servidor de Archivos', N'Instalación de almacenamiento NAS y compartición segura', 950.00, 1);
END
GO

-- 9. Refacciones e Inventario (10 refacciones con existencias reales)
IF NOT EXISTS (SELECT 1 FROM dbo.Refaccion)
BEGIN
    INSERT INTO dbo.Refaccion (IdCategoriaRefaccion, SKU, Nombre, Descripcion, CostoReferencia, PrecioVenta, StockMinimo, Activo) VALUES
    (1, N'SSD-KING-480', N'Unidad SSD Kingston 480GB SATA 2.5', N'SSD de estado sólido de alta velocidad', 420.00, 680.00, 5, 1),
    (1, N'SSD-NVME-1TB', N'SSD Kingston NV2 1TB PCIe 4.0 NVMe M.2', N'Unidad ultrarrápida para laptops y PCs modernas', 850.00, 1300.00, 3, 1),
    (1, N'SSD-ADATA-240', N'SSD Adata SU650 240GB SATA 2.5', N'Unidad para reemplazo económico de disco duro', 250.00, 420.00, 4, 1),
    (2, N'RAM-DDR4-8GB', N'Memoria RAM Kingston Fury 8GB DDR4 3200MHz', N'Módulo SODIMM para laptop', 380.00, 590.00, 4, 1),
    (2, N'RAM-DDR4-16GB', N'Memoria RAM Kingston Fury 16GB DDR4 3200MHz', N'Módulo UDIMM para escritorio', 680.00, 1050.00, 3, 1),
    (2, N'RAM-CORSAIR-16G', N'Memoria RAM Corsair Vengeance 16GB DDR4 3600MHz', N'Módulo gamer con disipador de aluminio', 750.00, 1180.00, 2, 1),
    (3, N'DISP-LED-156', N'Pantalla Display LED 15.6 Slim 30 Pines FHD', N'Panel de repuesto genérico compatible con HP/Dell/Lenovo', 1100.00, 1750.00, 2, 1),
    (4, N'BAT-DELL-INSP', N'Batería Original Dell Inspiron 42Wh 3 Celdas', N'Batería interna de ion de litio', 650.00, 1100.00, 2, 1),
    (6, N'FUENTE-EVGA-600', N'Fuente de Poder EVGA 600W 80 Plus White', N'Fuente certificada para PC gamer y ensambles', 720.00, 1150.00, 2, 1),
    (8, N'PASTA-ARTIC-MX4', N'Pasta Térmica Arctic MX-4 4g', N'Pasta de alto rendimiento micropartículas de carbono', 120.00, 220.00, 6, 1);

    INSERT INTO dbo.Inventario (IdRefaccion, Existencia, FechaActualizacion)
    VALUES
    (1, 15, SYSDATETIME()),
    (2, 8, SYSDATETIME()),
    (3, 12, SYSDATETIME()),
    (4, 14, SYSDATETIME()),
    (5, 7, SYSDATETIME()),
    (6, 6, SYSDATETIME()),
    (7, 4, SYSDATETIME()),
    (8, 5, SYSDATETIME()),
    (9, 4, SYSDATETIME()),
    (10, 25, SYSDATETIME());
END
GO

-- 10. Refacción - Proveedor (Relación N:M)
IF NOT EXISTS (SELECT 1 FROM dbo.RefaccionProveedor)
BEGIN
    INSERT INTO dbo.RefaccionProveedor (IdRefaccion, IdProveedor, CodigoProveedor, UltimoCosto, Activo) VALUES
    (1, 1, N'PROV-K480', 420.00, 1),
    (1, 9, N'KING-SATA480', 410.00, 1),
    (2, 1, N'PROV-KNV1TB', 850.00, 1),
    (2, 9, N'KING-NVME1T', 835.00, 1),
    (3, 2, N'ADATA-SU240', 250.00, 1),
    (4, 9, N'KING-SOD8G', 380.00, 1),
    (5, 9, N'KING-UD16G', 680.00, 1),
    (6, 4, N'CVA-COR16G', 750.00, 1),
    (7, 7, N'DPD-FHD156', 1100.00, 1),
    (8, 5, N'IRD-BATDELL', 650.00, 1),
    (9, 3, N'IMM-EVGA600', 720.00, 1),
    (10, 10, N'PHQ-MX44G', 120.00, 1);
END
GO

-- 11. Órdenes de Servicio (25 órdenes en diversas fechas y estados)
IF NOT EXISTS (SELECT 1 FROM dbo.OrdenServicio)
BEGIN
    INSERT INTO dbo.OrdenServicio (Folio, IdCliente, IdEquipo, IdEstadoOrden, IdUsuarioRecepcion, FechaRecepcion, FechaPrometida, FechaEntrega, FallaReportada, Observaciones, Presupuesto, PresupuestoAutorizado, FechaAutorizacion, DiagnosticoGeneral) VALUES
    (N'ORD-2026-0001', 1, 1, 8, 3, '2026-02-01 09:30', '2026-02-03 18:00', '2026-02-03 16:30', N'Sobrecalentamiento y ventilador ruidoso al jugar', N'Carcasa con rayones leves', 750.00, 1, '2026-02-01 12:00', N'Disipador obstruido por polvo y pasta térmica seca'),
    (N'ORD-2026-0002', 2, 3, 8, 3, '2026-02-05 10:15', '2026-02-07 14:00', '2026-02-06 17:00', N'Extremadamente lenta al iniciar Windows y abrir programas', N'Cargador original incluido', 1080.00, 1, '2026-02-05 15:30', N'Disco duro mecánico al 100% de uso con sectores defectuosos'),
    (N'ORD-2026-0003', 3, 5, 8, 4, '2026-02-10 11:00', '2026-02-12 18:00', '2026-02-12 15:00', N'La computadora enciende pero no da video en monitor', N'Gabinete con panel de cristal templado', 650.00, 1, '2026-02-10 14:00', N'Módulos de memoria RAM sulfatados y BIOS desconfigurada'),
    (N'ORD-2026-0004', 4, 6, 8, 3, '2026-02-14 16:20', '2026-02-16 19:00', '2026-02-16 11:00', N'Ventana emergente de virus y publicidad en Chrome', N'Equipo corporativo', 300.00, 1, '2026-02-14 17:00', N'Adware y extensiones maliciosas instaladas'),
    (N'ORD-2026-0005', 5, 7, 8, 4, '2026-02-20 12:45', '2026-02-24 18:00', '2026-02-23 18:30', N'Consola se apaga de golpe a los 15 minutos de juego', N'Sin cables incluidos', 650.00, 1, '2026-02-20 16:00', N'Metal líquido desplazado y disipador tapado de pelusa'),
    (N'ORD-2026-0006', 6, 8, 8, 3, '2026-02-25 10:00', '2026-02-27 15:00', '2026-02-26 14:00', N'Pantalla parpadea con líneas horizontales', N'Equipo en excelente estado estético', 150.00, 1, '2026-02-25 12:00', N'Flexor de video flojo, reajuste y pruebas ok'),
    (N'ORD-2026-0007', 7, 9, 8, 4, '2026-03-01 11:30', '2026-03-02 18:00', '2026-03-02 17:00', N'No carga la batería a menos que se presione el cable', N'Sin funda', 450.00, 1, '2026-03-01 13:00', N'Pelusa compactada en puerto USB-C y pin sulfatado'),
    (N'ORD-2026-0008', 8, 10, 8, 3, '2026-03-05 14:10', '2026-03-08 19:00', '2026-03-07 18:00', N'Optimización general y mantenimiento antes de torneo', N'Laptop de alta gama', 650.00, 1, '2026-03-05 16:00', N'Mantenimiento térmico profundo ok'),
    (N'ORD-2026-0009', 9, 11, 8, 4, '2026-03-10 09:00', '2026-03-12 18:00', '2026-03-11 16:00', N'Reinicio constante en pantalla azul de Windows', N'CPU de oficina', 400.00, 1, '2026-03-10 11:30', N'Corrupción de archivos del sistema operativo por corte de luz'),
    (N'ORD-2026-0010', 10, 12, 8, 3, '2026-03-15 13:20', '2026-03-17 18:00', '2026-03-17 12:00', N'Instalación de paquetería de diseño y antivirus', N'Incluye cargador', 400.00, 1, '2026-03-15 15:00', N'Formateo e instalación limpia con software autorizado'),
    (N'ORD-2026-0011', 11, 13, 7, 4, '2026-03-20 15:00', '2026-03-23 18:00', NULL, N'El lector de discos no expulsa los juegos', N'Consola PS4', 550.00, 1, '2026-03-20 17:00', N'Mecanismo de rodillos atorado, reparado y probado'),
    (N'ORD-2026-0012', 12, 14, 7, 3, '2026-03-25 10:40', '2026-03-27 18:00', NULL, N'Aumento de memoria RAM para clases en línea', N'Color gris', 590.00, 1, '2026-03-25 11:30', N'Instalación de módulo SODIMM 8GB Kingston'),
    (N'ORD-2026-0013', 13, 15, 7, 4, '2026-03-28 12:00', '2026-03-31 16:00', NULL, N'Atasco de papel constante en bandeja 2', N'Tóner casi vacío', 450.00, 1, '2026-03-28 14:00', N'Rodillos de alimentación desgastados y cambiados'),
    (N'ORD-2026-0014', 14, 16, 5, 3, '2026-04-01 11:00', '2026-04-04 18:00', NULL, N'Teclado no responden las teclas W, A, S, D', N'Teclado RGB', 750.00, 1, '2026-04-01 13:30', N'En espera de reemplazo de teclado'),
    (N'ORD-2026-0015', 15, 17, 5, 4, '2026-04-03 16:00', '2026-04-06 18:00', NULL, N'Batería dura menos de 30 minutos y se infló la parte trasera', N'Pantalla intacta', 1200.00, 1, '2026-04-03 18:00', N'Batería degradada al 62%, en proceso de cambio'),
    (N'ORD-2026-0016', 16, 18, 5, 3, '2026-04-07 10:15', '2026-04-10 18:00', NULL, N'Actualización de disco HDD a SSD y clonación', N'CPU sin cables', 950.00, 1, '2026-04-07 12:00', N'Clonando partición a SSD Kingston 480GB'),
    (N'ORD-2026-0017', 17, 19, 6, 4, '2026-04-10 14:00', '2026-04-15 18:00', NULL, N'Pantalla estrellada por caída en esquina', N'Equipo golpeado', 1750.00, 1, '2026-04-10 16:00', N'Esperando llegada de refacción display FHD'),
    (N'ORD-2026-0018', 18, 20, 6, 3, '2026-04-12 11:30', '2026-04-16 18:00', NULL, N'Centro de carga roto, la clavija baila', N'Incluye cargador reparado', 650.00, 1, '2026-04-12 14:00', N'Esperando conector hembra Jack DC'),
    (N'ORD-2026-0019', 19, 21, 4, 4, '2026-04-15 12:00', '2026-04-18 18:00', NULL, N'Se derramó café sobre teclado y touchpad', N'Huele a líquido seco', 1100.00, 0, NULL, N'Cotizado lavado ultrasónico de tarjeta madre'),
    (N'ORD-2026-0020', 20, 22, 4, 3, '2026-04-18 15:45', '2026-04-21 18:00', NULL, N'Bisagra izquierda rota, al abrir cruje la pantalla', N'Carcasa despegada', 850.00, 0, NULL, N'Cotizada reconstrucción plástica de bujes'),
    (N'ORD-2026-0021', 1, 2, 2, 4, '2026-04-20 10:00', '2026-04-22 18:00', NULL, N'No enciende tras tormenta eléctrica', N'Gabinete con olor a quemado', 150.00, 0, NULL, N'En pruebas de fuente y tarjeta madre'),
    (N'ORD-2026-0022', 2, 4, 2, 3, '2026-04-22 13:00', '2026-04-24 18:00', NULL, N'iPad no responde touch en la mitad superior', N'Sin mica', 150.00, 0, NULL, N'En diagnóstico de panel digitalizador'),
    (N'ORD-2026-0023', 3, 5, 1, 4, '2026-04-25 11:10', '2026-04-28 18:00', NULL, N'Mantenimiento preventivo anual', N'Buen estado', NULL, 0, NULL, N'Equipo recibido en mostrador'),
    (N'ORD-2026-0024', 4, 6, 1, 3, '2026-04-26 16:30', '2026-04-29 18:00', NULL, N'Lentitud y ventilador forzado', N'Cargador sellado', NULL, 0, NULL, N'Equipo recibido en mostrador'),
    (N'ORD-2026-0025', 5, 7, 9, 4, '2026-04-27 10:00', '2026-04-29 18:00', '2026-04-28 11:00', N'Cliente desistió del servicio por costo de refacción', N'Equipo devuelto sin reparar', NULL, 0, NULL, N'Orden cancelada por el cliente');
END
GO

-- 12. Detalle de Orden de Servicio (50 líneas de servicios realizados)
IF NOT EXISTS (SELECT 1 FROM dbo.DetalleOrdenServicio)
BEGIN
    INSERT INTO dbo.DetalleOrdenServicio (IdOrdenServicio, IdServicio, DescripcionTrabajo, Cantidad, PrecioUnitario, EstadoActividad, Obligatoria, FechaFinalizacion) VALUES
    (1, 1, N'Limpieza y cambio de pasta térmica', 1, 350.00, N'Completada', 1, '2026-02-03 12:00'),
    (1, 4, N'Actualización de BIOS y controladores', 1, 400.00, N'Completada', 0, '2026-02-03 15:00'),
    (2, 5, N'Instalación limpia de Windows 11', 1, 400.00, N'Completada', 1, '2026-02-06 14:00'),
    (2, 3, N'Mano de obra cambio de unidad SSD', 1, 400.00, N'Completada', 1, '2026-02-06 16:00'),
    (3, 2, N'Limpieza ultrasónica y mantenimiento PC Gamer', 1, 650.00, N'Completada', 1, '2026-02-12 14:00'),
    (4, 6, N'Desinfección de malware y optimización de registro', 1, 300.00, N'Completada', 1, '2026-02-16 10:30'),
    (5, 2, N'Mantenimiento térmico profundo y reemplazo de pasta PS5', 1, 650.00, N'Completada', 1, '2026-02-23 16:00'),
    (6, 4, N'Reajuste de flexor de pantalla y pruebas', 1, 150.00, N'Completada', 1, '2026-02-26 13:00'),
    (7, 8, N'Limpieza de puerto de carga y resoldadura Jack DC', 1, 450.00, N'Completada', 1, '2026-03-02 16:00'),
    (8, 2, N'Mantenimiento integral PC Gamer', 1, 650.00, N'Completada', 1, '2026-03-07 17:00'),
    (9, 5, N'Reinstalación de sistema operativo', 1, 400.00, N'Completada', 1, '2026-03-11 15:00'),
    (10, 5, N'Instalación de Windows y software autorizado', 1, 400.00, N'Completada', 1, '2026-03-17 11:30'),
    (11, 3, N'Reparación de mecanismo de expulsión de disco', 1, 550.00, N'Completada', 1, '2026-03-22 17:00'),
    (12, 3, N'Instalación y configuración de memoria RAM', 1, 200.00, N'Completada', 1, '2026-03-26 15:00'),
    (13, 9, N'Servicio a impresora y cambio de rodillos', 1, 450.00, N'Completada', 1, '2026-03-30 14:00'),
    (14, 3, N'Mano de obra cambio de teclado gamer', 1, 400.00, N'EnProceso', 1, NULL),
    (15, 3, N'Desarme y reemplazo de batería interna', 1, 350.00, N'EnProceso', 1, NULL),
    (16, 5, N'Clonación de disco duro a SSD', 1, 400.00, N'EnProceso', 1, NULL),
    (17, 3, N'Mano de obra cambio de panel display', 1, 450.00, N'Pendiente', 1, NULL),
    (18, 8, N'Reparación de centro de carga DC Jack', 1, 550.00, N'Pendiente', 1, NULL),
    (19, 2, N'Limpieza de líquidos y baño químico', 1, 650.00, N'Pendiente', 1, NULL),
    (20, 3, N'Reconstrucción de bisagras con resina epóxica', 1, 450.00, N'Pendiente', 1, NULL),
    (21, 4, N'Diagnóstico eléctrico de componentes', 1, 150.00, N'EnProceso', 1, NULL),
    (22, 4, N'Diagnóstico de tarjeta digitalizadora iPad', 1, 150.00, N'EnProceso', 1, NULL),
    (23, 1, N'Mantenimiento preventivo laptop', 1, 350.00, N'Pendiente', 1, NULL);
END
GO

-- 13. Orden - Refacción (Refacciones consumidas en órdenes)
IF NOT EXISTS (SELECT 1 FROM dbo.OrdenRefaccion)
BEGIN
    INSERT INTO dbo.OrdenRefaccion (IdOrdenServicio, IdRefaccion, Cantidad, PrecioUnitario, FechaConsumo) VALUES
    (1, 10, 1, 220.00, '2026-02-03 11:00'),
    (2, 1, 1, 680.00, '2026-02-06 15:00'),
    (3, 10, 1, 220.00, '2026-02-12 13:00'),
    (5, 10, 1, 220.00, '2026-02-23 15:00'),
    (8, 10, 1, 220.00, '2026-03-07 16:00'),
    (12, 4, 1, 590.00, '2026-03-26 14:00'),
    (16, 1, 1, 680.00, '2026-04-08 11:00'),
    (17, 7, 1, 1750.00, '2026-04-11 12:00'),
    (18, 10, 1, 220.00, '2026-04-13 10:00');
END
GO

-- 14. Asignación de Técnicos a Órdenes (OrdenTecnico)
IF NOT EXISTS (SELECT 1 FROM dbo.OrdenTecnico)
BEGIN
    INSERT INTO dbo.OrdenTecnico (IdOrdenServicio, IdEmpleado, FechaAsignacion, FechaFin, EsResponsable) VALUES
    (1, 5, '2026-02-01 10:00', '2026-02-03 16:30', 1),
    (2, 6, '2026-02-05 11:00', '2026-02-06 17:00', 1),
    (3, 7, '2026-02-10 12:00', '2026-02-12 15:00', 1),
    (4, 5, '2026-02-14 17:00', '2026-02-16 11:00', 1),
    (5, 8, '2026-02-20 13:00', '2026-02-23 18:30', 1),
    (6, 6, '2026-02-25 11:00', '2026-02-26 14:00', 1),
    (7, 7, '2026-03-01 12:00', '2026-03-02 17:00', 1),
    (8, 5, '2026-03-05 15:00', '2026-03-07 18:00', 1),
    (9, 6, '2026-03-10 10:00', '2026-03-11 16:00', 1),
    (10, 7, '2026-03-15 14:00', '2026-03-17 12:00', 1),
    (11, 8, '2026-03-20 16:00', NULL, 1),
    (12, 5, '2026-03-25 11:00', NULL, 1),
    (13, 6, '2026-03-28 13:00', NULL, 1),
    (14, 7, '2026-04-01 12:00', NULL, 1),
    (15, 8, '2026-04-03 17:00', NULL, 1),
    (16, 5, '2026-04-07 11:00', NULL, 1),
    (17, 6, '2026-04-10 15:00', NULL, 1),
    (18, 7, '2026-04-12 12:00', NULL, 1);
END
GO

-- 15. Compras a Proveedores (Proceso Secundario 1: 5 Compras con Detalle)
IF NOT EXISTS (SELECT 1 FROM dbo.Compra)
BEGIN
    INSERT INTO dbo.Compra (Folio, IdProveedor, IdUsuario, FechaCompra, Estado, Observaciones) VALUES
    (N'COM-2026-0001', 9, 1, '2026-01-20 10:00', N'Confirmada', N'Adquisición de lotes de memoria RAM y SSDs Kingston'),
    (N'COM-2026-0002', 10, 1, '2026-02-01 11:30', N'Confirmada', N'Resurtido de pasta térmica Arctic MX-4 e insumos'),
    (N'COM-2026-0003', 7, 2, '2026-02-15 14:00', N'Confirmada', N'Displays LED 15.6 slim para stock'),
    (N'COM-2026-0004', 3, 1, '2026-03-01 09:30', N'Confirmada', N'Fuentes de poder EVGA 600W'),
    (N'COM-2026-0005', 1, 2, '2026-04-05 16:00', N'Borrador', N'Cotización en proceso de SSDs NVMe');

    INSERT INTO dbo.DetalleCompra (IdCompra, IdRefaccion, Cantidad, CostoUnitario) VALUES
    (1, 1, 10, 410.00),
    (1, 2, 5, 835.00),
    (1, 4, 10, 380.00),
    (2, 10, 20, 120.00),
    (3, 7, 5, 1100.00),
    (4, 9, 4, 720.00),
    (5, 2, 5, 850.00);
END
GO

-- 16. Ventas de Refacciones en Mostrador (Proceso Secundario 2: 15 Ventas con Detalle)
IF NOT EXISTS (SELECT 1 FROM dbo.VentaRefaccion)
BEGIN
    INSERT INTO dbo.VentaRefaccion (Folio, IdCliente, IdUsuario, FechaVenta, Estado, Observaciones) VALUES
    (N'VTA-2026-0001', 1, 3, '2026-02-04 11:00', N'Confirmada', N'Venta mostrador disco SSD'),
    (N'VTA-2026-0002', 2, 3, '2026-02-08 12:30', N'Confirmada', N'Memoria RAM 8GB para actualización'),
    (N'VTA-2026-0003', 3, 4, '2026-02-15 16:00', N'Confirmada', N'Pasta térmica Arctic MX-4'),
    (N'VTA-2026-0004', 4, 3, '2026-02-22 17:15', N'Confirmada', N'SSD NVMe 1TB Kingston'),
    (N'VTA-2026-0005', 5, 4, '2026-03-01 10:45', N'Confirmada', N'Memoria RAM Corsair 16GB'),
    (N'VTA-2026-0006', 6, 3, '2026-03-06 14:00', N'Confirmada', N'SSD Adata 240GB'),
    (N'VTA-2026-0007', 7, 4, '2026-03-12 18:00', N'Confirmada', N'Fuente de poder EVGA 600W'),
    (N'VTA-2026-0008', 8, 3, '2026-03-18 11:20', N'Confirmada', N'Jeringa de pasta térmica'),
    (N'VTA-2026-0009', 9, 4, '2026-03-24 16:40', N'Confirmada', N'Memoria RAM Kingston 16GB'),
    (N'VTA-2026-0010', 10, 3, '2026-03-30 12:00', N'Confirmada', N'SSD Kingston 480GB'),
    (N'VTA-2026-0011', 11, 4, '2026-04-03 15:30', N'Confirmada', N'Pasta térmica MX-4'),
    (N'VTA-2026-0012', 12, 3, '2026-04-08 17:00', N'Confirmada', N'SSD NVMe 1TB'),
    (N'VTA-2026-0013', 13, 4, '2026-04-14 11:15', N'Confirmada', N'Memoria RAM 8GB SODIMM'),
    (N'VTA-2026-0014', 14, 3, '2026-04-20 13:45', N'Confirmada', N'SSD Kingston 480GB'),
    (N'VTA-2026-0015', 15, 4, '2026-04-26 16:00', N'Borrador', N'Apartado pendiente de pago');

    INSERT INTO dbo.DetalleVenta (IdVentaRefaccion, IdRefaccion, Cantidad, PrecioUnitario) VALUES
    (1, 1, 1, 680.00),
    (2, 4, 1, 590.00),
    (3, 10, 1, 220.00),
    (4, 2, 1, 1300.00),
    (5, 6, 1, 1180.00),
    (6, 3, 1, 420.00),
    (7, 9, 1, 1150.00),
    (8, 10, 2, 220.00),
    (9, 5, 1, 1050.00),
    (10, 1, 1, 680.00),
    (11, 10, 1, 220.00),
    (12, 2, 1, 1300.00),
    (13, 4, 1, 590.00),
    (14, 1, 1, 680.00),
    (15, 2, 1, 1300.00);
END
GO

-- 17. Pagos Registrados (20 pagos asociados a órdenes y ventas)
IF NOT EXISTS (SELECT 1 FROM dbo.Pago)
BEGIN
    INSERT INTO dbo.Pago (IdOrdenServicio, IdVentaRefaccion, IdMetodoPago, IdUsuario, Importe, FechaPago, Referencia, Estado) VALUES
    (1, NULL, 1, 3, 750.00, '2026-02-03 16:30', N'Cobro en caja', N'Aplicado'),
    (2, NULL, 2, 3, 1080.00, '2026-02-06 17:00', N'Tarjeta BBVA aut. 91028', N'Aplicado'),
    (3, NULL, 1, 4, 650.00, '2026-02-12 15:00', N'Efectivo exacto', N'Aplicado'),
    (4, NULL, 4, 3, 300.00, '2026-02-16 11:00', N'SPEI Santander 481920', N'Aplicado'),
    (5, NULL, 3, 4, 650.00, '2026-02-23 18:30', N'Tarjeta Banamex aut. 11029', N'Aplicado'),
    (6, NULL, 1, 3, 150.00, '2026-02-26 14:00', N'Cobro diagnóstico', N'Aplicado'),
    (7, NULL, 1, 4, 450.00, '2026-03-02 17:00', N'Efectivo', N'Aplicado'),
    (8, NULL, 2, 3, 650.00, '2026-03-07 18:00', N'Tarjeta HSBC aut. 55019', N'Aplicado'),
    (9, NULL, 4, 4, 400.00, '2026-03-11 16:00', N'SPEI BBVA 990182', N'Aplicado'),
    (10, NULL, 1, 3, 400.00, '2026-03-17 12:00', N'Efectivo', N'Aplicado'),
    (NULL, 1, 1, 3, 680.00, '2026-02-04 11:00', N'Mostrador efectivo', N'Aplicado'),
    (NULL, 2, 2, 3, 590.00, '2026-02-08 12:30', N'Terminal Santander', N'Aplicado'),
    (NULL, 3, 1, 4, 220.00, '2026-02-15 16:00', N'Mostrador', N'Aplicado'),
    (NULL, 4, 4, 3, 1300.00, '2026-02-22 17:15', N'SPEI 110928', N'Aplicado'),
    (NULL, 5, 2, 4, 1180.00, '2026-03-01 10:45', N'Terminal Banamex', N'Aplicado'),
    (NULL, 6, 1, 3, 420.00, '2026-03-06 14:00', N'Efectivo', N'Aplicado'),
    (NULL, 7, 3, 4, 1150.00, '2026-03-12 18:00', N'Tarjeta crédito', N'Aplicado'),
    (NULL, 8, 1, 3, 440.00, '2026-03-18 11:20', N'Efectivo', N'Aplicado'),
    (NULL, 9, 2, 4, 1050.00, '2026-03-24 16:40', N'Tarjeta débito', N'Aplicado'),
    (NULL, 10, 1, 3, 680.00, '2026-03-30 12:00', N'Efectivo', N'Aplicado');
END
GO

-- 18. Historial de Estados de Órdenes (Trazabilidad)
IF NOT EXISTS (SELECT 1 FROM dbo.HistorialEstadoOrden)
BEGIN
    INSERT INTO dbo.HistorialEstadoOrden (IdOrdenServicio, IdEstadoAnterior, IdEstadoNuevo, IdUsuario, FechaCambio, Motivo) VALUES
    (1, NULL, 1, 3, '2026-02-01 09:30', N'Recepción en mostrador'),
    (1, 1, 2, 5, '2026-02-01 10:30', N'Inicio de revisión en banco de trabajo'),
    (1, 2, 5, 5, '2026-02-01 12:30', N'Presupuesto aceptado, desarmado de laptop'),
    (1, 5, 7, 5, '2026-02-03 14:00', N'Mantenimiento concluido con pruebas de temperatura ok'),
    (1, 7, 8, 3, '2026-02-03 16:30', N'Entregado al cliente a satisfacción y cobrado'),
    (2, NULL, 1, 3, '2026-02-05 10:15', N'Recepción en mostrador'),
    (2, 1, 2, 6, '2026-02-05 11:30', N'Diagnóstico con CrystalDiskInfo'),
    (2, 2, 5, 6, '2026-02-05 16:00', N'Aprobado cambio de disco por SSD'),
    (2, 5, 7, 6, '2026-02-06 15:00', N'Windows instalado y activado'),
    (2, 7, 8, 3, '2026-02-06 17:00', N'Entregada y cobrada con tarjeta');
END
GO

-- 19. Configuración del Sistema
IF NOT EXISTS (SELECT 1 FROM dbo.Configuracion)
BEGIN
    INSERT INTO dbo.Configuracion (Clave, Valor, Descripcion) VALUES
    (N'NOMBRE_NEGOCIO', N'Servicio Técnico Digitalandia', N'Nombre comercial que aparece en encabezados y recibos'),
    (N'DIRECCION_NEGOCIO', N'Av. Tecnológico #100, Pachuca, Hgo.', N'Dirección física del taller'),
    (N'TELEFONO_NEGOCIO', N'771-555-0199', N'Teléfono de atención al cliente'),
    (N'IVA_PORCENTAJE', N'16', N'Porcentaje de impuesto al valor agregado'),
    (N'DIAS_GARANTIA_DEFAULT', N'30', N'Días naturales de garantía en reparaciones');
END
GO
