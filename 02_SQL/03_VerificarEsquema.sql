USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Alteraciones evolutivas sobre el esquema (ALTER TABLE)

-- Alteracion 1: Validar que el nombre de marca no sea una cadena vacia.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Marca_NombreNoVacio')
    ALTER TABLE dbo.Marca ADD CONSTRAINT CK_Marca_NombreNoVacio CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0);
GO

-- Alteracion 2: Validar que el nombre del tipo de equipo no sea una cadena vacia.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_TipoEquipo_NombreNoVacio')
    ALTER TABLE dbo.TipoEquipo ADD CONSTRAINT CK_TipoEquipo_NombreNoVacio CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0);
GO

-- Alteracion 3: Validar que el nombre de proveedor no sea una cadena vacia.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedor_NombreNoVacio')
    ALTER TABLE dbo.Proveedor ADD CONSTRAINT CK_Proveedor_NombreNoVacio CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0);
GO

-- Alteracion 4: Validar que la longitud minima del RFC del proveedor sea de 12 o 13 caracteres cuando se capture.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedor_LongitudRFC')
    ALTER TABLE dbo.Proveedor ADD CONSTRAINT CK_Proveedor_LongitudRFC CHECK (RFC IS NULL OR LEN(LTRIM(RTRIM(RFC))) BETWEEN 12 AND 13);
GO

-- Alteracion 5: Validar que el modelo del equipo no quede en blanco.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Equipo_ModeloNoVacio')
    ALTER TABLE dbo.Equipo ADD CONSTRAINT CK_Equipo_ModeloNoVacio CHECK (LEN(LTRIM(RTRIM(Modelo))) > 0);
GO

-- Alteracion 6: Validar que el nombre de usuario tenga al menos 3 caracteres.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuario_LongitudMinima')
    ALTER TABLE dbo.Usuario ADD CONSTRAINT CK_Usuario_LongitudMinima CHECK (LEN(LTRIM(RTRIM(NombreUsuario))) >= 3);
GO

-- Alteracion 7: Validar que el folio de la orden de servicio no este vacio.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_OrdenServicio_FolioNoVacio')
    ALTER TABLE dbo.OrdenServicio ADD CONSTRAINT CK_OrdenServicio_FolioNoVacio CHECK (LEN(LTRIM(RTRIM(Folio))) > 0);
GO

-- Alteracion 8: Validar que la falla reportada tenga contenido descriptivo.
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_OrdenServicio_FallaNoVacia')
    ALTER TABLE dbo.OrdenServicio ADD CONSTRAINT CK_OrdenServicio_FallaNoVacia CHECK (LEN(LTRIM(RTRIM(FallaReportada))) > 0);
GO

-- 2. Verificacion del esquema y conteo de objetos

-- Resumen general de tablas y restricciones definidas por el usuario.
SELECT COUNT(*) AS TotalTablas FROM sys.tables WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalClavesForaneas FROM sys.foreign_keys WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalCheckConstraints FROM sys.check_constraints WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalUniqueConstraints FROM sys.key_constraints WHERE type = 'UQ';

-- Mostrar el numero de columnas de cada tabla del esquema.
SELECT t.name AS Tabla, COUNT(c.column_id) AS Columnas
FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id
WHERE t.is_ms_shipped = 0 GROUP BY t.name ORDER BY t.name;
GO
