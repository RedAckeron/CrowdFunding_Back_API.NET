CREATE PROCEDURE [dbo].[GetOne]
	@idStep int
AS
	SELECT Id, IdProject, Amount, Reward FROM Step
	WHERE Id = @idStep
RETURN 0
