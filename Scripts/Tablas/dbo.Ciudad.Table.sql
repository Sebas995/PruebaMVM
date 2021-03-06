USE [PRUEVAMVM]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CiudadId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[DepartamentoId] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY([CiudadId])
REFERENCES [dbo].[Departamento] ([DepartamentoId])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Departamento]
GO
