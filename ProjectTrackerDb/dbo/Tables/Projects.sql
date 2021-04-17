CREATE TABLE [dbo].[Projects] (
	[Id] INT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR (100) NULL, 
    [Status] INT NULL, 
    [Stage] INT NULL, 
    [Comments] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_Projects_Statuses] FOREIGN KEY ([Status]) REFERENCES [Statuses]([Id]), 
    CONSTRAINT [FK_Projects_Stages] FOREIGN KEY ([Stage]) REFERENCES [Stages]([Id])
);

