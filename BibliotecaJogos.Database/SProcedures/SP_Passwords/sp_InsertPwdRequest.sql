CREATE PROCEDURE [dbo].[sp_InsertPwdRequest]
	@email varchar(256)
AS
begin
	declare @guid uniqueidentifier
	set @guid = newid()

	SELECT * FROM tblUsers WHERE email = @email
	if(@@ROWCOUNT<>0)
	begin
		select -1 as returncode
	end
	else
	begin
		declare @count int
		SELECT @count = COUNT(*) FROM tblResetPwdRequests WHERE email = @email
		if(@count<>0)
		begin
			select 1 as returncode
			update tblResetPwdRequests set guid=@guid,date_recovery_request=GETDATE() where email = @email
		end
		else
		begin
			select 1 as returncode
			insert into tblResetPwdRequests values (@guid,@email,GETDATE())
		end
	end
end