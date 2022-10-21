CREATE PROCEDURE [dbo].[InsertPalier]
	@Title VARCHAR(50),
	@Montant DECIMAL(9,2),
	@Description VARCHAR(250),
	@IdProject INT
AS
BEGIN 
    INSERT INTO Paliers(Title, Montant, [Description], IdProject) 
    OUTPUT INSERTED.Id
    VALUES (@Title,@Montant,@Description,@IdProject);
END

