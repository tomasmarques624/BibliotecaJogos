CREATE TABLE [dbo].[tblUsers]
(
	[id_user] INT NOT NULL PRIMARY KEY identity,
	[username] varchar(50) not null,
	[password] char(64) not null,
	[role] char(1) not null,
	[is_looked] BIT NOT NULL, 
    [nr_attempts] INT NOT NULL, 
    [locked_date_time] DATETIME NOT NULL, 
    constraint [UK_tblUsers_username] unique ([username])
)
