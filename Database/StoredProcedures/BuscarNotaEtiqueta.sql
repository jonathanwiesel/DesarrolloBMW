USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[BuscarNotaEtiqueta]    Script Date: 11/17/2012 19:46:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BuscarNotaEtiqueta](@contenidoBusqueda VARCHAR(50),@correoUsuario VARCHAR(50))
AS
BEGIN

	select distinct n.idNota ,n.titulo, n.fechaCreacion from NOTA n, ETIQUETA e, 
	LIBRETA l, USUARIO u, ETIQUETA_NOTA en 
	where u.correo = @correoUsuario and u.idUsuario = l.fkidUsuario and
	 l.idLibreta = n.fkidLibreta and n.idNota = en.fkidnota and en.fkidetiqueta = e.idEtiqueta and 
	(l.nombreLibreta like @contenidoBusqueda or e.nombre like @contenidoBusqueda
	or n.titulo like @contenidoBusqueda or n.contenido like @contenidoBusqueda);
	
END
GO

