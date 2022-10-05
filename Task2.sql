-- �������� ������� ���������
create table Product(
	[Id] int not null identity(1,1) primary key,
	[Name] varchar(max) not null
)

-- �������� ������� ���������
create table Category(
	[Id] int not null identity(1,1) primary key,
	[Name] varchar(max) not null
)

-- �������� ������������� ������� ��� ���������� ����� ������ �� ������
create table ProductCategory(
	[Product_Id] int not null foreign key references Product(Id),
	[Category_Id] int not null foreign key references Category(Id)
)

-- ���������� ������ � �������
insert into Product (Name) values ('������� 1'), ('������� 2'), ('������� 3')
insert into Category(Name) values ('��������� 1'), ('��������� 2'), ('��������� 3')
insert into ProductCategory(Product_Id, Category_Id) values (1,1), (1,2), (2,2), (2,1), (1,3)

-- ������ ��� ������ ���� ��� ���� �������� � ��� ���������
select Product.Name, Category.Name from Product
left join ProductCategory on Product_Id = Product.Id
left join Category on Category_Id = Category.Id
order by Product.Name