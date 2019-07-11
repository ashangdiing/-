
执行
create table SMS(
	id int identity(1,1) primary key,
	number varchar(20),
	[message] varchar(100),
	[state] bit not null default(0),
	[datetime] datetime not null default(getdate()),
	isRead bit not null default(0)
)