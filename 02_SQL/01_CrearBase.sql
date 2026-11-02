-- Ejecutar primero desde SQL Server Management Studio con permisos para crear bases de datos.
USE master;
GO

-- Crear la base de datos solo si todavía no existe.
IF DB_ID(N'ServicioTecnicoBD') IS NULL
    CREATE DATABASE ServicioTecnicoBD;
GO

-- Seleccionar la base de datos que utilizarán los scripts siguientes.
USE ServicioTecnicoBD;
GO
