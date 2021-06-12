CREATE PROCEDURE [dbo].[TruncateProjects]
AS
	ALTER TABLE [Tasks]
	DROP CONSTRAINT [FK_Tasks_Statuses]; 

	ALTER TABLE [Tasks]
	DROP CONSTRAINT [FK_Tasks_Projects]; 

	TRUNCATE TABLE [Projects];

	ALTER TABLE [Tasks]
	ADD CONSTRAINT [FK_Tasks_Statuses] FOREIGN KEY ([Status]) REFERENCES [Statuses]([Id]);

	ALTER TABLE [Tasks]
	ADD CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]);

RETURN 0