CREATE PROCEDURE [dbo].[sp_GetPwdRequestDataByGUID]
	@guid uniqueidentifier
AS
begin
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblResetPwdRequests WHERE guid = @guid

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		select * from tblResetPwdRequests where guid = @guid
		SELECT 1 AS ReturnCode
	END
END
