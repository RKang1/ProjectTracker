CREATE PROCEDURE [dbo].[GetTaskById]
	@Id int,
	@UserId NVARCHAR (450)
AS
	SELECT t.[Id], t.[ProjectId], t.[Description], t.[StatusId], sts.[Description] AS 'Status', t.[Comments]
    FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	JOIN Statuses sts on sts.Id = t.StatusId
	WHERE t.Id = @Id
	AND p.UserId = @UserId;
RETURN 0
