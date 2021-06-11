CREATE PROCEDURE [dbo].[AddTask]
	@UserId NVARCHAR (450),
    @ProjectId INT, 
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000) 
AS
    INSERT INTO Tasks ([UserId], [ProjectId], [Description], [Status], [Comments])
    VALUES (@UserId, @ProjectId, @Description, @Status, @Comments)
RETURN 0
