CREATE TABLE [dbo].[tblGames]
(
	[id_game] INT NOT NULL PRIMARY KEY identity,
	[title] varchar(50) not null,
	[cover_image] varchar(256) not null,
	[amount_paid] money null,
	[purchase_date] date null,
	[id_publisher] int not null,
	[id_genre] int not null,
	constraint [UK_tblGames_title] unique ([title]),
	constraint [UK_tblGames_cover_image] unique ([cover_image]),
	constraint [FK_tblGames_tblPublishers] foreign key ([id_publisher]) references [tblPublishers]([id_publisher]),
	constraint [FK_tblGames_tblGenres] foreign key ([id_genre]) references [tblGenres]([id_genre])
)
