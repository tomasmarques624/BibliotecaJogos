CREATE PROCEDURE [dbo].[sp_UpdateGenreByID]
	@id_genre int,
	@description_genre varchar(50)
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
		update tblGenres set description_genre = @description_genre where id_genre = @id_genre
		SELECT 1 AS ReturnCode
	END
END