CREATE DATABASE FabricaPro
go
USE FabricaPro
go
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Proyect_Recursos_Poyectos]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Projects_Resources] DROP CONSTRAINT [FK_Proyect_Recursos_Poyectos]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Proyect_Recursos_RecursosHumanos]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Projects_Resources] DROP CONSTRAINT [FK_Proyect_Recursos_RecursosHumanos]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Projects]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Projects]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Projects_Resources]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Projects_Resources]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Human_Resources]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Human_Resources]
;

CREATE TABLE [Projects]
(
	[Pro_ID] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(100) NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL,
	[ProyectLeader] varchar(100),
	[IsActive] bit not null
)
;

CREATE TABLE [Projects_Resources]
(
	[Pro_ID] int,
	[Rec_ID] int
)
;

CREATE TABLE [Human_Resources]
(
	[Rec_ID] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(100) NOT NULL,
	[LastName] varchar(100) NOT NULL,
	[Position] varchar(100) NOT NULL,
	[Email] varchar(150) NOT NULL,
	[IsActive] bit NOT NULL
)
;

ALTER TABLE [Projects] 
 ADD CONSTRAINT [PK_Poyectos]
	PRIMARY KEY CLUSTERED ([Pro_ID])
;

CREATE INDEX [IXFK_Proyect_Recursos_Poyectos] 
 ON [Projects_Resources] ([Pro_ID] ASC)
;

CREATE INDEX [IXFK_Proyect_Recursos_RecursosHumanos] 
 ON [Projects_Resources] ([Rec_ID] ASC)
;

ALTER TABLE [Human_Resources] 
 ADD CONSTRAINT [PK_RecursosHumanos]
	PRIMARY KEY CLUSTERED ([Rec_ID])
;

ALTER TABLE [Projects_Resources] ADD CONSTRAINT [FK_Proyect_Recursos_Poyectos]
	FOREIGN KEY ([Pro_ID]) REFERENCES [Projects] ([Pro_ID]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Projects_Resources] ADD CONSTRAINT [FK_Proyect_Recursos_RecursosHumanos]
	FOREIGN KEY ([Rec_ID]) REFERENCES [Human_Resources] ([Rec_ID]) ON DELETE No Action ON UPDATE No Action
;
