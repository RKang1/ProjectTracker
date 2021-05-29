CREATE TABLE [dbo].[Tasks]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [ProjectId] INT NOT NULL,
    [Description] NVARCHAR (250) NULL,
    [Status] INT NULL,
    [Comments] NVARCHAR(1000) NULL,
    CONSTRAINT [FK_Tasks_Statuses] FOREIGN KEY ([Status]) REFERENCES [Statuses]([Id]),
    CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]) 
)
