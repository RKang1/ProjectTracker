CREATE PROCEDURE [dbo].[GetProjectById]
	@Id INT,
	@UserId NVARCHAR (450)

AS
	SELECT [Id], [UserId], [Name], [Status], [Stage], [Comments]
	FROM Projects
	WHERE Id = @Id
	AND UserId = @UserId;
RETURN 0
