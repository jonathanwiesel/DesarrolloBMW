USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BorrarNota]    Script Date: 11/17/2012 17:46:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BorrarNota](
	@idNota numeric(18,0)
)
AS
BEGIN

	delete from NOTA  
	where idNota = @idNota;		
	
END

GO

