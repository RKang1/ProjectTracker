CREATE PROCEDURE [dbo].[DeleteProject]
	@Id int
AS
	DELETE Tasks
	WHERE ProjectId = @Id;

	DELETE Projects
	WHERE Id = @Id;
RETURN 0
