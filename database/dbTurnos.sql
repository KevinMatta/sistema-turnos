CREATE DATABASE dbTurnos
GO
USE dbTurnos
GO
CREATE SCHEMA [Acce]
GO

CREATE SCHEMA [Gene]
GO

CREATE SCHEMA [Turn]
GO

CREATE TABLE [Acce].[tbUsuarios] (
  [Usua_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Usua_Usuario] varchar(50) NOT NULL,
  [Usua_Clave] varbinary(max),
  [Rol_Id] int,
  [Usua_IsAdmin] bit,
  [Usua_Estado] bit DEFAULT (1),
  [Usua_Creacion] int NOT NULL,
  [Usua_FechaCreacion] datetime NOT NULL,
  [Usua_Modificacion] int,
  [Usua_FechaModificacion] datetime
)
GO

CREATE TABLE [Acce].[tbRoles] (
  [Rol_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Rol_Descripcion] varchar(50) NOT NULL,
  [Rol_Estado] bit DEFAULT (1),
  [Rol_Creacion] int NOT NULL,
  [Rol_FechaCreacion] datetime NOT NULL,
  [Rol_Modificacion] int,
  [Rol_FechaModificacion] datetime
)
GO

CREATE TABLE [Acce].[tbPantallas] (
  [Pant_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Pant_Descripcion] varchar(50) NOT NULL,
  [Pant_Estado] bit DEFAULT (1),
  [Pant_Creacion] int NOT NULL,
  [Pant_FechaCreacion] datetime NOT NULL,
  [Pant_Modificacion] int,
  [Pant_FechaModificacion] datetime
)
GO

CREATE TABLE [Acce].[tbPantallasPorRoles] (
  [PaRo_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Pant_Id] int NOT NULL,
  [Rol_Id] int NOT NULL,
  [PaRo_Estado] bit DEFAULT (1),
  [PaRo_Creacion] int NOT NULL,
  [PaRo_FechaCreacion] datetime NOT NULL,
  [PaRo_Modificacion] int,
  [PaRo_FechaModificacion] datetime
)
GO

CREATE TABLE [Gene].[tbEstados] (
  [Esta_Id] varchar(2) PRIMARY KEY,
  [Esta_Descripcion] varchar(50) NOT NULL,
  [Esta_Estado] bit DEFAULT (1),
  [Esta_Creacion] int NOT NULL,
  [Esta_FechaCreacion] datetime NOT NULL,
  [Esta_Modificacion] int,
  [Esta_FechaModificacion] datetime
)
GO

CREATE TABLE [Gene].[tbCiudades] (
  [Ciud_Id] varchar(4) PRIMARY KEY,
  [Ciud_Descripcion] varchar(50) NOT NULL,
  [Esta_Id] varchar(2) NOT NULL,
  [Ciud_Estado] bit DEFAULT (1),
  [Ciud_Creacion] int NOT NULL,
  [Ciud_FechaCreacion] datetime NOT NULL,
  [Ciud_Modificacion] int,
  [Ciud_FechaModificacion] datetime
)
GO

CREATE TABLE [Gene].[tbEstadosCiviles] (
  [EsCi_Id] int PRIMARY KEY IDENTITY(1, 1),
  [EsCi_Descripcion] varchar(50) NOT NULL,
  [EsCi_Estado] bit DEFAULT (1),
  [EsCi_Creacion] int NOT NULL,
  [EsCi_FechaCreacion] datetime NOT NULL,
  [EsCi_Modificacion] int,
  [EsCi_FechaModificacion] datetime
)
GO

CREATE TABLE [Gene].[tbPersonas] (
  [Pers_Identidad] varchar(13) PRIMARY KEY,
  [Pers_PrimerNombre] varchar(50) NOT NULL,
  [Pers_SegundoNombre] varchar(50),
  [Pers_PrimerApellido] varchar(50) NOT NULL,
  [Pers_SegundoApellido] varchar(50),
  [EsCi_Id] int NOT NULL,
  [Pers_Sexo] char(1) NOT NULL,
  [Pers_Estado] bit DEFAULT (1),
  [Pers_Creacion] int NOT NULL,
  [Pers_FechaCreacion] datetime NOT NULL,
  [Pers_Modificacion] int,
  [Pers_FechaModificacion] datetime
)
GO

