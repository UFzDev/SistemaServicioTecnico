USE ServicioTecnicoBD;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Crear roles de base de datos en SQL Server

IF DATABASE_PRINCIPAL_ID('Rol_Administrador') IS NULL
    CREATE ROLE Rol_Administrador;
GO

IF DATABASE_PRINCIPAL_ID('Rol_Supervisor') IS NULL
    CREATE ROLE Rol_Supervisor;
GO

IF DATABASE_PRINCIPAL_ID('Rol_Operador') IS NULL
    CREATE ROLE Rol_Operador;
GO

IF DATABASE_PRINCIPAL_ID('Rol_Tecnico') IS NULL
    CREATE ROLE Rol_Tecnico;
GO

IF DATABASE_PRINCIPAL_ID('Rol_Consulta') IS NULL
    CREATE ROLE Rol_Consulta;
GO

-- 2. Permisos para Rol_Consulta (Solo lectura general)
GRANT SELECT ON SCHEMA::dbo TO Rol_Consulta;
DENY SELECT ON dbo.Auditoria TO Rol_Consulta;
DENY SELECT ON dbo.Usuario TO Rol_Consulta;
GO

-- 3. Permisos para Rol_Tecnico (Diagnostico, reparacion y consumo de refacciones)
GRANT SELECT ON SCHEMA::dbo TO Rol_Tecnico;
GRANT UPDATE (DiagnosticoGeneral, FallaReportada) ON dbo.OrdenServicio TO Rol_Tecnico;
GRANT INSERT, UPDATE ON dbo.DetalleOrdenServicio TO Rol_Tecnico;
GRANT INSERT, UPDATE ON dbo.OrdenRefaccion TO Rol_Tecnico;
GRANT INSERT ON dbo.HistorialEstadoOrden TO Rol_Tecnico;

-- Denegar acceso a finanzas, compras, auditoria y seguridad
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.Pago TO Rol_Tecnico;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.Compra TO Rol_Tecnico;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.DetalleCompra TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.Cliente TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.Rol TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.Usuario TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.UsuarioRol TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.Configuracion TO Rol_Tecnico;
DENY INSERT, UPDATE, DELETE ON dbo.Auditoria TO Rol_Tecnico;
GO

-- 4. Permisos para Rol_Operador (Recepcion, atencion a clientes, caja y ventas)
GRANT SELECT ON SCHEMA::dbo TO Rol_Operador;
GRANT INSERT, UPDATE ON dbo.Cliente TO Rol_Operador;
GRANT INSERT, UPDATE ON dbo.Equipo TO Rol_Operador;
GRANT INSERT, UPDATE (IdCliente, IdEquipo, FallaReportada, Observaciones, IdEstadoOrden, FechaEntrega) ON dbo.OrdenServicio TO Rol_Operador;
GRANT INSERT, UPDATE ON dbo.VentaRefaccion TO Rol_Operador;
GRANT INSERT, UPDATE ON dbo.DetalleVenta TO Rol_Operador;
GRANT INSERT ON dbo.Pago TO Rol_Operador;
GRANT INSERT ON dbo.HistorialEstadoOrden TO Rol_Operador;

DENY INSERT, UPDATE, DELETE ON dbo.Rol TO Rol_Operador;
DENY INSERT, UPDATE, DELETE ON dbo.Usuario TO Rol_Operador;
DENY INSERT, UPDATE, DELETE ON dbo.UsuarioRol TO Rol_Operador;
DENY INSERT, UPDATE, DELETE ON dbo.Configuracion TO Rol_Operador;
DENY INSERT, UPDATE, DELETE ON dbo.Auditoria TO Rol_Operador;
DENY INSERT, UPDATE, DELETE ON dbo.Compra TO Rol_Operador;
GO

-- 5. Permisos para Rol_Supervisor (Supervision tecnica, autorizaciones, compras y reportes)
GRANT SELECT ON SCHEMA::dbo TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.Cliente TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.Equipo TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.OrdenServicio TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.DetalleOrdenServicio TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.OrdenTecnico TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.OrdenRefaccion TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.Compra TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.DetalleCompra TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.VentaRefaccion TO Rol_Supervisor;
GRANT INSERT, UPDATE ON dbo.DetalleVenta TO Rol_Supervisor;
GRANT INSERT ON dbo.Pago TO Rol_Supervisor;
GRANT INSERT ON dbo.HistorialEstadoOrden TO Rol_Supervisor;
GRANT UPDATE ON dbo.Inventario TO Rol_Supervisor;

DENY INSERT, UPDATE, DELETE ON dbo.Rol TO Rol_Supervisor;
DENY INSERT, UPDATE, DELETE ON dbo.Usuario TO Rol_Supervisor;
DENY INSERT, UPDATE, DELETE ON dbo.UsuarioRol TO Rol_Supervisor;
DENY INSERT, UPDATE, DELETE ON dbo.Auditoria TO Rol_Supervisor;
GO

-- 6. Permisos para Rol_Administrador (Control total del esquema dbo)
GRANT CONTROL ON SCHEMA::dbo TO Rol_Administrador;
GO

-- 7. Usuarios de prueba para verificar los roles en SQL Server

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'usr_consulta')
    CREATE USER usr_consulta WITHOUT LOGIN;
GO
ALTER ROLE Rol_Consulta ADD MEMBER usr_consulta;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'usr_tecnico')
    CREATE USER usr_tecnico WITHOUT LOGIN;
GO
ALTER ROLE Rol_Tecnico ADD MEMBER usr_tecnico;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'usr_operador')
    CREATE USER usr_operador WITHOUT LOGIN;
GO
ALTER ROLE Rol_Operador ADD MEMBER usr_operador;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'usr_supervisor')
    CREATE USER usr_supervisor WITHOUT LOGIN;
GO
ALTER ROLE Rol_Supervisor ADD MEMBER usr_supervisor;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'usr_admin')
    CREATE USER usr_admin WITHOUT LOGIN;
GO
ALTER ROLE Rol_Administrador ADD MEMBER usr_admin;
GO
