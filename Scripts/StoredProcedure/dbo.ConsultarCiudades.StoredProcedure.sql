USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCiudades]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[ConsultarCiudades]
		 @CiudadId INT
AS
BEGIN

	SELECT CiudadId
		Nombre,
		DepartamentoId
	FROM Ciudad C 
	WHERE 
		C.Activo = 1 
		AND (@CiudadId = 0 OR C.CiudadId = @CiudadId)
	;

END

GO
