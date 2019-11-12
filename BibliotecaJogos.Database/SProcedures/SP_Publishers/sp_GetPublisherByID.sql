CREATE PROCEDURE [dbo].[sp_GetPublisherByID]
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
		SELECT 1 AS ReturnCode
		select * from tblPublishers where id_publisher = @id_publisher
	END
END