USE [BaseTurnos]
GO
/****** Object:  User [madian]    Script Date: 1/11/2024 15:20:15 ******/
CREATE USER [madian] FOR LOGIN [madian] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [madian]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [madian]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [madian]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [madian]
GO
ALTER ROLE [db_datareader] ADD MEMBER [madian]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [madian]
GO
/****** Object:  Schema [Acce]    Script Date: 1/11/2024 15:20:15 ******/
CREATE SCHEMA [Acce]
GO
/****** Object:  Schema [Gene]    Script Date: 1/11/2024 15:20:15 ******/
CREATE SCHEMA [Gene]
GO
/****** Object:  Schema [Nadaim_SQLLogin_1]    Script Date: 1/11/2024 15:20:15 ******/
CREATE SCHEMA [Nadaim_SQLLogin_1]
GO
/****** Object:  Schema [Turn]    Script Date: 1/11/2024 15:20:15 ******/
CREATE SCHEMA [Turn]
GO
/****** Object:  Table [Acce].[tbPantallas]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acce].[tbPantallas](
	[Pant_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pant_Descripcion] [varchar](50) NOT NULL,
	[Pant_Estado] [bit] NULL,
	[Pant_Creacion] [int] NOT NULL,
	[Pant_FechaCreacion] [datetime] NOT NULL,
	[Pant_Modificacion] [int] NULL,
	[Pant_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acce].[tbPantallasPorRoles]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acce].[tbPantallasPorRoles](
	[PaRo_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pant_Id] [int] NOT NULL,
	[Rol_Id] [int] NOT NULL,
	[PaRo_Estado] [bit] NULL,
	[PaRo_Creacion] [int] NOT NULL,
	[PaRo_FechaCreacion] [datetime] NOT NULL,
	[PaRo_Modificacion] [int] NULL,
	[PaRo_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaRo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acce].[tbRoles]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acce].[tbRoles](
	[Rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_Descripcion] [varchar](50) NOT NULL,
	[Rol_Estado] [bit] NULL,
	[Rol_Creacion] [int] NOT NULL,
	[Rol_FechaCreacion] [datetime] NOT NULL,
	[Rol_Modificacion] [int] NULL,
	[Rol_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acce].[tbUsuarios]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acce].[tbUsuarios](
	[Usua_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usua_Usuario] [varchar](50) NOT NULL,
	[Usua_Clave] [varbinary](max) NULL,
	[Rol_Id] [int] NULL,
	[Usua_IsAdmin] [bit] NULL,
	[Usua_Estado] [bit] NULL,
	[Usua_Creacion] [int] NOT NULL,
	[Usua_FechaCreacion] [datetime] NOT NULL,
	[Usua_Modificacion] [int] NULL,
	[Usua_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Usua_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Gene].[tbCargos]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gene].[tbCargos](
	[Carg_Id] [int] IDENTITY(1,1) NOT NULL,
	[Carg_Descripcion] [varchar](50) NOT NULL,
	[Carg_Estado] [bit] NULL,
	[Carg_Creacion] [int] NOT NULL,
	[Carg_FechaCreacion] [datetime] NOT NULL,
	[Carg_Modificacion] [int] NULL,
	[Carg_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Carg_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gene].[tbCiudades]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gene].[tbCiudades](
	[Ciud_Id] [varchar](4) NOT NULL,
	[Ciud_Descripcion] [varchar](50) NOT NULL,
	[Esta_Id] [varchar](2) NOT NULL,
	[Ciud_Estado] [bit] NULL,
	[Ciud_Creacion] [int] NOT NULL,
	[Ciud_FechaCreacion] [datetime] NOT NULL,
	[Ciud_Modificacion] [int] NULL,
	[Ciud_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ciud_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gene].[tbEstados]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gene].[tbEstados](
	[Esta_Id] [varchar](2) NOT NULL,
	[Esta_Descripcion] [varchar](50) NOT NULL,
	[Esta_Estado] [bit] NULL,
	[Esta_Creacion] [int] NOT NULL,
	[Esta_FechaCreacion] [datetime] NOT NULL,
	[Esta_Modificacion] [int] NULL,
	[Esta_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Esta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gene].[tbEstadosCiviles]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gene].[tbEstadosCiviles](
	[EsCi_Id] [int] IDENTITY(1,1) NOT NULL,
	[EsCi_Descripcion] [varchar](50) NOT NULL,
	[EsCi_Estado] [bit] NULL,
	[EsCi_Creacion] [int] NOT NULL,
	[EsCi_FechaCreacion] [datetime] NOT NULL,
	[EsCi_Modificacion] [int] NULL,
	[EsCi_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EsCi_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Gene].[tbPersonas]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Gene].[tbPersonas](
	[Pers_Identidad] [varchar](13) NOT NULL,
	[Pers_PrimerNombre] [varchar](50) NOT NULL,
	[Pers_SegundoNombre] [varchar](50) NULL,
	[Pers_PrimerApellido] [varchar](50) NOT NULL,
	[Pers_SegundoApellido] [varchar](50) NULL,
	[EsCi_Id] [int] NOT NULL,
	[Pers_Sexo] [char](1) NOT NULL,
	[Pers_Estado] [bit] NULL,
	[Pers_Creacion] [int] NOT NULL,
	[Pers_FechaCreacion] [datetime] NOT NULL,
	[Pers_Modificacion] [int] NULL,
	[Pers_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pers_Identidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Turn].[tbEmpleados]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Turn].[tbEmpleados](
	[Empl_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pers_Identidad] [varchar](13) NOT NULL,
	[Usua_Id] [int] NULL,
	[Carg_Id] [int] NULL,
	[Hosp_Id] [int] NULL,
	[Empl_Estado] [bit] NULL,
	[Empl_Creacion] [int] NOT NULL,
	[Empl_FechaCreacion] [datetime] NOT NULL,
	[Empl_Modificacion] [int] NULL,
	[Empl_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Empl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Turn].[tbHospitales]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Turn].[tbHospitales](
	[Hosp_Id] [int] IDENTITY(1,1) NOT NULL,
	[Hosp_Descripcion] [varchar](50) NOT NULL,
	[Hosp_Direccion] [varchar](50) NOT NULL,
	[Ciud_Id] [varchar](4) NOT NULL,
	[Hosp_Estado] [bit] NULL,
	[Hosp_Creacion] [int] NOT NULL,
	[Hosp_FechaCreacion] [datetime] NOT NULL,
	[Hosp_Modificacion] [int] NULL,
	[Hosp_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Hosp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Turn].[tbTurnos]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Turn].[tbTurnos](
	[Turn_Id] [int] IDENTITY(1,1) NOT NULL,
	[Turn_Descripcion] [varchar](50) NOT NULL,
	[Turn_HoraEntrada] [time](7) NOT NULL,
	[Turn_Estado] [bit] NULL,
	[Turn_Creacion] [int] NOT NULL,
	[Turn_FechaCreacion] [datetime] NOT NULL,
	[Turn_Modificacion] [int] NULL,
	[Turn_FechaModificacion] [datetime] NULL,
	[Turn_HoraSalida] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Turn_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Turn].[tbTurnosPorEmpleados]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Turn].[tbTurnosPorEmpleados](
	[TuEm_Id] [int] IDENTITY(1,1) NOT NULL,
	[TuEm_FechaInicio] [date] NOT NULL,
	[Turn_Id] [int] NOT NULL,
	[Empl_Id] [int] NOT NULL,
	[TuEm_Estado] [bit] NULL,
	[TuEm_Creacion] [int] NOT NULL,
	[TuEm_FechaCreacion] [datetime] NOT NULL,
	[TuEm_Modificacion] [int] NULL,
	[TuEm_FechaModificacion] [datetime] NULL,
	[TuEm_HoraEntrada] [time](7) NULL,
	[TuEm_HoraSalida] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[TuEm_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Acce].[tbPantallas] ON 

INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (1, N'Roles', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (2, N'Departamento', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (3, N'Municipios', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (4, N'Usuarios', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (5, N'Turnos', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (6, N'Hospitales', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_Estado], [Pant_Creacion], [Pant_FechaCreacion], [Pant_Modificacion], [Pant_FechaModificacion]) VALUES (7, N'Cargos', 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Acce].[tbPantallas] OFF
GO
SET IDENTITY_INSERT [Acce].[tbPantallasPorRoles] ON 

INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (1, 1, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (2, 2, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (3, 3, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (4, 4, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (5, 5, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (6, 6, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
INSERT [Acce].[tbPantallasPorRoles] ([PaRo_Id], [Pant_Id], [Rol_Id], [PaRo_Estado], [PaRo_Creacion], [PaRo_FechaCreacion], [PaRo_Modificacion], [PaRo_FechaModificacion]) VALUES (7, 7, 6, 1, 1, CAST(N'2024-04-07T16:29:32.367' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Acce].[tbPantallasPorRoles] OFF
GO
SET IDENTITY_INSERT [Acce].[tbRoles] ON 

INSERT [Acce].[tbRoles] ([Rol_Id], [Rol_Descripcion], [Rol_Estado], [Rol_Creacion], [Rol_FechaCreacion], [Rol_Modificacion], [Rol_FechaModificacion]) VALUES (1, N'Depurador', 1, 1, CAST(N'2024-04-07T14:24:00.457' AS DateTime), NULL, NULL)
INSERT [Acce].[tbRoles] ([Rol_Id], [Rol_Descripcion], [Rol_Estado], [Rol_Creacion], [Rol_FechaCreacion], [Rol_Modificacion], [Rol_FechaModificacion]) VALUES (2, N'Prueba', 1, 1, CAST(N'2024-04-07T14:24:00.457' AS DateTime), NULL, NULL)
INSERT [Acce].[tbRoles] ([Rol_Id], [Rol_Descripcion], [Rol_Estado], [Rol_Creacion], [Rol_FechaCreacion], [Rol_Modificacion], [Rol_FechaModificacion]) VALUES (3, N'Prueba 2', 1, 1, CAST(N'2024-04-07T16:44:18.497' AS DateTime), NULL, NULL)
INSERT [Acce].[tbRoles] ([Rol_Id], [Rol_Descripcion], [Rol_Estado], [Rol_Creacion], [Rol_FechaCreacion], [Rol_Modificacion], [Rol_FechaModificacion]) VALUES (4, N'Prueba 2', 1, 1, CAST(N'2024-04-07T16:46:12.050' AS DateTime), NULL, NULL)
INSERT [Acce].[tbRoles] ([Rol_Id], [Rol_Descripcion], [Rol_Estado], [Rol_Creacion], [Rol_FechaCreacion], [Rol_Modificacion], [Rol_FechaModificacion]) VALUES (6, N'admin', 1, 1, CAST(N'2024-04-07T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Acce].[tbRoles] OFF
GO
SET IDENTITY_INSERT [Acce].[tbUsuarios] ON 

INSERT [Acce].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Clave], [Rol_Id], [Usua_IsAdmin], [Usua_Estado], [Usua_Creacion], [Usua_FechaCreacion], [Usua_Modificacion], [Usua_FechaModificacion]) VALUES (1, N'madian', 0x8819FE7884DAE0DA59CCCBC53D3E0EDD7AD668DCA6F40A03CB6695AC0A692D42F0AD76EB1A70D968D062BFD4E687891EB7138456CE6CCB670D2C5AC049DDD4FC, 6, 1, 1, 1, CAST(N'2024-04-02T15:09:58.493' AS DateTime), NULL, NULL)
INSERT [Acce].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Clave], [Rol_Id], [Usua_IsAdmin], [Usua_Estado], [Usua_Creacion], [Usua_FechaCreacion], [Usua_Modificacion], [Usua_FechaModificacion]) VALUES (2, N'kevin', 0x5DFE55879638E99CC14A1D4730238936207B92050EF3CD24AE64D52D773084485B55B00F835A076BDC8F8C307AB5EB183EAF332867A2B6F47557D913234F2973, 6, 1, 1, 1, CAST(N'2024-04-02T15:09:58.493' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Acce].[tbUsuarios] OFF
GO
SET IDENTITY_INSERT [Gene].[tbCargos] ON 

INSERT [Gene].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_Estado], [Carg_Creacion], [Carg_FechaCreacion], [Carg_Modificacion], [Carg_FechaModificacion]) VALUES (1, N'Enfermero/a', 1, 1, CAST(N'2024-04-04T02:59:58.473' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_Estado], [Carg_Creacion], [Carg_FechaCreacion], [Carg_Modificacion], [Carg_FechaModificacion]) VALUES (2, N'Cirujano/a', 1, 1, CAST(N'2024-04-04T02:59:58.473' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_Estado], [Carg_Creacion], [Carg_FechaCreacion], [Carg_Modificacion], [Carg_FechaModificacion]) VALUES (3, N'Anestesiólogo/a', 1, 1, CAST(N'2024-04-04T02:59:58.473' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_Estado], [Carg_Creacion], [Carg_FechaCreacion], [Carg_Modificacion], [Carg_FechaModificacion]) VALUES (4, N'Técnico/a de Laboratorio', 1, 1, CAST(N'2024-04-04T02:59:58.473' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_Estado], [Carg_Creacion], [Carg_FechaCreacion], [Carg_Modificacion], [Carg_FechaModificacion]) VALUES (5, N'Farmacéutico/a', 1, 1, CAST(N'2024-04-04T02:59:58.473' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Gene].[tbCargos] OFF
GO
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0201', N'trujillo', N'02', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0401', N'Santa Rosa de Copan', N'04', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0501', N'San Pedro Sula', N'05', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0601', N'Choluteca', N'06', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0801', N'Tegucigalpa', N'08', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'0901', N'Puerto Lempira', N'09', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
INSERT [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Estado], [Ciud_Creacion], [Ciud_FechaCreacion], [Ciud_Modificacion], [Ciud_FechaModificacion]) VALUES (N'1001', N'La Esperanza', N'10', 1, 1, CAST(N'2024-04-04T02:59:58.270' AS DateTime), NULL, NULL)
GO
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'02', N'Colon', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'04', N'Copan', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'05', N'Cortes', 1, 1, CAST(N'2024-04-03T00:49:49.137' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'06', N'Cholutecaaa', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'08', N'Francisco Morazanaa', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'09', N'Gracias a Dios', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Estado], [Esta_Creacion], [Esta_FechaCreacion], [Esta_Modificacion], [Esta_FechaModificacion]) VALUES (N'10', N'Intibuca', 1, 1, CAST(N'2024-04-04T02:59:58.170' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [Gene].[tbEstadosCiviles] ON 

INSERT [Gene].[tbEstadosCiviles] ([EsCi_Id], [EsCi_Descripcion], [EsCi_Estado], [EsCi_Creacion], [EsCi_FechaCreacion], [EsCi_Modificacion], [EsCi_FechaModificacion]) VALUES (1, N'Soltero(a)', 1, 1, CAST(N'2024-04-02T15:09:58.370' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstadosCiviles] ([EsCi_Id], [EsCi_Descripcion], [EsCi_Estado], [EsCi_Creacion], [EsCi_FechaCreacion], [EsCi_Modificacion], [EsCi_FechaModificacion]) VALUES (2, N'Casado(a)', 1, 1, CAST(N'2024-04-02T15:09:58.370' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstadosCiviles] ([EsCi_Id], [EsCi_Descripcion], [EsCi_Estado], [EsCi_Creacion], [EsCi_FechaCreacion], [EsCi_Modificacion], [EsCi_FechaModificacion]) VALUES (3, N'Divorciado(a)', 1, 1, CAST(N'2024-04-02T15:09:58.370' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstadosCiviles] ([EsCi_Id], [EsCi_Descripcion], [EsCi_Estado], [EsCi_Creacion], [EsCi_FechaCreacion], [EsCi_Modificacion], [EsCi_FechaModificacion]) VALUES (4, N'Viudo(a)', 1, 1, CAST(N'2024-04-02T15:09:58.370' AS DateTime), NULL, NULL)
INSERT [Gene].[tbEstadosCiviles] ([EsCi_Id], [EsCi_Descripcion], [EsCi_Estado], [EsCi_Creacion], [EsCi_FechaCreacion], [EsCi_Modificacion], [EsCi_FechaModificacion]) VALUES (5, N'Union libre', 1, 1, CAST(N'2024-04-02T15:09:58.370' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Gene].[tbEstadosCiviles] OFF
GO
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0320200100293', N'Mindy', NULL, N'Campos', NULL, 1, N'F', 1, 1, CAST(N'2024-04-04T02:59:58.373' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0410200101233', N'Victor', NULL, N'Campos', NULL, 1, N'M', 1, 1, CAST(N'2024-04-04T02:59:58.373' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0501200403104', N'Jason', NULL, N'Campos', NULL, 1, N'M', 1, 1, CAST(N'2024-04-04T02:59:58.373' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0512200600338', N'Alejandra', NULL, N'Solis', NULL, 1, N'F', 1, 1, CAST(N'2024-04-04T02:59:58.373' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0512200600377', N'Madian', NULL, N'Velasquez', NULL, 1, N'M', 1, 1, CAST(N'2024-04-02T15:09:58.437' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'0801200120525', N'Kevin', NULL, N'Membre?o', NULL, 1, N'M', 1, 1, CAST(N'2024-04-02T15:09:58.437' AS DateTime), NULL, NULL)
INSERT [Gene].[tbPersonas] ([Pers_Identidad], [Pers_PrimerNombre], [Pers_SegundoNombre], [Pers_PrimerApellido], [Pers_SegundoApellido], [EsCi_Id], [Pers_Sexo], [Pers_Estado], [Pers_Creacion], [Pers_FechaCreacion], [Pers_Modificacion], [Pers_FechaModificacion]) VALUES (N'1240200100004', N'Pavel', NULL, N'Campos', NULL, 1, N'M', 1, 1, CAST(N'2024-04-04T02:59:58.373' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [Turn].[tbEmpleados] ON 

INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (1, N'0801200120525', 1, NULL, NULL, 1, 1, CAST(N'2024-04-02T15:09:58.553' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (2, N'0512200600377', 2, NULL, NULL, 1, 1, CAST(N'2024-04-02T15:09:58.553' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (3, N'0320200100293', NULL, 1, 1, 1, 1, CAST(N'2024-04-04T02:59:58.670' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (4, N'0512200600338', NULL, 2, 2, 1, 1, CAST(N'2024-04-04T02:59:58.670' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (5, N'1240200100004', NULL, 3, 3, 1, 1, CAST(N'2024-04-04T02:59:58.670' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (6, N'0501200403104', NULL, 4, 4, 1, 1, CAST(N'2024-04-04T02:59:58.670' AS DateTime), NULL, NULL)
INSERT [Turn].[tbEmpleados] ([Empl_Id], [Pers_Identidad], [Usua_Id], [Carg_Id], [Hosp_Id], [Empl_Estado], [Empl_Creacion], [Empl_FechaCreacion], [Empl_Modificacion], [Empl_FechaModificacion]) VALUES (7, N'0410200101233', NULL, 5, 5, 1, 1, CAST(N'2024-04-04T02:59:58.670' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Turn].[tbEmpleados] OFF
GO
SET IDENTITY_INSERT [Turn].[tbHospitales] ON 

INSERT [Turn].[tbHospitales] ([Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Estado], [Hosp_Creacion], [Hosp_FechaCreacion], [Hosp_Modificacion], [Hosp_FechaModificacion]) VALUES (1, N'Hospital Escuela', N'Avenida La Paz', N'0801', 1, 1, CAST(N'2024-04-04T02:59:58.577' AS DateTime), NULL, NULL)
INSERT [Turn].[tbHospitales] ([Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Estado], [Hosp_Creacion], [Hosp_FechaCreacion], [Hosp_Modificacion], [Hosp_FechaModificacion]) VALUES (2, N'Hospital San Felipe', N'Calle Real', N'0501', 1, 1, CAST(N'2024-04-04T02:59:58.577' AS DateTime), NULL, NULL)
INSERT [Turn].[tbHospitales] ([Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Estado], [Hosp_Creacion], [Hosp_FechaCreacion], [Hosp_Modificacion], [Hosp_FechaModificacion]) VALUES (3, N'Hospital Mario Catarino Rivas', N'Avenida 15 de Septiembre', N'0501', 1, 1, CAST(N'2024-04-04T02:59:58.577' AS DateTime), NULL, NULL)
INSERT [Turn].[tbHospitales] ([Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Estado], [Hosp_Creacion], [Hosp_FechaCreacion], [Hosp_Modificacion], [Hosp_FechaModificacion]) VALUES (4, N'Hospital Leonardo Martínez', N'Avenida República de Honduras', N'0801', 1, 1, CAST(N'2024-04-04T02:59:58.577' AS DateTime), NULL, NULL)
INSERT [Turn].[tbHospitales] ([Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Estado], [Hosp_Creacion], [Hosp_FechaCreacion], [Hosp_Modificacion], [Hosp_FechaModificacion]) VALUES (5, N'Hospital Psiquiátrico Santa Rosita', N'Calle Principal', N'0801', 1, 1, CAST(N'2024-04-04T02:59:58.577' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Turn].[tbHospitales] OFF
GO
SET IDENTITY_INSERT [Turn].[tbTurnos] ON 

INSERT [Turn].[tbTurnos] ([Turn_Id], [Turn_Descripcion], [Turn_HoraEntrada], [Turn_Estado], [Turn_Creacion], [Turn_FechaCreacion], [Turn_Modificacion], [Turn_FechaModificacion], [Turn_HoraSalida]) VALUES (1, N'Turno A', CAST(N'07:00:00' AS Time), 1, 1, CAST(N'2024-04-04T02:59:58.770' AS DateTime), NULL, NULL, CAST(N'15:00:00' AS Time))
INSERT [Turn].[tbTurnos] ([Turn_Id], [Turn_Descripcion], [Turn_HoraEntrada], [Turn_Estado], [Turn_Creacion], [Turn_FechaCreacion], [Turn_Modificacion], [Turn_FechaModificacion], [Turn_HoraSalida]) VALUES (2, N'Turno B', CAST(N'15:00:00' AS Time), 1, 1, CAST(N'2024-04-04T02:59:58.770' AS DateTime), NULL, NULL, CAST(N'23:00:00' AS Time))
INSERT [Turn].[tbTurnos] ([Turn_Id], [Turn_Descripcion], [Turn_HoraEntrada], [Turn_Estado], [Turn_Creacion], [Turn_FechaCreacion], [Turn_Modificacion], [Turn_FechaModificacion], [Turn_HoraSalida]) VALUES (3, N'Turno C', CAST(N'23:00:00' AS Time), 1, 1, CAST(N'2024-04-04T02:59:58.770' AS DateTime), NULL, NULL, CAST(N'07:00:00' AS Time))
SET IDENTITY_INSERT [Turn].[tbTurnos] OFF
GO
SET IDENTITY_INSERT [Turn].[tbTurnosPorEmpleados] ON 

INSERT [Turn].[tbTurnosPorEmpleados] ([TuEm_Id], [TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Estado], [TuEm_Creacion], [TuEm_FechaCreacion], [TuEm_Modificacion], [TuEm_FechaModificacion], [TuEm_HoraEntrada], [TuEm_HoraSalida]) VALUES (1, CAST(N'2024-04-04' AS Date), 1, 3, 1, 1, CAST(N'2024-04-04T02:59:58.873' AS DateTime), NULL, NULL, CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [Turn].[tbTurnosPorEmpleados] ([TuEm_Id], [TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Estado], [TuEm_Creacion], [TuEm_FechaCreacion], [TuEm_Modificacion], [TuEm_FechaModificacion], [TuEm_HoraEntrada], [TuEm_HoraSalida]) VALUES (2, CAST(N'2024-04-04' AS Date), 2, 4, 1, 1, CAST(N'2024-04-04T02:59:58.873' AS DateTime), NULL, NULL, CAST(N'15:00:00' AS Time), CAST(N'23:00:00' AS Time))
INSERT [Turn].[tbTurnosPorEmpleados] ([TuEm_Id], [TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Estado], [TuEm_Creacion], [TuEm_FechaCreacion], [TuEm_Modificacion], [TuEm_FechaModificacion], [TuEm_HoraEntrada], [TuEm_HoraSalida]) VALUES (3, CAST(N'2024-04-04' AS Date), 3, 5, 1, 1, CAST(N'2024-04-04T02:59:58.873' AS DateTime), NULL, NULL, CAST(N'23:00:00' AS Time), CAST(N'07:00:00' AS Time))
INSERT [Turn].[tbTurnosPorEmpleados] ([TuEm_Id], [TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Estado], [TuEm_Creacion], [TuEm_FechaCreacion], [TuEm_Modificacion], [TuEm_FechaModificacion], [TuEm_HoraEntrada], [TuEm_HoraSalida]) VALUES (4, CAST(N'2024-04-05' AS Date), 1, 6, 1, 1, CAST(N'2024-04-04T02:59:58.873' AS DateTime), NULL, NULL, CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [Turn].[tbTurnosPorEmpleados] ([TuEm_Id], [TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Estado], [TuEm_Creacion], [TuEm_FechaCreacion], [TuEm_Modificacion], [TuEm_FechaModificacion], [TuEm_HoraEntrada], [TuEm_HoraSalida]) VALUES (5, CAST(N'2024-04-06' AS Date), 2, 7, 1, 1, CAST(N'2024-04-04T02:59:58.873' AS DateTime), NULL, NULL, CAST(N'15:00:00' AS Time), CAST(N'23:00:00' AS Time))
SET IDENTITY_INSERT [Turn].[tbTurnosPorEmpleados] OFF
GO
ALTER TABLE [Acce].[tbPantallas] ADD  DEFAULT ((1)) FOR [Pant_Estado]
GO
ALTER TABLE [Acce].[tbPantallasPorRoles] ADD  DEFAULT ((1)) FOR [PaRo_Estado]
GO
ALTER TABLE [Acce].[tbRoles] ADD  DEFAULT ((1)) FOR [Rol_Estado]
GO
ALTER TABLE [Acce].[tbUsuarios] ADD  DEFAULT ((1)) FOR [Usua_Estado]
GO
ALTER TABLE [Gene].[tbCargos] ADD  DEFAULT ((1)) FOR [Carg_Estado]
GO
ALTER TABLE [Gene].[tbCiudades] ADD  DEFAULT ((1)) FOR [Ciud_Estado]
GO
ALTER TABLE [Gene].[tbEstados] ADD  DEFAULT ((1)) FOR [Esta_Estado]
GO
ALTER TABLE [Gene].[tbEstadosCiviles] ADD  DEFAULT ((1)) FOR [EsCi_Estado]
GO
ALTER TABLE [Gene].[tbPersonas] ADD  DEFAULT ((1)) FOR [Pers_Estado]
GO
ALTER TABLE [Turn].[tbEmpleados] ADD  DEFAULT ((1)) FOR [Empl_Estado]
GO
ALTER TABLE [Turn].[tbHospitales] ADD  DEFAULT ((1)) FOR [Hosp_Estado]
GO
ALTER TABLE [Turn].[tbTurnos] ADD  DEFAULT ((1)) FOR [Turn_Estado]
GO
ALTER TABLE [Turn].[tbTurnosPorEmpleados] ADD  DEFAULT ((1)) FOR [TuEm_Estado]
GO
ALTER TABLE [Acce].[tbPantallas]  WITH CHECK ADD FOREIGN KEY([Pant_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbPantallas]  WITH CHECK ADD FOREIGN KEY([Pant_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbPantallasPorRoles]  WITH CHECK ADD FOREIGN KEY([Pant_Id])
REFERENCES [Acce].[tbPantallas] ([Pant_Id])
GO
ALTER TABLE [Acce].[tbPantallasPorRoles]  WITH CHECK ADD FOREIGN KEY([PaRo_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbPantallasPorRoles]  WITH CHECK ADD FOREIGN KEY([PaRo_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbPantallasPorRoles]  WITH CHECK ADD FOREIGN KEY([Rol_Id])
REFERENCES [Acce].[tbRoles] ([Rol_Id])
GO
ALTER TABLE [Acce].[tbRoles]  WITH CHECK ADD FOREIGN KEY([Rol_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbRoles]  WITH CHECK ADD FOREIGN KEY([Rol_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbUsuarios]  WITH CHECK ADD FOREIGN KEY([Usua_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acce].[tbUsuarios]  WITH CHECK ADD FOREIGN KEY([Usua_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbCargos]  WITH CHECK ADD FOREIGN KEY([Carg_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbCargos]  WITH CHECK ADD FOREIGN KEY([Carg_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbCiudades]  WITH CHECK ADD FOREIGN KEY([Ciud_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbCiudades]  WITH CHECK ADD FOREIGN KEY([Ciud_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbCiudades]  WITH CHECK ADD FOREIGN KEY([Esta_Id])
REFERENCES [Gene].[tbEstados] ([Esta_Id])
GO
ALTER TABLE [Gene].[tbEstados]  WITH CHECK ADD FOREIGN KEY([Esta_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbEstados]  WITH CHECK ADD FOREIGN KEY([Esta_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbEstadosCiviles]  WITH CHECK ADD FOREIGN KEY([EsCi_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbEstadosCiviles]  WITH CHECK ADD FOREIGN KEY([EsCi_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbPersonas]  WITH CHECK ADD FOREIGN KEY([EsCi_Id])
REFERENCES [Gene].[tbEstadosCiviles] ([EsCi_Id])
GO
ALTER TABLE [Gene].[tbPersonas]  WITH CHECK ADD FOREIGN KEY([Pers_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Gene].[tbPersonas]  WITH CHECK ADD FOREIGN KEY([Pers_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbEmpleados]  WITH CHECK ADD FOREIGN KEY([Carg_Id])
REFERENCES [Gene].[tbCargos] ([Carg_Id])
GO
ALTER TABLE [Turn].[tbEmpleados]  WITH CHECK ADD FOREIGN KEY([Empl_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbEmpleados]  WITH CHECK ADD FOREIGN KEY([Empl_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbEmpleados]  WITH CHECK ADD FOREIGN KEY([Hosp_Id])
REFERENCES [Turn].[tbHospitales] ([Hosp_Id])
GO
ALTER TABLE [Turn].[tbEmpleados]  WITH CHECK ADD FOREIGN KEY([Pers_Identidad])
REFERENCES [Gene].[tbPersonas] ([Pers_Identidad])
GO
ALTER TABLE [Turn].[tbHospitales]  WITH CHECK ADD FOREIGN KEY([Ciud_Id])
REFERENCES [Gene].[tbCiudades] ([Ciud_Id])
GO
ALTER TABLE [Turn].[tbHospitales]  WITH CHECK ADD FOREIGN KEY([Hosp_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbHospitales]  WITH CHECK ADD FOREIGN KEY([Hosp_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbTurnos]  WITH CHECK ADD FOREIGN KEY([Turn_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbTurnos]  WITH CHECK ADD FOREIGN KEY([Turn_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbTurnosPorEmpleados]  WITH CHECK ADD FOREIGN KEY([Empl_Id])
REFERENCES [Turn].[tbEmpleados] ([Empl_Id])
GO
ALTER TABLE [Turn].[tbTurnosPorEmpleados]  WITH CHECK ADD FOREIGN KEY([TuEm_Creacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbTurnosPorEmpleados]  WITH CHECK ADD FOREIGN KEY([TuEm_Modificacion])
REFERENCES [Acce].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Turn].[tbTurnosPorEmpleados]  WITH CHECK ADD FOREIGN KEY([Turn_Id])
REFERENCES [Turn].[tbTurnos] ([Turn_Id])
GO
/****** Object:  StoredProcedure [Acce].[sp_Pantallas_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === PANTALLAS ===
CREATE   PROCEDURE [Acce].[sp_Pantallas_crear]
    @Pant_Descripcion varchar(50),
    @Pant_Creacion int,
    @Pant_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbPantallas] (Pant_Descripcion, Pant_Creacion, Pant_FechaCreacion)
        VALUES (@Pant_Descripcion, @Pant_Creacion, @Pant_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Pantallas_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Pantallas_editar]
    @Pant_Id int,
    @Pant_Descripcion varchar(50),
    @Pant_Modificacion int,
    @Pant_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbPantallas]
        SET Pant_Descripcion = @Pant_Descripcion,
            Pant_Modificacion = @Pant_Modificacion,
            Pant_FechaModificacion = @Pant_FechaModificacion
        WHERE Pant_Id = @Pant_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Pantallas_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Pantallas_eliminar]
    @Pant_Id int,
    @Pant_Estado bit,
    @Pant_Modificacion int,
    @Pant_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbPantallas]
        SET Pant_Estado = @Pant_Estado,
            Pant_Modificacion = @Pant_Modificacion,
            Pant_FechaModificacion = @Pant_FechaModificacion
        WHERE Pant_Id = @Pant_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Pantallas_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Pantallas_listar] AS
BEGIN
    SELECT Pant_Id, Pant_Descripcion
    FROM [Acce].[tbPantallas]
    WHERE Pant_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Pantallas_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Pantallas_obtener]
    @Pant_Id int
AS
BEGIN
    SELECT Pant_Id, Pant_Descripcion, Pant_Creacion, Pant_FechaCreacion, Pant_Modificacion, Pant_FechaModificacion
    FROM [Acce].[tbPantallas]
    WHERE Pant_Id = @Pant_Id AND Pant_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Acce].[sp_PantallasPorRol_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === PANTALLAS POR ROL ===
CREATE   PROCEDURE [Acce].[sp_PantallasPorRol_crear]
    @Rol_Id int,
    @Pant_Id int,
    @PaRo_Creacion int,
    @PaRo_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbPantallasPorRoles] (Rol_Id, Pant_Id, PaRo_Creacion, PaRo_FechaCreacion)
        VALUES (@Rol_Id, @Pant_Id, @PaRo_Creacion, @PaRo_FechaCreacion);
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_PantallasPorRol_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_PantallasPorRol_eliminar]
    @Rol_Id int
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Acce].[tbPantallasPorRoles]
        WHERE PaRo_Id = @Rol_Id;
        SELECT 1 AS Resultado; 

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Roles_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === ROLES ===
CREATE   PROCEDURE [Acce].[sp_Roles_crear]
    @Rol_Descripcion VARCHAR(50),
    @Rol_Creacion INT,
    @Rol_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbRoles] (Rol_Descripcion, Rol_Creacion, Rol_FechaCreacion) VALUES (@Rol_Descripcion, @Rol_Creacion, @Rol_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Roles_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Roles_editar]
    @Rol_Id INT,
    @Rol_Descripcion VARCHAR(50),
    @Rol_Modificacion INT,
    @Rol_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbRoles]
        SET Rol_Descripcion = @Rol_Descripcion,
            Rol_Modificacion = @Rol_Modificacion,
            Rol_FechaModificacion = @Rol_FechaModificacion
        WHERE Rol_Id = @Rol_Id;
        SELECT 1 AS Resultado;  

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Roles_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Roles_eliminar]
    @Rol_Id INT,
    @Rol_Estado BIT,
    @Rol_Modificacion INT,
    @Rol_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbRoles]
        SET Rol_Estado = @Rol_Estado,
            Rol_Modificacion = @Rol_Modificacion,
            Rol_FechaModificacion = @Rol_FechaModificacion 
        WHERE Rol_Id = @Rol_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Roles_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Roles_listar] AS
BEGIN
    SELECT Rol_Id, Rol_Descripcion
    FROM [Acce].[tbRoles]
    WHERE Rol_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Roles_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Roles_obtener]
    @Rol_Id INT
AS
BEGIN
    SELECT Rol_Id, Rol_Descripcion, Rol_Creacion, Rol_FechaCreacion, Rol_Modificacion, Rol_FechaModificacion
    FROM [Acce].[tbRoles]
    WHERE Rol_Id = @Rol_Id AND Rol_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Usuarios_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- === USUARIOS ===
CREATE   PROCEDURE [Acce].[sp_Usuarios_crear]
    @Usua_Usuario VARCHAR(50),
    @Usua_Clave VARCHAR(50),
    @Rol_Id INT,
    @Usua_IsAdmin BIT,
    @Usua_Creacion INT,
    @Usua_FechaCreacion DATETIME,
    @ID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbUsuarios] (Usua_Usuario, Usua_Clave, Rol_Id, Usua_IsAdmin, Usua_Creacion, Usua_FechaCreacion)
        VALUES (@Usua_Usuario, HASHBYTES('SHA2_512', @Usua_Clave), @Rol_Id, @Usua_IsAdmin, @Usua_Creacion, @Usua_FechaCreacion);
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Usuarios_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Usuarios_editar]
    @Usua_Id INT,
    @Usua_Usuario VARCHAR(50),
    @Usua_Clave VARCHAR(50),
    @Rol_Id INT,
    @Usua_IsAdmin BIT,
    @Usua_Modificacion INT,
    @Usua_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbUsuarios]
        SET Usua_Usuario = @Usua_Usuario,
            Usua_Clave = HASHBYTES('SHA2_512', @Usua_Clave),
            Rol_Id = @Rol_Id,
            Usua_IsAdmin = @Usua_IsAdmin,
            Usua_Modificacion = @Usua_Modificacion,
            Usua_FechaModificacion = @Usua_FechaModificacion
        WHERE Usua_Id = @Usua_Id;
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Usuarios_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Usuarios_eliminar]
    @Usua_Id INT,
    @Usua_Estado BIT,
    @Usua_Modificacion INT,
    @Usua_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbUsuarios]
        SET Usua_Estado = @Usua_Estado,
            Usua_Modificacion = @Usua_Modificacion,
            Usua_FechaModificacion = @Usua_FechaModificacion
        WHERE Usua_Id = @Usua_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Acce].[SP_Usuarios_InicioSesion]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [Acce].[SP_Usuarios_InicioSesion]
(
@Usuario VARCHAR(30), 
@Contra VARCHAR(MAX)
)
AS
BEGIN 
	SELECT u.*, u.[Usua_Usuario] AS Usua_Nombre, p.* FROM Acce.tbUsuarios u, Acce.tbPantallas p
	WHERE u.Usua_Usuario = @Usuario AND u.Usua_Clave = HASHBYTES('SHA2_512', @Contra)
END 
GO
/****** Object:  StoredProcedure [Acce].[sp_Usuarios_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Usuarios_listar]
AS
BEGIN
    SELECT Usua_Id, Usua_Usuario, Usua_Clave, u.Rol_Id, r.Rol_Descripcion, Usua_IsAdmin 
    FROM [Acce].[tbUsuarios] as u
    JOIN [Acce].[tbRoles] as r on u.Rol_Id = r.Rol_Id
    WHERE Usua_Estado = 1 AND r.Rol_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Acce].[sp_Usuarios_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Acce].[sp_Usuarios_obtener]
    @Usua_Id INT
AS
BEGIN
    SELECT Usua_Id, Usua_Usuario, Usua_Clave, u.Rol_Id, r.Rol_Descripcion, Usua_IsAdmin, Usua_Creacion, Usua_FechaCreacion, Usua_Modificacion, Usua_FechaModificacion
    FROM [Acce].[tbUsuarios] as u
    JOIN [Acce].[tbRoles] as r on u.Rol_Id = r.Rol_Id
    WHERE Usua_Id = @Usua_Id AND Usua_Estado = 1 AND r.Rol_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Cargos_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === CARGOS ===
CREATE   PROCEDURE [Gene].[sp_Cargos_crear]
    @Carg_Descripcion varchar(50),
    @Carg_Creacion int,
    @Carg_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbCargos] (Carg_Descripcion, Carg_Creacion, Carg_FechaCreacion)
        VALUES (@Carg_Descripcion, @Carg_Creacion, @Carg_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Cargos_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Cargos_editar]
    @Carg_Id int,
    @Carg_Descripcion varchar(50),
    @Carg_Modificacion int,
    @Carg_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCargos]
        SET Carg_Descripcion = @Carg_Descripcion,
            Carg_Modificacion = @Carg_Modificacion,
            Carg_FechaModificacion = @Carg_FechaModificacion
        WHERE Carg_Id = @Carg_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Cargos_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Cargos_eliminar]
    @Carg_Id int,
    @Carg_Estado bit,
    @Carg_Modificacion int,
    @Carg_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCargos]
        SET Carg_Estado = @Carg_Estado,
            Carg_Modificacion = @Carg_Modificacion,
            Carg_FechaModificacion = @Carg_FechaModificacion
        WHERE Carg_Id = @Carg_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Cargos_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Cargos_listar]
AS
BEGIN
    SELECT Carg_Id, Carg_Descripcion
    FROM [Gene].[tbCargos]
    WHERE Carg_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Cargos_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Cargos_obtener]
    @Carg_Id int
AS
BEGIN
    SELECT Carg_Id, Carg_Descripcion
    FROM [Gene].[tbCargos]
    WHERE Carg_Id = @Carg_Id;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Ciudades_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Ciudades_crear]
    @Ciud_Id varchar(4),
    @Esta_Id varchar(2),
    @Ciud_Descripcion varchar(50),
    @Ciud_Creacion int,
    @Ciud_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbCiudades] ( Ciud_Id, Esta_Id, Ciud_Descripcion, Ciud_Creacion, Ciud_FechaCreacion)
        VALUES ( @Ciud_Id, @Esta_Id, @Ciud_Descripcion, @Ciud_Creacion, @Ciud_FechaCreacion);
        SELECT @Ciud_Id AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Ciudades_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Ciudades_eliminar]
    @Ciud_Id varchar(4)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Gene].[tbCiudades]
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Ciudades_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Ciudades_listar] AS
BEGIN
    SELECT Ciud_Id, Ciud_Descripcion, c.Esta_Id, e.Esta_Descripcion
    FROM [Gene].[tbCiudades] c
    JOIN [Gene].[tbEstados] e ON c.Esta_Id = e.Esta_Id
    WHERE Ciud_Estado = 1 AND e.Esta_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Ciudades_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Ciudades_obtener]
    @Ciud_Id varchar(4)
AS
BEGIN
    SELECT Ciud_Id, Ciud_Descripcion, c.Esta_Id, e.Esta_Descripcion, Ciud_Creacion, Ciud_FechaCreacion, Ciud_Modificacion, Ciud_FechaModificacion
    FROM [Gene].[tbCiudades] c
    JOIN [Gene].[tbEstados] e ON c.Esta_Id = e.Esta_Id
    WHERE Ciud_Id = @Ciud_Id AND Ciud_Estado = 1 AND e.Esta_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Estados_crear]
    @Esta_Id varchar(2),
    @Esta_Descripcion varchar(50),
    @Esta_Creacion int,
    @Esta_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Gene.[tbEstados] ( Esta_Id, Esta_Descripcion, Esta_Creacion, Esta_FechaCreacion)
        VALUES (@Esta_Id, @Esta_Descripcion, @Esta_Creacion, @Esta_FechaCreacion);
        SELECT @Esta_Id AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Estados_editar]
    @Esta_Id varchar(2),
    @Esta_Descripcion varchar(50),
    @Esta_Modificacion int,
    @Esta_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Gene.[tbEstados]
        SET Esta_Descripcion = @Esta_Descripcion,
            Esta_Modificacion = @Esta_Modificacion,
            Esta_FechaModificacion = @Esta_FechaModificacion
        WHERE Esta_Id = @Esta_Id;
        SELECT 1 AS Resultado;

        COMMIT; 
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Estados_eliminar]
    @Esta_Id varchar(2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM Gene.[tbEstados]
        WHERE Esta_Id = @Esta_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Estados_listar] AS
BEGIN
    SELECT Esta_Id, Esta_Descripcion
    FROM Gene.[tbEstados]
    WHERE Esta_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_llenar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [Gene].[sp_Estados_llenar]
    @Esta_Id varchar(2)
AS
BEGIN
    SELECT *
    FROM Gene.[tbEstados]
    WHERE Esta_Id = @Esta_Id
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Estados_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Gene].[sp_Estados_obtener] 
    @Esta_Id varchar(2)
AS
BEGIN
    SELECT Esta_Id, 
	       Esta_Descripcion, 
		   usua1.Usua_Usuario as usua_creac,
		   Esta_FechaCreacion, 
		   usua2.Usua_Usuario as usua_modi,
		   Esta_FechaModificacion
    FROM Gene.[tbEstados] e INNER JOIN Acce.tbUsuarios usua1 
	ON e.Esta_Creacion = usua1.Usua_Id FULL JOIN Acce.tbUsuarios usua2 
	ON e.Esta_Modificacion = usua2.Usua_Id
    WHERE Esta_Id = @Esta_Id AND Esta_Estado = 1;
END

GO
/****** Object:  StoredProcedure [Gene].[sp_EstadosCiviles_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === ESTADOS CIVILES ===
CREATE   PROCEDURE [Gene].[sp_EstadosCiviles_crear]
    @EsCi_Descripcion varchar(50),
    @EsCi_Creacion int,
    @EsCi_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbEstadosCiviles] (EsCi_Descripcion, EsCi_Creacion, EsCi_FechaCreacion)
        VALUES (@EsCi_Descripcion, @EsCi_Creacion, @EsCi_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_EstadosCiviles_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_EstadosCiviles_editar]
    @EsCi_Id int,
    @EsCi_Descripcion varchar(50),
    @EsCi_Modificacion int,
    @EsCi_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbEstadosCiviles]
        SET EsCi_Descripcion = @EsCi_Descripcion,
            EsCi_Modificacion = @EsCi_Modificacion,
            EsCi_FechaModificacion = @EsCi_FechaModificacion
        WHERE EsCi_Id = @EsCi_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_EstadosCiviles_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_EstadosCiviles_eliminar]
    @EsCi_Id int,
    @EsCi_Estado bit,
    @EsCi_Modificacion int,
    @EsCi_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbEstadosCiviles]
        SET EsCi_Estado = @EsCi_Estado,
            EsCi_Modificacion = @EsCi_Modificacion,
            EsCi_FechaModificacion = @EsCi_FechaModificacion
        WHERE EsCi_Id = @EsCi_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_EstadosCiviles_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_EstadosCiviles_listar] AS
BEGIN
    SELECT EsCi_Id, EsCi_Descripcion
    FROM [Gene].[tbEstadosCiviles]
    WHERE EsCi_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_EstadosCiviles_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_EstadosCiviles_obtener]
    @EsCi_Id int
AS
BEGIN
    SELECT EsCi_Id, EsCi_Descripcion, EsCi_Creacion, EsCi_FechaCreacion, EsCi_Modificacion, EsCi_FechaModificacion
    FROM [Gene].[tbEstadosCiviles]
    WHERE EsCi_Id = @EsCi_Id AND EsCi_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Personas_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === PERSONAS ===
CREATE   PROCEDURE [Gene].[sp_Personas_crear]
    @Pers_Identidad varchar(13),
    @Pers_PrimerNombre varchar(50),
    @Pers_SegundoNombre varchar(50),
    @Pers_PrimerApellido varchar(50),
    @Pers_SegundoApellido varchar(50),
    @EsCi_Id int,
    @Pers_Sexo char(1),
    @Pers_Creacion int,
    @Pers_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbPersonas] (Pers_Identidad, Pers_PrimerNombre, Pers_SegundoNombre, Pers_PrimerApellido, Pers_SegundoApellido, EsCi_Id, Pers_Sexo, Pers_Creacion, Pers_FechaCreacion)
        VALUES (@Pers_Identidad, @Pers_PrimerNombre, @Pers_SegundoNombre, @Pers_PrimerApellido, @Pers_SegundoApellido, @EsCi_Id, @Pers_Sexo, @Pers_Creacion, @Pers_FechaCreacion);
        SELECT @Pers_Identidad AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Personas_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Personas_editar]
    @Pers_Identidad varchar(13),
    @Pers_PrimerNombre varchar(50),
    @Pers_SegundoNombre varchar(50),
    @Pers_PrimerApellido varchar(50),
    @Pers_SegundoApellido varchar(50),
    @EsCi_Id int,
    @Pers_Sexo char(1),
    @Pers_Modificacion int,
    @Pers_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbPersonas]
        SET Pers_PrimerNombre = @Pers_PrimerNombre,
            Pers_SegundoNombre = @Pers_SegundoNombre,
            Pers_PrimerApellido = @Pers_PrimerApellido,
            Pers_SegundoApellido = @Pers_SegundoApellido,
            EsCi_Id = @EsCi_Id,
            Pers_Sexo = @Pers_Sexo,
            Pers_Modificacion = @Pers_Modificacion,
            Pers_FechaModificacion = @Pers_FechaModificacion
        WHERE Pers_Identidad = @Pers_Identidad;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[sp_Personas_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[sp_Personas_eliminar]
    @Pers_Identidad varchar(13),
    @Pers_Estado bit,
    @Pers_Modificacion int,
    @Pers_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbPersonas]
        SET Pers_Estado = @Pers_Estado,
            Pers_Modificacion = @Pers_Modificacion,
            Pers_FechaModificacion = @Pers_FechaModificacion
        WHERE Pers_Identidad = @Pers_Identidad;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Gene].[tbCiudades_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Gene].[tbCiudades_editar]
    @Ciud_Id varchar(4),
    @Esta_Id varchar(2),
    @Ciud_Descripcion varchar(50),
    @Ciud_Modificacion int,
    @Ciud_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCiudades]
        SET Esta_Id = @Esta_Id,
            Ciud_Descripcion = @Ciud_Descripcion,
            Ciud_Modificacion = @Ciud_Modificacion,
            Ciud_FechaModificacion = @Ciud_FechaModificacion
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Empleados_buscar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Empleados_buscar] 
@Empl_Id INT
AS
BEGIN
    SELECT [Empl_Id], e.[Pers_Identidad], CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido) as Nombre,
    p.Pers_PrimerNombre, p.Pers_SegundoNombre, p.Pers_PrimerApellido, p.Pers_SegundoApellido, p.Pers_Sexo, p.EsCi_Id, es.EsCi_Descripcion, e.[Carg_Id], c.Carg_Descripcion, e.[Hosp_Id], h.Hosp_Descripcion
    FROM [Turn].[tbEmpleados] e
    JOIN [Gene].[tbCargos] c ON c.Carg_Id = e.[Carg_Id]
    JOIN [Turn].[tbHospitales] h ON h.Hosp_Id = e.[Hosp_Id]
    JOIN [Gene].[tbPersonas] p ON p.Pers_Identidad = e.[Pers_Identidad]
    JOIN [Gene].[tbEstadosCiviles] es ON es.EsCi_Id = p.EsCi_Id
    WHERE [Empl_Id] = @Empl_Id AND [Empl_Estado] = 1 AND c.Carg_Estado = 1 AND h.Hosp_Estado = 1 AND p.Pers_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Empleados_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === EMPLEADOS ===
CREATE   PROCEDURE [Turn].[sp_Empleados_crear]
    @Pers_Identidad varchar(13),
    @Usua_Id int,
    @Carg_Id int,
    @Hosp_Id int,
    @Empl_Creacion int,
    @Empl_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbEmpleados] (Pers_Identidad, Usua_Id, Carg_Id, Hosp_Id, Empl_Creacion, Empl_FechaCreacion)
        VALUES (@Pers_Identidad, @Usua_Id, @Carg_Id, @Hosp_Id, @Empl_Creacion, @Empl_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Empleados_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Empleados_editar]
    @Empl_Id int,
    @Pers_Identidad varchar(13),
    @Usua_Id int,
    @Carg_Id int,
    @Hosp_Id int,
    @Empl_Modificacion int,
    @Empl_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbEmpleados]
        SET Pers_Identidad = @Pers_Identidad,
            Usua_Id = @Usua_Id,
            Carg_Id = @Carg_Id,
            Hosp_Id = @Hosp_Id,
            Empl_Modificacion = @Empl_Modificacion,
            Empl_FechaModificacion = @Empl_FechaModificacion
        WHERE Empl_Id = @Empl_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Empleados_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Empleados_eliminar]
    @Empl_Id INT,
    @Empl_Estado BIT,
    @Empl_Modificacion INT,
    @Empl_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbEmpleados]
        SET Empl_Estado = @Empl_Estado,
            Empl_Modificacion = @Empl_Modificacion,
            Empl_FechaModificacion = @Empl_FechaModificacion
        WHERE Empl_Id = @Empl_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Empleados_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Empleados_listar] AS
BEGIN
    SELECT [Empl_Id], e.[Pers_Identidad], CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido) as Nombre, e.[Carg_Id], c.Carg_Descripcion, e.[Hosp_Id], h.Hosp_Descripcion
    FROM [Turn].[tbEmpleados] e
    JOIN [Gene].[tbCargos] c ON c.Carg_Id = e.[Carg_Id]
    JOIN [Turn].[tbHospitales] h ON h.Hosp_Id = e.[Hosp_Id]
    JOIN [Gene].[tbPersonas] p ON p.Pers_Identidad = e.[Pers_Identidad]
    WHERE [Empl_Estado] = 1 AND c.Carg_Estado = 1 AND h.Hosp_Estado = 1 AND p.Pers_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Hospitales_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- === HOSPITALES ===
CREATE   PROCEDURE [Turn].[sp_Hospitales_crear]
    @Hosp_Descripcion varchar(50),
    @Hosp_Direccion varchar(50),
    @Ciud_Id varchar(4),
    @Hosp_Creacion int,
    @Hosp_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbHospitales] (Hosp_Descripcion, Hosp_Direccion, Ciud_Id, Hosp_Creacion, Hosp_FechaCreacion)
        VALUES (@Hosp_Descripcion, @Hosp_Direccion, @Ciud_Id, @Hosp_Creacion, @Hosp_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Hospitales_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Hospitales_editar]
    @Hosp_Id int,
    @Hosp_Descripcion varchar(50),
    @Hosp_Direccion varchar(50),
    @Ciud_Id varchar(4),
    @Hosp_Modificacion int,
    @Hosp_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbHospitales]
        SET Hosp_Descripcion = @Hosp_Descripcion,
            Hosp_Direccion = @Hosp_Direccion,
            Ciud_Id = @Ciud_Id,
            Hosp_Modificacion = @Hosp_Modificacion,
            Hosp_FechaModificacion = @Hosp_FechaModificacion
        WHERE Hosp_Id = @Hosp_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Hospitales_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Hospitales_eliminar]
    @Hosp_Id INT,
    @Hosp_Estado BIT,
    @Hosp_Modificacion INT,
    @Hosp_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [turn].[tbHospitales]
        SET Hosp_Estado = @Hosp_Estado,
            Hosp_Modificacion = @Hosp_Modificacion,
            Hosp_FechaModificacion = @Hosp_FechaModificacion
        WHERE Hosp_Id = @Hosp_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Hospitales_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Hospitales_listar] AS
BEGIN
    SELECT [Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], h.Ciud_Id, c.Ciud_Descripcion
    FROM [Turn].[tbHospitales] h
    INNER JOIN [Gene].[tbCiudades] c ON c.Ciud_Id = h.Ciud_Id
    WHERE [Hosp_Estado] = 1 AND c.Ciud_Estado = 1;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Hospitales_obtener]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE    PROCEDURE [Turn].[sp_Hospitales_obtener] 
@Hosp_Id int
AS
BEGIN
    SELECT [Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], h.[Ciud_Id], c.[Ciud_Descripcion], Ciud_Creacion, Ciud_FechaCreacion, Ciud_Modificacion, Ciud_FechaModificacion
    FROM [Turn].[tbHospitales] h
    INNER JOIN [Gene].[tbCiudades] c ON c.Ciud_Id = h.Ciud_Id
    WHERE [Hosp_Estado] = 1 AND c.Ciud_Estado = 1 AND [Hosp_Id] = @Hosp_Id;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Turnos_buscar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_Turnos_buscar] 
@Turn_Id int
AS
BEGIN
    SELECT [Turn_Id], [Turn_Descripcion], [Turn_HoraEntrada], [Turn_HoraSalida]
    FROM [Turn].[tbTurnos]
    WHERE [Turn_Id] = @Turn_Id AND [Turn_Estado] = 1;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Turnos_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_Turnos_crear]
    @Turn_Descripcion varchar(50),
    @Turn_HoraEntrada time,
	@Turn_HoraSalida time,
    @Turn_Creacion int,
    @Turn_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbTurnos] (Turn_Descripcion, Turn_HoraEntrada, Turn_HoraSalida, Turn_Creacion, Turn_FechaCreacion)
        VALUES (@Turn_Descripcion, @Turn_HoraEntrada, @Turn_HoraSalida, @Turn_Creacion, @Turn_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Turnos_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_Turnos_editar]
    @Turn_Id int,
    @Turn_Descripcion varchar(50),
    @Turn_HoraEntrada time,
	@Turn_HoraSalida time,
    @Turn_Modificacion int,
    @Turn_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnos]
        SET Turn_Descripcion = @Turn_Descripcion,
            Turn_HoraEntrada = @Turn_HoraEntrada,
			Turn_HoraSalida = @Turn_HoraSalida,
            Turn_Modificacion = @Turn_Modificacion,
            Turn_FechaModificacion = @Turn_FechaModificacion
        WHERE Turn_Id = @Turn_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Turnos_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Turn].[sp_Turnos_eliminar]
    @Turn_Id INT,
    @Turn_Estado BIT,
    @Turn_Modificacion INT,
    @Turn_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnos]
        SET Turn_Estado = @Turn_Estado,
            Turn_Modificacion = @Turn_Modificacion,
            Turn_FechaModificacion = @Turn_FechaModificacion
        WHERE Turn_Id = @Turn_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_Turnos_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE  [Turn].[sp_Turnos_listar] AS
BEGIN
    SELECT [Turn_Id], [Turn_Descripcion], [Turn_HoraEntrada], [Turn_HoraSalida]
    FROM [Turn].[tbTurnos]
    WHERE [Turn_Estado] = 1;
END
GO
/****** Object:  StoredProcedure [Turn].[sp_TurnosPorEmpleados_buscar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Turn].[sp_TurnosPorEmpleados_buscar]
@TuEm_Id INT
AS
BEGIN
	SELECT TuEm_Id, TuEm_FechaInicio, tuem.Turn_Id, t.Turn_Descripcion, tuem.Empl_Id, e.Pers_Identidad, CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido ) AS nombre, TuEm_Creacion, TuEm_FechaCreacion, TuEm_Modificacion, TuEm_FechaModificacion, TuEm_HoraEntrada, TuEm_HoraSalida
	FROM Turn.tbTurnosPorEmpleados tuem
	JOIN Turn.tbTurnos t on t.Turn_Id = tuem.Turn_Id
	JOIN Turn.tbEmpleados e on e.Empl_Id = tuem.Empl_Id
	JOIN Gene.tbPersonas p on p.Pers_Identidad = e.Pers_Identidad
	WHERE TuEm_Id = @TuEm_Id
END
GO
/****** Object:  StoredProcedure [Turn].[sp_TurnosPorEmpleados_crear]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_TurnosPorEmpleados_crear]
    @TuEm_FechaInicio date,
    @Turn_Id int,
    @Empl_Id int,
    @TuEm_Creacion int,
    @TuEm_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

		DECLARE @HoraEntrada TIME, @HoraSalida TIME;

        SELECT @HoraEntrada = Turn_HoraEntrada, @HoraSalida = Turn_HoraSalida
        FROM [Turn].[tbTurnos]
        WHERE Turn_Id = @Turn_Id;

        INSERT INTO [Turn].[tbTurnosPorEmpleados] (TuEm_FechaInicio, Turn_Id, Empl_Id, TuEm_HoraEntrada, TuEm_HoraSalida, TuEm_Creacion, TuEm_FechaCreacion)
        VALUES (@TuEm_FechaInicio, @Turn_Id, @Empl_Id, @HoraEntrada, @HoraSalida, @TuEm_Creacion, @TuEm_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_TurnosPorEmpleados_editar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_TurnosPorEmpleados_editar]
    @TuEm_Id int,
    @TuEm_FechaInicio date,
    @Turn_Id int,
    @Empl_Id int,
    @TuEm_Modificacion int,
    @TuEm_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

		DECLARE @HoraEntrada TIME, @HoraSalida TIME;

        SELECT @HoraEntrada = Turn_HoraEntrada, @HoraSalida = Turn_HoraSalida
        FROM [Turn].[tbTurnos]
        WHERE Turn_Id = @Turn_Id;

        UPDATE [Turn].[tbTurnosPorEmpleados]
        SET TuEm_FechaInicio = @TuEm_FechaInicio,
            Turn_Id = @Turn_Id,
            Empl_Id = @Empl_Id,
			TuEm_HoraEntrada = @HoraEntrada,
			TuEm_HoraSalida = @HoraSalida,
            TuEm_Modificacion = @TuEm_Modificacion,
            TuEm_FechaModificacion = @TuEm_FechaModificacion
        WHERE TuEm_Id = @TuEm_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_TurnosPorEmpleados_eliminar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_TurnosPorEmpleados_eliminar]
    @TuEm_Id INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Turn].[tbTurnosPorEmpleados]
        WHERE TuEm_Id = @TuEm_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Turn].[sp_TurnosPorEmpleados_listar]    Script Date: 1/11/2024 15:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Turn].[sp_TurnosPorEmpleados_listar]
AS
BEGIN
 SELECT 
    te.TuEm_Id as id, 
    te.Turn_Id,
    CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido, ': ', Turn_Descripcion) AS title,
    CONCAT(CONVERT(varchar(10), TuEm_FechaInicio, 23), 'T', CONVERT(varchar(5), TuEm_HoraEntrada, 108)) AS start,
    CASE 
        WHEN TuEm_HoraSalida < TuEm_HoraEntrada THEN 
            CONVERT(varchar(10), DATEADD(DAY, 1, CONVERT(date, TuEm_FechaInicio)), 23) + 'T' + CONVERT(varchar(5), TuEm_HoraSalida, 108)
        ELSE 
            CONVERT(varchar(10), TuEm_FechaInicio, 23) + 'T' + CONVERT(varchar(5), TuEm_HoraSalida, 108)
    END AS [end]
FROM Turn.tbTurnosPorEmpleados te
JOIN Turn.tbTurnos t ON te.Turn_Id = t.Turn_Id
JOIN Turn.tbEmpleados e ON e.Empl_Id = te.Empl_Id
JOIN Gene.tbPersonas p ON p.Pers_Identidad = e.Pers_Identidad
END;
GO
