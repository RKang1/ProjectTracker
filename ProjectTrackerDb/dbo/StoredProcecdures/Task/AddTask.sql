CREATE PROCEDURE [dbo].[AddTask]
    @ProjectId INT, 
    @Description NVARCHAR(250), 
    @Status INT, 
    @Comments NVARCHAR(1000) = NULL,
	@UserId NVARCHAR (450)
AS
    INSERT INTO Tasks ([ProjectId], [Description], [StatusId], [Comments])
    SELECT @ProjectId, @Description, @Status, @Comments
    FROM Projects
    WHERE Id = @ProjectId
    AND UserId = @UserId
RETURN 0
