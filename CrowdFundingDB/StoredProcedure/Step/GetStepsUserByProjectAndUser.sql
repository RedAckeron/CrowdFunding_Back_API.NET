CREATE PROCEDURE [dbo].[GetStepsUserByProjectAndUser]
	@projectId int,
	@userId int
AS
BEGIN
	SELECT Step.Id, Step.IdProject, Step.Amount, Step.Reward 
	FROM Step_User 
	INNER JOIN Step ON Step.Id = @projectId 
	WHERE IdUser = @userId AND Step.IdProject = @projectId
END


