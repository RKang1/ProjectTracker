CREATE PROCEDURE [dbo].[AddTask]
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000) 

AS
    INSERT INTO Tasks ([Description], [Status], [Comments])
    VALUES (@Description, @Status, @Comments)
RETURN 0
