CREATE PROCEDURE [dbo].[GetProjectById]
	@Id int
AS
	SELECT [Id], [Name], [Status], [Stage], [Comments]
	FROM Projects
	WHERE Id = @Id;
RETURN 0
