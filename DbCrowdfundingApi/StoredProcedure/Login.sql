CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(100),
	@pwd VARCHAR(100)
AS
	BEGIN

		--SELECT Id, Email, NickName FROM [Users] WHERE  Email LIKE @email
		
		DECLARE @salt VARCHAR(100)
		SET @salt = (SELECT Salt FROM [Users] WHERE Email LIKE @email)
		
		DECLARE @hash VARBINARY(64)
	--SELECT @hash HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt));
	--SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pdw, @salt));

		SELECT Id, Email = @salt, NickName = @hash FROM [Users] WHERE  Email LIKE @email
		
		/*
		SELECT Id, Email, NickName, IsActive
		FROM Users 
		WHERE  Email LIKE @email AND Pwd LIKE @hash*/
END
