USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[listarAdjuntosPorNota]    Script Date: 12/04/2012 18:31:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[listarAdjuntosPorNota](@tituloNota VARCHAR(50),@libreta varchar(100),@id int)
AS
BEGIN

	SELECT a.titulo FROM NOTA n, ADJUNTO a, ADJUNTO_NOTA an, LIBRETA l
	WHERE n.titulo = @tituloNota and n.idNota = an.fkidNota and an.fkidAdjunto = a.idAdjunto and 
	n.fkidLibreta=l.idLibreta and l.nombreLibreta=@libreta and l.fkidUsuario=@id;
	
END

GO

