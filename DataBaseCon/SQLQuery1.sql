use [ProductDB1]

create table Category
(
	Id int identity primary key,
	Name nvarchar(250),
	DisplayIndex int 
)

create table Product
(
	Id int identity primary key,
	Name nvarchar(250),
	Price float,
	CatId int foreign key references Category(Id)
)

insert into Category values ('Food', 1)
insert into Category values ('Drink', 2)
insert into Category values ('Cake', 3)

insert into Product values ('Bunbo', 20000, 1)
insert into Product values ('Comtam', 30000, 1)
insert into Product values ('Coke', 10000, 2)
insert into Product values ('Water', 5000, 2)
insert into Product values ('Chocolatecake', 20000, 3)







