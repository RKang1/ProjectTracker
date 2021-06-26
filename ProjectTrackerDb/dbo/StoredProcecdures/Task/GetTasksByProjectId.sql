CREATE PROCEDURE [dbo].[GetTasksByProjectId]
	@ProjectId int,
	@UserId NVARCHAR (450)
AS
	SELECT t.[Id], t.[ProjectId], t.[Description], t.[Status], t.[Comments]
    FROM Projects p
	JOIN Tasks t on t.ProjectId = p.Id
	WHERE p.Id = @ProjectId
	AND p.UserId = @UserId;
RETURN 0
