USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[VerificarLibreta]    Script Date: 12/03/2012 22:28:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[VerificarLibreta](

	@NOMBRE VARCHAR (100),
	@ID INTEGER
)
AS
BEGIN
	SELECT idLibreta FROM LIBRETA,USUARIO WHERE idUsuario=@ID AND idUsuario=fkidUsuario AND nombreLibreta=@NOMBRE;
END



GO

