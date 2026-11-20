/* Ejecutar primero desde SQL Server Management Studio. */
USE master;
GO

IF DB_ID(N'ServicioTecnicoBD') IS NULL
    CREATE DATABASE ServicioTecnicoBD;
GO

-- Ejecutar este script antes de crear las tablas del sistema.
USE ServicioTecnicoBD;
GO
