CREATE PROCEDURE [dbo].[sp_UpdatePublisherByID]
	@id_publisher int,
	@name_publisher varchar(50)
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
		update tblPublishers set name_publisher = @name_publisher where id_publisher = @id_publisher
		SELECT 1 AS ReturnCode
	END
END