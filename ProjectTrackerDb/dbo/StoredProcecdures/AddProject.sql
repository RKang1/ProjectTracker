CREATE PROCEDURE [dbo].[AddProject]
    @Name NVARCHAR, 
    @Status INT, 
    @Stage INT, 
    @Comments NVARCHAR(1000) 

AS
    INSERT INTO Projects ([Name], [Status], [Stage], [Comments])
    VALUES (@Name, @Status, @Stage, @Comments)
RETURN 0
