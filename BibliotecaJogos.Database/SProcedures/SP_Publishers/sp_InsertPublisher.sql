CREATE PROCEDURE [dbo].[sp_InsertPublisher]
	@name_publisher varchar(50)
AS
begin
DECLARE @count int

	SELECT @count = COUNT(*) FROM tblPublishers WHERE name_publisher = @name_publisher
	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
	insert into tblPublishers values (@name_publisher)
	SELECT 1 AS ReturnCode
	END
end