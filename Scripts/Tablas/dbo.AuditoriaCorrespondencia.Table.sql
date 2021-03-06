USE [PRUEVAMVM]
GO
/****** Object:  Table [dbo].[AuditoriaCorrespondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaCorrespondencia](
	[RegistroId] [int] IDENTITY(1,1) NOT NULL,
	[CorrespondenciaId] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaRegistro] [date] NULL,
	[UsuarioModificacion] [int] NULL,
 CONSTRAINT [PK_AuditoriaCorrespondencia] PRIMARY KEY CLUSTERED 
(
	[RegistroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaCorrespondencia_Correspondencia] FOREIGN KEY([CorrespondenciaId])
REFERENCES [dbo].[Correspondencia] ([CorrespondenciaId])
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia] CHECK CONSTRAINT [FK_AuditoriaCorrespondencia_Correspondencia]
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaCorrespondencia_UsuarioCreacion] FOREIGN KEY([UsuarioCreacion])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia] CHECK CONSTRAINT [FK_AuditoriaCorrespondencia_UsuarioCreacion]
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaCorrespondencia_UsuarioModificacion] FOREIGN KEY([UsuarioModificacion])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[AuditoriaCorrespondencia] CHECK CONSTRAINT [FK_AuditoriaCorrespondencia_UsuarioModificacion]
GO
