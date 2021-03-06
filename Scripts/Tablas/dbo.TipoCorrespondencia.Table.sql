USE [PRUEVAMVM]
GO
/****** Object:  Table [dbo].[TipoCorrespondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCorrespondencia](
	[TipoCorrespondenciaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Descripcion] [varchar](200) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_TipoCorrespondencia] PRIMARY KEY CLUSTERED 
(
	[TipoCorrespondenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
