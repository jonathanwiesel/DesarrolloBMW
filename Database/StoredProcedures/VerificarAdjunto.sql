USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[VerificarAdjunto]    Script Date: 12/04/2012 03:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[VerificarAdjunto](
	@url varchar(500),
	@nombre varchar(200)
)
as
begin
select idAdjunto from ADJUNTO where urlArchivo=@url and titulo = @nombre
end
GO

