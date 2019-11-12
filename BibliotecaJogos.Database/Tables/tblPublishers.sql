CREATE TABLE [dbo].[tblPublishers]
(
	[id_publisher] INT NOT NULL PRIMARY KEY identity,
	[name_publisher] varchar(50) not null,
	constraint [UK_tblPublishers_name_publisher] unique ([name_publisher])
)
