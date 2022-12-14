USE [master]
GO
/****** Object:  Database [db_a8e200_dbsalesment]    Script Date: 19/10/2022 10:21:19 ******/
CREATE DATABASE [db_a8e200_dbsalesment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_a8e200_dbsalesment_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a8e200_dbsalesment_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'db_a8e200_dbsalesment_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_a8e200_dbsalesment_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_a8e200_dbsalesment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET  MULTI_USER 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET QUERY_STORE = OFF
GO
USE [db_a8e200_dbsalesment]
GO
/****** Object:  Table [dbo].[TBL_BODEGA]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BODEGA](
	[ID_BODEGA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTANTERIA] [int] NOT NULL,
	[NIVEL] [int] NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_BODEGA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_CATEGORIA]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CATEGORIA](
	[ID_CATEGORIA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_CLIENTE]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CLIENTE](
	[ID_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DIRECCION] [varchar](200) NOT NULL,
	[TELEFONO] [varchar](15) NOT NULL,
	[EMAIL] [varchar](50) NOT NULL,
	[NIT] [varchar](20) NOT NULL,
	[CREADO_POR] [varchar](20) NULL,
	[ESTADO] [int] NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_EMPLEADO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_EMPLEADO](
	[ID_EMPLEADO] [int] NOT NULL,
	[PRIMER_NOMBRE] [varchar](50) NULL,
	[SEGUNDO_NOMBRE] [varchar](50) NULL,
	[PRIMER_APELLIDO] [varchar](50) NULL,
	[SEGUNDO_APELLIDO] [varchar](50) NULL,
	[DIRECCION] [varchar](200) NOT NULL,
	[TELEFONO] [varchar](15) NOT NULL,
	[ID_TIPO_EMPLEADO] [int] NOT NULL,
	[EMAIL] [varchar](50) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
	[URL_FOTOGRAFIA] [varchar](150) NULL,
 CONSTRAINT [PK__TBL_EMPL__922CA26924A9EE0E] PRIMARY KEY CLUSTERED 
(
	[ID_EMPLEADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MARCA_REPUESTO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MARCA_REPUESTO](
	[ID_MARCA_REPUESTO] [int] NOT NULL,
	[NOMBRE] [varchar](200) NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[ESTADO] [int] NULL,
	[CREADO_POR] [varchar](200) NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MARCA_REPUESTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MARCA_VEHICULO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MARCA_VEHICULO](
	[ID_MARCA_VEHICULO] [int] NOT NULL,
	[NOMBRE] [varchar](200) NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[ESTADO] [int] NULL,
	[CREADO_POR] [varchar](200) NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MARCA_VEHICULO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MODELO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MODELO](
	[ID_MODELO] [int] IDENTITY(1,1) NOT NULL,
	[FECHA_INICIAL] [datetime] NULL,
	[FECHA_FINAL] [datetime] NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MODELO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_PRODUCTO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_PRODUCTO](
	[ID_PRODUCTO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[PRECIO_COSTO] [decimal](18, 2) NOT NULL,
	[PRECIO_VENTA] [decimal](18, 2) NOT NULL,
	[STOCK] [int] NOT NULL,
	[CODIGO] [varchar](25) NOT NULL,
	[ID_BODEGA] [int] NOT NULL,
	[CREADO_POR] [varchar](20) NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
	[ID_SUBCATEGORIA] [int] NULL,
	[ID_MODELO] [int] NULL,
	[ID_PROVEEDOR] [int] NULL,
	[ID_MARCA_REPUESTO] [int] NULL,
	[ID_SERIE_VEHICULO] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_PROVEEDOR]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_PROVEEDOR](
	[ID_PROVEEDOR] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[TELEFONO] [varchar](15) NOT NULL,
	[DIRECCION] [varchar](200) NOT NULL,
	[CONTACTO] [varchar](50) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PROVEEDOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_ROL]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ROL](
	[ID_ROL] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_SERIE_VEHICULO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_SERIE_VEHICULO](
	[ID_SERIE_VEHICULO] [int] NOT NULL,
	[NOMBRE] [varchar](200) NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[ESTADO] [int] NULL,
	[CREADO_POR] [varchar](200) NULL,
	[FECHA_CREACION] [datetime] NULL,
	[ID_MARCA_VEHICULO] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_SERIE_VEHICULO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_SUBCATEGORIA]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_SUBCATEGORIA](
	[ID_SUBCATEGORIA] [int] NOT NULL,
	[NOMBRE] [varchar](200) NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[ID_CATEGORIA] [int] NULL,
	[ESTADO] [int] NULL,
	[CREADO_POR] [varchar](200) NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_SUBCATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_SUMINISTRA]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_SUMINISTRA](
	[ID_PROVEEDOR] [int] NOT NULL,
	[ID_PRODUCTO] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_TIPO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_TIPO](
	[ID_TIPO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_TIPO_EMPLEADO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_TIPO_EMPLEADO](
	[ID_TIPO_EMPLEADO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](200) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_TIPO_EMPLEADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_USUARIO]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_USUARIO](
	[ID_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](50) NOT NULL,
	[CONTRASEÑA] [varchar](50) NOT NULL,
	[ID_EMPLEADO] [int] NOT NULL,
	[ID_ROL] [int] NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
	[url_pantalla] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_VENTA]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_VENTA](
	[ID_VENTA] [int] IDENTITY(1,1) NOT NULL,
	[SERIE] [varchar](10) NOT NULL,
	[CORRELATIVO] [decimal](18, 2) NULL,
	[FECHA] [datetime] NOT NULL,
	[ID_CLIENTE] [int] NOT NULL,
	[TOTAL] [decimal](18, 2) NOT NULL,
	[SUBTOTAL] [decimal](18, 2) NOT NULL,
	[TOTAL_IVA] [decimal](18, 2) NOT NULL,
	[TOTAL_DESCUENTO] [decimal](18, 2) NOT NULL,
	[CREADO_POR] [varchar](20) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[FECHA_CREACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_VENTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_VENTA_DETALLE]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_VENTA_DETALLE](
	[ID_VENTA_DETALLE] [int] IDENTITY(1,1) NOT NULL,
	[ID_VENTA] [int] NOT NULL,
	[ID_PRODUCTO] [int] NOT NULL,
	[ID_CANTIDAD] [int] NOT NULL,
	[PRECIO_UNITARIO] [decimal](18, 2) NOT NULL,
	[TOTAL] [decimal](18, 2) NOT NULL,
	[IVA] [decimal](18, 2) NOT NULL,
	[DESCUENTO] [decimal](18, 2) NOT NULL,
	[SUBTOTAL] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_VENTA_DETALLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_EMPLE__ID_TI__151B244E] FOREIGN KEY([ID_TIPO_EMPLEADO])
REFERENCES [dbo].[TBL_TIPO_EMPLEADO] ([ID_TIPO_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_EMPLEADO] CHECK CONSTRAINT [FK__TBL_EMPLE__ID_TI__151B244E]
GO
ALTER TABLE [dbo].[TBL_EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_EMPLE__ID_TI__3F466844] FOREIGN KEY([ID_TIPO_EMPLEADO])
REFERENCES [dbo].[TBL_TIPO_EMPLEADO] ([ID_TIPO_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_EMPLEADO] CHECK CONSTRAINT [FK__TBL_EMPLE__ID_TI__3F466844]
GO
ALTER TABLE [dbo].[TBL_EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_EMPLE__ID_TI__5BE2A6F2] FOREIGN KEY([ID_TIPO_EMPLEADO])
REFERENCES [dbo].[TBL_TIPO_EMPLEADO] ([ID_TIPO_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_EMPLEADO] CHECK CONSTRAINT [FK__TBL_EMPLE__ID_TI__5BE2A6F2]
GO
ALTER TABLE [dbo].[TBL_EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_EMPLE__ID_TI__787EE5A0] FOREIGN KEY([ID_TIPO_EMPLEADO])
REFERENCES [dbo].[TBL_TIPO_EMPLEADO] ([ID_TIPO_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_EMPLEADO] CHECK CONSTRAINT [FK__TBL_EMPLE__ID_TI__787EE5A0]
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_BODEGA])
REFERENCES [dbo].[TBL_BODEGA] ([ID_BODEGA])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_BODEGA])
REFERENCES [dbo].[TBL_BODEGA] ([ID_BODEGA])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_BODEGA])
REFERENCES [dbo].[TBL_BODEGA] ([ID_BODEGA])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_BODEGA])
REFERENCES [dbo].[TBL_BODEGA] ([ID_BODEGA])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_MARCA_REPUESTO])
REFERENCES [dbo].[TBL_MARCA_REPUESTO] ([ID_MARCA_REPUESTO])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_MODELO])
REFERENCES [dbo].[TBL_MODELO] ([ID_MODELO])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_SERIE_VEHICULO])
REFERENCES [dbo].[TBL_SERIE_VEHICULO] ([ID_SERIE_VEHICULO])
GO
ALTER TABLE [dbo].[TBL_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([ID_SUBCATEGORIA])
REFERENCES [dbo].[TBL_SUBCATEGORIA] ([ID_SUBCATEGORIA])
GO
ALTER TABLE [dbo].[TBL_PROVEEDOR]  WITH CHECK ADD FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[TBL_PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[TBL_SERIE_VEHICULO]  WITH CHECK ADD FOREIGN KEY([ID_MARCA_VEHICULO])
REFERENCES [dbo].[TBL_MARCA_VEHICULO] ([ID_MARCA_VEHICULO])
GO
ALTER TABLE [dbo].[TBL_SUBCATEGORIA]  WITH CHECK ADD FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[TBL_CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[TBL_PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[TBL_PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[TBL_PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_SUMINISTRA]  WITH CHECK ADD FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[TBL_PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_USUAR__ID_EM__01142BA1] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[TBL_EMPLEADO] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_USUARIO] CHECK CONSTRAINT [FK__TBL_USUAR__ID_EM__01142BA1]
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_USUAR__ID_EM__1DB06A4F] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[TBL_EMPLEADO] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_USUARIO] CHECK CONSTRAINT [FK__TBL_USUAR__ID_EM__1DB06A4F]
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_USUAR__ID_EM__47DBAE45] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[TBL_EMPLEADO] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_USUARIO] CHECK CONSTRAINT [FK__TBL_USUAR__ID_EM__47DBAE45]
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK__TBL_USUAR__ID_EM__6477ECF3] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[TBL_EMPLEADO] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[TBL_USUARIO] CHECK CONSTRAINT [FK__TBL_USUAR__ID_EM__6477ECF3]
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[TBL_ROL] ([ID_ROL])
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[TBL_ROL] ([ID_ROL])
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[TBL_ROL] ([ID_ROL])
GO
ALTER TABLE [dbo].[TBL_USUARIO]  WITH CHECK ADD FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[TBL_ROL] ([ID_ROL])
GO
ALTER TABLE [dbo].[TBL_VENTA]  WITH CHECK ADD FOREIGN KEY([ID_CLIENTE])
REFERENCES [dbo].[TBL_CLIENTE] ([ID_CLIENTE])
GO
ALTER TABLE [dbo].[TBL_VENTA]  WITH CHECK ADD FOREIGN KEY([ID_CLIENTE])
REFERENCES [dbo].[TBL_CLIENTE] ([ID_CLIENTE])
GO
ALTER TABLE [dbo].[TBL_VENTA]  WITH CHECK ADD FOREIGN KEY([ID_CLIENTE])
REFERENCES [dbo].[TBL_CLIENTE] ([ID_CLIENTE])
GO
ALTER TABLE [dbo].[TBL_VENTA]  WITH CHECK ADD FOREIGN KEY([ID_CLIENTE])
REFERENCES [dbo].[TBL_CLIENTE] ([ID_CLIENTE])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[TBL_PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_VENTA])
REFERENCES [dbo].[TBL_VENTA] ([ID_VENTA])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_VENTA])
REFERENCES [dbo].[TBL_VENTA] ([ID_VENTA])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_VENTA])
REFERENCES [dbo].[TBL_VENTA] ([ID_VENTA])
GO
ALTER TABLE [dbo].[TBL_VENTA_DETALLE]  WITH CHECK ADD FOREIGN KEY([ID_VENTA])
REFERENCES [dbo].[TBL_VENTA] ([ID_VENTA])
GO
/****** Object:  StoredProcedure [dbo].[sp_clientes]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_clientes](@NOMBRE        VARCHAR(50) = NULL,
                                    @DIRECCION     VARCHAR(200) = NULL,
                                    @TELEFONO      VARCHAR(15) = NULL,
                                    @EMAIL         VARCHAR(50) = NULL,
                                    @NIT           VARCHAR(20) = NULL,
                                    @CREADO_POR    VARCHAR(50) = NULL,
                                    @ID_CLIENTE    INT = NULL,
                                    @MTIPO         INT)
AS
    DECLARE @resultado  VARCHAR(2),
            @mrespuesta VARCHAR(100)

    SET @resultado ='01'
    SET @mrespuesta =''

    BEGIN TRANSACTION

    SELECT @resultado = Count(*)
    FROM   tbl_empleado

  BEGIN try
      IF @MTIPO = 1
        BEGIN
            INSERT INTO tbl_cliente
                        (nombre,
                         direccion,
                         telefono,
                         email,
                         nit,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      (@NOMBRE,
                         @DIRECCION,
                         @TELEFONO,
                         @EMAIL,
                         @NIT,
                         @CREADO_POR,
                         1,
                         Getdate());

            SELECT @resultado AS RESULTADO;
        END

      IF @MTIPO = 2
        BEGIN
            UPDATE tbl_cliente
            SET    nombre = @NOMBRE,
                   direccion = @DIRECCION,
                   telefono = @TELEFONO,
                   email = @EMAIL,
                   nit = @NIT
            WHERE  id_cliente = @ID_CLIENTE;
        END

      IF @MTIPO = 3
        BEGIN
            UPDATE tbl_cliente
            SET    estado = 0
            WHERE  id_cliente = @ID_CLIENTE;
        END

      IF @MTIPO = 4
        BEGIN
            SELECT nombre,
                   direccion,
                   telefono,
                   email,
				   nit,
                   estado
            FROM   tbl_cliente
            ORDER  BY nombre;
        END

      COMMIT TRANSACTION
  END try

  BEGIN catch
      -- si existe error,  ingresa al CATCH y alli podemos manejar la informacion
      ROLLBACK TRANSACTION;

      PRINT Error_message()

      PRINT Error_line()

      --insert into pv_transac_sistemas_log (cod_pais,cod_emp,sistema,fecha,modulo,tipo_error,mensaje,procedimiento,correo) values (@mcod_pais,@mcod_emp,@msistema,getdate(),@modulo, ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_LINE(),'N')
      IF Error_number() = 70203
        BEGIN
            -- SELECT ERROR_NUMBER() AS NumeroError, ERROR_SEVERITY() AS ErrorSeverity, ERROR_STATE() AS StadoError, ERROR_PROCEDURE() AS Procedimiento, ERROR_LINE() AS LineaError, ERROR_MESSAGE() AS MensajeError
            SELECT Error_message() AS codigo_respuesta,
                   @mrespuesta     mensaje_respuesta
        END;
  END catch
GO
/****** Object:  StoredProcedure [dbo].[sp_inventario]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_inventario] (@NOMBRE         VARCHAR(50) = NULL,
                                       @DESCRIPCION    VARCHAR(200) = NULL,
                                       @ESTANTE        INT = NULL,
                                       @NIVEL          INT = NULL,
                                       @CREADO_POR     VARCHAR(50) = NULL,
                                       @ID_PRODUCTO    INT = NULL,
                                       @ID_CATEGORIA   INT = NULL,
                                       @ID_MODELO      INT = NULL,
                                       @ID_TIPO        INT = NULL,
                                       @ID_BODEGA      INT = NULL,
                                       @PRECIO_COSTO   DECIMAL = NULL,
                                       @PRECIO_VENTA   DECIMAL = NULL,
                                       @STOCK          INT = NULL,
                                       @ANIO_FABRICADO INT = NULL,
                                       @CODIGO         VARCHAR(25) = NULL,
                                       @MTIPO          INT)
AS
    DECLARE @resultado  VARCHAR(2),
            @mrespuesta VARCHAR(100)

    SET @resultado ='01'
    SET @mrespuesta =''

    BEGIN TRANSACTION

  BEGIN try
      /***********************CATEGORIA***********************/
      IF @MTIPO = 1
        BEGIN
            INSERT INTO tbl_categoria
                        (nombre,
                         descripcion,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      ( @NOMBRE,
                          @DESCRIPCION,
                          @CREADO_POR,
                          1,
                          Getdate() );

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 2
        BEGIN
            UPDATE tbl_categoria
            SET    nombre = @NOMBRE,
                   descripcion = @DESCRIPCION
            WHERE  id_categoria = @ID_CATEGORIA;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 3
        BEGIN
            UPDATE tbl_categoria
            SET    estado = 0
            WHERE  id_categoria = @ID_CATEGORIA;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 4
        BEGIN
            SELECT nombre,
                   descripcion,
                   estado,
                   id_categoria
            FROM   tbl_categoria;
        END

      /***********************MODELO***********************/
      IF @MTIPO = 5
        BEGIN
            INSERT INTO tbl_modelo
                        (nombre,
                         descripcion,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      ( @NOMBRE,
                          @DESCRIPCION,
                          @CREADO_POR,
                          1,
                          Getdate() );

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 6
        BEGIN
            UPDATE tbl_modelo
            SET    nombre = @NOMBRE,
                   descripcion = @DESCRIPCION
            WHERE  id_modelo = @ID_MODELO;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 7
        BEGIN
            UPDATE tbl_modelo
            SET    estado = 0
            WHERE  id_modelo = @ID_MODELO;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 8
        BEGIN
            SELECT nombre,
                   descripcion,
                   estado,
                   id_modelo
            FROM   tbl_modelo;
        END

      /***********************TIPO***********************/
      IF @MTIPO = 9
        BEGIN
            INSERT INTO tbl_tipo
                        (nombre,
                         descripcion,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      ( @NOMBRE,
                          @DESCRIPCION,
                          @CREADO_POR,
                          1,
                          Getdate() );

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 10
        BEGIN
            UPDATE tbl_tipo
            SET    nombre = @NOMBRE,
                   descripcion = @DESCRIPCION
            WHERE  id_tipo = @ID_TIPO;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 11
        BEGIN
            UPDATE tbl_tipo
            SET    estado = 0
            WHERE  id_tipo = @ID_TIPO;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 12
        BEGIN
            SELECT nombre,
                   descripcion,
                   estado,
                   id_tipo
            FROM   tbl_tipo;
        END

      /***********************BODEGA***********************/
      IF @MTIPO = 13
        BEGIN
            INSERT INTO tbl_bodega
                        (nombre,
                         estanteria,
                         nivel,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      ( @NOMBRE,
                          @ESTANTE,
                          @NIVEL,
                          @CREADO_POR,
                          1,
                          Getdate() );

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 14
        BEGIN
            UPDATE tbl_bodega
            SET    nombre = @NOMBRE,
                   estanteria = @ESTANTE,
                   nivel = @NIVEL
            WHERE  id_bodega = @ID_BODEGA;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 15
        BEGIN
            UPDATE tbl_bodega
            SET    estado = 0
            WHERE  id_bodega = @ID_BODEGA;

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 16
        BEGIN
            SELECT nombre,
                   estanteria,
                   nivel,
                   estado,
                   id_bodega
            FROM   tbl_bodega;
        END

      IF @MTIPO = 17
        BEGIN
            INSERT INTO tbl_producto
                        (id_categoria,
                         id_modelo,
                         id_tipo,
                         id_bodega,
                         nombre,
                         descripcion,
                         precio_costo,
                         precio_venta,
                         stock,
                         anio_fabricado,
                         codigo,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      (@ID_CATEGORIA,
                         @ID_MODELO,
                         @ID_TIPO,
                         @ID_BODEGA,
                         @NOMBRE,
                         @DESCRIPCION,
                         @PRECIO_COSTO,
                         @PRECIO_VENTA,
                         @STOCK,
                         @ANIO_FABRICADO,
                         @CODIGO,
                         @CREADO_POR,
                         1,
                         Getdate())

            SELECT @resultado AS resultado;
        END

      IF @MTIPO = 18
        BEGIN
            SELECT a.id_producto,
                   A.nombre,
                   A.descripcion,
                   A.precio_costo,
                   A.precio_venta,
                   A.stock,
                   A.anio_fabricado,
                   A.codigo,
                   A.estado,
                   A.creado_por,
                   A.fecha_creacion,
                   B.id_categoria,
                   B.nombre NOMBRE_CATEGORIA,
                   C.id_modelo,
                   C.nombre NOMBRE_MODELO,
                   D.id_tipo,
                   D.nombre NOMBRE_TIPO,
                   E.id_bodega,
                   E.estanteria,
                   E.nivel
            FROM   tbl_producto A
                   LEFT JOIN tbl_categoria B
                          ON A.id_categoria = B.id_categoria
                   LEFT JOIN tbl_modelo C
                          ON A.id_modelo = C.id_modelo
                   LEFT JOIN tbl_tipo D
                          ON A.id_tipo = D.id_tipo
                   LEFT JOIN tbl_bodega E
                          ON E.id_bodega = A.id_bodega
        END

      IF @MTIPO = 19
        BEGIN
            UPDATE tbl_producto
            SET    id_categoria = @ID_CATEGORIA,
                   id_modelo = @ID_MODELO,
                   id_tipo = @ID_TIPO,
                   id_bodega = @ID_BODEGA,
                   nombre = @NOMBRE,
                   descripcion = @DESCRIPCION,
                   precio_costo = @PRECIO_COSTO,
                   precio_venta = @PRECIO_VENTA,
                   stock = @STOCK,
                   anio_fabricado = @ANIO_FABRICADO,
                   codigo = @CODIGO
            WHERE  id_producto = @ID_PRODUCTO;
			SELECT @resultado AS resultado;
        END

      IF @MTIPO = 20
        BEGIN
            UPDATE tbl_producto
            SET    estado = 0
            WHERE  id_producto = @ID_PRODUCTO;
			SELECT @resultado AS resultado;
        END

      COMMIT TRANSACTION
  END try

  BEGIN catch
      -- si existe error,  ingresa al CATCH y alli podemos manejar la informacion
      ROLLBACK TRANSACTION;

      PRINT Error_message()

      PRINT Error_line()

      --insert into pv_transac_sistemas_log (cod_pais,cod_emp,sistema,fecha,modulo,tipo_error,mensaje,procedimiento,correo) values (@mcod_pais,@mcod_emp,@msistema,getdate(),@modulo, ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_LINE(),'N')
      IF Error_number() = 70203
        BEGIN
            -- SELECT ERROR_NUMBER() AS NumeroError, ERROR_SEVERITY() AS ErrorSeverity, ERROR_STATE() AS StadoError, ERROR_PROCEDURE() AS Procedimiento, ERROR_LINE() AS LineaError, ERROR_MESSAGE() AS MensajeError
            SELECT Error_message() AS codigo_respuesta,
                   @mrespuesta     mensaje_respuesta
        END;
  END catch 
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login](@USUARIO  VARCHAR(50) = NULL,
                                           @PASSWORD VARCHAR(50) = NULL,
                                           @MTIPO    INT)
AS
    DECLARE @resultado  VARCHAR(2),
            @mrespuesta VARCHAR(100),
            @rows       INT

    SET @mrespuesta =''

    BEGIN TRANSACTION

  BEGIN try
      SELECT @rows = Count(*)
      FROM   tbl_usuario a
             INNER JOIN tbl_empleado b
                     ON a.id_empleado = b.id_empleado
      WHERE  a.usuario = @USUARIO
             AND a.contraseña = @PASSWORD;

      IF @MTIPO = 1
        BEGIN
            IF @rows > 0
              BEGIN
                  SET @resultado='01';

                  SELECT @resultado AS RESULTADO,
                         a.id_usuario,
                         a.usuario,
                         b.primer_nombre,
                         b.segundo_nombre,
                         b.PRIMER_APELLIDO,
                         b.segundo_apellido,
						 a.url_pantalla,
						 b.url_fotografia as path
                  FROM   tbl_usuario a
                         INNER JOIN tbl_empleado b
                                 ON a.id_empleado = b.id_empleado
                  WHERE  a.usuario = @USUARIO
                         AND a.contraseña = @PASSWORD;
              END
            ELSE
              BEGIN
                  SET @resultado='00'
              END
        END

      COMMIT TRANSACTION
  END try

  BEGIN catch
      -- si existe error,  ingresa al CATCH y alli podemos manejar la informacion
      ROLLBACK TRANSACTION;

      PRINT Error_message()

      PRINT Error_line()

      --insert into pv_transac_sistemas_log (cod_pais,cod_emp,sistema,fecha,modulo,tipo_error,mensaje,procedimiento,correo) values (@mcod_pais,@mcod_emp,@msistema,getdate(),@modulo, ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_LINE(),'N')
      IF Error_number() = 70203
        BEGIN
            -- SELECT ERROR_NUMBER() AS NumeroError, ERROR_SEVERITY() AS ErrorSeverity, ERROR_STATE() AS StadoError, ERROR_PROCEDURE() AS Procedimiento, ERROR_LINE() AS LineaError, ERROR_MESSAGE() AS MensajeError
            SELECT Error_message() AS codigo_respuesta,
                   @mrespuesta     mensaje_respuesta
        END;
  END catch
GO
/****** Object:  StoredProcedure [dbo].[sp_usuarios]    Script Date: 19/10/2022 10:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_usuarios](@PRIMER_NOMBRE    VARCHAR(50) = NULL,
                                           @SEGUNDO_NOMBRE   VARCHAR(50) = NULL,
                                           @PRIMER_APELLIDO  VARCHAR(50) = NULL,
                                           @SEGUNDO_APELLIDO VARCHAR(50) = NULL,
                                           @DIRECCION        VARCHAR(50) = NULL,
                                           @TELEFONO         VARCHAR(50) = NULL,
                                           @ID_TIPO_EMPLEADO INT = NULL,
                                           @EMAIL            VARCHAR(50) = NULL,
                                           @CREADO_POR       VARCHAR(50) = NULL,
                                           @USUARIO          VARCHAR(50) = NULL,
                                           @PASSWORD         VARCHAR(50) = NULL,
                                           @ID_ROL           INT = NULL,
										   @URL_FOTOGRAFIA   VARCHAR(150) = NULL,
                                           @MTIPO            INT)
AS
    DECLARE @rows       INT,
            @fecha      DATETIME,
            @idEmpleado INT,
            @resultado  VARCHAR(2),
            @mrespuesta VARCHAR(100)

    SET @resultado ='01'
    SET @mrespuesta =''
    SET @fecha =Getdate()

    /*
    ---Inserta Bitacora
    insert into pv_sistemas_bitacora (cod_pais,cod_emp,sistema,modulo,tipo,fecha,usuario,comentario) 
    values (@mcod_pais,@mcod_emp,@msistema,@modulo,@mtipo,getdate(),@musuario,@accesion+' '+@mguia+' ')
    */
    BEGIN TRANSACTION

    SELECT @resultado = Count(*)
    FROM   tbl_empleado

    IF @resultado > 0
      BEGIN
          SELECT @idEmpleado = Max(id_empleado) + 1 FROM   tbl_empleado;
      END
    ELSE
      BEGIN
          SET @idEmpleado=1;
      END

  BEGIN try
      IF @MTIPO = 1
        BEGIN
            INSERT INTO tbl_empleado
                        (id_empleado,
                         primer_nombre,
                         segundo_nombre,
                         primer_apellido,
                         segundo_apellido,
                         direccion,
                         telefono,
                         id_tipo_empleado,
                         email,
						 url_fotografia,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      (@idEmpleado,
                         @PRIMER_NOMBRE,
                         @SEGUNDO_NOMBRE,
                         @PRIMER_APELLIDO,
                         @SEGUNDO_APELLIDO,
                         @DIRECCION,
                         @TELEFONO,
                         @ID_TIPO_EMPLEADO,
                         @EMAIL,
						 @URL_FOTOGRAFIA,
                         @CREADO_POR,
                         1,
                         @fecha);

            INSERT INTO tbl_usuario
                        (usuario,
                         contraseña,
                         id_empleado,
                         id_rol,
						 url_pantalla,
                         creado_por,
                         estado,
                         fecha_creacion)
            VALUES      (@USUARIO,
                         @PASSWORD,
                         @idEmpleado,
                         @ID_ROL,
						 'Default/Index',
                         @CREADO_POR,
                         1,
                         @fecha);
            
			SELECT*FROM TBL_EMPLEADO WHERE ID_EMPLEADO=@idEmpleado;
        END

      IF @MTIPO = 2
        BEGIN
            SELECT id_tipo_empleado,
                   nombre,
                   descripcion
            FROM   tbl_tipo_empleado
            WHERE  estado = 1
            ORDER  BY nombre;

            --SELECT @mrespuesta AS RESPUESTA
        END

      IF @MTIPO = 3
        BEGIN
            SELECT id_rol,
                   nombre,
                   descripcion
            FROM   tbl_rol
            WHERE  estado = 1
            ORDER  BY nombre

            --SELECT @mrespuesta AS RESPUESTA
        END
		
      IF @MTIPO = 4
        BEGIN
            --exec sp_usuarios @mtipo=4	

SELECT a.id_usuario,
				   b.id_empleado,
				   a.id_rol,
				   D.NOMBRE AS NOMBRE_ROL,
				   b.id_tipo_empleado,
				   C.NOMBRE AS NOMBRE_TIPO_EMPLEADO,
				   a.usuario,
				   b.primer_nombre,
				   b.segundo_nombre,
				   b.primer_apellido,
				   b.segundo_apellido,
				   b.direccion,
				   b.telefono,
				   b.email,
				   b.estado,
				   a.url_pantalla
			FROM   tbl_usuario a
				   INNER JOIN tbl_empleado b ON a.id_empleado = b.id_empleado 
				   INNER JOIN TBL_TIPO_EMPLEADO C ON C.ID_TIPO_EMPLEADO=B.ID_TIPO_EMPLEADO
				   INNER JOIN TBL_ROL D ON D.ID_ROL=A.ID_ROL
			ORDER BY
				b.PRIMER_NOMBRE;
        END
      COMMIT TRANSACTION
  END try

  BEGIN catch
      -- si existe error,  ingresa al CATCH y alli podemos manejar la informacion
      ROLLBACK TRANSACTION;

      PRINT Error_message()

      PRINT Error_line()

      --insert into pv_transac_sistemas_log (cod_pais,cod_emp,sistema,fecha,modulo,tipo_error,mensaje,procedimiento,correo) values (@mcod_pais,@mcod_emp,@msistema,getdate(),@modulo, ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_LINE(),'N')
      IF Error_number() = 70203
        BEGIN
            -- SELECT ERROR_NUMBER() AS NumeroError, ERROR_SEVERITY() AS ErrorSeverity, ERROR_STATE() AS StadoError, ERROR_PROCEDURE() AS Procedimiento, ERROR_LINE() AS LineaError, ERROR_MESSAGE() AS MensajeError
            SELECT Error_message() AS codigo_respuesta,
                   @mrespuesta     mensaje_respuesta
        END;
  END catch
/*
INSERT INTO TBL_TIPO_EMPLEADO(NOMBRE, DESCRIPCION, CREADO_POR, ESTADO, FECHA_CREACION)
VALUES('ADMINISTRADOR SISTEMA', 'FULL ACCESS', 'RALOPEZ', 1, GETDATE())
*/
GO
USE [master]
GO
ALTER DATABASE [db_a8e200_dbsalesment] SET  READ_WRITE 
GO
