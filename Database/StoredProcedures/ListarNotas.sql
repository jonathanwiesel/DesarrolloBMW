USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ListarNotas]    Script Date: 10/27/2012 21:29:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ListarNotas](@correoUsuario VARCHAR(50))
AS
BEGIN

	SELECT n.titulo FROM NOTA n, LIBRETA l, USUARIO u where 
	n.fkidLibreta = l.idLibreta and l.fkidUsuario = u.idUsuario and u.correo = @correoUsuario;
	
END

GO

