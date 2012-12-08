USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[GeneraNotasLibreta]    Script Date: 12/07/2012 19:31:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GeneraNotasLibreta](@nombreLibreta VARCHAR(50), @cantNotas int)
AS
BEGIN

	DECLARE @i int = 0
	WHILE @i < @cantNotas BEGIN
		SET @i = @i + 1
		
		insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
		values ('Contenido Nota ','Titulo Nota '+convert(varchar, @i),GETDATE(),null,
		(select idLibreta from LIBRETA where nombreLibreta = @nombreLibreta));
		
	END
	
	commit;
	
END


GO

