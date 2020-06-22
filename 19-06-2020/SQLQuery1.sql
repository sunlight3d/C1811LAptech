CREATE DATABASE C1811L;
USE C1811L;
CREATE TABLE tblEmployees(
id INT IDENTITY PRIMARY KEY,
EmployeeName VARCHAR(500) NOT NULL,
Department VARCHAR(500) NOT NULL,
Gender VARCHAR(100),
Telephone VARCHAR(250)
);
alter TABLE tblEmployees
add DeptId INT;
INSERT INTO tblEmployees(EmployeeName,Department,Gender,Telephone)
VALUES('Hoang', 'IT', 'male', '011223344');
INSERT INTO tblEmployees(EmployeeName,Department,Gender,Telephone)
VALUES('Huy', 'Sales', 'female', '055446688');
SELECT * FROM tblEmployees;
CREATE TABLE tblDepartments(
DeptID INT IDENTITY PRIMARY KEY,
DeptName VARCHAR(500) NOT NULL,
);
INSERT INTO tblDepartments(DeptName)
VALUES('IT');
INSERT INTO tblDepartments(DeptName)
VALUES('Sales');
select * from tblDepartments;
select * from tblEmployees;
update tblEmployees set DeptId = 1 where id =3;
alter table tblEmployees drop column Department;