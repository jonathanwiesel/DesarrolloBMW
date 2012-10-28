USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ConsultarLibretas]    Script Date: 10/27/2012 21:28:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ConsultarLibretas](@correoUsuario VARCHAR(50))
AS
BEGIN

	SELECT l.nombreLibreta FROM USUARIO u, LIBRETA l WHERE u.CORREO = @correoUsuario AND u.idUsuario = l.fkidUsuario
	
END
GO

