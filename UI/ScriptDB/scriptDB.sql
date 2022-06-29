USE [master]
GO
/****** Object:  Database [Diploma]    Script Date: 29/6/2022 17:55:05 ******/
CREATE DATABASE [Diploma]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diploma', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Diploma.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Diploma_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Diploma_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
EXEC sys.sp_db_vardecimal_storage_format N'Diploma', N'ON'
GO
ALTER DATABASE [Diploma] SET QUERY_STORE = OFF
GO
USE [Diploma]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 29/6/2022 17:55:05 ******/
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
/****** Object:  Table [dbo].[DigitoVerificador]    Script Date: 29/6/2022 17:55:05 ******/
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
/****** Object:  Table [dbo].[etiquetas]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etiquetas](
	[id_etiqueta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_etiqueta] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[idPermisoPadre] [int] NOT NULL,
	[idPermisoHijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 29/6/2022 17:55:05 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Permiso] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[ID_UnidadMedida] [int] NOT NULL,
	[LeadTimeCompra] [int] NULL,
	[ConsumoMensual] [float] NULL,
	[ConsumoTrimestral] [float] NULL,
	[ConsumoSemestral] [float] NULL,
	[StockMinimo] [float] NULL,
	[StockOptimo] [float] NULL,
	[Estado] [nvarchar](15) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [nvarchar](50) NOT NULL,
	[cuit] [int] NOT NULL,
	[direccion] [nvarchar](50) NULL,
	[telefono] [int] NULL,
	[estado] [nvarchar](15) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 29/6/2022 17:55:05 ******/
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
/****** Object:  Table [dbo].[Unidad_Medida]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad_Medida](
	[Id_UnidadMedida] [int] IDENTITY(1,1) NOT NULL,
	[Simbolo] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[estado] [nvarchar](15) NULL,
 CONSTRAINT [PK_Unidad_Medida] PRIMARY KEY CLUSTERED 
(
	[Id_UnidadMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/6/2022 17:55:05 ******/
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
	[DVH] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Permiso]    Script Date: 29/6/2022 17:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Permiso](
	[idUsuario] [int] NOT NULL,
	[idPermiso] [int] NOT NULL
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
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2950, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBEaWdpdG8gVmVydGljYWwgZGUgbGEgdGFibGE6IFVzdWFyaW8=', 1, N'20220614185440', 828672)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2951, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBndWFyZGFkbyBlbiBsYSB0YWJsYTogVXN1YXJpbw==', 1, N'20220614185441', 737354)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2952, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBEaWdpdG8gVmVydGljYWwgZGUgbGEgdGFibGE6IFVzdWFyaW8=', 1, N'20220614185508', 828744)
INSERT [dbo].[Bitacora] ([id_bitacora], [fk_usuario], [Descripcion], [Criticidad], [Fecha_movimiento], [DVH]) VALUES (2953, 1, N'RXJyb3IgZW4gbGEgdmFsaWRhY2lvbiBkZSBsYSBzdW1hIGRlIGRpZ2l0b3MgaG9yaXpvbnRhbGVzIGNvbiBlbCBndWFyZGFkbyBlbiBsYSB0YWJsYTogVXN1YXJpbw==', 1, N'20220614185508', 737412)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[DigitoVerificador] ON 

INSERT [dbo].[DigitoVerificador] ([id_DV], [nombre_tabla], [valorDVV]) VALUES (1, N'Bitacora', 7995907)
INSERT [dbo].[DigitoVerificador] ([id_DV], [nombre_tabla], [valorDVV]) VALUES (3, N'Usuario', 570702)
SET IDENTITY_INSERT [dbo].[DigitoVerificador] OFF
GO
SET IDENTITY_INSERT [dbo].[etiquetas] ON 

INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (1, N'Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (2, N'Password')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (3, N'Administracion_Permisos')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (4, N'Administracion_Usuarios')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (5, N'ABM_Negocio')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (6, N'Compra')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (7, N'Venta')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (8, N'Idioma')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (9, N'Cerrar Sesion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (10, N'Alta_Permisos')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (11, N'Asignacion_F_P')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (12, N'Asignacion_P_U')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (13, N'Desasignar_Permisos')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (14, N'Alta_Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (15, N'Baja_Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (16, N'Cambio_Password')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (17, N'Desbloquear_Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (18, N'Producto')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (19, N'Proveedor')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (20, N'Español')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (21, N'English')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (22, N'Nombre_Patente')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (23, N'Permiso')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (24, N'Nombre_Familia')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (25, N'Alta_Familia_Patente')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (26, N'Alta_Usuario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (27, N'Email')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (28, N'Alta')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (29, N'Cancelar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (30, N'Familias')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (31, N'Patentes')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (32, N'Agregar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (33, N'Mostrar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (34, N'Guardar_Permiso')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (35, N'Eliminar_Patente')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (36, N'Codigo')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (37, N'Descripcion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (38, N'Unidad_Medida')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (39, N'Stock_Minimo')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (40, N'Stock_Optimo')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (41, N'Baja')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (42, N'Modificar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (43, N'Datos')
SET IDENTITY_INSERT [dbo].[etiquetas] OFF
GO
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 1)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 3)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 4)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 5)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 6)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 7)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 13)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 14)
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (1, N'español', 1)
INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (2, N'ingles', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (1, N'alta usuario', N'Alta_Usuario')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (2, N'Admin', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (3, N'baja usuario', N'Baja_Usuario')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (4, N'cambio password', N'Cambio_Password')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (5, N'Crear Familia Patente', N'Crear_Familia_Patentes')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (6, N'asignar familia patente', N'Asignar_Familia_Patentes')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (7, N'asignar permiso usuario', N'Asignar_Permisos_Usuarios')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (8, N'abm producto', N'Abm_Producto')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (9, N'abm proveedor', N'Abm_Proveedor')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (10, N'gestion compras', N'Gestion_Compras')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (11, N'gestion ventas', N'Gestion_Ventas')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (12, N'Administrador', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (13, N'desbloquear usuario', N'Desbloquear_Usuario')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (14, N'desasignar permiso', N'Desasignar_Permisos')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado]) VALUES (5, N'cl', N'Clavo', 2, 0, 0, 0, 0, 0, 20, N'BAJA')
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado]) VALUES (6, N'tr', N'Tornillo', 2, 0, 0, 0, 0, 10, 50, N'BAJA')
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado]) VALUES (8, N'lm', N'Lamparita', 3, 0, 0, 0, 0, 10, 50, N'BAJA')
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado]) VALUES (9, N'tr', N'tornillo', 2, 0, 0, 0, 0, 50, 100, NULL)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Traducciones] ON 

INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (1, 1, N'Usuario', 1)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (2, 1, N'Contraseña', 2)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (3, 1, N'Administracion Permisos', 3)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (4, 1, N'Administracion Usuarios', 4)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (5, 1, N'ABM Negocio', 5)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (6, 1, N'Compra', 6)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (7, 1, N'Venta', 7)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (8, 1, N'Idioma', 8)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (9, 1, N'Cerrar Sesion', 9)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (10, 1, N'Alta Permisos', 10)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (11, 1, N'Asignacion Familia Patente', 11)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (12, 1, N'Asignacion Permisos Usuarios', 12)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (13, 1, N'Desasignar Permisos', 13)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (14, 1, N'Baja Usuario', 15)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (15, 1, N'Cambio de Password', 16)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (16, 1, N'Desbloquear Usuario', 17)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (17, 1, N'Producto', 18)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (18, 1, N'Proveedor', 19)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (19, 1, N'Español', 20)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (20, 1, N'Ingles', 21)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (21, 1, N'Nombre Patente', 22)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (22, 1, N'Permiso', 23)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (23, 1, N'Nombre Familia', 24)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (24, 1, N'Alta Familia Patente', 25)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (25, 1, N'Alta Usuario', 26)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (26, 1, N'Email', 27)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (27, 1, N'Alta', 28)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (28, 1, N'Cancelar', 29)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (29, 1, N'Familias', 30)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (30, 1, N'Patentes', 31)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (31, 1, N'Agregar', 32)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (32, 1, N'Mostrar', 33)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (33, 1, N'Guardar Permiso', 34)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (34, 1, N'Eliminar Patente', 35)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (35, 1, N'Codigo', 36)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (36, 1, N'Descripcion', 37)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (37, 1, N'Unidad de Medida', 38)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (38, 1, N'Stock Minimo', 39)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (39, 1, N'Stock Optimo', 40)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (40, 1, N'Baja', 41)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (41, 1, N'Modificar', 42)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (42, 1, N'Datos', 43)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (43, 2, N'User', 1)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (44, 2, N'Password', 2)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (45, 2, N'Permission Management', 3)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (46, 2, N'Users Management', 4)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (47, 2, N'CRUD BUSSINESS', 5)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (48, 2, N'Purchasing ', 6)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (49, 2, N'Sales', 7)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (50, 2, N'Language', 8)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (51, 2, N'Sign off', 9)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (52, 2, N'Create Permission', 10)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (53, 2, N'Assign Role Permissions', 11)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (54, 2, N'Assign User Permissions', 12)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (55, 2, N'Unassign Permissions', 13)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (56, 2, N'Delete User', 15)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (57, 2, N'Change Password', 16)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (58, 2, N'Unlock User', 17)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (59, 2, N'Product', 18)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (60, 2, N'Supplier', 19)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (61, 2, N'Spanish', 20)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (62, 2, N'English', 21)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (63, 2, N'Permission Name', 22)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (64, 2, N'Permission', 23)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (65, 2, N'Role Name', 24)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (66, 2, N'Create Permission Role', 25)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (67, 2, N'Create User', 26)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (68, 2, N'Email', 27)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (69, 2, N'Create', 28)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (70, 2, N'Cancel', 29)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (71, 2, N'Role', 30)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (72, 2, N'Permissions', 31)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (73, 2, N'Add', 32)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (74, 2, N'Show', 33)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (75, 2, N'Save Permission', 34)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (76, 2, N'Delete Permission', 35)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (77, 2, N'Code', 36)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (78, 2, N'Description', 37)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (79, 2, N'Unit of Measurement', 38)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (80, 2, N'Minimum Stock', 39)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (81, 2, N'optimal stock', 40)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (82, 2, N'Delete', 41)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (83, 2, N'Update', 42)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (84, 2, N'Data', 43)
SET IDENTITY_INSERT [dbo].[Traducciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Unidad_Medida] ON 

INSERT [dbo].[Unidad_Medida] ([Id_UnidadMedida], [Simbolo], [Nombre], [estado]) VALUES (2, N'KG', N'Kilogramo', NULL)
INSERT [dbo].[Unidad_Medida] ([Id_UnidadMedida], [Simbolo], [Nombre], [estado]) VALUES (3, N'UN', N'Unidad', NULL)
SET IDENTITY_INSERT [dbo].[Unidad_Medida] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (6, N'cGVwZQ==', N'I+oGN4nA6GESI8UXA4mssXVmXvlkU1/zm1hO8XsU9YE=', 1, NULL, N'pepe@gmail.com', 0)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (14, N'dG90bw==', N'/w17GWbXw7K32raL1vG7L3d0hRmg9O0DxeEWUCRHRj0=', 1, NULL, N'toto@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (6, 12)
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (6, 10)
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (6, 11)
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (6, 8)
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Unidad_Medida] FOREIGN KEY([ID_UnidadMedida])
REFERENCES [dbo].[Unidad_Medida] ([Id_UnidadMedida])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Unidad_Medida]
GO
USE [master]
GO
ALTER DATABASE [Diploma] SET  READ_WRITE 
GO
