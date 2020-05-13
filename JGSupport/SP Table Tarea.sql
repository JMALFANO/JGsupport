use JGSupport;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_upd')
DROP PROCEDURE tarea_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_sel_max_id_tarea')
DROP PROCEDURE tarea_sel_max_id_tarea
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_sel_by_id')
DROP PROCEDURE tarea_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_sel_all')
DROP PROCEDURE tarea_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_ins')
DROP PROCEDURE tarea_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'tarea_del')
DROP PROCEDURE tarea_del
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE tarea_sel_max_id_tarea
AS
BEGIN
	SELECT MAX(id_tarea) FROM Tarea
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE tarea_ins
	@id_solicitud int,
	@id_cliente int,
	@modo_solucion int, 
	@reporte varchar(250),
	@tecnico_asignado int,
	@Fecha date,
	@hora_inicio time,
	@hora_fin time
	AS
BEGIN
	INSERT INTO Tarea 
            (id_solicitud, id_cliente, Modo_Solucion, Reporte, Tecnico_Asignado, Fecha, Hora_Inicio, Hora_Fin) 
    VALUES 
			(@id_solicitud, @id_cliente, @Modo_Solucion, @Reporte, @Tecnico_Asignado, @Fecha, @Hora_Inicio, @Hora_Fin) 
END

GO

/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE tarea_upd
	@id_tarea int,
	@id_solicitud int,
	@id_cliente int,
	@modo_solucion int, 
	@reporte varchar(250),
	@tecnico_asignado int,
	@Fecha date,
	@hora_inicio time,
	@hora_fin time
AS
BEGIN
	UPDATE Tarea
	SET  
		id_solicitud = @id_solicitud, 
		id_cliente = @id_cliente, 
		Modo_Solucion = @Modo_Solucion,
		Reporte = @Reporte,
		Tecnico_Asignado = @Tecnico_Asignado,
		Fecha = @Fecha,
		Hora_Inicio = @Hora_Inicio,
		Hora_Fin = @Hora_Fin                                 
	WHERE id_tarea = @id_tarea
END

GO

/***
* Descripción: Selecciona un registro de la tabla Socio por su clave primaria (primary key).
***/
CREATE PROCEDURE [tarea_sel_by_id]
	@id_tarea int
AS
BEGIN
	SELECT * FROM Tarea WHERE id_tarea = @id_tarea
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Socios.
***/
CREATE PROCEDURE tarea_sel_all
AS
BEGIN
	SELECT * FROM Tarea ORDER BY id_tarea ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE tarea_del
	@id_tarea int
AS
BEGIN
	DELETE FROM Tarea WHERE id_tarea = @id_tarea
END
GO