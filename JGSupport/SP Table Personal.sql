use JGSupport;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_upd')
DROP PROCEDURE personal_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_sel_max_id_personal')
DROP PROCEDURE personal_sel_max_id_personal
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_sel_by_id')
DROP PROCEDURE personal_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_sel_all')
DROP PROCEDURE personal_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_ins')
DROP PROCEDURE personal_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_del')
DROP PROCEDURE personal_del
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_login')
DROP PROCEDURE personal_login
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'personal_id')
DROP PROCEDURE personal_id
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE personal_sel_max_id_personal
AS
BEGIN
	SELECT MAX(id_personal) FROM Personal
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE personal_ins
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Mail varchar(50),
	@Telefono varchar(50),
	@Contraseña varchar(50),
	@Activo bit,
	@id_privilegio int
	AS
BEGIN
	INSERT INTO Personal 
            (Nombre, Apellido, Mail, Telefono, Contraseña, Activo, id_privilegio) 
    VALUES 
           (@Nombre, @Apellido, @Mail, @Telefono, @Contraseña, @Activo, @id_privilegio) 
END

GO

/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE personal_upd
	@id_personal int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Mail varchar(50),
	@Telefono varchar(50),
	@Contraseña varchar(50),
	@Activo bit,
	@id_Privilegio int
AS
BEGIN
	UPDATE Personal
	SET  
		Nombre = @Nombre, 
		Apellido = @Apellido,
		Mail = @Mail,
		Telefono = @Telefono,
		Contraseña = @Contraseña,
		Activo = @Activo,
		id_privilegio = @id_privilegio    
		                           
	 WHERE id_personal = @id_personal
END

GO

/***
* Descripción: Selecciona un registro de la tabla Socio por su clave primaria (primary key).
***/
CREATE PROCEDURE [personal_sel_by_id]
	@id_personal int
AS
BEGIN
	SELECT * FROM Personal WHERE id_personal = @id_personal
END

GO


CREATE  PROCEDURE [personal_login]
	@mail VARCHAR(50),
	@contraseña VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @PersonalId INT, @Activo BIT, @Privilegio INT

	SELECT @PersonalId = id_personal, @Activo = activo, @Privilegio = id_privilegio FROM Personal WHERE @mail = mail  AND @contraseña = contraseña  

	IF @PersonalId IS NOT NULL
	BEGIN

	IF @Activo = 1
		BEGIN
			SELECT  @Privilegio [id_privilegio] -- User Valid
		END
		ELSE
		BEGIN
			SELECT -2 -- User not activated.
		END
	END
	ELSE
	BEGIN
		SELECT -1 -- User invalid.
	END
END
GO


CREATE  PROCEDURE [personal_id]
	@mail VARCHAR(50),
	@contraseña VARCHAR(50)
AS
BEGIN

	DECLARE @PersonalId INT

	SELECT @PersonalId = id_personal FROM Personal WHERE @mail = mail AND @contraseña = contraseña  
		
	SELECT @PersonalId [id_personal] -- User Valid

END
GO


/***
* Descripción: Selecciona todos los registros de la tabla Socios.
***/
CREATE PROCEDURE personal_sel_all
AS
BEGIN
	SELECT * FROM Personal ORDER BY id_personal ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE personal_del
	@id_personal int
AS
BEGIN
	DELETE FROM Personal WHERE id_personal = @id_personal
END
GO