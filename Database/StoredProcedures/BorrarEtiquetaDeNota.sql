USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BorrarEtiquetasDeNota]    Script Date: 12/01/2012 19:39:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[BorrarEtiquetasDeNota](
	@idNota integer
)
AS
BEGIN

	delete from ETIQUETA_NOTA where fkidnota = @idNota;		
	
END

GO

