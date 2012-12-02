USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BuscarIdNota]    Script Date: 12/01/2012 19:40:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BuscarIdNota](
	@tituloNota VARCHAR(50)
)
AS
BEGIN

	SELECT n.idNota FROM NOTA n, LIBRETA l
	WHERE n.titulo = @tituloNota and n.fkidLibreta = l.idLibreta;	
	
END

GO

