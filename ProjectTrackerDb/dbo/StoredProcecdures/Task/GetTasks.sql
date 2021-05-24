CREATE PROCEDURE [dbo].[GetTasks]
AS
	SELECT [Id], [Description], [Status], [Comments] FROM Tasks;
RETURN 0
