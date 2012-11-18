USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BorrarNota]    Script Date: 11/17/2012 20:31:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BorrarNota](
	@idNota integer
)
AS
BEGIN

	delete from ETIQUETA_NOTA where fkidnota = @idNota;
	delete from ADJUNTO_NOTA where fkidNota = @idNota;
	delete from NOTA  where idNota = @idNota;		
	
END

execute BorrarNota 1;
GO

