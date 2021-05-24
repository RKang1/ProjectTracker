CREATE PROCEDURE [dbo].[DeleteTask]
	@Id int
AS
	DELETE Tasks
	WHERE Id = @Id;
RETURN 0
