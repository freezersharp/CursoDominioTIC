/****** Object:  Table [dbo].[Categoria]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_CategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Establecimiento]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Establecimiento](
	[IdEstablecimiento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](2000) NULL,
	[Calificacion] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Establecimiento] PRIMARY KEY CLUSTERED 
(
	[IdEstablecimiento] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstablecimientoRubro]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstablecimientoRubro](
	[IdEstablecimiento] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
 CONSTRAINT [PK_EstablecimientoRubro] PRIMARY KEY CLUSTERED 
(
	[IdEstablecimiento] ASC,
	[IdRubro] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorito]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorito](
	[IdFavorito] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [nvarchar](250) NOT NULL,
	[IdEstablecimiento] [int] NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Favorito] PRIMARY KEY CLUSTERED 
(
	[IdFavorito] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opinion]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opinion](
	[IdOpinion] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [nvarchar](250) NOT NULL,
	[IdEstablecimiento] [int] NULL,
	[IdProducto] [int] NULL,
	[Calificacion] [decimal](5, 2) NULL,
	[Tipo] [char](1) NULL,
 CONSTRAINT [PK_Opinion] PRIMARY KEY CLUSTERED 
(
	[IdOpinion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[IdCategoria] [int] NOT NULL,
	[IdEstablecimiento] [int] NOT NULL,
	[Calificacion] [decimal](5, 2) NOT NULL,
	[Foto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubro](
	[IdRubro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdRubro] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/06/2020 09:34:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [nvarchar](250) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[IdPerfil] [nvarchar](20) NOT NULL,
	[Estado] [char](1) NULL,
	[Calificacion] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Establecimiento] ADD  CONSTRAINT [DF_Establecimiento_Puntuacion]  DEFAULT ((0)) FOR [Calificacion]
GO
ALTER TABLE [dbo].[Favorito] ADD  CONSTRAINT [DF_Favorito_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Opinion] ADD  CONSTRAINT [DF_Opinion_Calificacion]  DEFAULT ((0)) FOR [Calificacion]
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Calificacion]  DEFAULT ((0)) FOR [Calificacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Estado]  DEFAULT ('A') FOR [Estado]
GO
ALTER TABLE [dbo].[EstablecimientoRubro]  WITH CHECK ADD  CONSTRAINT [FK_EstablecimientoRubro_Establecimiento] FOREIGN KEY([IdEstablecimiento])
REFERENCES [dbo].[Establecimiento] ([IdEstablecimiento])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EstablecimientoRubro] CHECK CONSTRAINT [FK_EstablecimientoRubro_Establecimiento]
GO
ALTER TABLE [dbo].[EstablecimientoRubro]  WITH CHECK ADD  CONSTRAINT [FK_EstablecimientoRubro_Rubro] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubro] ([IdRubro])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EstablecimientoRubro] CHECK CONSTRAINT [FK_EstablecimientoRubro_Rubro]
GO
ALTER TABLE [dbo].[Favorito]  WITH CHECK ADD  CONSTRAINT [FK_Favorito_Establecimiento] FOREIGN KEY([IdEstablecimiento])
REFERENCES [dbo].[Establecimiento] ([IdEstablecimiento])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorito] CHECK CONSTRAINT [FK_Favorito_Establecimiento]
GO
ALTER TABLE [dbo].[Favorito]  WITH CHECK ADD  CONSTRAINT [FK_Favorito_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorito] CHECK CONSTRAINT [FK_Favorito_Usuario]
GO
ALTER TABLE [dbo].[Opinion]  WITH CHECK ADD  CONSTRAINT [FK_Opinion_Establecimiento] FOREIGN KEY([IdEstablecimiento])
REFERENCES [dbo].[Establecimiento] ([IdEstablecimiento])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Opinion] CHECK CONSTRAINT [FK_Opinion_Establecimiento]
GO
ALTER TABLE [dbo].[Opinion]  WITH CHECK ADD  CONSTRAINT [FK_Opinion_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Opinion] CHECK CONSTRAINT [FK_Opinion_Producto]
GO
ALTER TABLE [dbo].[Opinion]  WITH CHECK ADD  CONSTRAINT [FK_Opinion_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Opinion] CHECK CONSTRAINT [FK_Opinion_Usuario]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Establecimiento] FOREIGN KEY([IdEstablecimiento])
REFERENCES [dbo].[Establecimiento] ([IdEstablecimiento])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Establecimiento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P:Producto; E:Establecimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Opinion', @level2type=N'COLUMN',@level2name=N'Tipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A: Activo; I: Inactivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Estado'
GO
