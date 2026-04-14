CREATE DATABASE Company;
use Company;
CREATE TABLE Employees(
EmployeeId  int,
FirstName NVARCHAR(50),
LastName NVARCHAR(50),
Email varchar(100),
PhoneNumber varchar(20),
HireDate DATE,
JobTitle NVARCHAR(50),
Salary DECIMAL(10,2),
Department NVARCHAR(50)
)

INSERT INTO Employees (EmployeeId,FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department)
VALUES
(1,'Ali', 'Aliyev', 'ali@company.az', '0501111111', '2021-05-10', 'Developer', 2500, 'IT'),
(2,'Leyla', 'Hesenova', 'leyla@company.az', '0502222222', '2019-03-15', 'HR', 1800, 'HR'),
(3,'Murad', 'Mammadov', 'murad@company.az', '0503333333', '2022-07-01', 'Engineer', 3000, 'IT'),
(4,'Aysel', 'Quliyeva', 'aysel@company.az', '0504444444', '2018-11-20', 'Accountant', 2200, 'Finance'),
(5,'Rauf', 'Raufov', 'rauf@company.az', '0505555555', '2023-01-10', 'Support', 1400, 'IT');

SELECT * FROM Employees;

SELECT * FROM Employees WHERE Salary > 2000;
SELECT * FROM Employees WHERE Department='IT';
SELECT * FROM Employees ORDER BY Salary DESC;
SELECT FirstName, Salary FROM Employees;
SELECT * FROM Employees WHERE HireDate > '2020-01-01';
SELECT * FROM Employees WHERE Email LIKE '%company.az';
SELECT MAX(Salary) FROM Employees;
SELECT MIN(Salary) FROM Employees;
SELECT AVG(Salary) FROM Employees;
SELECT COUNT(*) FROM Employees;
SELECT SUM(Salary) FROM Employees;

SELECT Department, COUNT(*) FROM Employees GROUP BY Department;
SELECT Department, AVG(Salary) FROM Employees GROUP BY Department;
SELECT Department, MAX(Salary) FROM Employees GROUP BY Department;

UPDATE Employees SET Salary = 2800 WHERE EmployeeID = 1;
UPDATE Employees SET Salary = Salary * 1.10 WHERE Department = 'IT';
UPDATE Employees SET JobTitle = 'HR Meneceri' WHERE FirstName = 'Leyla' AND LastName = 'Hesenova';

DELETE FROM Employees WHERE EmployeeID = 5;
DELETE FROM Employees WHERE Salary < 1500;

SELECT * FROM Employees WHERE FirstName LIKE '%a%';
SELECT * FROM Employees WHERE Salary BETWEEN 2000 AND 2500;
SELECT * FROM Employees WHERE Department IN ('Finance', 'IT');


SELECT * FROM Employees;
