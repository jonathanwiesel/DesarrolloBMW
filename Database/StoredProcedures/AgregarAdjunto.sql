USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AgregarAdjunto]    Script Date: 12/04/2012 02:18:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AgregarAdjunto]
(
	@url varchar(500),
	@titulo varchar(200)

)
as 
begin
	insert into ADJUNTO(urlArchivo,titulo) values (@url,@titulo)
end
GO

