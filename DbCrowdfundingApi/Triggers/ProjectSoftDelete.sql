CREATE TRIGGER [ProjectSoftDelete]
	ON [dbo].[Projects]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Projects SET 
		IdStatus = (select id FROM StatusProjects WHERE TypeStatus ='Deleted')
		WHERE Id = (SELECT id FROM DELETED)
	END
