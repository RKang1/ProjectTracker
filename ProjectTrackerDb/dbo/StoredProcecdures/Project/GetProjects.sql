CREATE PROCEDURE [dbo].[GetProjects]
AS
	SELECT [Id], [Name], [Status], [Stage], [Comments] FROM Projects;
RETURN 0
