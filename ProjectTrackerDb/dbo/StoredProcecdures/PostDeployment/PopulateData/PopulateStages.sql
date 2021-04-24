CREATE PROCEDURE [dbo].[PopulateStages]
AS

DECLARE
	@Description NVARCHAR(50)

SET @Description = 'Kickoff';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Concepts';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Alpha';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Alpha Review';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Beta';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Beta Review';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Master';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END

SET @Description = 'Master Review';
IF NOT EXISTS (select 1 from Stages WHERE Description = @Description)
BEGIN
	INSERT INTO Stages (Description) VALUES (@Description);
END
