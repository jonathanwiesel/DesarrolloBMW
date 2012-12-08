USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[BorrarAdjunto]    Script Date: 12/06/2012 02:12:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[BorrarAdjunto](
	@idNota int
)
as
begin
delete from ADJUNTO_NOTA where fkidNota = @idNota
end
GO

