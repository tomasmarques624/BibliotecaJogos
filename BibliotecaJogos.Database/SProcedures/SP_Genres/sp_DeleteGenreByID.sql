CREATE PROCEDURE [dbo].[sp_DeleteGenreByID]
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
	declare @count1 int
	select @count1 = COUNT(*) from tblGames where id_genre = @id_genre
	if(@count1=0)
	begin
		delete from tblGenres where id_genre = @id_genre
		SELECT 1 AS ReturnCode
	end
	else
	begin
		select 2 as ReturnCode
	end
	END
END