USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[listarEtiquetasPorNota]    Script Date: 10/27/2012 21:29:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[listarEtiquetasPorNota](@tituloNota VARCHAR(50))
AS
BEGIN

	SELECT e.nombre FROM NOTA n, ETIQUETA e, ETIQUETA_NOTA en 
	WHERE titulo = @tituloNota and n.idNota = en.fkidnota and en.fkidetiqueta = e.idEtiqueta;	
	
END
GO

