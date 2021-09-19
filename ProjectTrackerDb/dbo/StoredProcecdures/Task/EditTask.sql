CREATE PROCEDURE [dbo].[EditTask]
    @Id INT,
    @Description NVARCHAR(250), 
    @Status INT, 
    @Comments NVARCHAR(1000) = NULL,
	@UserId NVARCHAR (450)
AS
    UPDATE t
    SET [Description] = @Description, [StatusId] = @Status, [Comments] = @Comments
    FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	WHERE t.Id = @Id
	AND p.UserId = @UserId;
RETURN 0
