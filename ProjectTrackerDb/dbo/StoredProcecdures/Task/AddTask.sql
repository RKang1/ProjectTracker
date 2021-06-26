CREATE PROCEDURE [dbo].[AddTask]
    @ProjectId INT, 
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000),
	@UserId NVARCHAR (450)
AS
    INSERT INTO Tasks ([ProjectId], [Description], [Status], [Comments])
    SELECT @ProjectId, @Description, @Status, @Comments
    FROM Projects
    WHERE Id = @ProjectId
    AND UserId = @UserId
RETURN 0
