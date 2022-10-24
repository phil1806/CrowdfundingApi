/*
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

/*
INSERT INTO Roles (TypeRole) 
VALUES ('Admin'), ('ProjectOwner'), ('Contributeur');


INSERT INTO StatusProjects (TypeStatus) 
VALUES ('Submit'), ('Accept'), ('Refused'), ('Encours'), ('Finished');
*/


INSERT INTO Roles (TypeRole) 
VALUES ('Admin'), ('ProjectOwner'), ('Contributeur');

INSERT INTO StatusProjects (TypeStatus) 
VALUES ('Submit'), ('Accept'), ('Refused'), ('Encours'),('Deleted'),('Finished');

DECLARE @date Date;
SELECT @date = DATEFROMPARTS ( 2010, 12, 31 )

EXEC [RegisterUser] @nickname = 'Phil',	@email= 'Phil@gmail.com',	@pdw = '1234$', @birthdate = @date ,@role  = 1;
EXEC [RegisterUser] @nickname = 'Pol',	@email= 'Pol@gmail.com',	@pdw = '1234$', @birthdate = @date ,@role  = 2;
EXEC [RegisterUser] @nickname = 'Will',	@email= 'Will@gmail.com',	@pdw = '1234$', @birthdate = @date ,@role  = 3;


INSERT INTO Projects VALUES('Mon Projet 1','Desc Projet 1',12.21,'BE 123654','2020-10-01','2022-10-05',1,1);
INSERT INTO Projects VALUES('Mon Projet 2','Desc Projet 2',45251.32,'BE 123654','2020-10-01','2022-10-05',2,2);
INSERT INTO Projects VALUES('Mon Projet 3','Desc Projet 3',458.21,'BE 123654','2020-10-01','2022-10-05',3,3);
INSERT INTO Projects VALUES('Mon Projet 4','Desc Projet 4',12.02,'BE 123654','2020-10-01','2022-10-05',1,4);
INSERT INTO Projects VALUES('Mon Projet 5','Desc Projet 5',482.12,'BE 123654','2020-10-01','2022-10-05',2,5);
INSERT INTO Projects VALUES('Mon Projet 56','Desc Projet 56',482.12,'BE 123654','2020-10-01','2022-10-05',2,6);

INSERT INTO Paliers VALUES('Bronze', 50,'T-shirts',1),
('Argent',100,'Paire de lunette',1),
('Gold',200,'Ordinateur',1),
('Argent',100,'Tasses',2),
('Bronze',50,'Pull-Over',2),
('Gold',200,'Sac ordinateur',2);

INSERT INTO Contributions VALUES(1235.23,'2022-10-01',3,1);
INSERT INTO Contributions VALUES(15.23,'2022-10-01',3,2);
INSERT INTO Contributions VALUES(715.23,'2022-10-01',3,3);
INSERT INTO Contributions VALUES(58.23,'2022-10-01',3,4);

INSERT INTO Contributions VALUES(1235.23,'2022-10-01',3,1);
INSERT INTO Contributions VALUES(15.23,'2022-10-01',3,2);
INSERT INTO Contributions VALUES(715.23,'2022-10-01',3,3);
INSERT INTO Contributions VALUES(58.23,'2022-10-01',3,4);


/*
//TODO active SQLServerAgent 
//TODO @command of the job

USE msdb;
EXEC dbo.sp_add_job  
	@job_name = N'MyJob',
	@owner_login_name = 'sa'
GO  

GO  
EXEC sp_add_jobstep  
	@job_name = N'MyJob',  
	@step_name = N'Set database to read only',  
	@subsystem = N'TSQL',  
	@command = 'UPDATE Projects SET IdStatus = 3 WHERE DateFin < NOW',
	@database_name = 'TestCrownfounding'
	 
GO 

EXEC sp_add_jobserver 
	@job_name = N'MyJob'


USE msdb;
EXEC sp_start_job   
	 @job_name = N'MyJob'

GO  
-- creates a schedule named NightlyJobs.   
-- Jobs that use this schedule execute every day when the time on the server is 01:00.   
EXEC sp_add_schedule  
	@schedule_name = N'ExecMyJob' ,  
	@freq_type = 4,  
	@freq_interval = 1,  
	@active_start_time = 000000 ;  
GO  

-- attaches the schedule to the job BackupDatabase  
EXEC sp_attach_schedule  
   @job_name = N'MyJob',  
   @schedule_name = N'ExecMyJob' ;  
GO  
*/



