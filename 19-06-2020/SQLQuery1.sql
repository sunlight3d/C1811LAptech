CREATE DATABASE C1811L;
USE C1811L;
CREATE TABLE tblEmployees(
id INT IDENTITY PRIMARY KEY,
EmployeeName VARCHAR(500) NOT NULL,
Department VARCHAR(500) NOT NULL,
Gender VARCHAR(100),
Telephone VARCHAR(250)
);
INSERT INTO tblEmployees(EmployeeName,Department,Gender,Telephone)
VALUES('Hoang', 'IT', 'male', '011223344');
INSERT INTO tblEmployees(EmployeeName,Department,Gender,Telephone)
VALUES('Huy', 'Sales', 'female', '055446688');
SELECT * FROM tblEmployees;