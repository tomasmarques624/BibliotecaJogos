CREATE PROCEDURE [dbo].[sp_DeleteGameByID]
	@id_game int
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblGames WHERE id_game = @id_game

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		delete from tblGames where id_game = @id_game
		SELECT 1 AS ReturnCode
	END
END
