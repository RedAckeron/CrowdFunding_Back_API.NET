CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@nickName VARCHAR(50),
	@email VARCHAR(100),
	@birthdate VARCHAR(100)
AS
BEGIN
	UPDATE [User]
	SET NickName = @nickName, Email = @email, BirthDate = CONVERT(date, @birthDate)
	WHERE Id = @id
END
