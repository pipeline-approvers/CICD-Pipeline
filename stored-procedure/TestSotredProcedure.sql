USE [PHP_Test]
GO

IF OBJECT_ID('dbo.GetEmployeeDetails', 'P') IS NOT NULL
    DROP PROCEDURE dbo.GetEmployeeDetails;
GO

CREATE PROCEDURE dbo.GetEmployeeDetails
AS
BEGIN
    SET NOCOUNT ON;

    -- Select statement to retrieve employee details
    SELECT EmployeeID, FirstName, LastName, JobTitle
    FROM dbo.Employees;
END;
GO
