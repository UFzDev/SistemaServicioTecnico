# 04 Evidencias

Esta carpeta almacena capturas de pantalla, pruebas de ejecución y resultados de validación de entrega conforme a las Secciones 17 y 20 de `ProyectoFinal8Semanas.docx`.

## Estructura

- **`capturas/sql/`**: Resultados de ejecución real contra `ServicioTecnicoBD_Temp` (SQL Server 2025) mostrando instrucción SQL y resultado:
  - `01_verificar_esquema.txt` y `02_resultados_12_pruebas.txt`: Salidas completas de `03_VerificarEsquema.sql` y `12_Pruebas.sql`.
  - `01_esquema_conteo_objetos.png`: Conteo de 30 tablas, 44 FK, 39 CHECK y 20 UNIQUE.
  - `02_validacion_check_cliente.png`: Violación de `CK_Cliente_Nombre` (error 547).
  - `03_validacion_check_precio.png`: Violación de `CK_Servicio_PrecioBase` (error 547).
  - `04_validacion_unique_sku.png`: Violación de `UQ_Refaccion_SKU` (error 2627).
  - `05_validacion_fk_equipo_cliente.png`: Violación de `FK_Orden_EquipoCliente` (error 547).
  - `06_funciones_escalares.png`: `fn_CostoTotalOrden`, `fn_SaldoPendienteOrden`, `fn_DiasGarantiaRestantes`, `fn_ClasificacionCliente`.
  - `07_vistas_operativas_analiticas.png`: `vw_InventarioStockAlerta` y `vw_ReporteIngresosMensuales`.
  - `08_transaccion_cancelacion_reintegro.png`: `usp_Tx_CancelarOrdenServicio` con reintegro de stock y `ROLLBACK`.
  - `09_transaccion_rollback_sin_stock.png`: `usp_Tx_RegistrarVentaMostrador` con stock insuficiente (error 50031).
  - `10_seguridad_roles_denegado.png`: `EXECUTE AS USER = 'usr_consulta'` sobre `dbo.Auditoria` (error 229).
  - `11_trigger_auditoria_update.png`: `UPDATE dbo.Refaccion` disparando trigger y registro en `dbo.Auditoria`.
- **`capturas/winforms/`**: Capturas de pantalla de los 14 módulos de Windows Forms y control de acceso por rol:
  - `01_login.png`: Pantalla de acceso al sistema (`FrmLogin`).
  - `02_menu_dashboard_admin.png`: Menú principal y dashboard con rol Administrador.
  - `03_ordenes_servicio.png`: Proceso principal maestro-detalle (`FrmOrdenServicio`).
  - `04_clientes.png`: Gestión de clientes (`FrmClientes`).
  - `05_ajustes_cancelaciones.png`: Cancelaciones y ajustes (`FrmAjustes`).
  - `06_historial_busquedas.png`: Historial y búsquedas combinadas (`FrmHistorial`).
  - `07_servicios.png`: Catálogo de servicios (`FrmServicios`).
  - `08_refacciones.png`: Catálogo e inventario de refacciones (`FrmRefacciones`).
  - `09_catalogos_base.png`: Catálogos base (`FrmCatalogosBase`).
  - `10_ventas_refacciones.png`: Proceso secundario de ventas (`FrmVentas`).
  - `11_compras_proveedores.png`: Compras y proveedores (`FrmCompras`).
  - `12_reportes_analiticos.png`: Visor de reportes analíticos (`FrmReportes`).
  - `13_auditoria.png`: Visor de auditoría (`FrmAuditoria`).
  - `14_usuarios_roles.png`: Administración de usuarios y roles (`FrmUsuarios`).
  - `15_menu_rol_tecnico_restringido.png`: Menú principal con rol `Tecnico` evidenciando restricción de módulos.
- **[Demo completa del Sistema de Gestión de Servicio Técnico](video_demo/Demo-completa-Servicio-Tecnico.mp4)** (MP4, 3 min 10 s). Sigue el caso de Mariana Luna desde el registro de su equipo hasta la entrega de la orden `ORD-2026-0026` y su verificación en el historial. Cierra con un recorrido por los módulos y conserva la narración de Dalia y los acercamientos de ambas grabaciones.
- [Video demo del Sistema de Gestión de Servicio Técnico](video_demo/SistemaServicioTecnico-demo.mp4) (MP4, 47 segundos). Grabación de la aplicación en ejecución con narración en español y acercamientos al panel del taller, clientes, órdenes de servicio e historial.
- [Recepción de un equipo y seguimiento por folio](video_demo/Recepcion-y-seguimiento.mp4) (MP4, 1 min 23 s). Demostración narrada del registro de Mariana Luna y su Lenovo ThinkPad E14, la creación de la orden `ORD-2026-0026` y su búsqueda en el historial.
- [Del diagnóstico a la entrega](video_demo/Diagnostico-entrega-y-modulos.mp4). Continuación de la orden `ORD-2026-0026`. Muestra el diagnóstico, los cambios de estado, la entrega y su verificación en el historial. Cierra con un recorrido por los módulos del taller, catálogos, operaciones y administración.
