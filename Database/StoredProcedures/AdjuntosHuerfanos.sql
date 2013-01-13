USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AdjuntosHuerfanos]    Script Date: 01/12/2013 22:42:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AdjuntosHuerfanos]
( @idLibreta integer)
as 
begin
select a.titulo from ADJUNTO a, ADJUNTO_NOTA an, NOTA n, LIBRETA l where 
l.idLibreta=@idLibreta and n.fkidLibreta=l.idLibreta and an.fkidNota=n.idNota and an.fkidAdjunto=a.idAdjunto;
end
GO

