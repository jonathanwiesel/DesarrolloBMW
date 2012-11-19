USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AgregarLibreta]    Script Date: 11/18/2012 19:31:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AgregarLibreta](

	@correo varchar(100),
	@nombre varchar(100)
)
as
begin
	insert into LIBRETA (nombreLibreta,fkidUsuario) values (@nombre,(select idUsuario from USUARIO where correo = @correo))
end
GO

