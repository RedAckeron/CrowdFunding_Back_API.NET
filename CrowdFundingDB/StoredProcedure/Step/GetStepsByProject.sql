CREATE PROCEDURE [dbo].[GetStepsByProject]
	@idProject int
AS
	SELECT * FROM Step
	WHERE IdProject = @idProject
RETURN 0
