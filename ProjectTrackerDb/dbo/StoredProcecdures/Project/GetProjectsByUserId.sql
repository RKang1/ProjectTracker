CREATE PROCEDURE [dbo].[GetProjectsByUserId]
	@UserId NVARCHAR (450)
AS
	SELECT [Id], [UserId], [Name], [StatusId], [StageId], [Comments]
	FROM Projects
	WHERE [UserId] = @UserId;
RETURN 0