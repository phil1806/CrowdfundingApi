CREATE PROCEDURE [dbo].[validProject]
	@IdProjectParams INT
AS
BEGIN
    DECLARE @IdProjet INT;
    DECLARE @status INT;

	-- On selection si l'id du projet existe
	SELECT @IdProjet = Id, @status = IdStatus
	FROM Projects
	WHERE Id = @IdProjectParams;

	-- On teste si le projet existe
	IF (@IdProjet IS NULL)
		 SELECT'Erreur :  Projet non existant..';
	ELSE
		Update Projects
		SET IdStatus = 2
		WHERE Id = @IdProjectParams;
END
