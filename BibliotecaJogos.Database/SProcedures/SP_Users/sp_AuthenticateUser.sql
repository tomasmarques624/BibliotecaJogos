CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
	@username varchar(50),
	@password char(64)
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(*) FROM tblUsers WHERE username = @username

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		declare @isloocked bit
		declare @nr_attempts int
		declare @locked_date_time datetime
		DECLARE @count1 int

		--verificar se o user tem o acesso bloqueado
		 --caso tenham passado 24 horas, desbloquear o acesso


		--caso não tenha o acesso bloqueado
		 --ver se as credenciais estão corretas
		  -- se as credenciais estiverem erradas
		   -- se o nº de tentativas falhadas > 3, bloquear o acesso
		   -- senão, incrementar o nº de tentativas falhadas

		--no final, efetuar o select: SELECT * FROM tblUsers WHERE username = @username
		
		select @locked_date_time = locked_date_time from tblUsers WHERE username = @username
		Select @isloocked = is_looked FROM tblUsers WHERE username = @username
		select @nr_attempts = nr_attempts from tblUsers WHERE username = @username

		if(@isloocked = 1)
			begin
				declare @a int
				select @a = DATEDIFF(HOUR,@locked_date_time,GETDATE())
				if(@a>24)
				begin
					update tblUsers set is_looked = 0,locked_date_time = null, nr_attempts = 0 where username = @username
					SELECT @count1 = COUNT(*) FROM tblUsers WHERE username = @username and password = @password
					if(@count1 = 0)
						begin
							update tblUsers set nr_attempts = @nr_attempts + 1 where username = @username
							select -1 as ReturnCode
							SELECT * FROM tblUsers WHERE username = @username
						end
					else
						begin
							select 1 as ReturnCode
							SELECT * FROM tblUsers WHERE username = @username
							update tblUsers set is_looked = 0,locked_date_time = null, nr_attempts = 0 where username = @username
						end
				end
				else
				begin
					select -1 as ReturnCode
					SELECT * FROM tblUsers WHERE username = @username
				end
			End
		else
			begin
				SELECT @count1 = COUNT(*) FROM tblUsers WHERE username = @username and password = @password
				if(@count1 = 0)
					begin
						if(@nr_attempts >= 3)
							begin
								update tblUsers set is_looked = 1, locked_date_time = GETDATE() where username = @username
								select -1 as ReturnCode
								SELECT * FROM tblUsers WHERE username = @username
							end
						else
							begin
								update tblUsers set nr_attempts = @nr_attempts + 1 where username = @username
								select -1 as ReturnCode
								SELECT * FROM tblUsers WHERE username = @username
							end	
					end
				else
					begin
						select 1 as ReturnCode
						SELECT * FROM tblUsers WHERE username = @username
						update tblUsers set is_looked = 0,locked_date_time = null, nr_attempts = 0 where username = @username
					end
			end
	END
END