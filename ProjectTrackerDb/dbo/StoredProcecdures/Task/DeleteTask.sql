CREATE PROCEDURE [dbo].[DeleteTask]
	@Id INT,
	@UserId NVARCHAR (450)
AS
	DELETE t
	FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	WHERE t.Id = @Id
	AND p.UserId = @UserId;
RETURN 0
