CREATE TABLE Location
    ( LocationId    INT PRIMARY KEY
    , StreetAddress NVARCHAR(40)
    , PostalCode    NVARCHAR(12)
    , City          NVARCHAR(30) NOT NULL
    , StateProvince NVARCHAR(25)
    )
