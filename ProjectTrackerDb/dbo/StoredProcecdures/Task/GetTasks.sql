CREATE PROCEDURE [dbo].[GetTasks]
AS
	SELECT [Id], [ProjectId], [Description], [Status], [Comments] FROM Tasks;
RETURN 0
