USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[EditarContacto]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[EditarContacto]
		  @ContactoId INT
		 ,@Nombres INT
		 ,@Apellidos INT
		 ,@Ciudad INT
		 ,@UsuarioModificacion INT
AS
BEGIN

	UPDATE Contacto
	   SET 
		   Nombres = @Nombres
		  ,Apellidos = @Apellidos
		  ,CiudadId = @Ciudad    
		  ,UsuarioModificacion = @UsuarioModificacion
		  ,FechaModificacion = GETDATE()
	 WHERE ContactoId = @ContactoId;

END
GO
