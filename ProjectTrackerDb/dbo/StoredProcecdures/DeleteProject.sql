CREATE PROCEDURE [dbo].[DeleteProject]
	@Id int
AS
	DELETE Projects
	WHERE Id = @Id;
RETURN 0
