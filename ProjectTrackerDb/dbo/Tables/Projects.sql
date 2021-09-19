CREATE TABLE [dbo].[Projects] (
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [UserId] NVARCHAR (450) NOT NULL, 
    [Name] NVARCHAR (100) NULL, 
    [StatusId] INT NULL, 
    [StageId] INT NULL, 
    [Comments] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_Projects_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]),
    CONSTRAINT [FK_Projects_Statuses] FOREIGN KEY ([StatusId]) REFERENCES [Statuses]([Id]), 
    CONSTRAINT [FK_Projects_Stages] FOREIGN KEY ([StageId]) REFERENCES [Stages]([Id])
);

