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