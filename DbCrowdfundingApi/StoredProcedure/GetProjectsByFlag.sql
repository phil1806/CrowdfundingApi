 CREATE PROCEDURE [dbo].[GetProjectsByFlag]
    -- on passe un flag qui est 1 par default pour definir les choix 
	@Flag TINYINT = 1 
AS
BEGIN
    -- ici on slectionne les projets en cours et acceptés 
	IF (@Flag = 1)	
			SELECT P.Id, P.Titre, P.[Description], P.Objectif, P.DateDebut, P.DateFin, P.CompteBQ,TypeStatus,sum(Montant) as ContributionTotal
			FROM Contributions AS ctr
			JOIN  Projects As P
			ON ctr.IdProject = P.Id
			JOIN StatusProjects 
			ON P.IdStatus  = StatusProjects.Id
			WHERE StatusProjects.TypeStatus = 'Accept' OR StatusProjects.TypeStatus = 'Encours'
			group by p.id, P.Titre, P.[Description], P.Objectif, P.DateDebut, P.DateFin, P.CompteBQ,TypeStatus;
	ELSE 
	 -- Si non tous les projets confondus
			SELECT P.Id, P.Titre, P.[Description], P.Objectif, P.DateDebut, P.DateFin, P.CompteBQ,TypeStatus,SUM(ISNULL(MONTANT,0)) as ContributionTotal
			FROM Contributions AS ctr
			FULL JOIN  Projects As P
			ON ctr.IdProject = P.Id
			FULL JOIN StatusProjects 
			ON P.IdStatus  = StatusProjects.Id
			WHERE StatusProjects.TypeStatus != 'Deleted' 
			group by p.id, P.Titre, P.[Description], P.Objectif, P.DateDebut, P.DateFin, P.CompteBQ,TypeStatus;
END
