CREATE PROCEDURE [dbo].[GetProjetById]
	-- Paramètre (l'id du project)
	@IdProject INT
AS
BEGIN
	-- Requête 
	SELECT Titre,Description,Objectif,DateDebut,DateFin,Montant,DateContribution, NickName,U.Id 
	FROM Projects AS P
	INNER JOIN  Contributions AS CT
	ON CT.IdProject = P.Id
	INNER JOIN Users AS U
	ON CT.IdUserContributeur = U.Id
	WHERE P.Id = @IdProject;
END
