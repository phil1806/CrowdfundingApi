﻿CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Titre VARCHAR(50) NOT NULL,
	[Description] VARCHAR(150),
	Objectif  VARCHAR(200),
	CompteBQ  VARCHAR(100) ,
	DateDebut DATETIME NOT NULL,
	DateFin DATETIME NOT NULL,
	[IdUserOwner] INT NOT NULL REFERENCES [Users](Id),
	[IdStatus] INT NOT NULL REFERENCES [StatusProjects](Id)


)
