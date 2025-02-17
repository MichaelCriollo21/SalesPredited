DECLARE @OrderId INT;
DECLARE @EmpId INT = 1;  
DECLARE @ShipperId INT = 2;  
DECLARE @ShipName NVARCHAR(100) = 'John Doe';
DECLARE @ShipAddress NVARCHAR(255) = '123 Main Street';
DECLARE @ShipCity NVARCHAR(100) = 'New York';
DECLARE @OrderDate DATETIME = GETDATE();
DECLARE @RequiredDate DATETIME = DATEADD(DAY, 5, @OrderDate);
DECLARE @ShippedDate DATETIME = NULL; 
DECLARE @Freight DECIMAL(10,2) = 15.75;
DECLARE @ShipCountry NVARCHAR(50) = 'USA';

DECLARE @ProductId INT = 1; 
DECLARE @UnitPrice DECIMAL(10,2) = 25.99;
DECLARE @Qty INT = 3;
DECLARE @Discount DECIMAL(10,2) = 0.05;

INSERT INTO Sales.Orders (EmpId, ShipperId, ShipName, ShipAddress, ShipCity, OrderDate, RequiredDate, ShippedDate, Freight, ShipCountry)
VALUES (@EmpId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

SET @OrderId = SCOPE_IDENTITY();

INSERT INTO Sales.OrderDetails (OrderId, ProductId, UnitPrice, Qty, Discount)
VALUES (@OrderId, @ProductId, @UnitPrice, @Qty, @Discount);