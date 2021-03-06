USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[EditarUsuario]
		  @UsuarioId INT
		 ,@Nombres VARCHAR(200)
		 ,@Apellidos VARCHAR(200)
		 ,@Correo VARCHAR(200)
		 ,@Rol INT
		 ,@Telefono VARCHAR(20)
		 ,@Contacto INT
		 ,@UsuarioModificacion INT
AS
BEGIN


UPDATE Usuario
   SET Nombres = @Nombres
      ,Apellidos = @Apellidos
      ,Correo = @Correo
      ,RolId = @Rol
      ,TelefonoContacto = @Telefono
      ,UsuarioModificacion = @UsuarioModificacion
	  ,ContactoId = @Contacto
      ,FechaModificacion = GETDATE()
	 WHERE UsuarioId = @UsuarioId;

END
GO