CREATE TABLE [Gene].[tbCargos] (
  [Carg_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Carg_Descripcion] varchar(50) NOT NULL,
  [Carg_Estado] bit DEFAULT (1),
  [Carg_Creacion] int NOT NULL,
  [Carg_FechaCreacion] datetime NOT NULL,
  [Carg_Modificacion] int,
  [Carg_FechaModificacion] datetime
)
GO

CREATE TABLE [Turn].[tbHospitales] (
  [Hosp_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Hosp_Descripcion] varchar(50) NOT NULL,
  [Hosp_Direccion] varchar(50) NOT NULL,
  [Ciud_Id] varchar(4) NOT NULL,
  [Hosp_Estado] bit DEFAULT (1),
  [Hosp_Creacion] int NOT NULL,
  [Hosp_FechaCreacion] datetime NOT NULL,
  [Hosp_Modificacion] int,
  [Hosp_FechaModificacion] datetime
)
GO

CREATE TABLE [Turn].[tbEmpleados] (
  [Empl_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Pers_Identidad] varchar(13) NOT NULL,
  [Usua_Id] int,
  [Carg_Id] int,
  [Hosp_Id] int,
  [Empl_Estado] bit DEFAULT (1),
  [Empl_Creacion] int NOT NULL,
  [Empl_FechaCreacion] datetime NOT NULL,
  [Empl_Modificacion] int,
  [Empl_FechaModificacion] datetime
)
GO

CREATE TABLE [Turn].[tbTurnos] (
  [Turn_Id] int PRIMARY KEY IDENTITY(1, 1),
  [Turn_Descripcion] varchar(50) NOT NULL,
  [Turn_Horario] time NOT NULL,
  [Turn_Estado] bit DEFAULT (1),
  [Turn_Creacion] int NOT NULL,
  [Turn_FechaCreacion] datetime NOT NULL,
  [Turn_Modificacion] int,
  [Turn_FechaModificacion] datetime
)
GO

CREATE TABLE [Turn].[tbTurnosPorEmpleados] (
  [TuEm_Id] int PRIMARY KEY IDENTITY(1, 1),
  [TuEm_FechaInicio] date NOT NULL,
  [Turn_Id] int NOT NULL,
  [Empl_Id] int NOT NULL,
  [TuEm_Estado] bit DEFAULT (1),
  [TuEm_Creacion] int NOT NULL,
  [TuEm_FechaCreacion] datetime NOT NULL,
  [TuEm_Modificacion] int,
  [TuEm_FechaModificacion] datetime
)
GO

INSERT INTO Gene.tbEstadosCiviles (EsCi_Descripcion, EsCi_Creacion, EsCi_FechaCreacion)
VALUES  ('Soltero(a)', 1, getdate()),
		('Casado(a)', 1, getdate()),
		('Divorciado(a)', 1, getdate()),
		('Viudo(a)', 1, getdate()),
		('Union libre', 1, getdate());
GO

INSERT INTO Gene.tbPersonas (Pers_Identidad, Pers_PrimerNombre, Pers_PrimerApellido, Pers_Sexo, EsCi_Id, Pers_Creacion, Pers_FechaCreacion)
VALUES  ('0801200120525', 'Kevin', 'Membre�o', 'M', 1, 1, getdate()),
		('0512200600377', 'Madian', 'Velasquez', 'M', 1, 1, getdate())
GO

INSERT INTO Acce.tbUsuarios (Usua_Usuario, Usua_Clave, Usua_IsAdmin, Usua_Creacion, Usua_FechaCreacion)
VALUES  ('madian', HASHBYTES('SHA2_512', 'madian'), 1, 1, getdate()),
		('kevin', HASHBYTES('SHA2_512', 'kevin'), 1, 1, getdate());
GO

