CREATE PROCEDURE [dbo].[RegisterUser]
	@nickname VARCHAR(50),
	@email VARCHAR(150),
	@pdw VARCHAR(50),
	@birthdate DATE,
	@role INT
AS
BEGIN 
	DECLARE @salt VARCHAR(150)
    SET @salt = CONCAT(NEWID(), NEWID(), NEWID(), NEWID());

	DECLARE @hash VARBINARY(64)
    SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pdw, @salt));

    DECLARE @RoleName VARCHAR(50);
    SELECT @RoleName = TypeRole FROM Roles WHERE Id = @role

    DECLARE @outputTable TABLE ( Id INT , nickname VARCHAR(50), Email VARCHAR(50),Birthdate DATE, RoleName VARCHAR(50) )

    INSERT INTO Users (Email, NickName, Pwd, Birthdate, IdRole, Salt) 
    OUTPUT INSERTED.Id,INSERTED.NickName,INSERTED.Email,INSERTED.Birthdate,@RoleName
    INTO @outputTable
    VALUES (@email, @nickname, @hash,@birthdate,@role, @salt)
    SELECT * FROM @outputTable
END

