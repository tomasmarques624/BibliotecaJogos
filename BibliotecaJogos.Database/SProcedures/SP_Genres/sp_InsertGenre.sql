CREATE PROCEDURE [dbo].[sp_InsertGenre]
	@description_genre varchar(50)
AS
begin
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblGenres WHERE description_genre = @description_genre

	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
	insert into tblGenres values (@description_genre)
	SELECT 1 AS ReturnCode
	END
end
