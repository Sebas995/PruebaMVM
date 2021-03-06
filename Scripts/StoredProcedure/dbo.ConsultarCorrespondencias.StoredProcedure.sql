USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCorrespondencias]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[ConsultarCorrespondencias]
		 @CorrespondenciaId INT
		 ,@ContactoId INT
		 ,@Estado INT
AS
BEGIN

	SELECT C.CorrespondenciaId
		   ,C.TipoCorrespondencia
           ,TC.Nombre  + C.NumeroRadicado NumeroRadicado
           ,E.Nombre Estado
           ,CR.Nombres + ' ' + CR.Apellidos Remitente
           ,CD.Nombres + ' ' + CD.Apellidos Destinatario
	FROM Correspondencia C 
		INNER JOIN TipoCorrespondencia TC ON C.TipoCorrespondencia = TC.TipoCorrespondenciaId
		INNER JOIN Contacto CD ON C.ContactoDestinatario = CD.ContactoId
		INNER JOIN Contacto CR ON C.ContactoRemitente = CR.ContactoId
		INNER JOIN Estado E ON E.EstadoId = C.Estado 
	WHERE 
		C.Eliminado = 0 
		AND (@CorrespondenciaId = 0 OR C.CorrespondenciaId = @CorrespondenciaId)
		AND (@ContactoId = 0 OR CD.ContactoId = @ContactoId)
		AND (@Estado = 0 OR C.Estado = @Estado)
	;

END

GO
