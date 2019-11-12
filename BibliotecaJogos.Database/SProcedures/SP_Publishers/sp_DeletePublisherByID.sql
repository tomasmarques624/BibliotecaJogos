CREATE PROCEDURE [dbo].[sp_DeletePublisherByID]
	@id_publisher int
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblPublishers WHERE id_publisher = @id_publisher

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
	declare @count1 int
	select @count1 = COUNT(*) from tblGames where id_publisher = @id_publisher
	if(@count1=0)
	begin
		delete from tblPublishers where id_publisher = @id_publisher
		SELECT 1 AS ReturnCode
	end
	else
	begin
		select 2 as ReturnCode
	end
	END
END