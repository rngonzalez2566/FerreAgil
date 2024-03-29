USE [master]
GO
/****** Object:  Database [Diploma]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Compra]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[id_Compra] [int] IDENTITY(1,1) NOT NULL,
	[Nro] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Detalle] [nvarchar](200) NULL,
	[Total] [float] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[FechaRecepcion] [datetime] NULL,
	[FechaRecepcionAlmacen] [datetime] NULL,
	[id_Proveedor] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[id_Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Compra]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Compra](
	[id_Detalle_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_compra] [int] NOT NULL,
	[id_Producto] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[CantidadRecepcionada] [float] NULL,
 CONSTRAINT [PK_Detalle_Compra] PRIMARY KEY CLUSTERED 
(
	[id_Detalle_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificador]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[etiquetas]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etiquetas](
	[id_etiqueta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_etiqueta] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[idPermisoPadre] [int] NOT NULL,
	[idPermisoHijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 26/7/2022 17:57:12 ******/
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
	[PrecioUnitario] [float] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[spResult]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[spResult](
	[idPermisoPadre] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 26/7/2022 17:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [float] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Unidad_Medida]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/7/2022 17:57:12 ******/
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
/****** Object:  Table [dbo].[Usuario_Permiso]    Script Date: 26/7/2022 17:57:12 ******/
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
SET IDENTITY_INSERT [dbo].[Compra] ON 

INSERT [dbo].[Compra] ([id_Compra], [Nro], [Fecha], [Detalle], [Total], [Estado], [FechaRecepcion], [FechaRecepcionAlmacen], [id_Proveedor]) VALUES (4, 1, CAST(N'2022-07-14T00:00:00.000' AS DateTime), N'', 3950, N'Pedido Recepcionado', NULL, NULL, 2)
INSERT [dbo].[Compra] ([id_Compra], [Nro], [Fecha], [Detalle], [Total], [Estado], [FechaRecepcion], [FechaRecepcionAlmacen], [id_Proveedor]) VALUES (5, 2, CAST(N'2022-07-14T00:00:00.000' AS DateTime), N'', 3950, N'Pedido Recepcionado Almacen', NULL, NULL, 3)
INSERT [dbo].[Compra] ([id_Compra], [Nro], [Fecha], [Detalle], [Total], [Estado], [FechaRecepcion], [FechaRecepcionAlmacen], [id_Proveedor]) VALUES (6, 3, CAST(N'2022-07-14T00:00:00.000' AS DateTime), N'adssadasda', 26800, N'Pedido Recepcionado Almacen', NULL, NULL, 3)
INSERT [dbo].[Compra] ([id_Compra], [Nro], [Fecha], [Detalle], [Total], [Estado], [FechaRecepcion], [FechaRecepcionAlmacen], [id_Proveedor]) VALUES (7, 4, CAST(N'2022-07-14T00:00:00.000' AS DateTime), N'', 9460, N'Enviado Proveedor', NULL, NULL, 4)
INSERT [dbo].[Compra] ([id_Compra], [Nro], [Fecha], [Detalle], [Total], [Estado], [FechaRecepcion], [FechaRecepcionAlmacen], [id_Proveedor]) VALUES (8, 5, CAST(N'2022-07-14T00:00:00.000' AS DateTime), N'', 104060, N'Enviado Proveedor', NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Compra] OFF
GO
SET IDENTITY_INSERT [dbo].[Detalle_Compra] ON 

INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (1, 4, 9, 100, 10, 1000, 90)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (2, 4, 10, 295, 10, 2950, 295)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (3, 5, 9, 100, 10, 1000, 100)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (4, 5, 10, 295, 10, 2950, 280)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (5, 6, 13, 100, 200, 20000, 100)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (6, 6, 14, 200, 34, 6800, 10)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (7, 7, 14, 190, 34, 6460, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (8, 7, 13, 10, 200, 2000, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (9, 7, 10, 50, 10, 500, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (10, 7, 9, 50, 10, 500, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (11, 8, 14, 190, 34, 6460, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (12, 8, 15, 300, 300, 90000, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (13, 8, 16, 30, 250, 7500, NULL)
INSERT [dbo].[Detalle_Compra] ([id_Detalle_compra], [id_compra], [id_Producto], [Cantidad], [PrecioUnitario], [Total], [CantidadRecepcionada]) VALUES (14, 8, 11, 10, 10, 100, NULL)
SET IDENTITY_INSERT [dbo].[Detalle_Compra] OFF
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
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (44, N'Alta_Idioma')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (45, N'Alta_Etiqueta')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (46, N'Nombre_Idioma')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (47, N'Etiqueta')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (48, N'Traduccion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (49, N'Compra_Materiales')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (50, N'Nro')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (51, N'Fecha')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (52, N'Detalle')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (53, N'Proveedor')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (54, N'Eliminar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (55, N'Aceptar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (56, N'Compra_Materiales')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (57, N'Precio_Unitario')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (58, N'Total')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (59, N'Pendiente_Envio_Prov')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (60, N'Enviar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (61, N'Comprobante_Nro')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (62, N'Recepcion_Materiales')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (63, N'Cantidad_Recepcionada')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (64, N'Pendiente_Envio_Almacen')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (65, N'Recepcion_Almacen')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (66, N'Enviar_A_Modificar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (67, N'Recepcion_Almacen')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (68, N'Analisis_Compra')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (69, N'Analisis_Stock_Productos')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (70, N'Debajo_Stock_Minimo')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (71, N'Debajo_Stock_Optimo')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (72, N'Sin_PP')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (73, N'Fecha_REcepcion')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (74, N'REcepcionar')
INSERT [dbo].[etiquetas] ([id_etiqueta], [nombre_etiqueta]) VALUES (75, N'Administracion_Idioma')
SET IDENTITY_INSERT [dbo].[etiquetas] OFF
GO
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 1)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 3)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (40, 41)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (40, 42)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (40, 43)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (42, 44)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (43, 44)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 4)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 5)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 6)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 7)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 13)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 14)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 18)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 19)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 20)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 21)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 22)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 23)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 24)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (12, 25)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (43, 45)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (44, 46)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (46, 41)
INSERT [dbo].[Familia_Patente] ([idPermisoPadre], [idPermisoHijo]) VALUES (45, 41)
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (1, N'español', 1)
INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (2, N'ingles', 0)
INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (10, N'frances', 0)
INSERT [dbo].[Idioma] ([id_idioma], [nombre], [Default]) VALUES (11, N'portugues', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (1, N'alta usuario', N'Alta_Usuario')
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
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (16, N'sarasa', N'Gestion_Ventas')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (18, N'Alta Idioma', N'Alta_Idioma')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (19, N'Alta Etiqueta', N'Alta_Etiquetas')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (20, N'Compra Materiales', N'Compra_Materiales')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (21, N'Pendiente Envio Prov', N'Pendiente_Envio_Prov')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (22, N'Recepcion Materiales', N'Recepcion_Materiales')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (23, N'Pendiente Envio Almacen', N'Pendiente_Envio_Almacen')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (24, N'Recepcion Almacen', N'Recepcion_Almacen')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (25, N'Analisis Compra', N'Analisis_Stock')
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (40, N'Familia A', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (41, N'Familia B', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (42, N'Familia C', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (43, N'Familia D', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (44, N'Familia E', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (45, N'Familia F', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (46, N'Familia G', NULL)
INSERT [dbo].[Permiso] ([idPermiso], [Nombre], [Permiso]) VALUES (47, N'administrador1', NULL)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (5, N'cl', N'Clavo', 2, 0, 0, 0, 0, 0, 20, N'BAJA', 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (6, N'tr', N'Tornillo', 2, 0, 0, 0, 0, 10, 50, N'BAJA', 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (8, N'lm', N'Lamparita', 3, 0, 0, 0, 0, 10, 50, N'BAJA', 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (9, N'tr', N'tornillo', 2, 0, 0, 0, 0, 50, 100, NULL, 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (10, N'cl', N'Clavo', 2, 0, 0, 0, 0, 10, 300, NULL, 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (11, N'tg', N'tarugo', 3, 0, 0, 0, 0, 0, 0, NULL, 10)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (12, N'ar', N'arandela', 3, 0, 0, 0, 0, 0, 100, NULL, 15)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (13, N'cs', N'Cierras', 3, 0, 0, 0, 0, 10, 100, NULL, 200)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (14, N'ff', N'Destornillador', 3, 0, 0, 0, 0, 40, 200, NULL, 34)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (15, N'gf', N'Caños', 3, 0, 0, 0, 0, 50, 300, NULL, 300)
INSERT [dbo].[Producto] ([ID_Producto], [Codigo], [Descripcion], [ID_UnidadMedida], [LeadTimeCompra], [ConsumoMensual], [ConsumoTrimestral], [ConsumoSemestral], [StockMinimo], [StockOptimo], [Estado], [PrecioUnitario]) VALUES (16, N'cv', N'manguera', 3, 0, 0, 0, 0, 10, 30, NULL, 250)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([id_Proveedor], [razonSocial], [cuit], [direccion], [telefono], [estado]) VALUES (2, N'Sanitarios SRL', 123123123, NULL, NULL, NULL)
INSERT [dbo].[Proveedor] ([id_Proveedor], [razonSocial], [cuit], [direccion], [telefono], [estado]) VALUES (3, N'GriFerias SRL', 121312333, NULL, NULL, NULL)
INSERT [dbo].[Proveedor] ([id_Proveedor], [razonSocial], [cuit], [direccion], [telefono], [estado]) VALUES (4, N'Product Gral ', 341413122, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
INSERT [dbo].[spResult] ([idPermisoPadre]) VALUES (40)
INSERT [dbo].[spResult] ([idPermisoPadre]) VALUES (43)
INSERT [dbo].[spResult] ([idPermisoPadre]) VALUES (44)
INSERT [dbo].[spResult] ([idPermisoPadre]) VALUES (45)
INSERT [dbo].[spResult] ([idPermisoPadre]) VALUES (46)
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([id_stock], [id_producto], [cantidad]) VALUES (1, 10, 285)
INSERT [dbo].[Stock] ([id_stock], [id_producto], [cantidad]) VALUES (2, 12, 120)
INSERT [dbo].[Stock] ([id_stock], [id_producto], [cantidad]) VALUES (3, 9, 50)
INSERT [dbo].[Stock] ([id_stock], [id_producto], [cantidad]) VALUES (4, 13, 100)
INSERT [dbo].[Stock] ([id_stock], [id_producto], [cantidad]) VALUES (5, 14, 10)
SET IDENTITY_INSERT [dbo].[Stock] OFF
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
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (87, 2, N'Create language', 44)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (88, 1, N'Crear Idioma', 44)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (89, 1, N'Alta etiqueta', 45)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (90, 2, N'Create label', 45)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (91, 2, N'Name language', 46)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (92, 1, N'Nombre Idioma', 46)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (93, 1, N'Etiqueta', 47)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (94, 2, N'Label', 47)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (95, 2, N'Translation', 48)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (96, 1, N'Traduccion', 48)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (97, 1, N'Compra Materiales', 49)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (98, 2, N'Purchase products', 49)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (99, 2, N'Number', 50)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (100, 1, N'Nro', 50)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (101, 1, N'Fecha', 51)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (102, 2, N'Date', 51)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (103, 2, N'Detail', 52)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (104, 1, N'Detalle', 52)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (105, 1, N'Eliminar', 54)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (106, 2, N'Delete', 54)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (107, 1, N'Aceptar', 55)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (108, 2, N'accept', 55)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (109, 2, N'Unit Price', 57)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (110, 1, N'Precio Unitario', 57)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (111, 1, N'Total', 58)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (112, 2, N'Total', 58)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (113, 1, N'Pendiente Envio Proveedor', 59)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (114, 2, N'Pending delivery to supplier', 59)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (115, 2, N'Send', 60)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (116, 1, N'Enviar', 60)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (117, 1, N'Comprobante Nro', 61)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (118, 2, N'Voucher Number', 61)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (119, 1, N'Recepcion Materiales', 62)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (120, 2, N'Product receipt', 62)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (121, 2, N'Quantity received', 63)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (122, 1, N'Cantidad Recepcionada', 63)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (123, 1, N'Pendiente Envio Almacen', 64)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (124, 2, N'pending shipping warehouse', 64)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (125, 2, N'warehouse reception', 65)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (126, 1, N'Recepcion Almacen', 65)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (127, 1, N'Enviar a Modificar', 66)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (128, 2, N'send to modify', 66)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (129, 2, N'purchase analysis', 68)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (130, 1, N'Analisis de Compra', 68)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (131, 1, N'Analisis Stock Productos', 69)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (132, 2, N'product stock analysis', 69)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (133, 1, N'Debajo del Stock Minimo', 70)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (134, 2, N'below the minimum stock', 70)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (135, 1, N'Debajo de Stock Optimo', 71)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (136, 2, N'below optimal stock', 71)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (137, 1, N'Sin punto de pedido o Stock Optimo', 72)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (138, 2, N'No reorder point or Optimal Stock', 72)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (139, 1, N'Fecha Recepcion', 73)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (141, 2, N'Recive', 74)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (142, 1, N'Recepcionar', 74)
GO
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (143, 1, N'Administracion Idioma', 75)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (144, 2, N'Admintistration Language', 75)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (145, 10, N'rodrigo', 3)
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
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (140, 2, N'Reception Date', 73)
INSERT [dbo].[Traducciones] ([id_traducciones], [id_idioma], [traduccion], [id_etiqueta]) VALUES (146, 11, N'rodrigo', 3)
SET IDENTITY_INSERT [dbo].[Traducciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Unidad_Medida] ON 

INSERT [dbo].[Unidad_Medida] ([Id_UnidadMedida], [Simbolo], [Nombre], [estado]) VALUES (2, N'KG', N'Kilogramo', NULL)
INSERT [dbo].[Unidad_Medida] ([Id_UnidadMedida], [Simbolo], [Nombre], [estado]) VALUES (3, N'UN', N'Unidad', NULL)
SET IDENTITY_INSERT [dbo].[Unidad_Medida] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (16, N'YWRtaW4=', N'MUtBEjSxMp74dF6DqaQ8XcltOX4qEMuRPX8IPj6TIKI=', 1, NULL, N'admin@gmail.com', NULL)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (17, N'dXNlcjE=', N'R0QA2QYLyMIWe++ChBEZqFr/ZPaiVuZJEiuk+NjQcnI=', 0, NULL, N'user1@gmail.com', NULL)
INSERT [dbo].[Usuario] ([id_usuario], [usuario], [contrasena], [contador], [estado], [email], [DVH]) VALUES (18, N'dXNlcjI=', N'rJ5ywPSoukg32fHAbupSl3suldqi9p6JVKcLsL/UJdA=', 0, NULL, N'user2@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (6, 12)
INSERT [dbo].[Usuario_Permiso] ([idUsuario], [idPermiso]) VALUES (16, 12)
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Unidad_Medida] FOREIGN KEY([ID_UnidadMedida])
REFERENCES [dbo].[Unidad_Medida] ([Id_UnidadMedida])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Unidad_Medida]
GO
/****** Object:  StoredProcedure [dbo].[CrearTablaTemporal]    Script Date: 26/7/2022 17:57:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CrearTablaTemporal]
@idFamilia int

as
DROP TABLE IF EXISTS spResult    
create table spResult (idPermisoPadre int)
insert into spResult exec  dbo.traerRecursiva @idFamilia
select * from spResult 
GO
/****** Object:  StoredProcedure [dbo].[TraerRecursiva]    Script Date: 26/7/2022 17:57:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerRecursiva]
@idFamilia int = 41

AS


WITH RECURSIVO AS (SELECT fp.idPermisoPadre, fp.idPermisoHijo, 0 as cont FROM Familia_Patente fp 
WHERE fp.idPermisoPadre in(
Select fpp.idPermisoPadre
from Familia_Patente fpp
inner join Permiso pp2 on pp2.idPermiso = fpp.idPermisoPadre
where fpp.idPermisoHijo in (
SELECT fp.idPermisoPadre
FROM Familia_Patente fp 
inner join permiso p1 on p1.idPermiso = fp.idPermisoPadre
WHERE fp.idPermisoHijo = @idFamilia)
UNION ALL
SELECT fp.idPermisoPadre
FROM Familia_Patente fp 
inner join permiso p1 on p1.idPermiso = fp.idPermisoPadre
WHERE fp.idPermisoHijo = @idFamilia
)
UNION ALL 
SELECT fp2.idPermisoPadre, fp2.idPermisoHijo, cont + 1
FROM Familia_Patente fp2 INNER JOIN RECURSIVO r
on r.idPermisoHijo = fp2.idPermisoPadre)
SELECT r.idPermisoPadre 
FROM RECURSIVO r
INNER JOIN Permiso p on r.idPermisoHijo = p.idPermiso
INNER JOIN Permiso p1 on r.idPermisoPadre = p1.idPermiso
inner join Permiso p3 on p3.idPermiso = @idFamilia
where (cont = 0 or ( p.idPermiso = @idFamilia))
group by r.idPermisoPadre,p1.Nombre

GO
USE [master]
GO
ALTER DATABASE [Diploma] SET  READ_WRITE 
GO
