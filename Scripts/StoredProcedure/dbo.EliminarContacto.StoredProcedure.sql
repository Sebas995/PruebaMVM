USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[EliminarContacto]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[EliminarContacto]
		  @ContactoId INT
		 ,@UsuarioModificacion INT
AS
BEGIN

	UPDATE Contacto 
	   SET  
		  UsuarioModificacion = @UsuarioModificacion
		  ,FechaModificacion = GETDATE()
		  ,Activo = 0
	 WHERE ContactoId = @ContactoId;

END
GO
