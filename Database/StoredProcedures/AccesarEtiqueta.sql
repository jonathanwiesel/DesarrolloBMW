USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AccesarEtiqueta]    Script Date: 12/08/2012 16:21:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AccesarEtiqueta](
	@id int
)
as 
begin
select distinct e.idEtiqueta, e.nombre from ETIQUETA e, ETIQUETA_NOTA en, LIBRETA l, NOTA n, USUARIO u where u.idUsuario =@id and
l.fkidUsuario = u.idUsuario and n.fkidLibreta=l.idLibreta and en.fkidnota=n.idNota and en.fkidetiqueta=e.idEtiqueta order by e.idEtiqueta
end


GO

