CREATE DATABASE CompanyMM;
USE CompanyMM;

CREATE TABLE Employees(
EmployeeID int primary key identity,
FirstName varchar(30) not null,
LastName varchar(30) not null,
BirthDate date check(BirthDate<=GETDATE()),
Email varchar(50) unique
)

CREATE TABLE Projects(
ProjectID int primary key identity,
ProjectName varchar(50),
StartDate date,
EndDate date
)

CREATE TABLE EmployeeProjects(
EmployeeId int foreign key references Employees(EmployeeID),
ProjectId int foreign key  references Projects(ProjectID),
AssignedDate date,
PRIMARY KEY (EmployeeID, ProjectID),
)

insert into Employees (FirstName, LastName, BirthDate, Email) 
values
('Aysel',  'Mammadova', '1995-03-14', 'aysel@company.az'),
('Kamran', 'Huseynov',  '1988-07-22', 'kamran@company.az'),
('Nigar',  'Aliyeva',   '1997-11-05', 'nigar@company.az'),
('Tural',  'Hasanov',   '1990-01-30', 'tural@company.az'),
('Leyla',  'Rzayeva',   '1993-06-18', 'leyla@company.az')

insert into Projects (ProjectName, StartDate, EndDate) 
values
('ERP Sistemi',     '2024-01-10', '2024-12-31'),
('Mobil Tetbiq',    '2024-03-01', '2024-09-30'),
('Kibertehlukesizlik', '2024-05-15', '2025-05-14')

insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate) 
values
(1, 1, '2024-01-10'),
(1, 2, '2024-03-05'),
(1, 3, '2024-05-20'),
(2, 1, '2024-01-15'),
(2, 2, '2024-03-10'),
(3, 2, '2024-03-10'),
(3, 3, '2024-06-01'),
(4, 1, '2024-02-01'),
(5, 3, '2024-05-15'),
(5, 2, '2024-04-01')


SELECT * FROM Employees

SELECT * FROM Projects

SELECT e.EmployeeID, e.FirstName, e.LastName, p.ProjectName, ep.AssignedDate from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID

SELECT p.ProjectName, COUNT(ep.EmployeeID) as EmployeeCount from Projects p
join EmployeeProjects ep on p.ProjectID = ep.ProjectID
group by p.ProjectName

SELECT e.EmployeeID, e.FirstName, e.LastName, COUNT(ep.ProjectID) as ProjectCount from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
group by  e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2


CREATE VIEW EmployeeProjectView AS
SELECT e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) as FullName, p.ProjectID, p.ProjectName, ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID

SELECT * from EmployeeProjectView
where EmployeeID = 2


CREATE procedure sp_AssignEmployeeToProject @empId  int, @projId int
as
begin
    if not exists (
        select 1 from EmployeeProjects
        where EmployeeID = @empId and ProjectID = @projId
    )
    begin
        insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
        values (@empId, @projId, GETDATE())
    end
end


EXEC sp_AssignEmployeeToProject 1, 3

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 1




create function fn_GetProjectCount(@empId int)
returns int
as
begin
    declare @count int
    select @count = COUNT(*) from EmployeeProjects
    where EmployeeID = @empId
    return @count
end

SELECT e.EmployeeID, e.FirstName, e.LastName, dbo.fn_GetProjectCount(e.EmployeeID) AS ProjectCount
from Employees e



EXEC sp_AssignEmployeeToProject 5, 1

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 5

DELETE FROM EmployeeProjects
WHERE EmployeeID = 4

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 4
