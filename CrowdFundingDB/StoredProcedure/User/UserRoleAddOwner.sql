CREATE PROCEDURE [dbo].[UserRoleAddOwner]
	
	@idUser int
AS
BEGIN
	INSERT INTO User_Role (IdRole, IdUser) VALUES (3, @idUser)
END
