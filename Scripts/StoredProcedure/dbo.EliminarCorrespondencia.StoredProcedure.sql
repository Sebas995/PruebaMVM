USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[EliminarCorrespondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[EliminarCorrespondencia]
		  @CorrespondenciaId INT
		 ,@UsuarioModificacion INT
AS
BEGIN

	UPDATE Correspondencia 
	   SET  
		  UsuarioModificacion = @UsuarioModificacion
		  ,FechaModificacion = GETDATE()
		  ,Eliminado = 1
	 WHERE CorrespondenciaId = @CorrespondenciaId;

END
GO
