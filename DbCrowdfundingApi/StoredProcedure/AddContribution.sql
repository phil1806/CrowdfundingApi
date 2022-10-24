CREATE PROCEDURE [dbo].[AddContribution]
	@Montant DECIMAL(9,2),
	@IdUser int,
	@IdProject int
AS
    
	DECLARE @statuId INT;
    SELECT @statuId = IdStatus FROM Projects WHERE Id = @IdProject
    IF @statuId != 4
        THROW 1, 'project is not in progress', 1;


    DECLARE @userRole VARCHAR(50);
    SELECT  @userRole = RoleName FROM UsersActif WHERE Id = @IdUser
    IF @userRole NOT LIKE 'Contributeur'
        THROW 2, 'User is not contributor', 2;
    
    INSERT INTO Contributions (Montant, [IdUserContributeur], IdProject) VALUES (@Montant, @IdUser, @IdProject)

RETURN 0

