USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarios]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[ConsultarUsuarios]
		 @UsuarioId INT
AS
BEGIN

	SELECT U.UsuarioId
		  ,U.Nombres
		  ,U.Apellidos
		  ,U.Correo
		  ,R.Nombre Rol
		  ,U.ContactoId
		  ,U.TelefonoContacto
	FROM Usuario U 
		INNER JOIN Rol R ON U.UsuarioId = R.RolId
	WHERE 
		U.Activo = 1 
		AND (@UsuarioId = 0 OR U.UsuarioId = @UsuarioId)
	;

END

GO
