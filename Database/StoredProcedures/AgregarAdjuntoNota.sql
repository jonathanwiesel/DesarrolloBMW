USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AgregarAdjuntoNota]    Script Date: 12/04/2012 03:48:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AgregarAdjuntoNota](
	@idadjunto int,
	@idnota int
)
as
begin
	insert into ADJUNTO_NOTA (fkidAdjunto,fkidNota) values (@idadjunto,@idnota)
end
GO

