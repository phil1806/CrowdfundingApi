CREATE PROCEDURE [dbo].[RegisterUser]
	@nickname VARCHAR(50),
	@email VARCHAR(150),
	@pdw VARCHAR(50),
	@birthdate DATE,
	@role INT
AS
BEGIN 
	DECLARE @salt VARCHAR(150)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID(), NEWID(), NEWID())

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pdw, @salt))

	INSERT INTO Users (Email, NickName, Pwd, Birthdate, IdRole, Salt) VALUES (@email, @nickname, @hash, @birthdate, @role, @salt)
END
