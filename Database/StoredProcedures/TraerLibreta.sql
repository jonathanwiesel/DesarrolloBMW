USE [rapidNote]
GO

/****** Object:  StoredProcedure [dbo].[TraerLibreta]    Script Date: 12/03/2012 22:28:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TraerLibreta]
(
	@id int 
)
as 
begin
	select nombreLibreta from LIBRETA where idLibreta = @id; 

end
GO

