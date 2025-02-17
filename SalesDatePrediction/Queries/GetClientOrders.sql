DECLARE @CustomerId INT
SET @CustomerId = 1

SELECT 
    OrderId, 
    RequiredDate, 
    ShippedDate, 
    ShipName, 
    ShipAddress, 
    ShipCity
FROM Sales.Orders
WHERE CustId = @CustomerId;