INSERT INTO Turn.tbEmpleados (Pers_Identidad, Usua_Id, Empl_Creacion, Empl_FechaCreacion)
VALUES	('0801200120525', 1, 1, GETDATE()),
		('0512200600377', 2, 1, GETDATE());
GO

ALTER TABLE [Acce].[tbRoles] ADD FOREIGN KEY ([Rol_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbRoles] ADD FOREIGN KEY ([Rol_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbPantallas] ADD FOREIGN KEY ([Pant_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbPantallas] ADD FOREIGN KEY ([Pant_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbPantallasPorRoles] ADD FOREIGN KEY ([Rol_Id]) REFERENCES [Acce].[tbRoles] ([Rol_Id])
GO

ALTER TABLE [Acce].[tbPantallasPorRoles] ADD FOREIGN KEY ([Pant_Id]) REFERENCES [Acce].[tbPantallas] ([Pant_Id])
GO

ALTER TABLE [Acce].[tbPantallasPorRoles] ADD FOREIGN KEY ([PaRo_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbPantallasPorRoles] ADD FOREIGN KEY ([PaRo_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbCiudades] ADD FOREIGN KEY ([Esta_Id]) REFERENCES [Gene].[tbEstados] ([Esta_Id])
GO

ALTER TABLE [Turn].[tbHospitales] ADD FOREIGN KEY ([Ciud_Id]) REFERENCES [Gene].[tbCiudades] ([Ciud_Id])
GO

ALTER TABLE [Gene].[tbPersonas] ADD FOREIGN KEY ([EsCi_Id]) REFERENCES [Gene].[tbEstadosCiviles] ([EsCi_Id])
GO

ALTER TABLE [Turn].[tbEmpleados] ADD FOREIGN KEY ([Carg_Id]) REFERENCES [Gene].[tbCargos] ([Carg_Id])
GO

ALTER TABLE [Turn].[tbEmpleados] ADD FOREIGN KEY ([Hosp_Id]) REFERENCES [Turn].[tbHospitales] ([Hosp_Id])
GO

ALTER TABLE [Turn].[tbEmpleados] ADD FOREIGN KEY ([Pers_Identidad]) REFERENCES [Gene].[tbPersonas] ([Pers_Identidad])
GO

ALTER TABLE [Turn].[tbTurnosPorEmpleados] ADD FOREIGN KEY ([Turn_Id]) REFERENCES [Turn].[tbTurnos] ([Turn_Id])
GO

ALTER TABLE [Turn].[tbTurnosPorEmpleados] ADD FOREIGN KEY ([Empl_Id]) REFERENCES [Turn].[tbEmpleados] ([Empl_Id])
GO

ALTER TABLE [Acce].[tbUsuarios] ADD FOREIGN KEY ([Usua_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Acce].[tbUsuarios] ADD FOREIGN KEY ([Usua_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbEstados] ADD FOREIGN KEY ([Esta_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbEstados] ADD FOREIGN KEY ([Esta_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbCiudades] ADD FOREIGN KEY ([Ciud_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbCiudades] ADD FOREIGN KEY ([Ciud_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbHospitales] ADD FOREIGN KEY ([Hosp_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbHospitales] ADD FOREIGN KEY ([Hosp_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbPersonas] ADD FOREIGN KEY ([Pers_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbPersonas] ADD FOREIGN KEY ([Pers_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbEstadosCiviles] ADD FOREIGN KEY ([EsCi_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbEstadosCiviles] ADD FOREIGN KEY ([EsCi_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbCargos] ADD FOREIGN KEY ([Carg_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Gene].[tbCargos] ADD FOREIGN KEY ([Carg_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbEmpleados] ADD FOREIGN KEY ([Empl_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbEmpleados] ADD FOREIGN KEY ([Empl_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbTurnos] ADD FOREIGN KEY ([Turn_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbTurnos] ADD FOREIGN KEY ([Turn_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbTurnosPorEmpleados] ADD FOREIGN KEY ([TuEm_Creacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO

ALTER TABLE [Turn].[tbTurnosPorEmpleados] ADD FOREIGN KEY ([TuEm_Modificacion]) REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
