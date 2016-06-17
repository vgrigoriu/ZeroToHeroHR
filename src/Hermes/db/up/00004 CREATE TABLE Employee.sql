CREATE TABLE Employee
    ( EmployeeId     INT PRIMARY KEY
    , FirstName      NVARCHAR(20)
    , LastName       NVARCHAR(25) NOT NULL
    , Email          NVARCHAR(25) NOT NULL
    , PhoneNumber    NVARCHAR(20)
    , HireDate       DATE NOT NULL
    , JobId          NVARCHAR(10) NOT NULL REFERENCES Job(JobId)
    , Salary         DECIMAL(8,2)
    , CommissionPct  DECIMAL(2,2)
    , ManagerId      INT REFERENCES Employee(EmployeeId)
    , DepartmentId   INT REFERENCES Department(DepartmentId)
    , CONSTRAINT     EmpSalaryMin
                     CHECK (Salary > 0)
    , CONSTRAINT     EmpEmailUK
                     UNIQUE (Email)
    )
