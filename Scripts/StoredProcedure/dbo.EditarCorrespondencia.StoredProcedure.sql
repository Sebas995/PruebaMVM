USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[EditarCorrespondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[EditarCorrespondencia]
		  @CorrespondenciaId INT
		 ,@Estado INT
		 ,@ContactoDestinatario INT
		 ,@ContactoRemitente INT
		 ,@UsuarioModificacion INT
AS
BEGIN

	UPDATE Correspondencia
	   SET 
		  Estado = @Estado
		  ,ContactoDestinatario = @ContactoDestinatario
		  ,ContactoRemitente = @ContactoRemitente     
		  ,UsuarioModificacion = @UsuarioModificacion
		  ,FechaModificacion = GETDATE()
	 WHERE CorrespondenciaId = @CorrespondenciaId;

END
GO
