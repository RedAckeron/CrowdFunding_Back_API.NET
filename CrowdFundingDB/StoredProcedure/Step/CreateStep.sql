CREATE PROCEDURE [dbo].[CreateStep]
	@idProject int,
	@amout int,
	@reward VARCHAR(100)
AS
BEGIN
	INSERT INTO Step (IdProject, Amount, Reward) VALUES (@idProject, @amout, @reward)
END