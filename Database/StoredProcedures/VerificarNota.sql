USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[VerificarNota]    Script Date: 12/04/2012 03:49:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[VerificarNota](
	
	@titulo varchar(100),
	@nombre varchar(100),
	@correo varchar(100)
)
as
begin
	select n.idNota as idNota from NOTA n,LIBRETA l, USUARIO u where n.titulo = @titulo 
	and n.fkidLibreta = l.idLibreta and l.fkidUsuario=u.idUsuario and
	u.correo = @correo and l.nombreLibreta = @nombre
 end
GO

