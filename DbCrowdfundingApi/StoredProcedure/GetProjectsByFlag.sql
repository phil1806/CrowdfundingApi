CREATE PROCEDURE [dbo].[GetProjectsByFlag]
    -- on passe un flag qui est 1 par default pour definir les choix 
	@Flag TINYINT = 1 
AS
BEGIN
    -- ici on slectionne les projets en cours et acceptés 
	IF (@Flag = 1)	
		SELECT P.Id,P.Titre,P.[Description],P.Objectif,P.DateDebut,P.DateFin,P.CompteBQ,TypeStatus 
		FROM Projects As P
		join StatusProjects 
		ON P.IdStatus  = StatusProjects.Id
		WHERE StatusProjects.TypeStatus = 'Accept' OR StatusProjects.TypeStatus = 'Encours';
	ELSE 
	 -- Si non tous les projets confondus
		SELECT P.Id,P.Titre,P.[Description],P.Objectif,P.DateDebut,P.DateFin,P.CompteBQ,TypeStatus 
		FROM Projects As P
		join StatusProjects 
		ON P.IdStatus  = StatusProjects.Id
END
