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
   (ProductID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  
    ProductName VARCHAR(25) NOT NULL,
	Category VARCHAR(25),	
    Price DECIMAL (18, 2),  
    Quantity INT) 
GO

INSERT dbo.Products (ProductName, Category, Price, Quantity)  
    VALUES ('Tomato Soup', 'Groceries', 1, 150)  
GO

INSERT dbo.Products (ProductName, Category, Price, Quantity)  
    VALUES ('Yo-yo', 'Toys', 3.75, 78)  
GO

INSERT dbo.Products (ProductName, Category, Price, Quantity)  
    VALUES ('Hammer', 'Hardware', 16.99, 0)  
GO


