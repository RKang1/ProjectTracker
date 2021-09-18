CREATE PROCEDURE [dbo].[GetStatuses]
AS
	SELECT [Id], [Description]
	FROM Statuses
RETURN 0
