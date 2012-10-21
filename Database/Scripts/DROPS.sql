USE [rapidNote]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ADJUNTO_NOTA_ADJUNTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ADJUNTO_NOTA]'))
ALTER TABLE [dbo].[ADJUNTO_NOTA] DROP CONSTRAINT [FK_ADJUNTO_NOTA_ADJUNTO]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ADJUNTO_NOTA_NOTA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ADJUNTO_NOTA]'))
ALTER TABLE [dbo].[ADJUNTO_NOTA] DROP CONSTRAINT [FK_ADJUNTO_NOTA_NOTA]
GO

/****** Object:  Table [dbo].[ADJUNTO_NOTA]    Script Date: 10/20/2012 21:36:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADJUNTO_NOTA]') AND type in (N'U'))
DROP TABLE [dbo].[ADJUNTO_NOTA]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ETIQUETA_NOTA_ETIQUETA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ETIQUETA_NOTA]'))
ALTER TABLE [dbo].[ETIQUETA_NOTA] DROP CONSTRAINT [FK_ETIQUETA_NOTA_ETIQUETA]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ETIQUETA_NOTA_NOTA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ETIQUETA_NOTA]'))
ALTER TABLE [dbo].[ETIQUETA_NOTA] DROP CONSTRAINT [FK_ETIQUETA_NOTA_NOTA]
GO

USE [rapidNote]
GO

/****** Object:  Table [dbo].[ETIQUETA_NOTA]    Script Date: 10/20/2012 21:36:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ETIQUETA_NOTA]') AND type in (N'U'))
DROP TABLE [dbo].[ETIQUETA_NOTA]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NOTA_LIBRETA]') AND parent_object_id = OBJECT_ID(N'[dbo].[NOTA]'))
ALTER TABLE [dbo].[NOTA] DROP CONSTRAINT [FK_NOTA_LIBRETA]
GO

USE [rapidNote]
GO

/****** Object:  Table [dbo].[NOTA]    Script Date: 10/20/2012 21:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NOTA]') AND type in (N'U'))
DROP TABLE [dbo].[NOTA]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LIBRETA_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LIBRETA]'))
ALTER TABLE [dbo].[LIBRETA] DROP CONSTRAINT [FK_LIBRETA_USUARIO]
GO

USE [rapidNote]
GO

/****** Object:  Table [dbo].[LIBRETA]    Script Date: 10/20/2012 21:36:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LIBRETA]') AND type in (N'U'))
DROP TABLE [dbo].[LIBRETA]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BITACORA_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[BITACORA]'))
ALTER TABLE [dbo].[BITACORA] DROP CONSTRAINT [FK_BITACORA_USUARIO]
GO

USE [rapidNote]
GO

/****** Object:  Table [dbo].[BITACORA]    Script Date: 10/20/2012 21:37:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BITACORA]') AND type in (N'U'))
DROP TABLE [dbo].[BITACORA]
GO

/****** Object:  Table [dbo].[ETIQUETA]    Script Date: 10/20/2012 21:36:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ETIQUETA]') AND type in (N'U'))
DROP TABLE [dbo].[ETIQUETA]
GO

/****** Object:  Table [dbo].[ADJUNTO]    Script Date: 10/20/2012 21:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADJUNTO]') AND type in (N'U'))
DROP TABLE [dbo].[ADJUNTO]
GO

/****** Object:  Table [dbo].[USUARIO]    Script Date: 10/20/2012 21:37:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO]') AND type in (N'U'))
DROP TABLE [dbo].[USUARIO]
GO
