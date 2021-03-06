USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[IniciarSesion]
		 @Correo VARCHAR(200),
		 @Contrasena VARCHAR(150)
AS
BEGIN
DECLARE @Respuesta VARCHAR(200);	

		SELECT U.UsuarioId
		  ,U.Nombres
		  ,U.Apellidos
		  ,U.Correo
		  ,R.Nombre Rol
		  ,U.TelefonoContacto
	FROM Usuario U 
		INNER JOIN Rol R ON U.UsuarioId = R.RolId
	WHERE 
		U.Activo = 1 
		AND U.Correo = @Correo 
		AND U.Contrasena = @Contrasena

END

GO
