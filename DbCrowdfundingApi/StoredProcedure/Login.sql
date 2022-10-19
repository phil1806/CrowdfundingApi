CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(150),
	@pwd VARCHAR(50)
AS
	BEGIN
		
		DECLARE @userId INT;
		
		DECLARE @salt VARCHAR(150)

		SELECT @salt = Salt,@userId = Id FROM [Users] WHERE Email LIKE @email
		
		DECLARE @hash VARBINARY(64)
		SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt));

		DECLARE @RoleName VARCHAR(50);
		SELECT @RoleName = TypeRole FROM Roles WHERE Id = @userId
		
		
		SELECT Id, Email, NickName, IsActive, Birthdate, IdRole, @RoleName AS RoleName
		FROM Users 
		WHERE  Email LIKE @email AND Pwd LIKE @hash
END
