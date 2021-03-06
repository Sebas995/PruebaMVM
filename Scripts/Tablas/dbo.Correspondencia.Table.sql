USE [PRUEVAMVM]
GO
/****** Object:  Table [dbo].[Correspondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Correspondencia](
	[CorrespondenciaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoCorrespondencia] [int] NULL,
	[NumeroRadicado] [varchar](10) NULL,
	[Estado] [int] NULL,
	[ContactoDestinatario] [int] NULL,
	[ContactoRemitente] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [date] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [date] NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK_Comunicacion] PRIMARY KEY CLUSTERED 
(
	[CorrespondenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Comunicacion_Estado] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([EstadoId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Comunicacion_Estado]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Comunicacion_TipoCorrespondencia] FOREIGN KEY([TipoCorrespondencia])
REFERENCES [dbo].[TipoCorrespondencia] ([TipoCorrespondenciaId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Comunicacion_TipoCorrespondencia]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Correspondencia_ContactoDestinatario] FOREIGN KEY([ContactoDestinatario])
REFERENCES [dbo].[Contacto] ([ContactoId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Correspondencia_ContactoDestinatario]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Correspondencia_ContactoRemitente] FOREIGN KEY([ContactoRemitente])
REFERENCES [dbo].[Contacto] ([ContactoId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Correspondencia_ContactoRemitente]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Correspondencia_UsuarioCreacion] FOREIGN KEY([UsuarioCreacion])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Correspondencia_UsuarioCreacion]
GO
ALTER TABLE [dbo].[Correspondencia]  WITH CHECK ADD  CONSTRAINT [FK_Correspondencia_UsuarioModificacion] FOREIGN KEY([UsuarioModificacion])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Correspondencia] CHECK CONSTRAINT [FK_Correspondencia_UsuarioModificacion]
GO
