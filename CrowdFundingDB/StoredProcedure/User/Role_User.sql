CREATE PROCEDURE [dbo].[Role_User]
	@userId int
AS
	SELECT Role.Name FROM [User_Role]
	INNER JOIN Role ON Role.Id = User_Role.IdRole
	WHERE User_Role.IdUser = @userId
RETURN 0
