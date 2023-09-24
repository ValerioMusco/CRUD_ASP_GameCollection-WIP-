﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(max) NOT NULL,
	[Mail] NVARCHAR(100) NOT NULL UNIQUE,
	[Privileges] NVARCHAR(max) NOT NULL
)
