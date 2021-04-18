CREATE PROCEDURE [dbo].[PostDeployment]
AS
	EXEC PopulateStatuses;
	EXEC PopulateStages;
RETURN 0
