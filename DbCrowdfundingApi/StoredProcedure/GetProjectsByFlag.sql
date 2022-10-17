CREATE PROCEDURE [dbo].[GetProjectsByFlag]
	@Flag TINYINT = 1
AS
BEGIN
	IF (@Flag = 1)	
		SELECT P.Id,P.Titre,P.[Description],P.Objectif,P.DateDebut,P.DateFin,P.CompteBQ,StatusProjects.TypeStatus
		FROM Projects As P
		join StatusProjects 
		ON P.IdStatus  = StatusProjects.Id
		WHERE StatusProjects.TypeStatus = 'Accept' or StatusProjects.TypeStatus = 'Encours';
	ELSE 
		SELECT P.Id,P.Titre,P.[Description],P.Objectif,P.DateDebut,P.DateFin,P.CompteBQ,StatusProjects.TypeStatus
		FROM Projects As P
		join StatusProjects 
		ON P.IdStatus  = StatusProjects.Id
END
