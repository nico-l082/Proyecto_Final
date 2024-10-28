USE [master]
GO
/****** Object:  Database [Proyecto_Final]    Script Date: 22/10/2024 21:27:53 ******/
CREATE DATABASE [Proyecto_Final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proycto_Final', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proycto_Final.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proycto_Final_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proycto_Final_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Proyecto_Final] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto_Final].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto_Final] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto_Final] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto_Final] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto_Final] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto_Final] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto_Final] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proyecto_Final] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto_Final] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto_Final] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto_Final] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto_Final] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto_Final] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto_Final] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto_Final] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto_Final] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Proyecto_Final] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto_Final] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto_Final] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto_Final] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto_Final] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto_Final] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto_Final] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto_Final] SET RECOVERY FULL 
GO
ALTER DATABASE [Proyecto_Final] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto_Final] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto_Final] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto_Final] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto_Final] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proyecto_Final] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proyecto_Final] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Proyecto_Final', N'ON'
GO
ALTER DATABASE [Proyecto_Final] SET QUERY_STORE = ON
GO
ALTER DATABASE [Proyecto_Final] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Proyecto_Final]
GO
/****** Object:  Table [dbo].[Biblioteca]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biblioteca](
	[idBiblio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[juegos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBiblio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juegos]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juegos](
	[idJuegos] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[genero] [varchar](50) NULL,
	[itiPlus] [int] NULL,
	[precio] [money] NULL,
	[desarrolladora] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idJuegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresia]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresia](
	[idMembresia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[detalle] [varchar](100) NULL,
	[tipoMembresia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiembrosPlus]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiembrosPlus](
	[idMiembros] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NULL,
	[precioMembresia] [money] NULL,
	[formaPago] [varchar](50) NULL,
	[cantidadJuegosMembresia] [int] NULL,
	[vigencia] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMiembros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMembresia]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMembresia](
	[idTipoMembresia] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 22/10/2024 21:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuarios] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[contraseña] [varchar](100) NULL,
	[miembro] [int] NULL,
	[cantJuegos] [int] NULL,
	[biblioJuegos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Biblioteca]  WITH CHECK ADD  CONSTRAINT [biblio_Juego_fk] FOREIGN KEY([juegos])
REFERENCES [dbo].[Juegos] ([idJuegos])
GO
ALTER TABLE [dbo].[Biblioteca] CHECK CONSTRAINT [biblio_Juego_fk]
GO
ALTER TABLE [dbo].[Juegos]  WITH CHECK ADD  CONSTRAINT [Juegos_TipoMemb_FK] FOREIGN KEY([itiPlus])
REFERENCES [dbo].[TipoMembresia] ([idTipoMembresia])
GO
ALTER TABLE [dbo].[Juegos] CHECK CONSTRAINT [Juegos_TipoMemb_FK]
GO
ALTER TABLE [dbo].[MiembrosPlus]  WITH CHECK ADD  CONSTRAINT [Plus_TipoMemb_FK] FOREIGN KEY([tipo])
REFERENCES [dbo].[TipoMembresia] ([idTipoMembresia])
GO
ALTER TABLE [dbo].[MiembrosPlus] CHECK CONSTRAINT [Plus_TipoMemb_FK]
GO
ALTER TABLE [dbo].[TipoMembresia]  WITH CHECK ADD  CONSTRAINT [Tipo_Memb_FK] FOREIGN KEY([tipo])
REFERENCES [dbo].[Membresia] ([idMembresia])
GO
ALTER TABLE [dbo].[TipoMembresia] CHECK CONSTRAINT [Tipo_Memb_FK]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [usu_biblio_fk] FOREIGN KEY([biblioJuegos])
REFERENCES [dbo].[Biblioteca] ([idBiblio])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [usu_biblio_fk]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [Usu_Memb_fk] FOREIGN KEY([miembro])
REFERENCES [dbo].[MiembrosPlus] ([idMiembros])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [Usu_Memb_fk]
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Final] SET  READ_WRITE 
GO
