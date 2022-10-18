CREATE PROCEDURE [dbo].[GetUsersContributionById]
	@id int
	
AS
BEGIN
-- Declaration d'une variable
 DECLARE @typeDeRole VARCHAR(100);

-- JE selectionne le rôle du user
	Select @typeDeRole = typeRole
	FROM roles
	JOIN Users
	ON Roles.Id = IdRole
	WHERE Users.id = @Id ;

-- Je teste 
	IF(@typeDeRole like 'Contributeur')
		select C.id, C.Montant,C.DateContribution
		from Contributions as C
		inner join Users as U
		on C.IdUserContributeur = U.Id
		where U.id = @Id;
	ELSE
	 SELECT 'je ne suis pas Contributeur...';
END



