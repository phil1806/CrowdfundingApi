CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(150),
	@pwd VARCHAR(50)
AS
BEGIN		
		DECLARE @salt VARCHAR(150)

		SELECT @salt = Salt FROM [Users] WHERE Email LIKE @email
		
		DECLARE @hash VARBINARY(64)
		SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt));
			
		SELECT Id,Email, NickName, Birthdate, RoleName
		FROM UsersActif
		WHERE  Email LIKE @email AND Pwd LIKE @hash
END
