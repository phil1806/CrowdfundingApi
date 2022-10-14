CREATE TABLE [dbo].[Contributions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	Montant DECIMAL(9,2),
	DateContribution DATETIME DEFAULT GETDATE() NOT NULL,
	[IdUser] INT NOT NULL REFERENCES [Users](Id),
	[IdProject] INT NOT NULL REFERENCES [Projects](Id),
		


	
)
