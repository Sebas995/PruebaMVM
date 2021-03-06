USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[InsertarContacto]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[InsertarContacto]
		  @Nombres VARCHAR(200)
		 ,@Apellidos VARCHAR(200)
		 ,@Ciudad INT
		 ,@UsuarioCreacion INT
AS
BEGIN

	INSERT INTO [dbo].[Contacto]
			   ([Nombres]
			   ,[Apellidos]
			   ,[CiudadId]
			   ,[UsuarioCreacion]
			   ,[FechaCreacion]
			   ,[UsuarioModificacion]
			   ,[FechaModificacion]
			   ,[Activo])
		 VALUES
			   (@Nombres
			   ,@Apellidos
			   ,@Ciudad
			   ,@UsuarioCreacion
			   ,GETDATE()
			   ,NULL
			   ,NULL
			   ,1)

END

GO
