USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[CrearNota]    Script Date: 10/27/2012 21:28:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CrearNota](
	@tituloNota VARCHAR(50),
	@contenidoNota text,
	@nombreLibreta VARCHAR(50)
)
AS
BEGIN

	insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
	values (@contenidoNota,@tituloNota,GETDATE(),null,
	(select idLibreta from LIBRETA where nombreLibreta = @nombreLibreta));		
	
END
GO

