﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	NickName VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Pwd VARCHAR(100) NOT NULL,
	Birthdate DATE NOT NULL,
	Salt VARCHAR(100) NOT NULL,
	IsActive TINYINT DEFAULT 1 NOT NULL,
	[IdRole] INT NOT NULL REFERENCES [Roles](Id),
	
)
