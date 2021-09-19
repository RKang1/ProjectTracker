CREATE PROCEDURE [dbo].[GetTasksByProjectId]
	@ProjectId int,
	@UserId NVARCHAR (450)
AS
	SELECT t.[Id], t.[ProjectId], t.[Description], t.[StatusId], sts.[Description] AS 'Status', t.[Comments]
    FROM Projects p
	JOIN Tasks t on t.ProjectId = p.Id
	JOIN Statuses sts on sts.Id = t.StatusId
	WHERE p.Id = @ProjectId
	AND p.UserId = @UserId;
RETURN 0
