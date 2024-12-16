USE [PHP_Test]
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
    DROP TABLE dbo.Employees;
GO

CREATE TABLE dbo.Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    JobTitle NVARCHAR(50)
);
GO

-- Insert sample data
INSERT INTO dbo.Employees (FirstName, LastName, JobTitle)
VALUES ('John', 'Doe', 'Software Developer'),
       ('Jane', 'Smith', 'Project Manager'),
       ('Mike', 'Johnson', 'Business Analyst');
GO
