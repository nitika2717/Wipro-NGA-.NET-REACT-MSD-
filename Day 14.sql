USE ng;
--CREATE TABLE Employees
--(
--    EmpId INT IDENTITY(1,1) PRIMARY KEY,
--    Name VARCHAR(50) NOT NULL,
--    Salary INT NOT NULL,
--    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
--);
select * from Employees;
Alter PROCEDURE usp_AddEmployees
    @Name VARCHAR(50),
    @Salary INT,
    @EmpId INT OUTPUT
AS
BEGIN
 IF (@Salary <= 0)
    BEGIN
        THROW 50001, 'Salary must be greater than zero', 1;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Employees (Name, Salary)
        VALUES (@Name, @Salary);

        SET @EmpId = SCOPE_IDENTITY();--SCOPE_IDENTITY() returns the ID created by this INSERT

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END


 DECLARE @Id INT;

EXEC usp_AddEmployees
    'Ria',
    30000,
    @Id OUTPUT;
    EXEC usp_AddEmployees 'Amit', 40000, @Id OUTPUT;
EXEC usp_AddEmployees 'Neha', 35000, @Id OUTPUT;

SELECT @Id AS NewEmployeeId;


--US-03 updates the salary of an employee only after verifying the employee exists using IF EXISTS

CREATE PROCEDURE usp_UpdateEmployeeSalary
    @EmpId INT,
    @NewSalary INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmpId = @EmpId)
    BEGIN
        THROW 50002, 'Employee not found', 1;
    END

    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmpId = @EmpId;
END
EXEC usp_UpdateEmployeeSalary 3, 45000;


--us4
ALTER PROCEDURE usp_UpdateEmployeeSalary --A transaction is atomic if it either completes fully or doesn’t happen at all.
    @EmpId INT,
    @NewSalary INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if employee exists
        IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmpId = @EmpId)
        BEGIN
            THROW 50002, 'Employee not found', 1;
        END

        -- Update salary
        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmpId = @EmpId;

        COMMIT TRANSACTION;  -- Commit only if everything succeeds
        PRINT 'Salary updated successfully';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;  -- Rollback if any error occurs
        THROW;                 -- Re-throw the error
    END CATCH
END

