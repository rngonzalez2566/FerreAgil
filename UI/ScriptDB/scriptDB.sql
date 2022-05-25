USE [master]
GO
/****** Object:  Database [Diploma]    Script Date: 25/5/2022 17:23:43 ******/
CREATE DATABASE [Diploma]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diploma', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diploma.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Diploma_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diploma_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Diploma] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Diploma].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Diploma] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Diploma] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Diploma] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Diploma] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Diploma] SET ARITHABORT OFF 
GO
ALTER DATABASE [Diploma] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Diploma] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Diploma] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Diploma] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Diploma] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Diploma] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Diploma] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Diploma] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Diploma] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Diploma] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Diploma] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Diploma] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Diploma] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Diploma] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Diploma] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Diploma] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Diploma] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Diploma] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Diploma] SET  MULTI_USER 
GO
ALTER DATABASE [Diploma] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Diploma] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Diploma] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Diploma] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Diploma] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Diploma] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Diploma] SET QUERY_STORE = OFF
GO
USE [Diploma]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id_bitacora] [int] IDENTITY(1,1) NOT NULL,
	[fk_usuario] [int] NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[Criticidad] [int] NOT NULL,
	[Fecha_movimiento] [nvarchar](50) NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[id_bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificador]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificador](
	[id_DV] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tabla] [nvarchar](20) NOT NULL,
	[valorDVV] [int] NOT NULL,
 CONSTRAINT [PK_DigitoVerificador] PRIMARY KEY CLUSTERED 
(
	[id_DV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[etiquetas]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etiquetas](
	[id_etiqueta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_etiqueta] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id_idioma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[Default] [bit] NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traducciones](
	[id_traducciones] [int] IDENTITY(1,1) NOT NULL,
	[id_idioma] [int] NOT NULL,
	[traduccion] [nvarchar](50) NOT NULL,
	[id_etiqueta] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/5/2022 17:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](20) NOT NULL,
	[contrasena] [nvarchar](300) NOT NULL,
	[contador] [int] NOT NULL,
	[estado] [nvarchar](20) NULL,
	[email] [nvarchar](20) NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2922, 2, N'ZGFzZGFz', 2, N'20200910150937', 8785)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2923, 2, N'ZGFzZGFz', 2, N'20200910150937', 8785)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2924, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW8=', 2, N'20200916110052', 105862)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2925, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW8=', 2, N'20200916110326', 105915)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2926, 3, N'Q2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW8=', 2, N'20200916113452', 106689)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2927, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBEaWdpdG8gVmVydGljYWwgZGUgbGEgdGFibGE6IFVzdWFyaW8=', 1, N'20200916113655', 828713)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2928, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBndWFyZGFkbyBlbiBsYSB0YWJsYTogVXN1YXJpbw==', 1, N'20200916113659', 737437)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2929, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW8=', 2, N'20200916114001', 105827)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2930, 5, N'Q2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW8=', 2, N'20200916114030', 106600)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2931, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW8=', 2, N'20200916114150', 105890)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2932, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW8=', 2, N'20200916114158', 106002)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2933, 7, N'Q2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW8=', 2, N'20200916114209', 106713)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2934, 6, N'Q2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW86IGNHVndaUT09', 2, N'20200916114625', 158642)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2935, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW86IHRldG8=', 2, N'20200916114842', 138258)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2936, 6, N'Q2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW86IHBlcGU=', 2, N'20200916114850', 139718)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2937, 7, N'U2UgaGEgZGFkbyBkZSBiYWphIGVsIHVzdWFyaW86IGpvc2U=', 2, N'20200916123838', 107142)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2938, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW86IHNvc2E=', 2, N'20201006122858', 138131)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2939, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW86IHNvc2Ex', 2, N'20201006122912', 141311)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2940, 10, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHNvc2Ex', 1, N'20201006122941', 162535)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2941, 10, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHNvc2Ex', 1, N'20201006122944', 162577)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2942, 10, N'U2UgYmxvcXVlbyBwb3IgaW50ZW50b3MgZmFsbGlkb3MgZWwgdXN1YXJpbzogc29zYTE=', 1, N'20201006122946', 211235)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2943, 0, N'U2UgaGEgZGVzYmxvcXVlYWRvIGVsIHVzdWFyaW86IHNvc2Ex', 2, N'20201006123000', 108878)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2944, 0, N'U2UgaGEgZGFkbyBkZSBhbHRhIHVuIG51ZXZvIHVzdWFyaW86IHJvZHJp', 2, N'20201008181309', 141723)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2945, 6, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHBlcGU=', 1, N'20201026125156', 159880)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2946, 6, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHBlcGU=', 1, N'20201026181226', 159869)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2947, 6, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHBlcGU=', 1, N'20201026183119', 159908)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2948, 6, N'SW50ZW50byBGYWxsaWRvIGRlIGluZ3Jlc28gZGVsIHVzdWFyaW86IHBlcGU=', 1, N'20210614113553', 159866)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2949, 0, N'U2UgaGEgQ2FtYmlhZG8gbGEgY29udHJhc2XDsWEgZGVsIHVzdWFyaW86IHBlcGU=', 2, N'20220525084714', 180834)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[DigitoVerificador] ON 

