﻿CREATE TRIGGER [UserSoftDelete]
ON [dbo].[Users]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Users SET IsActive = 0 WHERE Id = (
	SELECT Id FROM deleted)
END
