CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(150),
	@pwd VARCHAR(50)
AS
	BEGIN
		DECLARE @salt VARCHAR(150)
		SET @salt = (SELECT Salt FROM [Users] WHERE Email LIKE @email)
		
		DECLARE @hash VARBINARY(64)
		SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt));
		
		
		SELECT Id, Email, NickName, IsActive, Birthdate
		FROM Users 
		WHERE  Email LIKE @email AND Pwd LIKE @hash
END
