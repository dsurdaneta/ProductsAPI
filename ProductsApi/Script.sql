USE master;
--Delete the ProductsApiTestData database if it exists.  
IF EXISTS(SELECT * from sys.databases WHERE name='ProductsApiTestData')  
BEGIN  
    DROP DATABASE ProductsApiTestData;  
END  
--Create a new database called ProductsApiTestData.  
CREATE DATABASE ProductsApiTestData; 
GO

USE ProductsApiTestData  
GO 

CREATE TABLE dbo.Products  
   (ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  
    Name varchar(25) NOT NULL,
	Category varchar(25) NOT NULL,	
    Price DECIMAL (18, 2),  
    Quantity   INT   NOT NULL) 
GO

INSERT dbo.Products (Name, Category, Price, Quantity)  
    VALUES ('Tomato Soup', 'Groceries', 1, 150)  
GO

INSERT dbo.Products (Name, Category, Price, Quantity)  
    VALUES ('Yo-yo', 'Toys', 3.75, 78)  
GO

INSERT dbo.Products (Name, Category, Price, Quantity)  
    VALUES ('Hammer', 'Hardware', 16.99, 0)  
GO


