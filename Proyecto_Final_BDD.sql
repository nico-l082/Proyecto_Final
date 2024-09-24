USE [Proyecto_Final]
GO
/****** Object:  Table [dbo].[biblioteca]    Script Date: 23/09/2024 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[biblioteca](
	[idBiblio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[juegos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBiblio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[juegos]    Script Date: 23/09/2024 23:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[juegos](
	[idJuegos] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[genero] [varchar](50) NOT NULL,
	[itiPlus] [int] NOT NULL,
	[precio] [money] NOT NULL,
	[desarrolladora] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idJuegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresia]    Script Date: 23/09/2024 23:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresia](
	[idMembresia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[detalle] [varchar](100) NOT NULL,
	[tipoMembresia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[miembrosPlus]    Script Date: 23/09/2024 23:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[miembrosPlus](
	[idMiembros] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NOT NULL,
	[precioMembresia] [money] NOT NULL,
	[formaPago] [varchar](50) NOT NULL,
	[cantidadJuegosMembresia] [int] NOT NULL,
	[vigencia] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMiembros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoMembresia]    Script Date: 23/09/2024 23:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoMembresia](
	[idTipoMembresia] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoMembresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 23/09/2024 23:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[idUsuarios] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[contraseña] [varchar](100) NOT NULL,
	[miembro] [int] NOT NULL,
	[cantJuegos] [int] NOT NULL,
	[biblioJuegos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[biblioteca]  WITH CHECK ADD  CONSTRAINT [biblio_Juego_fk] FOREIGN KEY([juegos])
REFERENCES [dbo].[juegos] ([idJuegos])
GO
ALTER TABLE [dbo].[biblioteca] CHECK CONSTRAINT [biblio_Juego_fk]
GO
ALTER TABLE [dbo].[juegos]  WITH CHECK ADD  CONSTRAINT [Juegos_TipoMemb_FK] FOREIGN KEY([itiPlus])
REFERENCES [dbo].[tipoMembresia] ([idTipoMembresia])
GO
ALTER TABLE [dbo].[juegos] CHECK CONSTRAINT [Juegos_TipoMemb_FK]
GO
ALTER TABLE [dbo].[miembrosPlus]  WITH CHECK ADD  CONSTRAINT [Plus_TipoMemb_FK] FOREIGN KEY([tipo])
REFERENCES [dbo].[tipoMembresia] ([idTipoMembresia])
GO
ALTER TABLE [dbo].[miembrosPlus] CHECK CONSTRAINT [Plus_TipoMemb_FK]
GO
ALTER TABLE [dbo].[tipoMembresia]  WITH CHECK ADD  CONSTRAINT [Tipo_Memb_FK] FOREIGN KEY([tipo])
REFERENCES [dbo].[Membresia] ([idMembresia])
GO
ALTER TABLE [dbo].[tipoMembresia] CHECK CONSTRAINT [Tipo_Memb_FK]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [usu_biblio_fk] FOREIGN KEY([biblioJuegos])
REFERENCES [dbo].[biblioteca] ([idBiblio])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [usu_biblio_fk]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [Usu_Memb_fk] FOREIGN KEY([miembro])
REFERENCES [dbo].[miembrosPlus] ([idMiembros])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [Usu_Memb_fk]
GO
