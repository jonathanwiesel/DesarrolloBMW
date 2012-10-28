USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[MostrarNota]    Script Date: 10/27/2012 21:29:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[MostrarNota](@tituloNota VARCHAR(50))
AS
BEGIN

	SELECT n.contenido, n.fechaCreacion, n.fechaModificacion, l.nombreLibreta FROM NOTA n, LIBRETA l
	WHERE n.titulo = @tituloNota and n.fkidLibreta = l.idLibreta;	
	
END
GO

