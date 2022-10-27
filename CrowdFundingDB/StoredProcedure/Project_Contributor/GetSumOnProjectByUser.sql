CREATE PROCEDURE [dbo].[GetSumOnProjectByUser]
	@idProject int,
	@idUser int
AS
	SELECT SUM(Amount) 
	FROM Project_Contributor
	WHERE IdUser = @idUser AND IdProject = @idProject
RETURN 0
