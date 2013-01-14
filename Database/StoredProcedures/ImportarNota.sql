USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ImportarNota]    Script Date: 01/13/2013 23:15:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ImportarNota](
	@tituloNota VARCHAR(50),
	@contenidoNota text,
	@FechaC DATE,
	@FechaM DATE,
	@nombreLibreta VARCHAR(50)
)
AS
BEGIN

	/*insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
	values (@contenidoNota,@tituloNota,convert(datetime, @FechaC),convert(datetime, @FechaM),
	(select idLibreta from LIBRETA where nombreLibreta = @nombreLibreta));		*/
	if(@FechaM < convert(datetime,'1/1/1753'))
	begin
		insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
		values (@contenidoNota,@tituloNota, @FechaC,@FechaM,
		(select idLibreta from LIBRETA where nombreLibreta = @nombreLibreta));
	end
	else
	begin
		insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
		values (@contenidoNota,@tituloNota, @FechaC,null,
		(select idLibreta from LIBRETA where nombreLibreta = @nombreLibreta));
	end 
END
GO

