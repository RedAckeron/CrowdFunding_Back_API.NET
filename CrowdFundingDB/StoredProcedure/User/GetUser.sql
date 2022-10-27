CREATE PROCEDURE [dbo].[GetUser]
	@idUser int

AS
BEGIN
	SELECT Id, NickName, Email, BirthDate FROM [User]
	WHERE Id = @idUser
END