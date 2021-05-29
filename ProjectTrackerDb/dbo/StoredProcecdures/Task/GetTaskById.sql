CREATE PROCEDURE [dbo].[GetTaskById]
	@Id int
AS
	SELECT [Id], [ProjectId], [Description], [Status], [Comments]
	FROM Tasks
	WHERE Id = @Id;
RETURN 0
