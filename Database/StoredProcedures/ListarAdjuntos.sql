USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[listarAdjuntosPorNota]    Script Date: 10/27/2012 21:29:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[listarAdjuntosPorNota](@tituloNota VARCHAR(50))
AS
BEGIN

	SELECT a.titulo FROM NOTA n, ADJUNTO a, ADJUNTO_NOTA an 
	WHERE n.titulo = @tituloNota and n.idNota = an.fkidNota and an.fkidAdjunto = a.idAdjunto;
	
END
GO

