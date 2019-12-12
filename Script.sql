create database Ecommerce
go

use Ecommerce
go

create table Categories
(
	[Id]				int						primary key		identity,
	[Name]				varchar(100)			not null
)

insert into Categories values ('Eletrônicos')
insert into Categories values ('Bebidas')
insert into Categories values ('Alimentos')

create table Products
(
	Id					int					primary key		identity,
	[Name]				varchar(200)		not null,
	[Description]		varchar(max)		not null,
	Price				decimal(9,2)		not null,
	CategoryId			int	references Categories (Id)
)

insert into Products values ('Notebook Dell', 'Intel i5 8GB 2TB', 2850.00, 1)
insert into Products values ('Doritos', 'Sweet Chili 500g', 10.99, 3)
insert into Products values ('Vinho Tinto', 'Argentino 750ml', 75.99, 2)
insert into Products values ('Smart TV LG', 'Full HD 50', 3140.00, 1)


create view view_products
AS
select p.Id, p.[Name], [Description], [Price], p.CategoryId, c.[Name] as Category
	from Products p, Categories c
	where p.CategoryId = c.Id

select * from view_products

select * from Products
