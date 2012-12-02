USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[BuscarEtiquetasDeUsuario]    Script Date: 12/01/2012 20:56:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[BuscarEtiquetasDeUsuario](
	@correo VARCHAR(50)
)
AS
BEGIN

	SELECT e.nombre FROM NOTA n, LIBRETA l, ETIQUETA e, USUARIO u, ETIQUETA_NOTA en
	WHERE u.correo = @correo and u.idUsuario = l.fkidUsuario and n.fkidLibreta = l.idLibreta 
	and n.idNota = en.fkidnota and en.fkidetiqueta = e.idEtiqueta;	
	
END


GO