INSERT [dbo].[DigitoVerificador] ([id_DV], [nombre_tabla], [valorDVV]) VALUES (1, N'Bitacora', 4863725)
INSERT [dbo].[DigitoVerificador] ([id_DV], [nombre_tabla], [valorDVV]) VALUES (3, N'Usuario', 570702)
SET IDENTITY_INSERT [dbo].[DigitoVerificador] OFF
GO
SET IDENTITY_INSERT [dbo].[etiquetas] ON 

INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (1, N'Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (2, N'Contraseña')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (12, N'Baja Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (13, N'Dar de Baja')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (5, N'Ingresar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (14, N'Aceptar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (15, N'Alta Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (16, N'Administracion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (17, N'Usuarios')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (18, N'Permisos')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (19, N'Cambio Password')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (20, N'Desbloquear Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (21, N'Bitacora')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (22, N'Cerrar Sesion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (23, N'¿Esta seguro?')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (24, N'[Sesión no iniciada]')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (25, N'Fecha Desde')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (26, N'Fecha Hasta')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (27, N'Criticidad')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (28, N'Filtro por Fecha')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (29, N'Filtro por Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (30, N'Filtro por Criticidad')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (31, N'Desbloqueo Password')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (32, N'Desbloquear')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (6, N'Salir')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (9, N'Idioma')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (11, N'Email')
SET IDENTITY_INSERT [dbo].[etiquetas] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (1, N'español', 1)
INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (2, N'ingles', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Traducciones] ON 

INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (1, 1, N'Usuario', 1)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (2, 2, N'Username', 1)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (3, 1, N'Contraseña', 2)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (4, 2, N'Password', 2)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (21, 1, N'Baja Usuario', 12)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (22, 2, N'User Unsubscribe', 12)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (24, 1, N'Dar de Baja', 13)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (25, 2, N'Unsubscribe', 13)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (26, 1, N'Aceptar', 14)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (27, 2, N'Accept', 14)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (28, 1, N'Alta Usuario', 15)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (30, 2, N'New User', 15)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (32, 1, N'Administracion', 16)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (33, 2, N'Administration', 16)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (34, 1, N'Usuarios', 17)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (35, 2, N'Users', 17)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (36, 1, N'Permisos', 18)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (38, 2, N'Permissions', 18)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (39, 1, N'Cambio de Contraseña', 19)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (40, 2, N'Change Password', 19)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (41, 1, N'Desbloquear Usuario', 20)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (43, 2, N'Unlock User', 20)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (44, 1, N'Bitacora', 21)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (45, 2, N'Log', 21)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (46, 1, N'Cerrar Sesion', 22)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (47, 2, N'Sign Off', 22)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (50, 1, N'¿Está seguro?', 23)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (54, 2, N'Are you Sure?', 23)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (56, 1, N'[Sesión no iniciada]', 24)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (58, 2, N'
[Session not started]', 24)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (61, 1, N'Fecha Desde', 25)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (63, 2, N'Start Date', 25)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (64, 1, N'Fecha Hasta', 26)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (65, 2, N'End Date', 26)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (66, 1, N'Criticidad', 27)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (68, 2, N'Criticality
', 27)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (71, 1, N'Filtro por Fecha', 28)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (72, 2, N'Filter by Date', 28)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (73, 1, N'Filtro por Usuario', 29)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (74, 2, N'Filter by Username', 29)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (75, 1, N'Filtro por Criticidad', 30)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (76, 2, N'Filter by Criticality', 30)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (77, 1, N'Desbloqueo de Contraseña', 31)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (79, 2, N'
Password unlock', 31)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (80, 1, N'Desbloquear', 32)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (81, 2, N'Unlock', 32)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (15, 1, N'Idioma', 9)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (10, 1, N'Ingresar', 5)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (11, 2, N'Login', 5)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (12, 1, N'Salir', 6)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (13, 2, N'Exit', 6)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (17, 2, N'Language', 9)
SET IDENTITY_INSERT [dbo].[Traducciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (6, N'cGVwZQ==', N'I+oGN4nA6GESI8UXA4mssXVmXvlkU1/zm1hO8XsU9YE=', 1, NULL, N'pepe@gmail.com', 97482)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (7, N'am9zZQ==', N'/1PKuI/3ISFiyB7DPzdEt34a+JHJHZUS8zBn/bZLOKg=', 0, N'BAJA', N'jose@gmail.com', 92958)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (8, N'dGV0bw==', N'kSQrqXOT3JjAH1XBvqMtTAHrngBpCPwOm6QFzy8CUX8=', 0, N'ACTIVO', N'teto@gmail.com', 98566)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (9, N'c29zYQ==', N'mOrC29/Nmuvyf8VgWFfkx0hGFHsnFoNG01c020V/aSE=', 0, N'ACTIVO', N'sosa@gmail.com', 91816)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (10, N'c29zYTE=', N'vO3Ze75EW442EbFRPi3ecDtFKm7gLz4QkBZRJCN0/U8=', 0, N'ACTIVO', N'sosa1@gmail.com', 91577)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (11, N'cm9kcmk=', N'xjYzHPLH/4KcNYuLsc3F2fNlpQlwPL8BFTHQHTljBXE=', 0, N'ACTIVO', N'rodri@gmail.com', 98303)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
USE [master]
GO
ALTER DATABASE [Diploma] SET  READ_WRITE 
GO
