USE [TelerikAcademy] 

/* Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement. */
SELECT [FirstName] + ' ' + [LastName] AS [Employee], [Salary]
FROM [Employees]
WHERE [Salary] = (SELECT MIN([Salary]) FROM [Employees])
GO 

/* Write a SQL query to find the names and salaries of the employees 
	that have a salary that is up to 10% higher than the minimal salary for the company */
SELECT [FirstName] + ' ' + [LastName] AS [Employee], [Salary]
FROM [Employees]
WHERE [Salary] > (SELECT MIN([Salary]) FROM [Employees]) 
	AND [Salary] <= (SELECT MIN([Salary])*1.1 FROM [Employees])
GO

/* Write a SQL query to find the full name, salary and department of the employees 
	that take the minimal salary in their department. Use a nested SELECT statement. */
SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Employee Name], 
		[e].[Salary], 
		[d].[Name]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [Salary] = (SELECT MIN([Salary]) FROM [Employees] WHERE DepartmentID = [e].[DepartmentID])
GO

/* Write a SQL query to find the average salary in the department #1 */	
SELECT AVG([Salary]) AS [Average Salary]
FROM [Employees]
WHERE [DepartmentID] = 1
GO

/* Write a SQL query to find the average salary in the "Sales" department. */
SELECT AVG([e].[Salary]) AS [Average Salary in Sales]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
GO

/* Write a SQL query to find the number of employees in the "Sales" department */
SELECT COUNT(*) AS [Employees Count in Sales]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
GO

/* Write a SQL query to find the number of all employees that have manager */
SELECT COUNT(*) AS [Employees with Manager]
FROM [Employees]
WHERE [ManagerID] > 0
GO

