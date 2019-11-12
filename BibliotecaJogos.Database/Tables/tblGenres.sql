CREATE TABLE [dbo].[tblGenres]
(
	[id_genre] INT NOT NULL PRIMARY KEY identity,
	[description_genre] varchar(50) not null,
	constraint [UK_tblGenres_description_genre] unique ([description_genre])
)
