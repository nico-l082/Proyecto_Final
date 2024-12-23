USE [master]
GO
/****** Object:  Database [Proyecto_Final]    Script Date: 11/11/2024 19:15:33 ******/
CREATE DATABASE [Proyecto_Final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_Final', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proyecto_Final.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto_Final_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proyecto_Final_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Proyecto_Final] SET READ_COMMITTED_SNAPSHOT ON 
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[idAdmin] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[contraseña] [varchar](100) NULL,
 CONSTRAINT [PK__Admin__B2C3ADE5F2A5DF96] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Biblioteca]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biblioteca](
	[idBiblio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[juegos] [int] NULL,
 CONSTRAINT [PK__Bibliote__C721831F871764D8] PRIMARY KEY CLUSTERED 
(
	[idBiblio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juegos]    Script Date: 11/11/2024 19:15:34 ******/
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
	[imagenURL] [varchar](225) NULL,
 CONSTRAINT [PK__Juegos__E4EEF679CB006B0B] PRIMARY KEY CLUSTERED 
(
	[idJuegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresia]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresia](
	[idMembresia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[detalle] [varchar](100) NULL,
	[tipoMembresia] [int] NULL,
 CONSTRAINT [PK__Membresi__BDDB80E94CDE81D8] PRIMARY KEY CLUSTERED 
(
	[idMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiembrosPlus]    Script Date: 11/11/2024 19:15:34 ******/
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
 CONSTRAINT [PK__Miembros__F1261B7C5B75030D] PRIMARY KEY CLUSTERED 
(
	[idMiembros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMembresia]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMembresia](
	[idTipoMembresia] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NULL,
 CONSTRAINT [PK__TipoMemb__1D164B22339793F0] PRIMARY KEY CLUSTERED 
(
	[idTipoMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/11/2024 19:15:34 ******/
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
 CONSTRAINT [PK__Usuarios__3940559A03D1B9BB] PRIMARY KEY CLUSTERED 
(
	[idUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosJuegos]    Script Date: 11/11/2024 19:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosJuegos](
	[idUJ] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[juegoId] [int] NULL,
	[fechaCompra] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241105044834_NombreDeTuMigracion', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([idAdmin], [nombre], [email], [contraseña]) VALUES (1, N'Esteban', N'esteban@yahoo.com.ar', N'123')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Juegos] ON 

INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (1, N'The Witcher 3: Wild Hunt', N'Juego de rol en un mundo abierto lleno de misiones y aventuras', N'RPG', NULL, 39.9900, N'CD Projekt', N'~/lib/Imagenes_Juegos/the-witcher-3.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (2, N'Cyberpunk 2077', N'Juego de rol y acción ambientado en un futuro distópico', N'RPG', NULL, 49.9900, N'CD Projekt', N'~/lib/Imagenes_Juegos/Cyberpunk2077.jpeg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (3, N'Minecraft', N'Juego de construcción y aventura en un mundo abierto de bloques', N'Sandbox', NULL, 19.9900, N'Mojang Studios', N'~/lib/Imagenes_Juegos/Minecraft.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (4, N'Fortnite', N'Juego de batalla campal multijugador con elementos de construcción', N'Battle Royale', NULL, 0.0000, N'Epic Games', N'~/lib/Imagenes_Juegos/Fortnite.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (5, N'Assassins Creed Valhalla', N'Juego de rol y acción con temática vikinga', N'Acción', NULL, 59.9900, N'Ubisoft', N'~/lib/Imagenes_Juegos/assassins_creed_Valhalla.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (6, N'Call of Duty: Modern Warfare', N'Juego de disparos en primera persona con un intenso modo multijugador', N'FPS', NULL, 59.9900, N'Activision', N'~/lib/Imagenes_Juegos/CallofDutyMW.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (7, N'Hades', N'Juego de exploración de mazmorras con temática mitológica', N'Roguelike', NULL, 24.9900, N'Supergiant Games', N'~/lib/Imagenes_Juegos/Hades.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (8, N'Stardew Valley', N'Simulador de granja donde puedes cultivar y criar animales', N'Simulación', NULL, 14.9900, N'ConcernedApe', N'~/lib/Imagenes_Juegos/stardew_valley.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (9, N'The Legend of Zelda: Breath of the Wild', N'Aventura en un mundo abierto lleno de exploración y combates', N'Aventura', NULL, 59.9900, N'Nintendo', N'~/lib/Imagenes_Juegos/TheLegendofZeldaBreathoftheWildjpg.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (10, N'Overwatch', N'Juego de disparos en equipo con personajes únicos', N'Shooter', NULL, 19.9900, N'Blizzard Entertainment', N'~/lib/Imagenes_Juegos/Overwatch.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (11, N'Grand Theft Auto V', N'Juego de acción y aventura en un mundo abierto con múltiples misiones', N'Acción', NULL, 29.9900, N'Rockstar Games', N'~/lib/Imagenes_Juegos/grand-theft-auto-v.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (12, N'Red Dead Redemption 2', N'Juego de aventura en el oeste americano', N'Acción', NULL, 59.9900, N'Rockstar Games', N'~/lib/Imagenes_Juegos/red_dead_redemption2.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (13, N'Celeste', N'Juego de plataformas con una historia profunda y desafiante', N'Plataformas', NULL, 19.9900, N'Maddy Makes Games', N'~/lib/Imagenes_Juegos/Celeste.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (14, N'Animal Crossing: New Horizons', N'Juego de simulación de vida en una isla desierta', N'Simulación', NULL, 59.9900, N'Nintendo', N'~/lib/Imagenes_Juegos/AnimalCrossinsNewHorizons.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (15, N'Doom Eternal', N'Juego de disparos en primera persona lleno de acción y monstruos', N'FPS', NULL, 49.9900, N'id Software', N'~/lib/Imagenes_Juegos/DoomEternal.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (16, N'Dark Souls III', N'Juego de rol y acción en un mundo sombrío y desafiante', N'RPG', NULL, 29.9900, N'FromSoftware', N'~/lib/Imagenes_Juegos/DarkSoulsIII.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (17, N'Hollow Knight', N'Juego de plataformas y aventuras en un mundo subterráneo', N'Metroidvania', NULL, 14.9900, N'Team Cherry', N'~/lib/Imagenes_Juegos/hollow_knight.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (18, N'Among Us', N'Juego de deducción social multijugador', N'Multijugador', NULL, 4.9900, N'Innersloth', N'~/lib/Imagenes_Juegos/AmongUs.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (19, N'Fall Guys', N'Juego de fiesta multijugador con diferentes pruebas', N'Party', NULL, 19.9900, N'Mediatonic', N'~/lib/Imagenes_Juegos/fallguys.jpg')
INSERT [dbo].[Juegos] ([idJuegos], [nombre], [descripcion], [genero], [itiPlus], [precio], [desarrolladora], [imagenURL]) VALUES (20, N'League of Legends', N'Juego multijugador de estrategia y combate', N'MOBA', NULL, 0.0000, N'Riot Games', N'~/lib/Imagenes_Juegos/League-of-Legends.jpg')
SET IDENTITY_INSERT [dbo].[Juegos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (1, N'nico', N'nico@gmail.com', N'123', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (4, N'nico', N'nico@gmail.com', N'123', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (8, N'juan', N'juan@gmail.com', N'123', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (9, N'pepe', N'pepe@gmail.com', N'123', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (10, N'hola', N'hola@gmail.com', N'123', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuarios], [nombreUsuario], [email], [contraseña], [miembro], [cantJuegos], [biblioJuegos]) VALUES (11, N'Garmendia', N'garmendia@yahoo.com', N'123', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuariosJuegos] ON 

INSERT [dbo].[UsuariosJuegos] ([idUJ], [userId], [juegoId], [fechaCompra]) VALUES (1, 11, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsuariosJuegos] OFF
GO
/****** Object:  Index [IX_Biblioteca_juegos]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_Biblioteca_juegos] ON [dbo].[Biblioteca]
(
	[juegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Juegos_itiPlus]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_Juegos_itiPlus] ON [dbo].[Juegos]
(
	[itiPlus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MiembrosPlus_tipo]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_MiembrosPlus_tipo] ON [dbo].[MiembrosPlus]
(
	[tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoMembresia_tipo]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_TipoMembresia_tipo] ON [dbo].[TipoMembresia]
(
	[tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_biblioJuegos]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_biblioJuegos] ON [dbo].[Usuarios]
(
	[biblioJuegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_miembro]    Script Date: 11/11/2024 19:15:34 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_miembro] ON [dbo].[Usuarios]
(
	[miembro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[UsuariosJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Juego] FOREIGN KEY([juegoId])
REFERENCES [dbo].[Juegos] ([idJuegos])
GO
ALTER TABLE [dbo].[UsuariosJuegos] CHECK CONSTRAINT [FK_Juego]
GO
ALTER TABLE [dbo].[UsuariosJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Usuario] FOREIGN KEY([userId])
REFERENCES [dbo].[Usuarios] ([idUsuarios])
GO
ALTER TABLE [dbo].[UsuariosJuegos] CHECK CONSTRAINT [FK_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Final] SET  READ_WRITE 
GO
