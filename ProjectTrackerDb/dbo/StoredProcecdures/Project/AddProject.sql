CREATE PROCEDURE [dbo].[AddProject]
    @Name NVARCHAR(100), 
    @Status INT, 
    @Stage INT, 
    @Comments NVARCHAR(1000) = NULL,
	@UserId NVARCHAR (450)

AS
    INSERT INTO Projects ([UserId], [Name], [Status], [Stage], [Comments])
    VALUES (@UserId, @Name, @Status, @Stage, @Comments)
RETURN 0
