CREATE PROCEDURE [dbo].[GetProjectById]
	@Id INT
AS
	SELECT [Id], [Name], [Status], [Stage], [Comments]
	FROM Projects
	WHERE Id = @Id;
RETURN 0
