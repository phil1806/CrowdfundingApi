CREATE TABLE [dbo].[Contributions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	Montant DECIMAL(9,2),
	DateContribution DATE DEFAULT GETDATE() NOT NULL,
	[IdUserContributeur] INT NOT NULL REFERENCES [Users](Id),
	[IdProject] INT NOT NULL REFERENCES [Projects](Id),
		


	
)
