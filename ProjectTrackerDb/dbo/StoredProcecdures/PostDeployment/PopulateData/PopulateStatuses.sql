CREATE PROCEDURE [dbo].[PopulateStatuses]
AS

DECLARE
	@Description NVARCHAR(50)

SET @Description = 'Nothing needed';
IF NOT EXISTS (select 1 from Statuses WHERE Description = @Description)
BEGIN
	INSERT INTO Statuses (Description) VALUES (@Description);
END

SET @Description = 'Needs Work';
IF NOT EXISTS (select 1 from Statuses WHERE Description = @Description)
BEGIN
	INSERT INTO Statuses (Description) VALUES (@Description);
END

SET @Description = 'Waiting';
IF NOT EXISTS (select 1 from Statuses WHERE Description = @Description)
BEGIN
	INSERT INTO Statuses (Description) VALUES (@Description);
END

SET @Description = 'Completed';
IF NOT EXISTS (select 1 from Statuses WHERE Description = @Description)
BEGIN
	INSERT INTO Statuses (Description) VALUES (@Description);
END

RETURN 0
