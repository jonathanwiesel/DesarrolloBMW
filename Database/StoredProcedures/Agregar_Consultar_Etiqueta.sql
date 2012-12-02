USE [rapidnote]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Consultar_Etiqueta]    Script Date: 12/01/2012 19:38:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Agregar_Consultar_Etiqueta](

	@nombre varchar(100)
)
as
begin
	begin tran
if exists (select * from ETIQUETA with (updlock,serializable) where nombre = @nombre)
begin
   select e.idEtiqueta from ETIQUETA e where e.nombre = @nombre;
end
else
begin
   insert into ETIQUETA values (@nombre);
   select e.idEtiqueta from ETIQUETA e where e.nombre = @nombre;
end
commit tran
end

GO

