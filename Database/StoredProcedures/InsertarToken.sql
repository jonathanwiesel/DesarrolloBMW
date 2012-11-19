USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[InsertarToken]    Script Date: 11/18/2012 19:31:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsertarToken](

	@correo varchar(100),
	@accesstoken varchar(100),
	@accesssecret varchar(100)
)
as 
begin
	update USUARIO set acesstoken = @accesstoken, acesssecret = @accesssecret where correo = @correo; 
end


GO

