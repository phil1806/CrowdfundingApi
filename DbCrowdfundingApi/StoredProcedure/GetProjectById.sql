CREATE PROCEDURE [dbo].[GetProjetById]
	-- Paramètre (l'id du project)
	@IdProject INT
AS
BEGIN
	-- Requête 

	declare @somme Decimal(9,2);

	select @somme = sum(Montant)
	from Contributions
	where IdProject = @IdProject;

	IF(@somme = NULL)
	   SET @somme = 0;

	SELECT P.Id, Titre,[Description],Objectif,DateDebut,DateFin,NickName,CompteBQ,@somme As ContributionTotal
	FROM Projects AS P
	INNER JOIN  Contributions AS CT
	ON CT.IdProject = P.Id
	INNER JOIN Users AS U
	ON CT.IdUserContributeur = U.Id
	WHERE P.Id = @IdProject;

END
