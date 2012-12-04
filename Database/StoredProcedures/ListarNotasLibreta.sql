USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ListarNotasLibreta]    Script Date: 12/03/2012 22:29:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ListarNotasLibreta](
	@id int
)
as
begin
	select n.idNota,n.titulo,n.fechaCreacion from LIBRETA l, NOTA n where l.idLibreta=@id and n.fkidLibreta=l.idLibreta
end

GO

