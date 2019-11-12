CREATE PROCEDURE [dbo].[sp_GetGenreByID]
	@id_genre int
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblGenres WHERE id_genre = @id_genre

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		SELECT 1 AS ReturnCode
		select * from tblGenres where id_genre = @id_genre
	END
END
