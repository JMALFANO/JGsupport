use JGSupport;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_upd')
DROP PROCEDURE solicitud_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_sel_max_id_solicitud')
DROP PROCEDURE solicitud_sel_max_id_solicitud
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_sel_by_id')
DROP PROCEDURE solicitud_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_sel_by_form')
DROP PROCEDURE solicitud_sel_by_form
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_finalizar')
DROP PROCEDURE solicitud_finalizar
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_sel_all')
DROP PROCEDURE solicitud_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_ins')
DROP PROCEDURE solicitud_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'solicitud_del')
DROP PROCEDURE solicitud_del
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE solicitud_sel_max_id_solicitud
AS
BEGIN
	SELECT MAX(id_solicitud) FROM Solicitud
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE solicitud_ins
	@fecha_inicio date,
	@fecha_fin date,
	@tecnico_asignado int,	
	@id_cliente int,
	@descripcion_tarea varchar(250),
	@estado int,
	@prioridad int,
	@complejidad int
	AS
BEGIN
	INSERT INTO Solicitud 
            (fecha_inicio, fecha_fin, tecnico_asignado, id_cliente, descripcion_tarea, estado, prioridad, complejidad) 
    VALUES 
		    (@fecha_inicio, @fecha_fin, @tecnico_asignado, @id_cliente, @descripcion_tarea, @estado, @prioridad, @complejidad) 
END

GO

CREATE PROCEDURE solicitud_finalizar
@id_solicitud int,
@fecha_fin date,
@estado int
AS
BEGIN
	UPDATE solicitud
	SET
	fecha_fin = @fecha_fin,
	estado = @estado
	WHERE id_solicitud = @id_solicitud
END 

GO
/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE solicitud_upd
	@id_solicitud int,
	@tecnico_asignado int,	
	@id_cliente int,
	@descripcion_tarea varchar(250),
	@estado int,
	@prioridad int,
	@complejidad int
AS
BEGIN
	UPDATE solicitud
	SET  
	Tecnico_Asignado = @tecnico_asignado,	
	id_Cliente = @id_cliente,
	Descripcion_Tarea = @descripcion_tarea,
	Estado = @estado,
	Prioridad = @prioridad,
	Complejidad = @complejidad                     
	WHERE id_solicitud = @id_solicitud
END

GO

/***
* Descripción: Selecciona un registro de la tabla Socio por su clave primaria (primary key).
***/
CREATE PROCEDURE [solicitud_sel_by_id]
	@id_solicitud int
AS
BEGIN
	SELECT * FROM solicitud WHERE id_solicitud = @id_solicitud
END

GO

CREATE PROCEDURE [solicitud_sel_by_form]
	@fecha_desde date,
	@fecha_hasta date
AS
BEGIN

select * from Solicitud where fecha_inicio >= @fecha_desde
   and fecha_fin < dateadd(day, 1, @fecha_hasta);
END

GO


/***
* Descripción: Selecciona todos los registros de la tabla Socios.
***/
CREATE PROCEDURE solicitud_sel_all
AS
BEGIN
	SELECT * FROM solicitud ORDER BY id_solicitud ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE solicitud_del
	@id_solicitud int
AS
BEGIN
	DELETE FROM solicitud WHERE id_solicitud = @id_solicitud
END
GO