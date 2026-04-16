create database Person
use Person

create table persons(
id int primary key,
Name varchar(20),
Surname varchar(38) default 'bosdu',
Age int 
)
DROP table  persons
select * from persons

insert into persons(id, Name,Surname,Age)
values
(1,'men','sen',3)

update persons set Age=29 where id=1