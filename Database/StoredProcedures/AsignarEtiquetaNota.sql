USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[AsignarEtiquetasNota]    Script Date: 12/01/2012 19:39:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[AsignarEtiquetasNota](
	@idNota integer,
	@idEtiqueta integer
)
AS
BEGIN

	insert into ETIQUETA_NOTA values (@idNota,@idEtiqueta);		
	
END

GO

