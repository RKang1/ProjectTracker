CREATE PROCEDURE [dbo].[GetProjectById]
	@Id int
AS
	SELECT *
	FROM Projects
	WHERE Id = @Id;
RETURN 0
