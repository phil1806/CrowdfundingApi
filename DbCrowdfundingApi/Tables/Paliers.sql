CREATE TABLE [dbo].[Paliers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(50),
	Montant DECIMAL(9,2),
	[Description] VARCHAR(250),
	[IdProject] INT NOT NULL REFERENCES [Projects](Id),
	
)
