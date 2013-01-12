USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[BorrarAdjunto]    Script Date: 01/12/2013 16:50:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[BorrarAdjunto](
	@idNota int,
	@titulo varchar(100)
)
as
begin
delete from ADJUNTO_NOTA where fkidNota = @idNota and fkidAdjunto = (select a.idAdjunto from ADJUNTO a, ADJUNTO_NOTA an, NOTA n where n.idNota = @idnota and an.fkidAdjunto = a.idAdjunto and an.fkidNota = n.idNota and a.titulo = @titulo)
delete from ADJUNTO where idAdjunto = (select a.idAdjunto from ADJUNTO a, ADJUNTO_NOTA an, NOTA n where n.idNota = @idnota and an.fkidAdjunto = a.idAdjunto and an.fkidNota = n.idNota)
end
GO

