USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BuscarNota]    Script Date: 11/17/2012 17:46:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BuscarNota](@idNota integer)
AS
BEGIN

	SELECT n.contenido, n.fechaCreacion, n.fechaModificacion, n.titulo, l.nombreLibreta FROM NOTA n, LIBRETA l
	WHERE n.idNota = @idNota and n.fkidLibreta = l.idLibreta;	
	
END

GO

