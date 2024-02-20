--CREATE DATABASE Storage
--GO

--USE Storage 
--GO

--CREATE TABLE Ware
--(
--	Id INT  IDENTITY(1, 1) NOT NULL PRIMARY KEY,
--	[Name] NVARCHAR(max) NOT NULL,
--	SupplierId INT NOT NULL,
--	WareTypeId INT NOT NULL,
--	WareCount INT NOT NULL,
--	Cost  MONEY NOT NULL
--);
--GO 

--CREATE TABLE Supplier
--(
--	Id INT  IDENTITY(1, 1) NOT NULL PRIMARY KEY,
--	[Name] NVARCHAR(max) NOT NULL,
--	SupplierCountry NVARCHAR(max) NOT NULL
--);
--GO 

--CREATE TABLE WareType
--(
--	Id INT  IDENTITY(1, 1) NOT NULL PRIMARY KEY,
--	TypeName NVARCHAR(max) NOT NULL
--);
--GO 

--CREATE TABLE Delivery
--(
--	Id INT  IDENTITY(1, 1) NOT NULL PRIMARY KEY,
--	WareId INT NOT NULL,
--	DeliveryDate  DATE NOT NULL,
--);
--GO 

--INSERT INTO Ware VALUES
--('Ware1', 1, 1, 15,100)

--INSERT INTO Ware VALUES
--('Ware2', 2, 2, 12,140)

--INSERT INTO Ware VALUES
--('Ware3', 3, 3, 17,220)

--INSERT INTO Ware VALUES
--('Ware4', 1, 2, 12,140)

--INSERT INTO Ware VALUES
--('Ware5', 2, 3, 14,370)



--INSERT INTO Delivery VALUES
--(1, '2023-11-12')

--INSERT INTO Delivery VALUES
--(2, '2024-01-12')

--INSERT INTO Delivery VALUES
--(3, '2024-02-10')

--INSERT INTO Delivery VALUES
--(4,  '2023-12-12')

--INSERT INTO Delivery VALUES
--(5, '2024-02-04')


--INSERT INTO Supplier VALUES
--('Supplier', 'Gremany')

--INSERT INTO Supplier VALUES
--('Supplier', 'USA')

--INSERT INTO Supplier VALUES
--('Supplier','China')


--INSERT INTO WareType VALUES
--('Type1')

--INSERT INTO WareType VALUES
--('Type2')

--INSERT INTO WareType VALUES
--('Type3')
