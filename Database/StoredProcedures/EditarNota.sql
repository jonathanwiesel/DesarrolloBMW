USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[EditarNota]    Script Date: 11/17/2012 17:46:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[EditarNota](
	@tituloNota VARCHAR(50),
	@contenidoNota text,
	@idNota numeric(18,0)
)
AS
BEGIN

	update NOTA set contenido = @contenidoNota ,titulo = @tituloNota ,fechaModificacion = GETDATE() 
	where idNota = @idNota;		
	
END

GO

