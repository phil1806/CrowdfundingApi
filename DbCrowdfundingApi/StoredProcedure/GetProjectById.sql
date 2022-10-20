CREATE PROCEDURE [dbo].[GetProjetById]
	-- Paramètre (l'id du project)
	@IdProject INT
AS
BEGIN
	-- Requête 

	declare @somme Decimal(9,2);

	SELECT @somme = sum(Montant)
	FROM Contributions
	WHERE IdProject = @IdProject;

	SELECT P.Id, Titre,[Description],Objectif,DateDebut,DateFin,ISNULL(NickName,'Pas renseigné') as NameUser,CompteBQ,ISNULL(@somme,0) As ContributionTotal
	FROM Projects AS P
	FULL JOIN  Contributions AS CT
	ON CT.IdProject = P.Id
	full JOIN Users AS U
	ON CT.IdUserContributeur = U.Id
	WHERE P.Id = @IdProject;

END
