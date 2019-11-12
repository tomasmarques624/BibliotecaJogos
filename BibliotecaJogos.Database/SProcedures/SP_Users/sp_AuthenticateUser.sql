CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
	@username varchar(50),
	@password char(64)
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblUsers WHERE username = @username and password = @password

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		SELECT 1 AS ReturnCode
		select * from tblUsers WHERE username = @username and password = @password
	END
END