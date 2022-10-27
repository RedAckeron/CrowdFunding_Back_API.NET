CREATE PROCEDURE [dbo].[GetAll]
	@idStep int
AS
BEGIN
	SELECT Id, IdProject, Amount, Reward FROM Step
END
