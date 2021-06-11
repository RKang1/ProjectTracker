CREATE PROCEDURE [dbo].[EditProject]
    @Id INT,
    @Name NVARCHAR(100), 
    @Status INT, 
    @Stage INT, 
    @Comments NVARCHAR(1000) 
AS
    UPDATE Projects
    SET [Name] = @Name, [Status] = @Status, [Stage] = @Stage, [Comments] = @Comments
    WHERE Id = @Id;
RETURN 0
