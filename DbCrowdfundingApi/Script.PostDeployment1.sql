/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Roles (TypeRole) 
VALUES ('Admin'), ('ProjectOwner'), ('Contributeur');

INSERT INTO StatusProjects (TypeStatus) 
VALUES ('Submit'), ('Accept'), ('Refused'), ('Encours'), ('Finished');

INSERT INTO Users VALUES('Phil','Phil@gmail.com','1234$','2000-01-01','jfjfjjfjfjff',1,1);
INSERT INTO Projects VALUES('monProjet','maDescription','mon objectif','12547','2022-10-01','2022-10-10',1,1);
INSERT INTO Contributions VALUES(56.2,getdate(),1,1);



--CREATE PROCEDURE [dbo].[GetContributionByUsers]
--@Id INT
--AS
--BEGIN
--select C.id, C.Montant,C.DateContribution
--from Contributions as C
--inner join Users as U
--on C.id = U.id
--where U.id = @Id;
--END

-- Tache
-- Mettre les elments en unique dans la table  => users (name et email)
-- Faire la procedure dans le trello ( ne pas oublier d'ajouter  le type de users )



 

