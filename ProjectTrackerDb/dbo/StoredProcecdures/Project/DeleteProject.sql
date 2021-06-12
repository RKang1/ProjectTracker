CREATE PROCEDURE [dbo].[DeleteProject]
	@Id INT,
	@UserId NVARCHAR (450)
AS
	DELETE Tasks
	WHERE ProjectId = @Id;

	DELETE Projects
	WHERE Id = @Id
	AND UserId = @UserId;
RETURN 0
