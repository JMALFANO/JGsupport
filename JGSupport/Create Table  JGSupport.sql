use JGSupport;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Personal')
DROP TABLE Personal
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Privilegio')
DROP TABLE Privilegio
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Solicitud')
DROP TABLE Solicitud
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Tarea')
DROP TABLE Tarea
GO

CREATE TABLE [dbo].[Personal] (
    [id_personal] INT  IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR (50) NOT NULL,
	[apellido]  VARCHAR (50) NULL,
	[mail]  VARCHAR (50) NULL,
    [telefono]  VARCHAR (50) NULL,
	[contraseña]  VARCHAR (50) NULL,
	[activo] BIT NULL,
	[id_privilegio] INT NULL,

  PRIMARY KEY CLUSTERED ([id_personal] ASC)
);


CREATE TABLE [dbo].[Privilegio] (
    [id_privilegio] INT IDENTITY(1,1) NOT NULL,
	[privilegio_desc] VARCHAR(50) NULL, 
    [rol_privilegio] INT NULL,

    PRIMARY KEY CLUSTERED ([id_privilegio] ASC)
	)

CREATE TABLE [dbo].[Solicitud] (
    [id_solicitud] INT IDENTITY(1,1) NOT NULL,
	[fecha_inicio] DATE NULL, 
	[fecha_fin] DATE NULL,
    [tecnico_asignado] int NULL,
    [id_cliente] INT NULL,
    [descripcion_tarea] VARCHAR(1000) NULL,
	[estado] INT NULL,
	[prioridad] INT NULL,
	[complejidad] INT NULL,

    PRIMARY KEY CLUSTERED ([id_solicitud] ASC)
	);

	CREATE TABLE [dbo].[Tarea] (
    [id_tarea] INT IDENTITY(1,1) NOT NULL,
	[id_solicitud] INT NULL,
	[id_cliente] INT NULL,
	[modo_solucion] INT NULL,
	[reporte] VARCHAR(1000) NULL,
	[tecnico_asignado] INT NULL,
	[fecha] DATE NULL,
	[hora_inicio] TIME NULL,
	[hora_fin] TIME NULL,

    PRIMARY KEY CLUSTERED ([id_tarea] ASC)
	);


	