USE [PRUEVAMVM]
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Martinez
-- Create date: 2021
-- Description:	Insertar Correspondencia 
-- =============================================


CREATE PROCEDURE [dbo].[InsertarUsuario]
		  @Nombres VARCHAR(200)
		 ,@Apellidos VARCHAR(200)
		 ,@Correo VARCHAR(200)
		 ,@Contrasena VARCHAR(150)
		 ,@Rol INT
		 ,@Telefono VARCHAR(20)
		 ,@ContactoId INT
		 ,@UsuarioCreacion INT
AS
BEGIN

	INSERT INTO [dbo].[Usuario]
           ([Nombres]
           ,[Apellidos]
           ,[Correo]
           ,[Contrasena]
           ,[RolId]
		   ,[ContactoId]
           ,[TelefonoContacto]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion]
           ,[Activo])
     VALUES
           (@Nombres
           ,@Apellidos
           ,@Correo
           ,@Contrasena
           ,@Rol
		   ,@ContactoId
           ,@Telefono
           ,@UsuarioCreacion
           ,GETDATE()
           ,NULL
           ,NULL
           ,1)

END

GO
