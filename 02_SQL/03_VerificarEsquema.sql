USE ServicioTecnicoBD;
GO

-- Resumen general de tablas y restricciones definidas por el usuario.
SELECT COUNT(*) AS TotalTablas FROM sys.tables WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalClavesForaneas FROM sys.foreign_keys WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalCheckConstraints FROM sys.check_constraints WHERE is_ms_shipped = 0;
SELECT COUNT(*) AS TotalUniqueConstraints FROM sys.key_constraints WHERE type = 'UQ';

-- Mostrar el número de columnas de cada tabla del esquema.
SELECT t.name AS Tabla, COUNT(c.column_id) AS Columnas
FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id
WHERE t.is_ms_shipped = 0 GROUP BY t.name ORDER BY t.name;
GO
