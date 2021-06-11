CREATE PROCEDURE [dbo].[GetTasksByProjectId]
	@ProjectId int
AS
	SELECT [Id], [UserId], [ProjectId], [Description], [Status], [Comments]
	FROM Tasks
	WHERE ProjectId = @ProjectId;
RETURN 0
