-- ============================================================================
-- SCRIPT 01: Crear Base de Datos y Configurar Permisos
-- Proyecto: SistemaServicioTecnico
-- ============================================================================

-- 1. Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ServicioTecnicoBD')
BEGIN
    CREATE DATABASE ServicioTecnicoBD;
END
GO

-- 2. Asegurar que tu usuario de Windows tenga acceso total a la base
USE ServicioTecnicoBD;
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'LOQ-Uriel\borer')
BEGIN
    CREATE USER [LOQ-Uriel\borer] FOR LOGIN [LOQ-Uriel\borer];
END
GO

ALTER ROLE db_owner ADD MEMBER [LOQ-Uriel\borer];
GO
