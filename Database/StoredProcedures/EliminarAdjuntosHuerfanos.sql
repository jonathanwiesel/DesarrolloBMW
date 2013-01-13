USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[EliminarAdjuntosHuerfanos]    Script Date: 01/12/2013 22:42:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EliminarAdjuntosHuerfanos]
( 
	@nombre varchar(100)
)
as 
begin
delete from ADJUNTO where titulo=@nombre;
end
GO

