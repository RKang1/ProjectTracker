CREATE PROCEDURE [dbo].[DeleteProjectById]
	@Id INT,
	@UserId NVARCHAR (450)
AS
	DELETE t
	FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	WHERE t.ProjectId = @Id
	AND p.UserId = @UserId;

	DELETE Projects
	WHERE Id = @Id
	AND UserId = @UserId;
RETURN 0
