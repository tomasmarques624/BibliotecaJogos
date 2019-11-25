CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@email varchar(256)
AS
BEGIN
	--DECLARE @count int

	--SELECT @count = COUNT(*) FROM tblUsers WHERE email = @email

	--IF(@count=0)
	--BEGIN
	--	SELECT -1 AS ReturnCode
	--END
	--ELSE
	--BEGIN
	--	SELECT 1 AS ReturnCode
		select * from tblUsers where email = @email
	--END
END
