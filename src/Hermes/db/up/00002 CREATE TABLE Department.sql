CREATE TABLE Department
    ( DepartmentId     INT PRIMARY KEY
    , DepartmentName   NVARCHAR(30) NOT NULL
    , LocationId       INT references Location (LocationId)
    )
