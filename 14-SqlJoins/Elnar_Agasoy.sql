create database Company1
use Company1

create table Employees(
Id int primary key identity,
[Name] varchar(30), 
Surname varchar(30),
Age int , 
Salary decimal(18, 2), 
Position varchar(30), 
IsDeleted bit,
CityId int foreign key references Cities(Id)
)

create table Cities(
Id int PRIMARY key identity,
[Name] nvarchar (40),
CountryId int foreign key references Countries(Id)
)

create table Countries(
Id int PRIMARY  key identity,
Name nvarchar(30)
)

insert into Countries(Name) 
values
('Azerbaycan'),
('Turkiye'),
('Amerika')

insert into Cities(CountryId,[Name])
values
(1,'Baku'),
(2,'Istanbul'),
(3,'New-York')

INSERT INTO Employees ([Name], Surname, Age, Salary, Position, IsDeleted, CityId) 
VALUES
('Ali', 'Aliyev', 25, 2500, 'Developer', 0, 1),
('Samir', 'VEliyev', 25, 1500, 'Reseption', 1, 2),
('Eziz', 'Sadiqov', 25, 2500, 'Sweeper', 0, 3)


select e.Name, e.Surname, c.Name as City, co.Name as Country
from Employees e
join Cities c on e.CityId = c.Id
join Countries co on c.CountryId = co.Id


select e.name, co.Name as Country from Employees e
join Cities c on e.CityId = c.Id 
join Countries co on c.CountryId = co.Id 
where e.Salary >2000

select c.Name as City, co.Name as Country from Cities c
join Countries co on c.CountryId =co.Id 

select  [Name],Surname,Age,Salary, Position,IsDeleted from Employees 
where position ='Reseption'

select 
e.Name, e.Surname,
c.Name as City,
co.Name as Country
from Employees e
join Cities c on e.CityId = c.Id
join Countries co on c.CountryId = co.Id
where e.IsDeleted = 1







