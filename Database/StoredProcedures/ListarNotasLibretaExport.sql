USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ListarNotasLibretaExport]    Script Date: 01/12/2013 16:22:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[ListarNotasLibretaExport](
	@id int
)
as
begin
	select n.idNota,n.titulo, n.contenido,n.fechaCreacion, n.fechaModificacion from LIBRETA l, NOTA n where l.idLibreta=@id and n.fkidLibreta=l.idLibreta
end


GO

