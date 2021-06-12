CREATE PROCEDURE [dbo].[EditTask]
    @Id INT,
    @Description NVARCHAR, 
    @Status INT, 
    @Comments NVARCHAR(1000) ,
	@UserId NVARCHAR (450)
AS
    UPDATE t
    SET [Description] = @Description, [Status] = @Status, [Comments] = @Comments
    FROM Tasks t
	JOIN Projects p on p.Id = t.ProjectId
	WHERE t.Id = @Id
	AND p.UserId = @UserId;
RETURN 0
