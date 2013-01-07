USE [rapidnote]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[BorrarLibreta](

	@idLibreta int
)
as
begin

	--borra las etiquetas asociadas a las notas a borrar
	delete from ETIQUETA_NOTA where fkidnota in (select n.idNota from NOTA n where n.fkidLibreta = @idLibreta);

	--borra los adjuntos asociados a las notas a borrar... como hay q borrar de dropbox se hara primero en otro procedure	
	--delete from ADJUNTO_NOTA where fkidNota in (select n.idNota from NOTA n where n.fkidLibreta = @idLibreta);
	
	--borra las notas asociadas a la libreta a borrar
	delete from NOTA where fkidLibreta = @idLibreta;

	--borra la libreta 	
	delete from LIBRETA where idLibreta = @idLibreta;

	--borra las etiquetas que puedan kedar huerfanas
	delete from ETIQUETA where nombre in (select e.nombre from ETIQUETA e except 
	(select et.nombre from ETIQUETA_NOTA en, ETIQUETA et 
		where en.fkidetiqueta = et.idEtiqueta ));
end

GO