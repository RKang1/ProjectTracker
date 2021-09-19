CREATE PROCEDURE [dbo].[GetProjectsByUserId]
	@UserId NVARCHAR (450)
AS
	SELECT p.[Id], p.[UserId], p.[Name], p.[StatusId], sts.Description AS 'Status', p.[StageId], stg.Description AS 'Stage', p.[Comments]
	FROM Projects p
	JOIN Statuses sts on sts.Id = p .StatusId
	JOIN Stages stg on stg.Id = p .StageId
	WHERE [UserId] = @UserId;
RETURN 0