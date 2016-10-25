/* Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
		Insert few records for testing.
		Write a stored procedure that selects the full names of all persons. */

CREATE DATABASE BankStuff
GO

USE BankStuff

/* Where there are tests with PRINT, take a look at the Messages tab
		not the Results tab, only tables are displayed in the Results! */

CREATE TABLE Persons (
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20),
	LastName NVARCHAR(20),
	SSN VARCHAR(9)
)
GO

CREATE TABLE Accounts (
	AccountId INT PRIMARY KEY IDENTITY,
	PersonId INT FOREIGN KEY REFERENCES Persons (PersonId),
	Balance MONEY
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Kiril', 'Stanoev', 333999555),
		('Iva', 'Elenska', 111111111),
		('Petya', 'Slavcheva', 223564781),
		('Mihaela', 'Petrova', 009204673),
		('Yordan', 'Krystev', 998725361),
		('Denislav', 'Gurev', 002936471)
GO

INSERT INTO Accounts (PersonId, Balance)
VALUES (1, 3334),
		(2, 0.55),
		(3, 222),
		(4, 5555555),
		(5, 21.434),
		(6, 0.99999999)
GO

/* Create a stored procedure that accepts a number as a parameter and returns all persons 
		who have more money in their accounts than the supplied number. */

CREATE PROC usp_UsersHavingMoreMoneyThanSomeMoney 
@minMoney MONEY
AS
SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
FROM Persons p
JOIN Accounts a
ON p.PersonId = a.PersonId
WHERE a.Balance > @minMoney
GO

EXEC usp_UsersHavingMoreMoneyThanSomeMoney 1
GO
EXEC usp_UsersHavingMoreMoneyThanSomeMoney 1000
GO

/* Create a function that accepts as parameters – sum, yearly interest rate and number of months.
		It should calculate and return the new sum.
		Write a SELECT to test whether the function works as expected. */

CREATE FUNCTION ufn_SumBySumAndInterestAndMonths 
	(@sum MONEY, @yearlyInterest DECIMAL, @numberOfMonths INT) RETURNS MONEY
AS
BEGIN
RETURN (@sum + @sum * @yearlyInterest/100 * @numberOfMonths/12)
END
GO

DECLARE @testSum MONEY = 504.71,
		@testInterest DECIMAL = 0.66,
		@testMonths INT = 4
PRINT dbo.ufn_SumBySumAndInterestAndMonths (@testSum, @testInterest, @testMonths)

DECLARE @sumTest MONEY = (
	SELECT Balance FROM Accounts a
	WHERE a.PersonId = 2
),
		@interestTest DECIMAL = 1.000000004,
		@monthsTest INT = 12
PRINT dbo.ufn_SumBySumAndInterestAndMonths (@sumTest, @interestTest, @monthsTest)
GO

/* Create a stored procedure that uses the function from the previous example 
		to give an interest to a person's account for one month.
		It should take the AccountId and the interest rate as parameters. */

CREATE PROC usp_PersonsBalanceInterestForAMonth
	(@yearlyInterest DECIMAL, @accountId INT)
AS 
DECLARE @totalSum MONEY = (
	SELECT Balance FROM Accounts a
	WHERE a.AccountId = @accountId
),
		@months INT = 12

UPDATE Accounts
SET Balance = dbo.ufn_SumBySumAndInterestAndMonths(@totalSum, @yearlyInterest, @months)
WHERE AccountId = @accountId
GO

EXEC usp_PersonsBalanceInterestForAMonth 2.2, 6
GO
EXEC usp_PersonsBalanceInterestForAMonth 6.06, 1
GO

/* Add two more stored procedures WithdrawMoney(AccountId, money) 
	and DepositMoney(AccountId, money) that operate in transactions. */

CREATE PROC usp_WithdrawMoney
	(@accountId INT, @moneyToWithdraw MONEY)
AS
DECLARE @balance MONEY = (
	SELECT Balance FROM Accounts a
	WHERE @accountId = a.AccountId
)
IF @moneyToWithdraw <= @balance
BEGIN
	UPDATE Accounts
	SET Balance = Balance - @moneyToWithdraw
	WHERE AccountId = @accountId
END
ELSE
	BEGIN
	PRINT 'You cannot withdraw more money than you have in your account!'
	END
GO

CREATE PROC usp_DepositMoney
	(@accountId INT, @moneyToDeposit MONEY)
AS
UPDATE Accounts
SET Balance = Balance + @moneyToDeposit
WHERE AccountId = @accountId
GO

/* First test will print the error message. */
EXEC usp_WithdrawMoney 2, 5
GO
EXEC usp_WithdrawMoney 1, 5
GO

/* After the third one, the last one will no longer print the error message. */
EXEC usp_DepositMoney 2, 6.9
GO
EXEC usp_WithdrawMoney 2, 5
GO

/* Create another table – Logs(LogID, AccountID, OldSum, NewSum).
		Add a trigger to the Accounts table that enters a new entry into the Logs table 
		every time the sum on an account changes. */

CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum INT,
	NewSum INT
)
GO

CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT i.AccountId, d.Balance, i.Balance
FROM inserted i, deleted d
GO

/* Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
		and all town's names that are comprised of given set of letters.
		Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'. */

USE [TelerikAcademy]
GO

CREATE FUNCTION ufn_Contains 
	(@patternToCheck NVARCHAR(100), @letters NVARCHAR(100)) RETURNS INT
AS
BEGIN
DECLARE @i INT = 1
DECLARE @currentLetter NVARCHAR(1)
WHILE (@i <= LEN(@patternToCheck))
	BEGIN
		SET @currentLetter = SUBSTRING (@patternToCheck, @i, 1)
		IF (CHARINDEX (LOWER(@currentLetter), LOWER(@letters)) <=0)
			BEGIN
				RETURN -1
			END
		SET @i = @i + 1
		END
	RETURN 1
END
GO

/* Tests: FirstName */

DECLARE @invalidPattern NVARCHAR(50) 
SET @invalidPattern = 'srgooapbqv'
DECLARE @validPattern NVARCHAR(50)
SET @validPattern = 'tniaeplyrrh'

DECLARE @firstNameTest NVARCHAR(50) 
SET @firstNameTest = (
SELECT FirstName FROM Employees e
WHERE e.EmployeeID = 5
)

PRINT @firstNameTest
PRINT dbo.ufn_Contains (@firstNameTest, @invalidPattern)
PRINT dbo.ufn_Contains (@firstNameTest, @validPattern)
GO

/* Tests: MiddleName */

DECLARE @invalidPattern NVARCHAR(50)
SET @invalidPattern = 'tnis''epldrrh'
DECLARE @validPattern NVARCHAR(50) 
SET @validPattern = 'srgooapbqv'

DECLARE @middleNameTest NVARCHAR(50) 
SET @middleNameTest = (
SELECT MiddleName FROM Employees e
WHERE e.EmployeeID = 5
)

PRINT @middleNameTest
PRINT dbo.ufn_Contains (@middleNameTest, @invalidPattern)
PRINT dbo.ufn_Contains (@middleNameTest, @validPattern)
GO

/* Tests: LastName */

DECLARE @invalidPattern NVARCHAR(50) 
SET @invalidPattern = 'srgooapbqv'
DECLARE @validPattern NVARCHAR(50)
SET @validPattern = 'tnis''epldrrh'

DECLARE @lastNameTest NVARCHAR(50) 
SET @lastNameTest = (
SELECT LastName FROM Employees e
WHERE e.EmployeeID = 5
)

PRINT @lastNameTest
PRINT dbo.ufn_Contains (@lastNameTest, @invalidPattern)
PRINT dbo.ufn_Contains (@lastNameTest, @validPattern)
GO

/* Tests: Name of town */

DECLARE @invalidPattern NVARCHAR(50) 
SET @invalidPattern = 'oistmiahf'
DECLARE @validPattern NVARCHAR(50)
SET @validPattern = 'leuvepglebq'

DECLARE @townName NVARCHAR(50)
SET @townName = (
SELECT Name FROM Towns t
WHERE t.TownID = 5
)

PRINT @townName
PRINT dbo.ufn_Contains (@townName, @invalidPattern)
PRINT dbo.ufn_Contains (@townName, @validPattern)
GO
