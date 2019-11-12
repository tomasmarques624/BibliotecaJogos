﻿CREATE TABLE [dbo].[tblUsers]
(
	[id_user] INT NOT NULL PRIMARY KEY identity,
	[username] varchar(50) not null,
	[password] char(64) not null,
	[role] char(1) not null,
	constraint [UK_tblUsers_username] unique ([username])
)