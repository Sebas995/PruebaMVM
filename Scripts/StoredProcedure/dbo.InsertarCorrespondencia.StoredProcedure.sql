USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCorrespondencia]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[InsertarCorrespondencia]
		 @TipoCorrespndencia INT
		 ,@Estado INT
		 ,@ContactoDestinatario INT
		 ,@ContactoRemitente INT
		 ,@UsuarioCreacion INT
AS
BEGIN
DECLARE @NumRadicado INT; 

SET @NumRadicado = (SELECT ISNULL(MAX(CAST(NumeroRadicado AS INT)),'0') + 1 FROM Correspondencia WHERE TipoCorrespondencia = @TipoCorrespndencia);

	INSERT INTO [dbo].[Correspondencia]
           ([TipoCorrespondencia]
           ,[NumeroRadicado]
           ,[Estado]
           ,[ContactoDestinatario]
           ,[ContactoRemitente]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion]
           ,[Eliminado])
     VALUES
           (@TipoCorrespndencia
		    -- ==============================================
			-- PAra generar el nmero de radicado use 3 funciones (RIGHT(),Ltrim(),Rtrim())
			-- Rtrim() : Para que quitara los espacios de la derecha
			-- Ltrim() : Para que quitara los espacios de la izquierda
			-- RIGHT() : Para que tomara los caracteres de la derecha luego de adicionarle los Ceros
			-- ==============================================
           ,RIGHT('00000000' + Ltrim(Rtrim(@NumRadicado)),9)	
           ,@Estado
           ,@ContactoDestinatario
           ,@ContactoRemitente
           ,@UsuarioCreacion
           ,GETDATE()
           ,NULL
           ,NULL
           ,0)

	SELECT C.CorrespondenciaId
		   ,C.TipoCorrespondencia
           ,TC.Nombre  + C.NumeroRadicado Radicado
           ,E.Nombre Estado
           ,CR.Nombres + ' ' + CR.Apellidos Remitente
           ,CD.Nombres + ' ' + CD.Apellidos Destinatario
	FROM Correspondencia C 
		INNER JOIN TipoCorrespondencia TC ON C.TipoCorrespondencia = TC.TipoCorrespondenciaId
		INNER JOIN Contacto CD ON C.ContactoDestinatario = CD.ContactoId
		INNER JOIN Contacto CR ON C.ContactoRemitente = CR.ContactoId
		INNER JOIN Estado E ON E.EstadoId = C.Estado 
	WHERE 
		C.CorrespondenciaId = SCOPE_IDENTITY()		
	;

END

GO
