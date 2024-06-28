create database TestEntity
go

use TestEntity
go

create table Lop
(
	ID int identity primary key,
	Name nvarchar(100) default N'Kteam class'
)
go

create table SinhVien
(
	ID int identity primary key,
	Name nvarchar(100) default N'Kter name',
	IDLop int not null
	foreign key (IDLop) references dbo.Lop(ID)
)
go

insert into dbo.Lop (Name)
values (N'Kteam class 1')

insert into dbo.Lop (Name)
values (N'Kteam class 2')

insert into dbo.Lop (Name)
values (N'Kteam class 3')

insert into dbo.Lop (Name)
values (N'Kteam class 4')

insert into dbo.Lop (Name)
values (N'Kteam class 5')


insert dbo.SinhVien (Name, IDLop)
values (N'Kter 1',1)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 2',1)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 3',1)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 4',1)

insert dbo.SinhVien (Name, IDLop)
values (N'Kter 1',2)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 2',2)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 3',2)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 4',2)

insert dbo.SinhVien (Name, IDLop)
values (N'Kter 1',3)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 2',3)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 3',3)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 4',3)

insert dbo.SinhVien (Name, IDLop)
values (N'Kter 1',4)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 2',4)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 3',4)
insert dbo.SinhVien (Name, IDLop)
values (N'Kter 4',4)
