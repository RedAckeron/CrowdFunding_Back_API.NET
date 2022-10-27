CREATE PROCEDURE [dbo].[RegisterUser]
	@nickname VARCHAR(50),
	@email VARCHAR(100),
	@pwd VARCHAR(100),
	@birthDate VARCHAR(100)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt))

	INSERT INTO [User] (Email, NickName, Password, BirthDate, Salt) VALUES (@email, @nickname, @hash, CONVERT(date, @birthDate), @salt)
END
