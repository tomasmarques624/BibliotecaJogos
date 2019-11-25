CREATE PROCEDURE [dbo].[sp_InsertUser]
	@username varchar(50),
	@password char(64),
	@email varchar(64),
	@role char(1)
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblUsers WHERE username = @username
	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		insert into tblUsers values (@username,@password,@email,@role)
		SELECT 1 AS ReturnCode
	END
END