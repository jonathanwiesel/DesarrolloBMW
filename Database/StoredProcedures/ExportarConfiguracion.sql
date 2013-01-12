USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ExportarConfiguracion]    Script Date: 01/12/2013 16:23:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[ExportarConfiguracion](
	@correoUsuario VARCHAR(100)
)
as 
begin
	Select idUsuario ,correo, clave, nombre, apellido, acesstoken, acesssecret from USUARIO where correo=@correoUsuario;
end


GO

