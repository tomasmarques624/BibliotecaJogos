CREATE PROCEDURE [dbo].[sp_GetGameByID]
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
		SELECT 1 AS ReturnCode
		select * from tblGames where id_game = @id_game
	END
END
