CREATE PROCEDURE [dbo].[GetTaskById]
	@Id int,
	@UserId NVARCHAR (450)
AS
	SELECT t.[Id], t.[ProjectId], t.[Description], t.[Status], t.[Comments]
    FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	WHERE t.Id = @Id
	AND p.UserId = @UserId;
RETURN 0
