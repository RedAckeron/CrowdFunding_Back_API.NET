CREATE PROCEDURE [dbo].[UserRoleRemoveOwner]
	
	@idUser int
AS
BEGIN
	DELETE FROM User_Role WHERE IdUser =@idUser and IdRole = 3;
END
