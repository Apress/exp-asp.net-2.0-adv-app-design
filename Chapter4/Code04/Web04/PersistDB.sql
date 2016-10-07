IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'VS_Persist')
	DROP DATABASE [VS_Persist]
GO

CREATE DATABASE [VS_Persist]  ON (NAME = N'VS_Persist_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\VS_Persist_Data.MDF' , SIZE = 1, FILEGROWTH = 10%) LOG ON (NAME = N'VS_Persist_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\VS_Persist_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'VS_Persist', N'autoclose', N'false'
GO

exec sp_dboption N'VS_Persist', N'bulkcopy', N'false'
GO

exec sp_dboption N'VS_Persist', N'trunc. log', N'false'
GO

exec sp_dboption N'VS_Persist', N'torn page detection', N'true'
GO

exec sp_dboption N'VS_Persist', N'read only', N'false'
GO

exec sp_dboption N'VS_Persist', N'dbo use', N'false'
GO

exec sp_dboption N'VS_Persist', N'single', N'false'
GO

exec sp_dboption N'VS_Persist', N'autoshrink', N'false'
GO

exec sp_dboption N'VS_Persist', N'ANSI null default', N'false'
GO

exec sp_dboption N'VS_Persist', N'recursive triggers', N'false'
GO

exec sp_dboption N'VS_Persist', N'ANSI nulls', N'false'
GO

exec sp_dboption N'VS_Persist', N'concat null yields null', N'false'
GO

exec sp_dboption N'VS_Persist', N'cursor close on commit', N'false'
GO

exec sp_dboption N'VS_Persist', N'default to local cursor', N'false'
GO

exec sp_dboption N'VS_Persist', N'quoted identifier', N'false'
GO

exec sp_dboption N'VS_Persist', N'ANSI warnings', N'false'
GO

exec sp_dboption N'VS_Persist', N'auto create statistics', N'true'
GO

exec sp_dboption N'VS_Persist', N'auto update statistics', N'true'
GO

use [VS_Persist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_LoadState]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_LoadState]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_SaveState]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_SaveState]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[State]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[State]
GO

CREATE TABLE [dbo].[State] (
	[PageName] [varchar] (400) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SessionID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StateData] [image] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[State] WITH NOCHECK ADD 
	CONSTRAINT [PK_State] PRIMARY KEY  CLUSTERED 
	(
		[PageName],
		[SessionID]
	)  ON [PRIMARY] 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE usp_LoadState
@PageName varchar(400),
@SessionID varchar(50)

AS

SELECT StateData From State WHERE PageName = @PageName and SessionID = @SessionID

DELETE FROM State WHERE PageName = @PageName and SessionID = @SessionID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE usp_SaveState
@PageName varchar(400),
@SessionID varchar(50),
@StateData image
 AS

DELETE FROM State WHERE PageName = @PageName and SessionID = @SessionID

INSERT INTO State (PageName, SessionID, StateData)
VALUES
(@PageName, @SessionID, @StateData)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

