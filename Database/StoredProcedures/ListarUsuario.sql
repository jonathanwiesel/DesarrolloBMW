USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 10/27/2012 22:27:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ListarUsuario](
	@CORREO VARCHAR(100)
)
as 
begin
	Select IDUSUARIO from USUARIO where correo=@CORREO;
end

GO

