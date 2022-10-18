﻿/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		s
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

INSERT INTO Users VALUES ('Phil','Phil@gmail.com','1234$','2000-01-01','abdhheyifjfhgfhjd',1,1);
INSERT INTO Users VALUES ('Pol','Pol@gmail.com','1234$','2000-01-01','abdhheyifjfhgfhjd',1,2);
INSERT INTO Users VALUES ('Will','Will@gmail.com','1234$','2000-01-01','abdhheyifjfhgfhjd',1,3);


INSERT INTO Projects VALUES('Mon Projet 1','Desc Projet 1',12.21,'BE 123654','2020-10-01','2022-10-05',1,1);
INSERT INTO Projects VALUES('Mon Projet 2','Desc Projet 2',45251.32,'BE 123654','2020-10-01','2022-10-05',2,2);
INSERT INTO Projects VALUES('Mon Projet 3','Desc Projet 3',458.21,'BE 123654','2020-10-01','2022-10-05',3,3);
INSERT INTO Projects VALUES('Mon Projet 4','Desc Projet 4',12.02,'BE 123654','2020-10-01','2022-10-05',1,4);
INSERT INTO Projects VALUES('Mon Projet 5','Desc Projet 5',482.12,'BE 123654','2020-10-01','2022-10-05',2,5);


INSERT INTO Contributions VALUES(1235.23,'2022-10-01',3,1);
INSERT INTO Contributions VALUES(15.23,'2022-10-01',3,2);
INSERT INTO Contributions VALUES(715.23,'2022-10-01',3,3);
INSERT INTO Contributions VALUES(58.23,'2022-10-01',3,4);



 
 

