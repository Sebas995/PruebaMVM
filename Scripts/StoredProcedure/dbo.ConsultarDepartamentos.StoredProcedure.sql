USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarDepartamentos]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[ConsultarDepartamentos]
		 @DepartamentoId INT
AS
BEGIN

	SELECT 
		DepartamentoId
		,D.Nombre
	FROM Departamento D
	WHERE 
		D.Activo = 1 
		AND (@DepartamentoId = 0 OR D.DepartamentoId = @DepartamentoId)
	;

END

GO
