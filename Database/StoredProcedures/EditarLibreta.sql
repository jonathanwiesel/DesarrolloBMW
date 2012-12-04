USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[EditarLibreta]    Script Date: 12/03/2012 22:29:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[EditarLibreta](
	@id int,
	@nombre varchar(100)
)
as
begin
	update LIBRETA set nombreLibreta=@nombre where idLibreta=@id
end
GO

