CREATE PROCEDURE [dbo].[AddTask]
    @ProjectId INT, 
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000) 

AS
    INSERT INTO Tasks ([ProjectId], [Description], [Status], [Comments])
    VALUES (@ProjectId, @Description, @Status, @Comments)
RETURN 0

