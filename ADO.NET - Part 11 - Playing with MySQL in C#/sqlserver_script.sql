user master
CREATE DATABASE [cms]
GO
use cms

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL
	)