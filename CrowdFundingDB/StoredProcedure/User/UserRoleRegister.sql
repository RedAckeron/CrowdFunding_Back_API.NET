CREATE PROCEDURE [dbo].[UserRoleRegister]
	@email VARCHAR(100),
	@idRole int
AS
BEGIN
	DECLARE @idUser AS INT
	SELECT @idUser = Id FROM [User] WHERE Email = @email
	INSERT INTO User_Role (IdRole, IdUser) VALUES (@idRole, @idUser)
END
