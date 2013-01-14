USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[ImportarConfiguracion]    Script Date: 01/13/2013 23:15:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[ImportarConfiguracion]
(
	@CORREO VARCHAR(200),
	@CLAVE VARCHAR(500),
	@NOMBRE VARCHAR(100),
	@APELLIDO VARCHAR(100),
	@AccesSecret VARCHAR(100),
	@AccesToken VARCHAR(100)
)
as
begin
insert into USUARIO (CORREO,CLAVE,NOMBRE,APELLIDO,acesssecret,acesstoken)
values (@CORREO,@CLAVE,@NOMBRE,@APELLIDO,@AccesSecret,@AccesToken);

end

GO

