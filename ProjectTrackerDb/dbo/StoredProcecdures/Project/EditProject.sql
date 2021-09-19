CREATE PROCEDURE [dbo].[EditProject]
    @Id INT,
    @Name NVARCHAR(100), 
    @Status INT, 
    @Stage INT, 
    @Comments NVARCHAR(1000) = NULL,
	@UserId NVARCHAR (450)

AS
    UPDATE Projects
    SET [Name] = @Name, [StatusId] = @Status, [StageId] = @Stage, [Comments] = @Comments
	WHERE Id = @Id
	AND UserId = @UserId;
RETURN 0
