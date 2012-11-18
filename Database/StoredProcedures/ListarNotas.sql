USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ListarNotas]    Script Date: 11/17/2012 20:04:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ListarNotas](@correoUsuario VARCHAR(50))
AS
BEGIN

	SELECT n.idNota, n.titulo, n.fechaCreacion
	FROM NOTA n, LIBRETA l, USUARIO u where 
	n.fkidLibreta = l.idLibreta and l.fkidUsuario = u.idUsuario and u.correo = @correoUsuario;
	
END

GO

