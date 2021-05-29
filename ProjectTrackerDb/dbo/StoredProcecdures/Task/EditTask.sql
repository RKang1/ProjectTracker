CREATE PROCEDURE [dbo].[EditTask]
    @Id INT,
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000) 
AS
    UPDATE Tasks
    SET [Description] = @Description, [Status] = @Status, [Comments] = @Comments
    WHERE Id = @Id;
RETURN 0
