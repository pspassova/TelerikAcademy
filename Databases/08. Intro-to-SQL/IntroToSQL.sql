USE [TelerikAcademy]

/****** Write a SQL query to find all information about all departments ******/
SELECT * FROM [Departments]
GO

/****** Write a SQL query to find all department names ******/
SELECT [Name] FROM [Departments]
GO

/****** Write a SQL query to find the salary of each employee ******/
SELECT [Salary] FROM [Employees]
GO

/****** Write a SQL to find the full name of each employee ******/
SELECT [FirstName] + ' ' + [LastName] AS [FullName] 
FROM [Employees]
GO

/****** Write a SQL query to find the email addresses of each employee (by his first and last name). 
	Consider that the mail domain is telerik.com. 
	Emails should look like “John.Doe@telerik.com". 
	The produced column should be named "Full Email Addresses". ******/
SELECT [FirstName] + '.' + [LastName] + '@telerik.com' AS [Full Email Addresses]
FROM [Employees]
GO

/****** Write a SQL query to find all different employee salaries ******/
SELECT DISTINCT [Salary] FROM [Employees]
GO

/****** Write a SQL query to find all information about the employees whose job title is “Sales Representative ******/
SELECT * FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'
GO

/****** Write a SQL query to find the names of all employees whose first name starts with "SA" ******/
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [FirstName] LIKE 'SA%'
GO

/****** Write a SQL query to find the names of all employees whose last name contains "ei" ******/
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [LastName] LIKE '%ei%'
GO

/****** Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000] ******/
SELECT [Salary] FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000
GO

/****** Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600 ******/

/****** I ADDED SALARY COLUMN FOR YOU TO BE SURE THAT THE RESULTS ARE CORRECT ******/
SELECT [FirstName], [LastName], [Salary] FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)
GO

/****** Write a SQL query to find all employees that do not have manager ******/
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [ManagerID] IS NULL
GO

/****** Write a SQL query to find all employees that have salary more than 50000. 
	Order them in decreasing order by salary ******/
SELECT [FirstName], [LastName], [Salary] FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC
GO

/****** Write a SQL query to find the top 5 best paid employees ******/
SELECT TOP 5 [FirstName], [LastName], [Salary] FROM [Employees]
ORDER BY [Salary] DESC
GO

/****** Write a SQL query to find all employees along with their address. Use inner join with ON clause ******/
SELECT [empl].[FirstName], [empl].[LastName], [addr].[AddressText]
FROM [Employees] [empl]
INNER JOIN [Addresses] [addr]
ON [empl].[AddressID] = [addr].[AddressID];
GO

/****** Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause) ******/
SELECT [empl].[FirstName], [empl].[LastName], [addr].[AddressText]
FROM [Employees] [empl], [Addresses] [addr]
WHERE [empl].[AddressID] = [addr].[AddressID]
GO 

/****** Write a SQL query to find all employees along with their manager ******/
SELECT [empl].[FirstName] + ' ' + [empl].[LastName] AS [Employee FullName], 
		[mng].[FirstName] + ' ' + [mng].[LastName] AS [Manager FullName]
FROM [Employees] [empl]
LEFT OUTER JOIN [Employees] [mng]
ON [empl].[ManagerID] = [mng].[EmployeeID]
GO

/****** Write a SQL query to find all employees, along with their manager and their address. 
	Join the 3 tables: Employees e, Employees m and Addresses a ******/
SELECT [empl].[FirstName] + ' ' + [empl].[LastName] AS [Employee], 
		[addr].[AddressText] AS [Address],
		[mng].[FirstName] + ' ' + [mng].[LastName] AS [Manager]		
FROM [Employees] [empl]
JOIN [Addresses] [addr]
ON [empl].[AddressID] = [addr].[AddressID]
JOIN [Employees] [mng]
ON [empl].[ManagerID] = [mng].[EmployeeID]
GO

/****** Write a SQL query to find all departments and all town names as a single list. Use UNION ******/
SELECT [Name] AS [Department and Town Names] FROM [Departments]
UNION
SELECT [Name] AS [Department and Town Names] FROM [Towns]
GO

/****** Write a SQL query to find all the employees and the manager for each of them 
	along with the employees that do not have manager. Use right outer join ******/
SELECT [empl].[FirstName] + ' ' + [empl].[LastName] AS [Employee],
		[mng].[FirstName] + ' ' + [mng].[LastName] AS [Manager]
FROM [Employees] [mng]
RIGHT OUTER JOIN [Employees] [empl]
ON [empl].[ManagerID] = [mng].[EmployeeID]
GO

/****** Rewrite the query to use left outer join ******/
SELECT [empl].[FirstName] + ' ' + [empl].[LastName] AS [Employee],
		[mng].[FirstName] + ' ' + [mng].[LastName] AS [Manager]
FROM [Employees] [empl]
LEFT OUTER JOIN [Employees] [mng]
ON [empl].[ManagerID] = [mng].[EmployeeID]
GO

/****** Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
	whose hire year is between 1995 and 2005 ******/
SELECT [empl].[FirstName] + ' ' + [empl].[LastName] AS [Employee],
		[empl].[HireDate],
		[dep].[Name] AS [Department]
FROM [Employees] [empl]
JOIN [Departments] [dep]
ON ([empl].[DepartmentID] = [dep].[DepartmentID]
	AND [empl].[HireDate] BETWEEN '1995-01-01' AND '2005-12-31'
	AND [dep].[Name] IN ('Sales', 'Finance'))
GO