/* Write a SQL query to find the number of all employees that have no manager */
SELECT COUNT(*) AS [Managers' Count]
FROM [Employees]
WHERE [ManagerID] IS NULL
GO

/* Write a SQL query to find all departments and the average salary for each of them */
SELECT [d].[Name], AVG([e].[Salary]) AS [Average Department Salary]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
GROUP BY [d].[Name]
GO

/* Write a SQL query to find the count of all employees in each department and for each town */
SELECT [t].[Name] AS [Town], [d].[Name] AS [Department], COUNT(*) AS [Employees' Count]
FROM [Employees] [e]
JOIN [Addresses] [a]
ON [a].[AddressID] = [e].[AddressID]
JOIN [Towns] [t]
ON [a].[TownID] = [t].[TownID]
JOIN [Departments] [d]
ON [d].[DepartmentID] = [e].[DepartmentID]
GROUP BY [d].[Name], [t].[Name]
GO
		
/* Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name */
SELECT [e].[FirstName], [e].[LastName] FROM [Employees] [e], [Employees] [m]
WHERE [e].[ManagerID] = [m].[EmployeeID] OR [m].[ManagerID] IS NULL
GROUP BY [e].[EmployeeID], [e].[FirstName], [e].[LastName]
HAVING COUNT(*) = 5
GO

/* Write a SQL query to find all employees along with their managers. 
	For employees that do not have manager display the value "(no manager)" */
SELECT [e].[FirstName] + ' ' + [e].[LastName] AS [Employees], 
		ISNULL([m].[FirstName] + ' ' + [m].[LastName], ('(no manager)')) AS [Managers]
FROM [Employees] [e]
LEFT OUTER JOIN [Employees] [m]
ON [e].[ManagerID] = [m].[EmployeeID]
GO

/* Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
	Use the built-in LEN(str) function */
SELECT [LastName] AS [LastName (5chars)] FROM [Employees]
WHERE LEN([LastName]) = 5
GO

/* Write a SQL query to display the current date and time in the following format 
	"day.month.year hour:minutes:seconds:milliseconds".
	Search in Google to find how to format dates in SQL Server */
SELECT CONVERT(VARCHAR(50), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(30), GETDATE(), 114) 
AS [Current DateTime]
GO

/* Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
	Define the primary key column as identity to facilitate inserting records.
	Define unique constraint to avoid repeating usernames.
	Define a check constraint to ensure the password is at least 5 characters long. */
CREATE TABLE [Users] (
	[ID] INT IDENTITY,
	[Username] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[LastLogin] DATETIME,
	CONSTRAINT [PK_User] PRIMARY KEY ([ID]),
	CONSTRAINT [UK_Username] UNIQUE([Username]),
	CONSTRAINT [Password_Check] CHECK (LEN([Password]) >= 5)
)
GO

/* Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
	Test if the view works correctly. */

	/* Testing with VIEW */
SET IDENTITY_INSERT [Users] ON

INSERT INTO [Users] ([ID], [Username], [Password], [FirstName], [LastName], [LastLogin])
VALUES ('1', 'peeepppss', 'parolchica', 'Imence', 'Familchica', '2016-10-22 01:33:54.840')
GO

CREATE VIEW [Today's Users] AS
SELECT [Username], [LastLogin]
FROM [Users]
WHERE CONVERT(VARCHAR(50), [LastLogin], 20) LIKE '2016-10-22%'
GO

	/* Testing with query */
INSERT INTO [Users] ([ID], [Username], [Password], [FirstName], [LastName], [LastLogin])
VALUES ('2', 'randomusnm', 'random', 'RandomName', 'RandomFam', '2016-10-22 02:43:14.002')
GO

SELECT [Username], [LastLogin]
FROM [Users]
WHERE CONVERT(VARCHAR(50), [LastLogin], 20) LIKE '2016-10-22%'
GO

/* Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
	Define primary key and identity column. */
CREATE TABLE [Groups] (
	[ID] INT IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Groups] PRIMARY KEY ([ID]),
	CONSTRAINT [UK_GroupName] UNIQUE ([Name])
)

SET IDENTITY_INSERT [Users] OFF
SET IDENTITY_INSERT [Groups] ON

/* Write a SQL statement to add a column GroupID to the table Users.
	Fill some data in this new column and as well in the `Groups table.
	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. */
ALTER TABLE [Users]
ADD [GroupID] INT
GO

ALTER TABLE [Users]
ADD CONSTRAINT [FK_Users_Groups] 
FOREIGN KEY ([GroupID]) REFERENCES [Groups] ([ID])
GO

INSERT INTO [Groups] ([ID], [Name])
VALUES ('1', 'Group I'),
		('2', 'Group II'),
		('3', 'Group III'),
		('4', 'Group IV'),
		('5', 'Group V'),
		('6', 'Group VI'),
		('7', 'Group VII')
GO

SET IDENTITY_INSERT [Groups] OFF
SET IDENTITY_INSERT [Users] ON
INSERT INTO [Users] ([ID], [Username], [Password], [LastLogin], [GroupID])
VALUES ('3', 'sampleuser', 'aPassword', GETDATE(), '2')
GO

/* Write SQL statements to insert several records in the Users and Groups tables */
INSERT INTO [Users] ([ID], [Username], [Password], [FirstName], [LastName], [LastLogin], [GroupID])
VALUES ('4', 'username11', 'pass11', 'Sample Name', 'Sample LastName', GETDATE(), '2'),
		('5', 'username21', 'pass91', 'Sample Name2', 'Sample2 LastName', GETDATE(), '1'),
		('6', 'username31', 'pass81', 'Sample Name3', 'Sample3 LastName', GETDATE(), '7'),
		('7', 'username41', 'pass71', 'Sample Name4', 'Sample4 LastName', GETDATE(), '5')
GO

SET IDENTITY_INSERT [Users] OFF
SET IDENTITY_INSERT [Groups] ON
INSERT INTO [Groups] ([ID], [Name])
VALUES ('8', 'Group VIII'),
		('9', 'Group IX'),
		('10', 'Group X')
GO

/* Write SQL statements to update some of the records in the Users and Groups tables. */
UPDATE [Users]
SET [Username] = 'TheCoolest'
WHERE [Username] = 'username21'
GO

UPDATE [Groups]
SET [Name] = 'JS WE LOVE YA'
WHERE [ID] = 1
GO

/* Write SQL statements to delete some of the records from the `Users` and `Groups` tables */
DELETE FROM [Groups]
WHERE [Name] = 'Group III'
GO

DELETE FROM [Users]
WHERE CONVERT(NVARCHAR(50), [LastLogin], 20) LIKE '%33%'
GO

/* Write SQL statements to insert in the Users table the names of all employees from the Employees table.
	Combine the first and last names as a full name.
	For username use the first letter of the first name + the last name (in lowercase).
	Use the same for the password, and NULL for last login time */
ALTER TABLE [Users]
ADD [FullName] NVARCHAR(100)
GO

/* I'm taking the first 3 characters from FirstName, because there were some problems with the UK and PK CONSTRAINTS 
	in Users-table if we use only the first character. */
INSERT INTO [Users] ([Username], [Password], [FullName], [LastLogin])
SELECT LEFT([FirstName], 3) + LOWER([LastName]), 
	LEFT([FirstName], 3) + LOWER([LastName]), 
	[FirstName] + ' ' + [LastName],
	NULL
FROM [Employees]
GO

/* Write a SQL statement that changes the password to NULL for all users 
	that have not been in the system since 10.03.2010. */

/* I don't really have a user like this, but if I did - it would throw an error, because password cant be 4 chars long */
UPDATE [Users]
SET [Password] = 'NULL'
WHERE [LastLogin] < CONVERT(DATETIME, '2016-03-10')
GO

/* Write a SQL statement that deletes all users without passwords (NULL password). */
DELETE FROM [Users]
WHERE [Password] = 'NULL'
GO

/* Write a SQL query to display the average employee salary by department and job title */
SELECT AVG([e].[Salary]) AS [AVG Salary], 
			[d].[Name] AS [Department], 
			[e].[JobTitle]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
GROUP BY [d].[Name], [e].[JobTitle]
GO

/* Write a SQL query to display the minimal employee salary by department and job title 
	along with the name of some of the employees that take it. */
SELECT MIN([e].[Salary]) AS [MIN Salary], 
			[d].[Name] AS [Department], 
			[e].[JobTitle],
			[e].[FirstName] + ' ' + [e].[LastName] AS [Employee]
FROM [Employees] [e]
JOIN [Departments] [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
GROUP BY [d].[Name], [e].[JobTitle], [e].[FirstName] + ' ' + [e].[LastName]
GO

/* Write a SQL query to display the town where maximal number of employees work */
SELECT TOP 1 [t].[Name] AS [Town], COUNT(*) AS [Employees' count]
FROM [Towns] [t], [Employees] [e], [Addresses] [a]
WHERE [e].[AddressID] = [a].[AddressID] AND [a].[TownID] = [t].[TownID]
GROUP BY [t].[Name]
ORDER BY COUNT(*) DESC
GO

/* Write a SQL query to display the number of managers from each town */
SELECT [t].[Name] AS [Town], COUNT(DISTINCT [e].[ManagerID]) AS [Managers' count]
FROM [Towns] [t], [Employees] [e], [Employees] [m], [Addresses] [a]
WHERE [e].[ManagerID] = [m].[EmployeeID]
	AND [m].[AddressID] = [a].[AddressID]
	AND [t].[TownID] = [a].[TownID]
GROUP BY [t].[Name]
GO

/* Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
	Don't forget to define identity, primary key and appropriate foreign key.
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
	For each change keep the old record data, the new record data and the command (insert / update / delete) */
CREATE TABLE [WorkHours] (
	[EmployeeID] INT IDENTITY,
	[Date] DATETIME,
	[Task] NVARCHAR(100),
	[Hours] INT NOT NULL,
	[Comments] NVARCHAR(100),
	CONSTRAINT [PK_WorkHours] PRIMARY KEY ([EmployeeID]),
	CONSTRAINT [FK_WorkHours_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID])
)
GO

INSERT INTO [WorkHours] ([Date], [Hours])
VALUES (GETDATE(), '16'),
		(GETDATE(), '33'),
		(GETDATE(), '1')
GO

UPDATE [WorkHours]
SET [Date] = GETDATE()
WHERE [EmployeeID] = 2
GO

UPDATE [WorkHours]
SET [Comments] = (SELECT CAST([Hours] AS NVARCHAR(100))) + ' hours worked.'
GO

DELETE FROM [WorkHours]
WHERE [Hours] < 10
GO

CREATE TABLE [WorkHoursLogs] (
	[LogID] INT IDENTITY,
	[OldRecord] NVARCHAR(500),
	[NewRecord] NVARCHAR(500),
	[Command] NVARCHAR(20),
	[EmployeeID] INT NOT NULL,
	CONSTRAINT [PK_WorkHoursLogs] PRIMARY KEY ([LogID]),
	CONSTRAINT [FK_WorkHoursLogs_WorkHours] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID])
)
GO

CREATE TRIGGER [trigger_WorkHoursInsert]
ON [WorkHours]
FOR INSERT
AS
INSERT INTO [WorkHoursLogs] ([OldRecord], [NewRecord], [Command], [EmployeeID]) 
VALUES ('', 
		(SELECT CAST([Date] AS NVARCHAR(30)) + '; Hours worked:' + CAST([Hours] AS NVARCHAR(10)) FROM [inserted]),
		'INSERT',
		(SELECT [EmployeeID] FROM [inserted])
)
GO

SET IDENTITY_INSERT [Groups] OFF
SET IDENTITY_INSERT [WorkHours] ON

INSERT INTO [WorkHours] ([EmployeeID], [Date], [Task], [Hours], [Comments])
VALUES(3, GETDATE(), 'DO STUFF!', 8, 'Do stuff I tell you!')
GO

CREATE TRIGGER [trigger_WorkHoursUpdate]
ON [WorkHours]
FOR UPDATE
AS
INSERT INTO [WorkHoursLogs] ([OldRecord], [NewRecord], [Command], [EmployeeID])
VALUES ((SELECT CAST([Date] AS NVARCHAR(30)) + '; Hours worked:' + CAST([Hours] AS NVARCHAR(10)) FROM [deleted]),
		(SELECT CAST([Date] AS NVARCHAR(30)) + '; Hours worked:' + CAST([Hours] AS NVARCHAR(10)) FROM [inserted]),
		'UPDATE',
		(SELECT [EmployeeID] FROM [inserted])
)
GO

CREATE TRIGGER [trigger_WorkHoursDelete]
ON [WorkHours]
FOR DELETE
AS
INSERT INTO [WorkHoursLogs] ([OldRecord], [NewRecord], [Command], [EmployeeID])
VALUES ((SELECT CAST([Date] AS NVARCHAR(30)) + '; Hours worked:' + CAST([Hours] AS NVARCHAR(10)) FROM [deleted]),
		'',
		'DELETE',
		(SELECT [EmployeeID] FROM [deleted])
)
GO

DELETE FROM [WorkHours]
WHERE [Comments] LIKE '33%'
GO

UPDATE [WorkHours]
SET [Date] = GETDATE(),
	[Task] = 'Here''s a task'
WHERE [Task] IS NULL
GO

/* Start a database transaction, delete all employees from the 'Sales' department 
	along with all dependent records from the pother tables. At the end rollback the transaction. */
BEGIN TRAN

ALTER TABLE [WorkHours]
DROP CONSTRAINT [FK_WorkHours_Employees]

ALTER TABLE [WorkHoursLogs]
DROP CONSTRAINT [FK_WorkHoursLogs_WorkHours]

ALTER TABLE [Departments]
DROP CONSTRAINT [FK_Departments_Employees]

DELETE FROM [Employees]
SELECT [d].[Name] AS [Deleted] FROM [Departments] [d]
JOIN [Employees] [e]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
GROUP BY [d].[Name]

ROLLBACK TRAN
GO

/* Start a database transaction and drop the table EmployeesProjects.
	Now how you could restore back the lost table data? */
BEGIN TRAN
DROP TABLE [EmployeesProjects]
ROLLBACK TRAN
GO

/* Find how to use temporary tables in SQL Server.
	Using temporary tables backup all records from EmployeesProjects and restore them back 
	after dropping and re-creating the table. */
CREATE TABLE #BackupRecords (
	[EmployeeID] INT,
	[ProjectID] INT
)
GO

INSERT INTO #BackupRecords
SELECT [EmployeeID], [ProjectID]
FROM [EmployeesProjects]
GO

DROP TABLE [EmployeesProjects]
GO

CREATE TABLE [EmployeesProjects] (
	[EmployeeID] INT,
	[ProjectID] INT,
	CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY ([EmployeeID], [ProjectID])
)
GO

INSERT INTO [EmployeesProjects]
SELECT [EmployeeID], [ProjectID]
FROM #BackupRecords
GO

