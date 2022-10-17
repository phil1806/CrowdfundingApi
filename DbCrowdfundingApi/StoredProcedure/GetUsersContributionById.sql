CREATE PROCEDURE [dbo].[GetUsersContributionById]
	@id int
	
AS
BEGIN
 DECLARE @typeDeRole VARCHAR(100);
	Select @typeDeRole = typeRole
	FROM roles
	JOIN Users
	ON Roles.Id = IdRole
	WHERE Users.id = @Id ;
	IF(@typeDeRole like '%Contributeur%')
		select C.id, C.Montant,C.DateContribution
		from Contributions as C
		inner join Users as U
		on C.IdUser = U.Id
		where U.id = @Id;
	ELSE
	 SELECT 'je ne suis pas Contributeur...';
END


