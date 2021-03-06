USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarContactos]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[ConsultarContactos]
		 @ContactoId INT
AS
BEGIN

	SELECT C.ContactoId
		  ,C.Nombres
		  ,C.Apellidos
		  ,CI.Nombre Ciudad
	FROM Contacto C 
		INNER JOIN Ciudad CI ON C.CiudadId = CI.CiudadId
	WHERE 
		C.Activo = 1 
		AND (@ContactoId = 0 OR C.ContactoId = @ContactoId)
	;

END

GO
