USE [rapidNote]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarLogin](
	@correoUsuario VARCHAR(50),
	@claveUsuario VARCHAR(500)
)
AS
BEGIN

	SELECT IDUSUARIO FROM USUARIO WHERE CORREO = @correoUsuario AND CLAVE = @claveUsuario;			
	
END
