USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[VerificarAdjuntoEliminar]    Script Date: 01/12/2013 16:50:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[VerificarAdjuntoEliminar](

	@id int,
	@titulo varchar(100)
)
as 
begin
select count(n.idNota) as idnota from ADJUNTO a, ADJUNTO_NOTA an, LIBRETA l, USUARIO u, NOTA n where u.idUsuario=@id and l.fkidUsuario=u.idUsuario and
n.fkidLibreta = l.idLibreta and an.fkidNota=n.idNota and a.idAdjunto=an.fkidAdjunto and a.titulo=@titulo
end
GO

