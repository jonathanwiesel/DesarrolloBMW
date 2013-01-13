USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[EliminarAdjuntosTodos]    Script Date: 01/12/2013 22:43:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EliminarAdjuntosTodos](
	@idLibreta integer
)
as 
begin
delete from ADJUNTO_NOTA where fkidAdjunto in (select a.idAdjunto from ADJUNTO a, ADJUNTO_NOTA an, NOTA n, LIBRETA l where 
l.idLibreta=@idLibreta and n.fkidLibreta=l.idLibreta and an.fkidNota=n.idNota and an.fkidAdjunto=a.idAdjunto)
end
GO

