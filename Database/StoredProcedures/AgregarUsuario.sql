USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 10/27/2012 22:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AgregarUsuario]
(
	@CORREO VARCHAR(200),
	@CLAVE VARCHAR(500),
	@NOMBRE VARCHAR(100),
	@APELLIDO VARCHAR(100)
)
as
begin

insert into USUARIO (CORREO,CLAVE,NOMBRE,APELLIDO)values (@CORREO,@CLAVE,@NOMBRE,@APELLIDO);
insert into LIBRETA (nombreLibreta, fkidUsuario) values ('Libreta por defecto de '+@NOMBRE+' '+@APELLIDO,
(select MAX(idusuario) from USUARIO));

end
GO

